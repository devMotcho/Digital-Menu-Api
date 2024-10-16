using DigitalMenuApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DigitalMenuApi.Data;


public interface IDataContext
{
    DbSet<Product> Products { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<DishOfTheDay> DishesOfTheDay {get; set;}
    // checks database connection when starting
    DatabaseFacade Database {get;}
}