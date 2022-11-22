using System;

namespace data.access
{
    public class Utils
    {

        public static string SOFT_DELETE_TAG = "SoftDelete";
        public static bool isNull<T>(T model) => model == null;

        public static string CONNECTION_STRING = @"Server=127.0.0.1,11433;Database=POSVentas;User ID=sa;Password=Sqlpass2022*";
    }
}
