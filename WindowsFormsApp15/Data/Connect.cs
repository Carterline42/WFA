﻿using System.IO;

namespace WindowsFormsApp15.Data
{
    class Connect
    {
        public static string ConnectionString => $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Directory.GetCurrentDirectory()}\FactoryDb.mdf;Integrated Security=True";
    }
}
