using FoodRecipe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRecipe.DAL
{
    public interface IFoodRepository : IDisposable
    {
        IEnumerable<Food> GetRecipe();
        Food GetRecipeByID(int FoodId);
        void InsertRecipe(Food FoodId);
        void DeleteRecipe(int FoodId);
        void UpdateRecipe(Food food);
        void Save();
    }
}
