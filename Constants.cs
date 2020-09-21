namespace data_import
{
    public static class Constants
    {
        //keys used in data files (.csv, .json, .xml)
        public static class DataKeys
        {
            public static string PRODUCT_NAME = "product_name";
            public static string PRODUCT_DESCRIPTION = "product_description";
            public static string OLD_PRICE = "old_price";
            public static string NEW_PRICE = "new_price";
            public static string FROM_DATE = "from_date";
            public static string TO_DATE = "to_date";
            public static string LOCATION_LATITUDE = "location_lat";
            public static string LOCATION_LONGITUDE = "location_lng";
            public static string VENDOR = "vendor";
            public static string SCRAP_DATE = "scrap_date";
        }
    }
}