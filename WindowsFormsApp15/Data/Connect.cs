using System.Configuration;
using System.IO;

namespace WindowsFormsApp15.Data
{
    class Connect
    {
        //public static string ConnectionString => ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public static string ConnectionString => @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\WindowsFormsApp15\WindowsFormsApp15\Data\FactoryDb.mdf;Integrated Security=True";
    }
}
