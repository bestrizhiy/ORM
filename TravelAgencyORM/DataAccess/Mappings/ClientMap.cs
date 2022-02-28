namespace DataAccess.Mappings
{
    using FluentNHibernate.Mapping;
    using Domain;

    internal class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            this.Table("Clients");

            this.Id(x => x.ID);

            this.Map(x => x.LastName)
                .Not.Nullable();

            this.Map(x => x.FirstName)
                .Not.Nullable();

            this.Map(x => x.DateOfBirth)
                .Not.Nullable();

            this.Map(x => x.Passport)
                .Not.Nullable();

            this.Map(x => x.Patronymic)
                .Nullable();

            this.Map(x => x.InternationalPassport)
                .Nullable();

            this.HasManyToMany(x => x.Tours)
                .Cascade.Delete();
        }
    }
}

