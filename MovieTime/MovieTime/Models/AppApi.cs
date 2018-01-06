using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTime.Models
{
    public class AppApi
    {
        //public const String AddresseApi = "http://localhost:54998";
        public const String AddresseApi = "http://movietimeapp.azurewebsites.net";
        public static string Token { get; set; }
    }
}
