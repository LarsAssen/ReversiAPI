using Microsoft.EntityFrameworkCore;
using ReversiMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiMvcApp.Data
{
	public class ReversiDbContext : DbContext
	{
		public ReversiDbContext(DbContextOptions<ReversiDbContext> options) : base(options) { }

		public DbSet<Speler> Speler { get; set; }
		public DbSet<Spel> Spel { get; set; }
		public DbSet<Stone> Stone { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Spel>()
				.Property(c => c.AandeBeurt)
				.HasConversion<int>();

			modelBuilder.Entity<Spel>()
				.Property(c => c.Bord)
				.HasConversion<int[,]>();

			modelBuilder.Entity<Spel>()
				.HasOne(spel => spel.Speler1);

			modelBuilder.Entity<Spel>()
				.HasOne(spel => spel.Speler2);

			modelBuilder.Entity<Speler>()
				.HasOne(speler => speler.Spel);
		}
	}
}
