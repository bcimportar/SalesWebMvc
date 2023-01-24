using System;

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }   // Associação de 1 para Muitos com Salles

        public SalesRecord()
        {

        }
        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id=id;
            Date=date;
            Amount=amount;
            Status=status;
            Seller=seller;
        }
    }
}
