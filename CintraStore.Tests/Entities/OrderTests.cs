using CintraStore.Domain.StoreContext.Entities;
using CintraStore.Domain.StoreContext.Enums;
using CintraStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CintraStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Customer _customer;
        private Order _order;
        private Product _mouse;
        private Product _teclado;

        public OrderTests()
        {
            var name = new Name("Eduardo", "Cintra");
            var doc = new Document("12036547801");
            var email = new Email("ecintra@gmail.com");
            _mouse = new Product("Mouse", "Mouse", "image.png", 49, 10);
            _teclado = new Product("Teclado", "Teclado", "image.png", 89, 10);
            _customer = new Customer(name, doc, email, "5535988113338");
            _order = new Order(_customer);
        }

        // Criar um novo pedido
        [TestMethod]
        public void ShouldCreateOrderWhenIsValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        // Ao criar o pedido, o status deve ser CREATED
        [TestMethod]
        public void ShouldBeReturnWhenOrderIsCreated()
        {
            Assert.AreEqual(_order.Status, EOrderStatus.Created);
        }

        //Ao adicionar um novo item, a quantidade de itens deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_mouse, 2);
            _order.AddItem(_teclado, 2);

            Assert.AreEqual(_order.Items.Count, 2);
        }

        //Ao adicionar um novo item, deve subtrair a quantidade do produto
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItem()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(5, _mouse.QuantityOnHands);
        }

        //Ao confirmar pedido, deve gerar um numero
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        //Ao pagar um pedido, o status deve ser PAGO
        [TestMethod]
        public void ShouldReturnPaidWhenOrderIsPaid()
        {
            _order.PayOrder();
            Assert.AreEqual(_order.Status, EOrderStatus.Paid);
        }

        //Dado mais 10 produtos, devem haver duas entregas
        [TestMethod]
        public void ShouldReturnTwoShippingsWhenPurchasedTenProducts()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            
            _order.ShipOrder();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        //Ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderIsCanceled()
        {
            _order.CancelOrder();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        //Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void WhenShippingStatusIsCanceledOrderShouldBeCanceled()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);

            _order.ShipOrder();

            _order.CancelOrder();

            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
        }
    }
}
