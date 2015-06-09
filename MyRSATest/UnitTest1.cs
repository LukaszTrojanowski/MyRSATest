using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRSA;
using System.Numerics;

namespace MyRSATest
{
    [TestClass]
    public class UnitTest1
    {
        // check all Utils methods
        [TestMethod]
        public void checkModInverse()
        {
            BigInteger result = MyRSA.Utils.modInverse(138, 191);
            BigInteger expected = 18;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void checkRandInRange()
        {
            BigInteger result = MyRSA.BigIntRand.RandInRange(10000000);
            Assert.IsTrue(result >= 0 && result <= 10000000, "result has value: " + result);
        }
        [TestMethod]
        public void checkRandOfSize()
        {
            int N = 128;
            BigInteger result = MyRSA.BigIntRand.RandOfSize(N); // must be devisable by 8
            Assert.IsTrue(result.ToByteArray().Length == N/8, "Obtained number does not have the right amount of bytes");
        }
        [TestMethod]
        public void TestGetBytesAndGetString()
        {
            string testString = "test";
            byte[] testBytes = MyRSA.Utils.GetBytes(testString);
            string stringFromBytes = MyRSA.Utils.GetString(testBytes);
            Assert.IsTrue(testString == stringFromBytes, "test string has value: " + testString + " from bytes has value: " + stringFromBytes);
        }
        
        [TestMethod]
        public void TestEncDec()
        {
            string testString = "Happy Birthday";
            MyRSA.RSA myRsa = new MyRSA.RSA();
            myRsa.keyGen(512, 65537);
            string enc = myRsa.encode(testString, 65537);
            BigInteger privKey = myRsa.getPrivateKey();
            string dec = myRsa.decode(enc, privKey);
            Assert.AreEqual(testString, dec);
        }

    }
}
