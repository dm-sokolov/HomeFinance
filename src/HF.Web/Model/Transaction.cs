using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HF.Web.Model
{
    public class Transaction
    {
        public int Id { get; set; }

        public Operation Operation { get; set; }

        public decimal Amount { get; set; }


        public Unit Unit { get; set; }

        public Currency Currency { get; set; }

        public DateTime OperationDateTime { get; set; }

        public Category Category { get; set; }
    }

    public class Category
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
