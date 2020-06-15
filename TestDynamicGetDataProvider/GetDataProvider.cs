using System;
using System.Data.Common;
using System.Reflection;

namespace TestDynamicGetDataProvider
{
    public class GetDataProvider
    {
        public GetDataProvider()
        {
            Register();
        }

        public DbConnection CreateConnection()
        {
            try
            {
                var a = Assembly.LoadFrom("Oracle.ManagedDataAccess.dll");
                DbProviderFactory factory = (DbProviderFactory)a.CreateInstance("Oracle.ManagedDataAccess.Client.OracleClientFactory", true);
                //DbProviderFactory factory = DbProviderFactories.GetFactory("Oracle.ManagedDataAccess.Client");
                DbConnection con = factory.CreateConnection();
                //con.ConnectionString = "xxxxxxxxxxxxxxxxx";
                //con.Open();
                //con.Close();
                return con;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        private void Register()
        {
            try
            {
                string invariantName = "Oracle.ManagedDataAccess.Client";
                string factoryTypeAssemblyQualifiedName = "Oracle.ManagedDataAccess.Client.OracleClientFactory,Oracle.ManagedDataAccess";
                DbProviderFactories.RegisterFactory(invariantName, factoryTypeAssemblyQualifiedName);
                //DbProviderFactories.RegisterFactory(invariantName, OracleClientFactory.Instance);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
