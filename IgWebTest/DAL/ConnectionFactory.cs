using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IgWebTest.DAL.ConnectionOptions;
using Microsoft.Extensions.Options;

namespace IgWebTest.DAL
{
    public class ConnectionFactory : IConnectionFactory
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        private readonly string connectionString = "";

        public ConnectionFactory(IOptions<ConnectionStrings> connOptions)
        {
            ConnectionStrings = connOptions.Value;
        }
    }
}
