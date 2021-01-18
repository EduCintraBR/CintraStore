using CintraStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using CintraStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using CintraStore.Domain.StoreContext.Entities;
using CintraStore.Domain.StoreContext.Repositories;
using CintraStore.Domain.StoreContext.Services;
using CintraStore.Domain.StoreContext.ValueObjects;
using CintraStore.Shared;
using CintraStore.Shared.Commands;
using FluentValidator;
using System;

namespace CintraStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            this._repository = repository;
            this._emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verify if the Document exists
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "The document already in use");

            // Verify if the Email exists
            if (_repository.CheckEmail(command.Document))
                AddNotification("Email", "This email already in use");
            
            // Create Value Objects
            var name = new Name(command.FirstName, command.LastName);
            var doc = new Document(command.Document);
            var email = new Email(command.Email);
            
            // Create Entities
            var customer = new Customer(name, doc, email, command.Phone);

            // Validate Entities and value objects
            AddNotifications(name.Notifications);
            AddNotifications(doc.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return new CommandResult(false, "Please, fix the fields below", Notifications);

            // Persist in the Database
            _repository.Save(customer);

            // Send a welcome e-mail to the Customer
            _emailService.Send(email.Address, "teste@gmail.com", "Welcome", $"Welcome to our shop {command.FirstName} {command.LastName}!");

            return new CommandResult(true, "Welcome to Cintra Store", new {
                Id = Guid.NewGuid(),
                Name = name.ToString(),
                Email = email.Address
            });
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
