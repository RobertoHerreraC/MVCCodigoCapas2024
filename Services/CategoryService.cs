using Domain;
using Infraestructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService
    {
        private readonly MarketContext _context;

        public CategoryService(MarketContext context) {
            _context = context;
        }

        public List<Category> Get()
        {
            var query = _context.Categories;
            return query.ToList();

        }

        public List<Category> GetByFilterName(string name)
        {
            var query = _context.Categories.Where(x => x.Name.Contains(name) || string.IsNullOrEmpty(name));

            return query.ToList();
        }

        public void Insert(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }


    }
}
