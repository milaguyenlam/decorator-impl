using System;
using System.Collections.Generic;

namespace data_import
{
    //data class corresponding to MVC model class
    public class Sell
    {
        public Sell(Dictionary<string, string> dictionary)
        {
            productName = dictionary[Constants.DataKeys.PRODUCT_NAME];
            productDescription = dictionary[Constants.DataKeys.PRODUCT_DESCRIPTION];
            oldPrice = float.Parse(dictionary[Constants.DataKeys.OLD_PRICE]);
            newPrice = float.Parse(dictionary[Constants.DataKeys.NEW_PRICE]);
            fromDate = DateTime.Parse(dictionary[Constants.DataKeys.FROM_DATE]);
            toDate = DateTime.Parse(dictionary[Constants.DataKeys.TO_DATE]);
            locationLatitude = float.Parse(dictionary[Constants.DataKeys.LOCATION_LATITUDE]);
            locationLongitude = float.Parse(dictionary[Constants.DataKeys.LOCATION_LONGITUDE]);
            vendor = dictionary[Constants.DataKeys.VENDOR];
            scrapDate = DateTime.Parse(dictionary[Constants.DataKeys.SCRAP_DATE]);
        }
        public string productName;
        public string productDescription;
        public float oldPrice;
        public float newPrice;
        public DateTime fromDate;
        public DateTime toDate;
        public float locationLatitude;
        public float locationLongitude;
        public string vendor;
        public DateTime scrapDate;
    }
}