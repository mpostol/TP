using System;
using TPA.ApplicationArchitecture.Data.API;

namespace TPA.ApplicationArchitecture.BusinessLogic.Tests
{
    public class TestLinq2SQL : ILinq2SQL
    {
        public override void Connect()
        {
            Console.Write("Text to write for UT");
        }
    }
}
