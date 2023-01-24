using System.Collections.Generic;
using System;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();  // Associação de Muitos  para 1 com Departaments

        public Department(int id, string name)
        {
            Id=id;
            Name=name;
        }

        public void AddSellers(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSeller(DateTime initial, DateTime final)
        {

            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }

    }
}
