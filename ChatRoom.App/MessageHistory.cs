using ChatRoom.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatRoom.App
{
   
    public static class MessageHistory
    {
        /// <summary>
        /// In-memory collection to persist chat history between multiple users
        /// </summary>
        public static List<Message> MessageList { get; set; }

        static MessageHistory()
        {
            MessageList = new List<Message>();
        }
    }
}