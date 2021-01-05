using CintraStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace CintraStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract().Requires()
                .HasMinLen(this.FirstName, 3, "FirstName", "The First Name must contain at least 3 characters")
                .HasMaxLen(this.FirstName, 50, "FirstName", "The First Name must contain a maximum of 50 characters")
                .HasMinLen(this.LastName, 3, "FirstName", "The Last Name must contain at least 3 characters")
                .HasMaxLen(this.LastName, 50, "FirstName", "The Last Name must contain a maximum of 50 characters")
                .IsEmail(this.Email, "Address", "This Email is invalid")
                .HasMinLen(this.Document, 11, "Document", "Document must contain at least 11 digits")
                .HasMaxLen(this.Document, 14, "Document", "Document must contain a maximum of 14 digits")
                );
            return IsValid;
        }
    }
}
