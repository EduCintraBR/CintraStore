using CintraStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CintraStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        [TestCategory("Document - Tests")]
        public void ShouldReturnANotificationWhenDocumentIsNotValid()
        {
            var document = new Document("123598");

            Assert.AreEqual(false, document.IsValid);
            Assert.IsTrue(document.Notifications.Count > 0);
        }

        [TestMethod]
        [TestCategory("Document - Tests")]
        public void ShouldntReturnANotificationWhenDocumentIsValid()
        {
            var document = new Document("12345678980000");

            Assert.AreEqual(true, document.IsValid);
            Assert.IsTrue(document.Notifications.Count == 0);
        }
    }
}
