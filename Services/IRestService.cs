using DigitalMenuApi.DTOs;

namespace DigitalMenuApi.Services;

public interface IRestService
{
    //GetAllProductsAsync()
    Task<List<GetProductDTO>> GetAllProductsAsync();

    //GetAllCategories()
    Task<List<GetCategoryDTO>> GetAllCategoriesAsync();
    
    //GetSingleProduct()
    Task<GetProductDTO?> GetSingleProductAsync(int id);

    //GetChefRecommendations()
    Task<List<GetChefRecommendationDTO>> GetChefRecommendationsAsync();

    //GetProductsByCategoryName()
    Task<List<GetProductDTO>> GetProductsByCategoryName(string categoryName);

    // DishOfTheDay
    Task<GetDishOfTheDayDTO?> WhatIsTheDishOfToday();

    Task<List<GetDishOfTheDayDTO>> GetDishesOfTheWeek();

}