using FoodRecipe.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRecipe.DAL
{
    public class FoodRepository : IFoodRepository, IDisposable
    {
        private FoodContext context;

        public FoodRepository(FoodContext context)
        {
            this.context = context;
        }

        public IEnumerable<Food> GetRecipe()
        {
            return context.Food.ToList();
        }

        public Food GetRecipeByID(int id)
        {
            return context.Food.Find(id);
        }

        public void InsertRecipe(Food food)
        {
            context.Food.Add(food);
        }

        public void DeleteRecipe(int FoodId)
        {
            Food food = context.Food.Find(FoodId);
            context.Food.Remove(food);
        }

        public void UpdateRecipe(Food food)
        {
            context.Entry(food).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
