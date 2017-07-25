using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NazarAPI.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string TransactionName { get; set; }
        public DateTime TransactionDate { get; set; }
        public int GotVolume { get; set; }

    }
}