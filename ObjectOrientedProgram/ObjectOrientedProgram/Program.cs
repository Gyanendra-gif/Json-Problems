using System;

namespace ObjectOrientedProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            InventoryMain im = new InventoryMain();
            while (flag)
            {
                Console.WriteLine("Enter your Choice Number to Execute the Address Program Press- 1-Name, 2-Weight, 3-Price");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:im.DisplayData(@"E:\GitDemo\Json-Problems\ObjectOrientedProgram\ObjectOrientedProgram\Files\Inventory.json");
                        break;
                    case 2:
                        flag = false;
                        break;

                }
            }
        }
    }
}