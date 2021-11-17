using Newtonsoft.Json;
using ObjectOrientedProgram.xyz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ObjectOrientedProgram
{
    public class InventoryMain

    {
        public List<InventoryModel> Rice;

        public void ReadData(string filepath)
        {
            try
            {
                using (StreamReader r = new StreamReader(filepath))
                {
                    var json = r.ReadToEnd();
                    InventoryFactory items = JsonConvert.DeserializeObject<InventoryFactory>(json);
                    Rice = items.RiceList;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DisplayData(string State)
        {
            Console.WriteLine("enter any one of state-[ Rice Or Pulse Or Wheat] which you want to display of that state Inventory");
            try 
            {
                if (State == "Rice")
                {
                    foreach (var item in Rice)
                    {

                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", item.Name, item.Weight, item.Price);
                    }
                }
               
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
    } }
}
