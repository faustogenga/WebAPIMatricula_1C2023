using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dto.General
{
    public class AppSettings
    {
        public string BaseDatos { get; set; }
        public string Secret { get; set; }
        public string MinutosExpiracionToken { get; set; }
    }
}
