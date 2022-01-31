using System;
using System.Collections.Generic;
using System.Linq;
using webapiApiService.Models;

namespace webapiApiService.Data
{
    public class webapiApiRepo : IwebapiApiRepo
    {

        private readonly AppDbContext _context;

        public webapiApiRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreatewebapiApi(webapiApi plat)
        {

            if (plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }

            _context.webapiApis.Add(plat);
        }

        public IEnumerable<webapiApi> GetAllwebapiApis()
        {
            return _context.webapiApis.ToList();
        }

        public webapiApi GetwebapiApiById(int id)
        {
            return _context.webapiApis.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}