using FluentValidator;
using FluentValidator.Validation;

namespace CintraStore.Domain.StoreContext.ValueObjects
{
    public class Document : Notifiable
    {
        public Document(string number)
        {
            this.Number = number;
            
            Validate();
        }

        public string Number { get; private set; }

        public override string ToString()
        {
            return Number;
        }

        public void Validate()
        {
            AddNotifications(new ValidationContract().Requires()
                .HasMinLen(this.Number, 11, "Document", "Document must contain at least 11 digits")
                .HasMaxLen(this.Number, 14, "Document", "Document must contain a maximum of 14 digits"));
        }
    }
}
