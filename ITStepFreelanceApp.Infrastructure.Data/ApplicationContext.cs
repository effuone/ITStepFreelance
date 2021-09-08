using ITStepFreelanceApp.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ITStepFreelanceApp.Infrastructure.Data {
  public class ApplicationContext : DbContext {
    public ApplicationContext([NotNull] DbContextOptions options) : base(options) {
    }
    public DbSet<Freelancer> Freelancers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
  }
}
