using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestConsume
{
    class Company
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string status { get; set; }
        public string logo { get; set; }
        public string address { get; set; }

        public Company()
        {
            this.id = 0;
            this.name = string.Empty;
            this.email = string.Empty;
            this.phone = string.Empty;
            this.phone = string.Empty;
            this.lat = string.Empty;
            this.lon = string.Empty;
            this.status = "A";
            this.address = string.Empty;
            this.logo = string.Empty;
        }

        
    }
}
