using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCore2.Mvc.DependencyInjections.Models
{
    public class State
    {
        public State(string name, string code) => (Name, Code) = (name, code);

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
