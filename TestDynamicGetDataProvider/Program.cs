using System;

namespace TestDynamicGetDataProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            GetDataProvider dp = new GetDataProvider();
            dp.CreateConnection();
        }
    }
}
