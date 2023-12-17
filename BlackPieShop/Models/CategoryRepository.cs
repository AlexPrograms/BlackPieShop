namespace BlackPieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BlackPieDbContext _blackPieContext;

        public CategoryRepository(BlackPieDbContext blackPieContext)
        {
            _blackPieContext = blackPieContext;
        }

        public IEnumerable<Category> AllCategories =>
            _blackPieContext.Categories.OrderBy(p=>p.CategoryName);
    }
}
