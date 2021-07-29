using System.Configuration;
using System.IO;

namespace WindowsFormsApp15.Data
{
    class Connect
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    }
}
