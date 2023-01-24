using System.Collections.Generic;
using System;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BasiscSalary { get; set; }
        public Department Department { get; set; }   // Associação de 1 para Muitos com Departaments
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>(); // Associação de Muitos para 1 SalesRecord


        public Seller()
        {


        }

        public Seller(int id, string name, string email, DateTime birthDate, double basiscSalary, Department department)
        {
            Id=id;
            Name=name;
            Email=email;
            BirthDate=birthDate;
            BasiscSalary=basiscSalary;
            Department=department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            // Pegando o total de vendas em um determinado período
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
