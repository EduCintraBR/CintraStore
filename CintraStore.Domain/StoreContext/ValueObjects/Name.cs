using FluentValidator;
using FluentValidator.Validation;

namespace CintraStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            Validate();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public void Validate()
        {
            AddNotifications(new ValidationContract().Requires()
                .HasMinLen(this.FirstName, 3, "FirstName", "The First Name must contain at least 3 characters")
                .HasMinLen(this.FirstName, 50, "FirstName", "The First Name must contain a maximum of 50 characters")
                .HasMinLen(this.LastName, 3, "FirstName", "The Last Name must contain at least 3 characters")
                .HasMinLen(this.LastName, 50, "FirstName", "The Last Name must contain a maximum of 50 characters"));
        }

    }
}
