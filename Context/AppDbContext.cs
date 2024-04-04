using System;
using api6969.Models;
using Microsoft.EntityFrameworkCore;

namespace api6969.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base (options){

        }
        public DbSet<Carro> carros{get;set;}
    }
}
