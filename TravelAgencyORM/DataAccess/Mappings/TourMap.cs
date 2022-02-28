namespace DataAccess.Mappings
{
    using FluentNHibernate.Mapping;
    using Domain;

    internal class TourMap : ClassMap<Tour>
    {
        public TourMap()
        {
            this.Table("Tours");

            this.Id(x => x.ID);

            this.Map(x => x.Country)
                .Not.Nullable();

            this.Map(x => x.City)
                .Not.Nullable();

            this.Map(x => x.Price)
                .Not.Nullable();

            this.HasManyToMany(x => x.Clients)
                .Cascade.Delete()
                .Inverse();
        }
    }
}
