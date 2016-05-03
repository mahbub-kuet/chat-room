using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatRoom.App.Models
{
    public class MessageViewModel
    {
        public string UserName { get; set; }
        public string Text { get; set; }
        public string Time { get; set; }
        public string color { get; set; }
    }
}