using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedProgram.Classes
{
    class TransactionModel
    {
        public string StockName { get; set; }
        public int NumberOfShare { get; set; }
        public int PricePerShare { get; set; }
        public string TransactionDetails { get; set; }
    }
}
