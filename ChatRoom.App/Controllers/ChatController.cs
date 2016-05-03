using ChatRoom.App.Dbcontext;
using ChatRoom.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatRoom.App.Controllers
{
    public class ChatController : ApiController
    {
        public static Dictionary<string, string> userColor = new Dictionary<string, string>();
        public static List<string> colors = new List<string> { 
            "red", 
            "blue", 
            "#f25170", 
            "#afc94c", 
            "#f25170", 
            "#9a504f"
        };

        private string getColor(string username)
        {
            try
            {
                return userColor[username];
            }catch(Exception ex){
                return "green";
            }
           
        }

        [HttpGet]
        public IEnumerable<MessageViewModel> GetMessages()
        {            
            return MessageHistory.MessageList.Select(x => new MessageViewModel
            {
                UserName = x.UserName,
                color = getColor(x.UserName),
                Text = x.Text,
                Time = x.Time.ToString("dd/MM/yyyyy HH:mm:ss")
            });
        }

        [HttpPost]
        [Route("api/chat/UserColor")]
        public void UserColor(User user)
        {
            
            try
            {
                userColor.Add(user.user, colors[0]);
                colors.RemoveAt(0);
            }
            catch (Exception ex)
            {

            }
        }


        [HttpPost]
        [Route("api/chat/Save")]
        public void Save()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Conversation conversation = new Conversation();
                conversation.Name = "conversation";
                conversation.Messages = MessageHistory.MessageList;
                db.Conversations.Add(conversation);
                db.SaveChanges();
            }
        }
      
        //[HttpPost]
        public void AddMessage(Message NewMessage)
        {           
            NewMessage.Time = DateTime.Now;           
            MessageHistory.MessageList.Add(NewMessage);            
        }



        
    
    
    }
}
