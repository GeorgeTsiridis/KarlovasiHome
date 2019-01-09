using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server.Tables;
using KarlovasiHomeService.DataObjects;

namespace KarlovasiHomeService.Models
{
    public class KarlovasiHomeContext : DbContext
    {
        private const string connectionStringName = "Name=MS_TableConnectionString";

        public KarlovasiHomeContext() : base(connectionStringName)
        {

        } 

        public DbSet<User> Users { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }
    }
}