using CintraStore.Domain.StoreContext.Entities;
using CintraStore.Domain.StoreContext.Enums;
using CintraStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CintraStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Eduardo","Cintra");
            var doc = new Document("12587965401");
            var email = new Email("ecintra@gmail.com");
            
            var address = new Address("Rua Pimenta de Pádua",
                                      "2384",
                                      "",
                                      "Lagoinha",
                                      "São Sebastião do Paraíso",
                                      "Minas Gerais",
                                      "Brasil",
                                      "37950000",
                                      EAddressType.Shipping);

            var customer = new Customer(name,
                        doc,
                        email,
                        "35988887770");

            // Adding the address to the customer
            customer.AddAddress(address);
            
            // Creating an new order
            var order = new Order(customer);

            // Creating new Products
            var cpV = new Product("Compound V", "Estheroid for Supers", "image.png", 500000, 1);
            var ak47 = new Product("AK-47", "Automatic Rifle", "image.png", 8000, 10);
            var tomahawk = new Product("TomaHawk Missile", "Balistic Missile", "image.png", 2000000, 5);

            var item1 = new OrderItem(cpV, 1);
            var item2 = new OrderItem(ak47, 1);
            var item3 = new OrderItem(tomahawk, 1);

            order.AddItem(item1);
            order.AddItem(item2);
            order.AddItem(item3);

            order.Place();

            order.PayOrder();

            order.ShipOrder();

            order.CancelOrder();
        }
    }
}
