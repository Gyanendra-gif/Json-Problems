using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ObjectOrientedProgram.Classes
{
    class StockMain
    {
        public void DisplayData(string filepath)
        {
            try
            {
                using (StreamReader r = new StreamReader(filepath))
                {
                    var json = r.ReadToEnd();
                    var items = JsonConvert.DeserializeObject<List<StockModel>>(json);
                    Console.WriteLine("StockName\tNumberOfShare\tPricePerShare");
                    foreach (var item in items)
                    {
                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", item.Microsoft, item.Apple, item.Tesla);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
