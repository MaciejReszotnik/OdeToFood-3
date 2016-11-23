using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood2
{
    public interface IGreeter
    {
        string GetGreeting();
    }

    public class Greeter : IGreeter
    {
        public Greeter(IConfiguration configuration)
        {
            _greeting = configuration["Greeting"];
        }

        public string _greeting { get; private set; }

        public string GetGreeting()
        {
            return _greeting;
        }
    }
}
