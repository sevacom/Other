using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Samples.Dapper.DataAccess;

namespace Samples.Dapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var target = new MssqlConnectionFactory();
            using (var connection = target.Create())
            {
                connection.Open();
                //connection.QuerySingleOrDefault()
                connection.Close();
            }
        }
    }
}
