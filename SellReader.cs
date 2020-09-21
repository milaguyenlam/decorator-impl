using System.Collections.Generic;
using Newtonsoft.Json;
using Csv;
using System.IO;
using System.Text;

namespace data_import
{
    //base component class for Decorator design pattern implementation
    //child classes implement parsing from a certain data format
    public abstract class SellReader : ISellReader
    {
        private List<Dictionary<string, string>> dictData;
        private int index;
        private int length;

        public SellReader(string filename)
        {
            dictData = ParseFromFile(filename);
            index = 0;
            length = dictData.Count;
        }

        public Sell readSell()
        {
            if (index < length)
            {
                var sell = new Sell(dictData[index]);
                index++;
                return sell;
            }
            else
            {
                return null;
            }
        }

        protected abstract List<Dictionary<string, string>> ParseFromFile(string filename);
    }

    //concrete implementation used read Sell objects from .csv files
    public class CSVSellReader : SellReader
    {
        public CSVSellReader(string filename) : base(filename)
        {
        }
        protected override List<Dictionary<string, string>> ParseFromFile(string filename)
        {
            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
            string csv = File.ReadAllText(filename, Encoding.UTF8);
            foreach (var line in CsvReader.ReadFromText(csv))
            {
                Dictionary<string, string> rowAsDict = new Dictionary<string, string>();
                rowAsDict[Constants.DataKeys.PRODUCT_NAME] = line[Constants.DataKeys.PRODUCT_NAME];
                rowAsDict[Constants.DataKeys.PRODUCT_DESCRIPTION] = line[Constants.DataKeys.PRODUCT_DESCRIPTION];
                rowAsDict[Constants.DataKeys.NEW_PRICE] = line[Constants.DataKeys.NEW_PRICE];
                rowAsDict[Constants.DataKeys.OLD_PRICE] = line[Constants.DataKeys.OLD_PRICE];
                rowAsDict[Constants.DataKeys.FROM_DATE] = line[Constants.DataKeys.FROM_DATE];
                rowAsDict[Constants.DataKeys.TO_DATE] = line[Constants.DataKeys.TO_DATE];
                rowAsDict[Constants.DataKeys.VENDOR] = line[Constants.DataKeys.VENDOR];
                rowAsDict[Constants.DataKeys.LOCATION_LATITUDE] = line[Constants.DataKeys.LOCATION_LATITUDE];
                rowAsDict[Constants.DataKeys.LOCATION_LONGITUDE] = line[Constants.DataKeys.LOCATION_LONGITUDE];
                rowAsDict[Constants.DataKeys.SCRAP_DATE] = line[Constants.DataKeys.SCRAP_DATE];
                data.Add(rowAsDict);
            }
            return data;
        }
    }

    //concrete implementation used read Sell objects from .json files
    public class JSONSellReader : SellReader
    {
        public JSONSellReader(string filename) : base(filename)
        {

        }
        protected override List<Dictionary<string, string>> ParseFromFile(string filename)
        {
            string json = File.ReadAllText(filename, Encoding.UTF8);
            var data = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
            return data;
        }
    }

    //Implemented when needed (probably won't be though)
    public class XMLSellReader : SellReader
    {
        public XMLSellReader(string filename) : base(filename)
        {
        }
        protected override List<Dictionary<string, string>> ParseFromFile(string filename)
        {
            throw new System.NotImplementedException();
        }
    }
}