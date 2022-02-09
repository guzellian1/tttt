using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodforAuthorize_true()
        {
            var login = "qwerty";
            var pass = "123";
            var result = true;
            var required = true;
            if (login.Length < 2)
                result = false;
            if (pass.Length < 2)
                result = false;
            Assert.AreEqual(required, result);
        }

        [TestMethod]
        public void TestMethodforAuthorize_false()
        {
            var login = "qwerty";
            var pass = "5";
            var result = true;
            var required = false;
            if (login.Length < 2)
                result = false;
            if (pass.Length < 2)
                result = false;
            Assert.AreEqual(required, result);
        }

        [TestMethod]
        public void TestMethodforRegistration_true()
        {
            var login = "Masha";
            var pass = "loh";
            var pass1 = "loh";
            var result = true;
            var required = true;
            if (login.Length < 2)
                result = false;
            if (pass.Length < 2)
                result = false;
            if (pass != pass1)
                result = false;
            Assert.AreEqual(required, result);
        }

        [TestMethod]
        public void TestMethodforRegistration_false()
        {
            var login = "Albert";
            var pass = "loh";
            var pass1 = "lohh";
            var result = true;
            var required = false;
            if (login.Length < 2)
                result = false;
            if (pass.Length < 2)
                result = false;
            if (pass != pass1)
                result = false;
            Assert.AreEqual(required, result);
        }
    }
}
