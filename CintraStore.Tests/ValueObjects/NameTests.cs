using CintraStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CintraStore.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        [TestCategory("Name - Tests")]
        public void ShouldReturnANotificationWhenNameIsInvalid()
        {
            var name = new Name("Ed", "Cintra");

            Assert.AreEqual(false, name.IsValid);
            Assert.IsTrue(name.Notifications.Count > 0);
        }

        [TestMethod]
        [TestCategory("Name - Tests")]
        public void ShouldntReturnANotificationWhenNameIsValid()
        {
            var name = new Name("Edu", "Cintra");

            Assert.AreEqual(true, name.IsValid);
            Assert.IsTrue(name.Notifications.Count == 0);
        }
    }
}
