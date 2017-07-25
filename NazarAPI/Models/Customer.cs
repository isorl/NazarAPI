using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NazarAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CarNumber { get; set; }
        public int ReservedVolume { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}