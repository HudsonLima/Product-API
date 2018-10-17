using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAPI.Tests
{
    public class Configuration
    {
        public static Configuration Default { get { return Local; } }

        public static Configuration Local = new Configuration()
        {
            Resource = "https://localhost:5001",
        };
        
        public string Resource { get; set; }
    }
}
