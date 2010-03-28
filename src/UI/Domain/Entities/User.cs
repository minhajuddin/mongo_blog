using System;
using Norm;

namespace MongoBlog.Web.Domain.Entities {
    public class User : IEntity {
        public ObjectId Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}