using MongoBlog.Web.Infrastructure.DataAccess;
using MongoBlog.Web.Domain.Entities;
using System;

namespace MongoBlog.IntegrationTests.Infrastructure {
    public class SeedTestData {
        public void Seed(ISession session) {
            using (session) {
                session.Add(new User { UserName = "khaja", Password = "min", CreatedOn = DateTime.Now, Role = Role.Admin });
            }
        }
    }
}