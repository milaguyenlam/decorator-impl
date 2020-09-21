using System.Collections.Generic;

namespace data_import
{
    //base component decorator class for Decorator design pattern implementation
    //child classes implement their on take on readSell() function
    public abstract class SellReaderDecorator : ISellReader
    {
        protected ISellReader _decoraterReader;
        public SellReaderDecorator(ISellReader reader)
        {
            _decoraterReader = reader;
        }
        public abstract Sell readSell();
    }

    //decorator translating productName field (using Dictionary<string,string>) of whatever its wrapee returns 
    public class TranslatedSellReader : SellReaderDecorator
    {
        private IReadOnlyDictionary<string, string> dictionary;
        public TranslatedSellReader(ISellReader reader, IReadOnlyDictionary<string, string> dict) : base(reader)
        {
            this.dictionary = dict;
        }

        public override Sell readSell()
        {
            var sell = _decoraterReader.readSell();
            if (sell != null)
            {
                sell.productName = dictionary[sell.productName];
            }
            return sell;
        }
    }

    //decorator changing productName, productDescription and vendor fields to uppercase of whatever its wrappee returns
    public class CapitalSellReader : SellReaderDecorator
    {
        public CapitalSellReader(ISellReader reader) : base(reader)
        {
        }

        public override Sell readSell()
        {
            var sell = _decoraterReader.readSell();
            if (sell != null)
            {
                sell.productName = sell.productName.ToUpper();
                sell.productDescription = sell.productDescription.ToUpper();
                sell.vendor = sell.vendor.ToUpper();
            }
            return sell;

        }
    }

    //decorator changing oldPrice and newPrice fields by multiplying those values by a given ratio of whatever its wrappee returns
    public class ChangeCurrencyReader : SellReaderDecorator
    {
        float rate;
        public ChangeCurrencyReader(ISellReader reader, float rate) : base(reader)
        {
            this.rate = rate;
        }
        public override Sell readSell()
        {
            Sell sell = _decoraterReader.readSell();
            if (sell != null)
            {
                sell.newPrice = sell.newPrice * rate;
                sell.oldPrice = sell.oldPrice * rate;
            }
            return sell;
        }
    }



}