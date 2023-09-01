using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Narevim.Server.Models;
using Narevim.Shared;

namespace Narr.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<Narevim.Server.Models.ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<Slider> Slider { get; set; } = default!;
        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<Basket> Basket { get; set; } = default!;
        public DbSet<City> City { get; set; } = default!;
        public DbSet<Town> Town { get; set; } = default!;
        public DbSet<Favoritte> Favoritte { get; set; } = default!;
        public DbSet<Order> Order { get; set; } = default!;
        public DbSet<Address> Address { get; set; } = default!;
        public DbSet<OrderProduct> OrderProduct { get; set; } = default!;
        public DbSet<Brand> Brand { get; set; } = default!;
        public DbSet<Cargo> Cargo { get; set; } = default!;
        public DbSet<ApplicationUser> Users { get; set; } = default!;


    }
}