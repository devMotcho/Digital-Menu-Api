using System.Data.SqlTypes;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using DigitalMenuApi.Data;
using DigitalMenuApi.DTOs;
using DigitalMenuApi.Helpers;

namespace DigitalMenuApi.Services;

public partial class RestService : IRestService
{
    private readonly DateTime _dateTime = DateTime.UtcNow;
    private readonly IDataContext _context;
    private readonly CultureInfo _culture;
    public RestService(IDataContext context)
    {
        try
        {
            var culture = CultureInfo.GetCultureInfo("pt-PT");
            // Use the culture object as needed
            _culture = culture;
        }
        catch (CultureNotFoundException)
        {
            // Handle the error, maybe fallback to a default culture
            var defaultCulture = CultureInfo.GetCultureInfo("pt");
            // Use defaultCulture instead
            _culture = defaultCulture;
        }
        _context = context;
    }

    public async Task<List<GetProductDTO>> GetAllProductsAsync()
    {
        return await _context.Products
            .Include(p => p.Category)
            .Where(p => p.IsActive == true)
            .Select(p => new GetProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                CategoryName = p.Category.Name,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                UnitType = p.UnitType,
                Price = p.Price,
                Discount = p.Discount,
                FinalPrice = p.FinalPrice,
                Accompaniment = p.Accompaniment,
                TimeOfPreparation = p.TimeOfPreparation,
            })
            .ToListAsync();
    }
    
    public async Task<GetProductDTO?> GetSingleProductAsync(int id)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .Where(p => p.Id == id 
                && p.IsActive == true)
            .FirstOrDefaultAsync();
        
        if (product == null) return null;

        return new GetProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            CategoryName = product.Category.Name,
            Description = product.Description,
            ImageUrl = product.ImageUrl,
            UnitType = product.UnitType,
            Price = product.Price,
            Discount = product.Discount,
            FinalPrice = product.FinalPrice,
            Accompaniment = product.Accompaniment,
            TimeOfPreparation = product.TimeOfPreparation,
        };
    }

    public async Task<List<GetChefRecommendationDTO>> GetChefRecommendationsAsync()
    {
        return await _context.Products
            .Include(p => p.Category)
            .Where(p => p.IsActive == true && p.IsChefRecommendation == true)
            .Select(p => new GetChefRecommendationDTO 
            {
                Id = p.Id,
                Name = p.Name,
                CategoryName = p.Category.Name,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                UnitType = p.UnitType,
                Price = p.Price,
                Discount = p.Discount,
                FinalPrice = p.FinalPrice,
                Accompaniment = p.Accompaniment,
                TimeOfPreparation = p.TimeOfPreparation,
                
            })
            .ToListAsync();
    }

    public async Task<List<GetProductDTO>> GetProductsByCategoryName(string categoryName)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Where(p => p.Category.Name == categoryName
            && p.IsActive == true)
            .Select(p => new GetProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                CategoryName = p.Category.Name,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                UnitType = p.UnitType,
                Price = p.Price,
                Discount = p.Discount,
                FinalPrice = p.FinalPrice,
                Accompaniment = p.Accompaniment,
                TimeOfPreparation = p.TimeOfPreparation,

            }).ToListAsync();
    }

    public async Task<List<GetCategoryDTO>> GetAllCategoriesAsync()
    {
        return await _context.Categories
            .OrderBy(c => c.Name)
            .Select(c => new GetCategoryDTO
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                ImageUrl = c.ImageUrl,
                PageDescription = c.PageDescription
            })
            .ToListAsync();
    }

    public async Task<GetDishOfTheDayDTO?> WhatIsTheDishOfToday()
    {
        SqlDateTime sqlNow = new SqlDateTime(_dateTime);

        return await _context.DishesOfTheDay
            .Where(d => d.ScheduledOn.Date == sqlNow.Value.Date)
            .Include(d => d.Product)
            .Select(d => new GetDishOfTheDayDTO
            {
                ProductId = d.Product.Id,
                ProductName = d.Product.Name,
                CategoryName = d.Product.Category.Name,
                ProductImage = d.Product.ImageUrl,
                ScheduledLisbonDate = DateTimeHelper
                    .ConvertUtcToLisbonTime(d.ScheduledOn),
                NewPrice = d.NewPrice,
                ScheduledFormatted = DateTimeHelper
                    .FormatDateByCulture(d.ScheduledOn, _culture),
                DayOfWeek = DateTimeHelper
                    .GetDayOfWeekByCulture(d.ScheduledOn, _culture),
                UnitType = d.Product.UnitType,
                ProductDescription = d.Product.Description,
                Accompaniment = d.Product.Accompaniment,
                TimeOfPreparation = d.Product.TimeOfPreparation
            })
            .FirstOrDefaultAsync();
    }

    public async Task<List<GetDishOfTheDayDTO>> GetDishesOfTheWeek()
    {
        var atualWeek = DateTimeHelper.NumberOfWeek(_dateTime, _culture);
        return await _context.DishesOfTheDay
            .Where(d => d.ScheduledWeek == atualWeek)
            .OrderBy(d => d.ScheduledOn)
            .Include(d => d.Product)
            .Select(d => new GetDishOfTheDayDTO
            {
                ProductId = d.Product.Id,
                ProductName = d.Product.Name,
                CategoryName = d.Product.Category.Name,
                ProductImage = d.Product.ImageUrl,
                ScheduledLisbonDate = DateTimeHelper
                    .ConvertUtcToLisbonTime(d.ScheduledOn),
                NewPrice = d.NewPrice,
                ScheduledFormatted = DateTimeHelper
                    .FormatDateByCulture(d.ScheduledOn, _culture),
                DayOfWeek = DateTimeHelper
                    .GetDayOfWeekByCulture(d.ScheduledOn, _culture),
                UnitType = d.Product.UnitType,
                ProductDescription = d.Product.Description,
                Accompaniment = d.Product.Accompaniment,
                TimeOfPreparation = d.Product.TimeOfPreparation,

            }).ToListAsync();

    }
}