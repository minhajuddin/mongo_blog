using Xunit;
using MongoBlog.Web.Presentation.Security;
using MongoBlog.Web.Domain.Entities;

namespace MongoBlog.UnitTests.Presentation.Security {
    public class RoleComparerTests {

        [Fact]
        public void returns_false_when_roles_are_not_the_same() {
            var comparer = new RoleComparer();

            Assert.False(comparer.AreEqual(Role.Subscriber, Role.Admin));
        }

        [Fact]
        public void returns_true_when_roles_are_not_the_same() {
            var comparer = new RoleComparer();

            Assert.True(comparer.AreEqual(Role.Subscriber, Role.Subscriber));
        }
    }
}