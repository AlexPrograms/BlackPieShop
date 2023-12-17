using Microsoft.EntityFrameworkCore;

namespace BlackPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly BlackPieDbContext _blackPieDbContext;

        public PieRepository(BlackPieDbContext blackPieDbContext)
        {
            _blackPieDbContext = blackPieDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get { return _blackPieDbContext.Pies.Include(c => c.Category); }
        }


        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _blackPieDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId)
        {
            return _blackPieDbContext.Pies.FirstOrDefault(p=> p.PieId == pieId);
        }
    }
}
