using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageIdentifier.BLL;
using PackageIdentifier.Common;

namespace PackageIdentifier.Test
{
    [TestClass]
    public class PackageIdentifierTest
    {
        [TestMethod]
        public void ValidateInputArgsTest()
        {
            string[] args = new string[] { "1" };
            Tuple<bool, string, int, int> tuple1 = Validation.ValidateInputArgs(args);
            var errorMsg = "Please provide both a start and end number for the application.";
            Assert.AreEqual(false, tuple1.Item1);
            Assert.AreEqual(errorMsg, tuple1.Item2);

            args = new string[] { "10", "20", "30" };
            Tuple<bool, string, int, int> tuple2 = Validation.ValidateInputArgs(args);
            errorMsg = "Please only provide a start and end number for the application.";
            Assert.AreEqual(false, tuple2.Item1);
            Assert.AreEqual(errorMsg, tuple2.Item2);

            args = new string[] { "-10", "abc" };
            Tuple<bool, string, int, int> tuple3 = Validation.ValidateInputArgs(args);
            errorMsg = "Please provide a positive integer for both the start and end numbers for the application.";
            Assert.AreEqual(false, tuple3.Item1);
            Assert.AreEqual(errorMsg, tuple3.Item2);

            args = new string[] { "3", "30" };
            Tuple<bool, string, int, int> tuple4 = Validation.ValidateInputArgs(args);
            errorMsg = string.Empty;
            Assert.AreEqual(true, tuple4.Item1);
            Assert.AreEqual(errorMsg, tuple4.Item2);
            Assert.AreEqual(3, tuple4.Item3);
            Assert.AreEqual(30, tuple4.Item4);
        }

        [TestMethod]
        public void GetPackageIdentifierTest()
        {
            int s = 3, e = 15;
            int totalElements = 13;
            var mul = new Multiplier();
            var result = mul.GetPackageIdentifier(s, e);
            Assert.AreEqual(totalElements, result.Count);

            string lastIdentifier;
            result.TryGetValue(e, out lastIdentifier);
            Assert.AreEqual(Constants.returnDelivery, lastIdentifier);
        }
    }
}
