using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static ObjectOrientedProgram.Classes.StockUtility;

namespace ObjectOrientedProgram.Classes
{
    class StockMain
    {
        private object stockAccount;
        List<StockModel> stockModels = new List<StockModel>();

        public bool StockModel { get; private set; }

        public void DisplayData(string filepath) // To Display Stocks
        {
            try
            {
                using (StreamReader r = new StreamReader(filepath))
                {
                    var json = r.ReadToEnd();
                    var items = JsonConvert.DeserializeObject<StockModel>(json);
                    Console.WriteLine("StockName\tNumberOfShare\tPricePerShare");
                        Console.WriteLine("{0}" + "\t" + "{1}" + "\t" + "{2}", items.StockName, items.NumberOfShare, items.PricePerShare);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void TotalValue(string filepath) 
        {
            try
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    var json = reader.ReadToEnd();
                    stockModels = JsonConvert.DeserializeObject<List<StockModel>>(json);
                    foreach (var item in stockModels)
                    {
                        item.value = item.NumberOfShare * item.PricePerShare;
                    }
                    string Value = JsonConvert.SerializeObject(stockModels);
                    File.WriteAllText(filepath, Value);
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Buy(string stockfilepath, string accountfilepath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(stockfilepath))
                {
                    var json = reader.ReadToEnd();
                    var ItemsToBuy = JsonConvert.DeserializeObject<List<StockModel>>(json);
                    Console.WriteLine("Enter the Number of Stocks to Buy:");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the Company Name:");
                    string name = Console.ReadLine();
                    TransactionModel transactionModel = new TransactionModel();
                    transactionModel.StockName = name;
                    foreach (var item in ItemsToBuy)
                    {
                        if (item.StockName == name)
                        {
                            transactionModel.TransactionDetails = DateTime.Now.ToString("dd/mm/yy HH:mm:ss");
                            transactionModel.PricePerShare += item.PricePerShare;
                            transactionModel.NumberOfShare += num;
                            item.value = item.NumberOfShare * item.PricePerShare;

                        }
                        reader.Close();
                        string transactionNewData = JsonConvert.SerializeObject(stockModels);
                        Console.WriteLine();
                        File.WriteAllText(stockfilepath, transactionNewData);

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
        public void Sell(string stockfilepath, string accountfilepath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(stockfilepath))
                {
                    var json = reader.ReadToEnd();
                    var ItemsToSell = JsonConvert.DeserializeObject<List<StockModel>>(json);
                    Console.WriteLine("Enter the Number of Stocks to Sell:");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the Company Name:");
                    string name = Console.ReadLine();
                    TransactionModel transactionModel = new TransactionModel();
                    transactionModel.StockName = name;
                    foreach (var item in ItemsToSell)
                    {
                        if (item.StockName == name)
                        {
                            transactionModel.TransactionDetails = DateTime.Now.ToString("dd/mm/yy HH:mm:ss");
                            transactionModel.PricePerShare -= item.PricePerShare;
                            transactionModel.NumberOfShare -= num;
                            item.value = item.NumberOfShare * item.PricePerShare;

                        }
                        reader.Close();
                        string transactionNewData = JsonConvert.SerializeObject(stockModels);
                        Console.WriteLine();
                        File.WriteAllText(stockfilepath, transactionNewData);

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