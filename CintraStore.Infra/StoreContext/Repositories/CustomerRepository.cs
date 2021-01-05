﻿using CintraStore.Domain.StoreContext.Entities;
using CintraStore.Domain.StoreContext.Queries;
using CintraStore.Domain.StoreContext.Repositories;
using CintraStore.Infra.StoreContext.DataContexts;
using Dapper;
using System.Data;
using System.Linq;

namespace CintraStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CintraDataContext _context;

        public CustomerRepository(CintraDataContext context)
        {
            this._context = context;
        }

        public bool CheckDocument(string document)
        {
            return this._context
                    .Connection
                    .Query<bool>(
                        "spCheckDocument",
                        new { Document = document },
                        commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return this._context
                    .Connection
                    .Query<bool>(
                        "spCheckEmail",
                        new { Email = email },
                        commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCountResult(string document)
        {
            return this._context
                    .Connection
                    .Query<CustomerOrdersCountResult>(
                        "spGetCustomerOrderCount",
                        new { Document = document },
                        commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            this._context.Connection.Execute("spCreateCustomer",
                new
                {
                    Íd = customer.Id,
                    FirstName = customer.Name,
                    LastName = customer.Name.LastName,
                    Document = customer.Document.Number,
                    Email = customer.Email,
                    Phone = customer.Phone
                }, commandType: CommandType.StoredProcedure);
            
            foreach (var address in customer.Addresses)
            {
                this._context.Connection.Execute("spCreateAddress",
                new
                {
                   Id = address.Id,
                   CustomerId = customer.Id,
                   Number = address.Number,
                   Complement = address.Complement,
                   District = address.District,
                   City = address.City,
                   State = address.State,
                   Country = address.Country,
                   ZipCoide = address.ZipCode,
                   Type = address.AddressType,
                }, commandType: CommandType.StoredProcedure);
            }    
        }
    }
}
