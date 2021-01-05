using CintraStore.Domain.StoreContext.Entities;
using CintraStore.Domain.StoreContext.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CintraStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCountResult GetCustomerOrdersCountResult(string document);
    }
}
