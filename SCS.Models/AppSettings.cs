using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCS.Models
{
    public class AppSettings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Key1 { get; set; }
        public string Key2 {  get; set; }
    }
}
