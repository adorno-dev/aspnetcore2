using AspnetCore2.Mvc.DependencyInjections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCore2.Mvc.DependencyInjections.Data.Services
{
    public class ProfileOptionsService
    {
        public IList<string> ListGenders() => new List<string> { "Female", "Male" };

        public IList<string> ListColors() => new List<string> { "Blue", "Green", "Red", "Yellow" };

        public IList<State> ListStates() => new List<State>
        {
            new State("Alabama", "AL"),
            new State("Alaska", "AK"),
            new State("Ohio", "OH"),
        };
    }
}
