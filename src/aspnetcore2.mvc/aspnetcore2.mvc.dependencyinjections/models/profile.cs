using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCore2.Mvc.DependencyInjections.Models
{
    public class Profile
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string FavColor { get; set; }
        public State State { get; set; }
    }
}
