using FluentValidator;
using FluentValidator.Validation;

namespace CintraStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            this.Address = address;
            
            Validate();
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }

        public void Validate()
        {
            AddNotifications( new ValidationContract().Requires()
                .IsEmail(this.Address, "Address", "This Email is invalid"));
        }
    }
}
