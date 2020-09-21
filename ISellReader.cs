using System.Collections.Generic;

namespace data_import
{
    //base interface for Decorator design pattern implementation (inherited by both the base component and the component decorator classes)
    public interface ISellReader
    {
        //returns Sell object (returns null if there is nothing to read)
        //function that is going to be altered by decorating classes
        public Sell readSell();
    }
}