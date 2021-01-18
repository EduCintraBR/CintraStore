using CintraStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using CintraStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using CintraStore.Domain.StoreContext.Entities;
using CintraStore.Domain.StoreContext.Handlers;
using CintraStore.Domain.StoreContext.Queries;
using CintraStore.Domain.StoreContext.Repositories;
using CintraStore.Domain.StoreContext.ValueObjects;
using CintraStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CintraStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repo;
        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            this._repo = repository;
            this._handler = handler;
        }
        
        [HttpGet]
        [Route("customers")]
        [ResponseCache(Location = ResponseCacheLocation.Client ,Duration = 60)]
        public List<ListCustomerQueryResult> Get()
        {
            return this._repo.Get();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return this._repo.GetById(id);
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<ListCustomerOrdersQueryResult> GetOrdersById(Guid id)
        {
            return this._repo.GetOrders(id);
        }

        [HttpPost]
        [Route("customers")]
        public ICommandResult Post([FromBody]CreateCustomerCommand command)
        {
            var result = _handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody]CreateCustomerCommand customer)
        {
            var name = new Name(customer.FirstName, customer.LastName);
            var doc = new Document(customer.Document);
            var email = new Email(customer.Email);
            var cst = new Customer(name, doc, email, customer.Phone);
            _repo.Save(cst);

            return cst;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete()
        {
            return new { message = "Hello World" };
        }
    }
}
