namespace CintraStore.Domain.StoreContext.ValueObjects
{
    public class Email
    {
        public Email(string address)
        {
            this.Address = address;
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}
