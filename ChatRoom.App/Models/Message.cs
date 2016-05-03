using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatRoom.App.Models
{
    public class Message
    {
        public Int64 Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }    

    public class User
    {
        public string user { get; set; }
    }
}