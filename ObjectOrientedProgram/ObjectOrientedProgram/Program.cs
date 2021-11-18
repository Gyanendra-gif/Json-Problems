using ObjectOrientedProgram.Classes;
using System;

namespace ObjectOrientedProgram
{
    class Program
    {
        static string filePath = @"E:\GitDemo\OOPS-Problems\ObjectOrientedProgram\ObjectOrientedProgram\Files\Stock.json";
        static void Main(string[] args)
        {
            bool flag = true;
            InventoryMain im = new InventoryMain();
            StockMain sm = new StockMain();
            int choice;
            while (flag)
            {
                Console.WriteLine("Enter your Choice Number to Execute the Json Program Press- 1-Inventory Items, 2-Inventory List, 3-Stock Items, 4-Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:im.ReadData(filePath);
                        break;
                    case 2:
                        im.ReadData(filePath);
                        im.DisplayData("Rice");
                        break;
                    case 3:
                        sm.DisplayData(@"E:\GitDemo\OOPS-Problems\ObjectOrientedProgram\ObjectOrientedProgram\Files\Stock.json");
                        break;
                    case 4:
                        flag = false;
                        break;
                }
            }
        }
    }
}