namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Staff.Extensions;
    public class Tour
    {
        public Tour(int id, string country, string city, string price, params Client[] clients)
            : this(id, country, city, price, new HashSet<Client>(clients))
        {
        }

        public Tour(int id, string country, string city, string price, ISet<Client> clients = null)
        {
            this.ID = id;
            this.Country = country.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(country));
            this.City = city.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(city));
            this.Price = price.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(price));



            foreach (var client in clients ?? Enumerable.Empty<Client>())
            {
                this.Clients.Add(client);
                client.AddTour(this);
            }
        }

        [Obsolete("For ORM", true)]
        protected Tour()
        {
        }

        public virtual int ID { get; protected set; }
        public virtual string Country { get; protected set; }
        public virtual string City { get; protected set; }
        public virtual string Price { get; protected set; }
        public virtual ISet<Client> Clients { get; protected set; } = new HashSet<Client>();

        public override string ToString() => $"{this.Country}, {this.City}, {Price}, {this.Clients.Join()}".Trim();

    }
}
