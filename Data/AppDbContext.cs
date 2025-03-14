﻿using EmployeeAdminPanel.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPanel.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
