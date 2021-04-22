using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA.ApplicationArchitecture.Data.API;
namespace TPA.ApplicationArchitectureTests.BusinessLogic.Tests
{
    public class Linq2SQL : ILinq2SQL
    {
        

        public override void Connect()
        {
            Console.WriteLine("Text to write for UT");
        }
    }
}
