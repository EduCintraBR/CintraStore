using FluentValidator;
using System;

namespace CintraStore.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
