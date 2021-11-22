using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedProgram.Classes
{
    class StockUtility
    {
        public LinkedList<Stocks> stocksList = new LinkedList<Stocks>();
        public class Stocks
        {
            public string StockName { get; set; }
            public int Shares { get; set; }
            public int Price { get; set; }
        }
    }
}
