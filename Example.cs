using System;
using System.Collections.Generic;

namespace data_import
{
    public class Example
    {
        public static string csvFilename = "data\\kaufland.csv";
        public static string jsonFilename = "data\\kaufland.json";
        public static Dictionary<string, string> translator = new Dictionary<string, string>() {
            {"K - Classic Játrová paštika", "K - Classic Liver pate"},
            {"K-Classic Selská šunka", "K - Classic Rustic ham"},
            {"Kostelecké uzeniny Salám Rio Ebro", "Kostelecké uzeniny Salami Rio Ebro"},
            {"Heidemark Krůtí nudličky z prsou", "Heidemark Turkey breast strips"}
        };
        public static float czkToEuroRate = 0.04f;
        public static void Main(string[] args)
        {
            var capitalCsvReader = new CapitalSellReader(new CSVSellReader(csvFilename));
            var translatedJsonReader = new ChangeCurrencyReader(new TranslatedSellReader(new JSONSellReader(jsonFilename), translator), czkToEuroRate);
            List<Sell> capitalSells = new List<Sell>();
            List<Sell> translatedEuroSells = new List<Sell>();
            Sell sell;
            while ((sell = capitalCsvReader.readSell()) != null)
            {
                capitalSells.Add(sell);
            }
            while ((sell = translatedJsonReader.readSell()) != null)
            {
                translatedEuroSells.Add(sell);
            }

            var capitalSell = capitalSells[0];
            var translatedEuroSell = translatedEuroSells[0];
            Console.WriteLine("Should be capital: " + capitalSell.productName + ", " + capitalSell.productDescription + ", " + capitalSell.vendor);
            Console.WriteLine("Should be translated from Czech to English: " + capitalSell.productName.ToLower() + " ---> " + translatedEuroSell.productName);
            Console.WriteLine("Should be converted from CZK to EUR: " + capitalSell.oldPrice + "CZK ---> " + translatedEuroSell.oldPrice + "EUR");
            Console.WriteLine("Should be converted from CZK to EUR: " + capitalSell.newPrice + "CZK ---> " + translatedEuroSell.newPrice + "EUR");


            //... add Sells to DB or frontend
        }
    }
}
