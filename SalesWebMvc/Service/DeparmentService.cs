using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Service
{
    public class DeparmentService
    {

        private readonly SalesWebMvcContext _context;
        public DeparmentService(SalesWebMvcContext context)
        {
            _context=context;   
        }

        public List<Department> FindAll()
        {
           return _context.Department.OrderBy( x=>x.Name).ToList();   
        }
    }
}
