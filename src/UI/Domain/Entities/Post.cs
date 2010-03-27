using System;
using Norm;

namespace MongoBlog.UI.Domain.Entities {
    public class Post : IEntity {

        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}