using CintraStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CintraStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        [TestCategory("Create Customer Command - Tests")]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Eduardo";
            command.LastName = "Cintra";
            command.Document = "12345678901";
            command.Email = "educin@gmail.com";
            command.Phone = "35988774411";

            Assert.IsTrue(command.Valid());
        }
    }
}
