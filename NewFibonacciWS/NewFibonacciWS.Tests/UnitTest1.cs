using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NewFibonacciWS.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FibonacciWS f = new FibonacciWS();
            f.Fibonacci(10);
        }
    }
}
