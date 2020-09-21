using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HF.Web.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [DisplayName("Тип операции")]
        public Operation Operation { get; set; }
        public int OperationId { get; set; }


        [DisplayName("Сумма")]
        public decimal Amount { get; set; }

        [DisplayName("Ед.изм.")]
        public Unit Unit { get; set; }
        public int UnitId { get; set; }

        [DisplayName("Валюта")]
        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        [DisplayName("Дата/Время")]
        public DateTime OperationDateTime { get; set; }

        [DisplayName("Категория")]
        //public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<TransactionCategory> TransactionCategories { get; set; } = new List<TransactionCategory>();

        //public Category Category { get; set; }
        //public int CategoryId { get; set; }
        
        [DisplayName("Для кого оплачено")]
        public Recipient Recipient { get; set; }
        public int RecipientId { get; set; }
        
        [DisplayName("Кому оплачено")]
        public Contractor Contractor { get; set; }
        public int ContractorId { get; set; }

        
        
    }

    public class Contractor
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<TransactionCategory> TransactionCategories { get; set; } = new List<TransactionCategory>();
    }

    public class TransactionCategory
    {
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
    
    public class Recipient
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Operation
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
