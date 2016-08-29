using ProjectDobavljac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectDobavljac.Model;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace ProjectDobavljac
{
    public class DataAccessPostgreSqlProvider : IDataAccessProvider
    {
        private readonly DomainModelPostgreSqlContext _context;
        private readonly ILogger _logger;

        public DataAccessPostgreSqlProvider(DomainModelPostgreSqlContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccessPostgreSqlProvider");
        }

        public void AddDobavljac(Dobavljac dobavljac)
        {         
            _context.Dobavljac.Add(dobavljac);
            _context.SaveChanges();
        }

        public void DeleteDobavljac(int dobavljacdId)
        {
            var entity = _context.Dobavljac.First(t => t.dobavljacId == dobavljacdId);
            _context.Dobavljac.Remove(entity);
            _context.SaveChanges();
        }

        public Dobavljac GetDobavljac(int dobavljacdId)
        {
            return _context.Dobavljac.First(t => t.dobavljacId == dobavljacdId);
        }

        public List<Dobavljac> GetDobavljaci()
        {
            return _context.Dobavljac.OrderByDescending(dobavljac => EF.Property<int>(dobavljac, "dobavljacId")).ToList();
        }

        public void UpdateDobavljac(int dobavljacdId, Dobavljac dobavljac)
        {
            _context.Dobavljac.Update(dobavljac);
            _context.SaveChanges();
        }
    }
}
