namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extensions;

    public class Client : IEquatable<Client>
    {
        public Client(int id, string lastName, string firstName, string dateOfBirth, string passport, string patronymic = null, string internationalPassport = null)
        {
            this.ID = id;
            this.LastName = lastName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(lastName));
            this.FirstName = firstName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(firstName));
            this.DateOfBirth = dateOfBirth.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(dateOfBirth));
            this.Passport = passport.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(passport));
            this.InternationalPassport = internationalPassport.TrimOrNull();
            this.Patronymic = patronymic.TrimOrNull();

        }

        [Obsolete("For ORM", true)]
        protected Client()
        {
        }
        public virtual int ID { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual string FirstName { get; protected set; }
        public virtual string DateOfBirth { get; protected set; }
        public virtual string Passport { get; protected set; }
        public virtual string Patronymic { get; protected set; }
        public virtual string InternationalPassport { get; protected set; }
        public virtual string FullInfo => $"Фамилия: {this.LastName}, Имя: {this.FirstName}, Отчество (при наличии): {this.Patronymic}, " +
            $"Дата рождения: {this.DateOfBirth[0..10]}, Паспорт: {this.Passport}, Загранпаспорт (при наличии): {this.InternationalPassport}\n".Trim();

        public virtual ISet<Tour> Tours { get; protected set; } = new HashSet<Tour>();

        public virtual bool AddTour(Tour tour)
        {
            return tour == null
                ? throw new ArgumentNullException(nameof(tour))
                : this.Tours.Add(tour);
        }

        public override string ToString() => this.FullInfo;

        public override bool Equals(object obj)
        {
            return !ReferenceEquals(null, obj) && (ReferenceEquals(this, obj) || this.Equals(obj as Client));
        }

        public virtual bool Equals(Client other)
        {
            return !ReferenceEquals(null, other) && (ReferenceEquals(this, other) || this.ID == other.ID);
        }

        public override int GetHashCode() => this.ID;
    }
}

