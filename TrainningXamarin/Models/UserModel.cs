using System;

namespace TrainningXamarin.Models
{
    public class UserModel
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreateAt { get; set; }
    }
}