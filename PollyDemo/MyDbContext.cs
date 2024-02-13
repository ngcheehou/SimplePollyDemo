using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PollyDemo
{
	public class MyDbContext : DbContext
	{
		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
		{
		}

		public virtual DbSet<Employee> Employees { get; set; }
	}

	 

}
