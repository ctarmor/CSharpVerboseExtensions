using System;
using CSharpBasicExtensionsKitSharedProject;
using CSharpBasicExtensionsKitTests.Supporting;
using CSharpVerboseExtensionsNetFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpVerboseExtensionsNetFrameworkTests
{
    [TestClass]
    public class IsEmptyTests
    {
        [TestMethod]
        public void IsEmpty_WithNullString_IsTrue()
        {
            string target = null;

            Assert.IsTrue(target.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_WithEmptyString_IsTrue()
        {
            var target = string.Empty;

            Assert.IsTrue(target.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_WithString_IsFalse()
        {
            const string target = "x";

            Assert.IsFalse(target.IsEmpty());
        }
    }


    [TestClass]
    public class IsNotEmptyTests
    {
        [TestMethod]
        public void IsNotEmpty_WithNullString_IsTrue()
        {
            string target = null;

            Assert.IsFalse(target.IsNotEmpty());
        }

        [TestMethod]
        public void IsNotEmpty_WithEmptyString_IsTrue()
        {
            var target = string.Empty;

            Assert.IsFalse(target.IsNotEmpty());
        }

        [TestMethod]
        public void IsNotEmpty_WithString_IsFalse()
        {
            const string target = "x";

            Assert.IsTrue(target.IsNotEmpty());
        }
    }


    [TestClass]
    public class IsEqualTests
    {
        [TestMethod]
        public void IsEqualTo_WithLeftNull_WithRighNull_IsTrue()
        {
            string targetLeft = null;
            string targetRight = null;

            var result = targetLeft.IsEqualTo(targetRight);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEqualTo_WithLeftEmpty_WithRighNull_IsTrue()
        {
            string targetLeft = string.Empty;
            string targetRight = null;

            var result = targetLeft.IsEqualTo(targetRight);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsEqualTo_WithLeftString_WithRighString_IsTrue()
        {
            string targetLeft = "x";
            string targetRight = "x";

            var result = targetLeft.IsEqualTo(targetRight);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEqualTo_WithLeftString_WithRighString_IsFalse()
        {
            string targetLeft = "x";
            string targetRight = "a";

            var result = targetLeft.IsEqualTo(targetRight);

            Assert.IsFalse(result);
        }
    }



    [TestClass]
    public class IsNotEqualToTests
    {
        [TestMethod]
        public void IsNotEqualTo_WithLeftNull_WithRighNull_IsFalse()
        {
            string targetLeft = null;
            string targetRight = null;

            var result = targetLeft.IsNotEqualTo(targetRight);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotEqualTo_WithLeftEmpty_WithRighNull_IsTrue()
        {
            string targetLeft = string.Empty;
            string targetRight = null;

            var result = targetLeft.IsNotEqualTo(targetRight);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsNotEqualTo_WithLeftString_WithRighString_IsFalse()
        {
            string targetLeft = "x";
            string targetRight = "x";

            var result = targetLeft.IsNotEqualTo(targetRight);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotEqualTo_WithLeftString_WithRighString_IsTrue()
        {
            const string targetLeft = "x";
            const string targetRight = "a";

            var result = targetLeft.IsNotEqualTo(targetRight);

            Assert.IsTrue(result);
        }


        //[TestMethod]
        //public void IfNotEqualTo_WithLeftString_WithRighString_WhenEqual()
        //{
        //    const string targetLeft = "x";
        //    const string targetRight = "X";

        //    var result = targetLeft.IfNotEqualTo(targetRight, (s, s1) => { Assert.Fail(); });
        //    ...
        //    Assert.IsTrue(result);
        //}
    }



    [TestClass]
    public class IfEmptyTests
    {
        [TestMethod]
        public void IfEmpty_WithNullString_CallAction()
        {
            string target = null;
            var isActionCalled = false;

            var result = target.IfEmpty(() => isActionCalled = true);

            Assert.IsTrue(isActionCalled);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IfEmpty_WithEmptyString_CallAction()
        {
            var target = string.Empty;
            var isActionCalled = false;

            var result = target.IfEmpty(() => isActionCalled = true);

            Assert.IsTrue(isActionCalled);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsEmpty());
        }

        [TestMethod]
        public void IfEmpty_WithString_DoNotCallAction()
        {
            const string target = "a";

            var result = target.IfEmpty(() => Assert.Fail());

            Assert.AreEqual(result, "a");
        }

        [TestMethod]
        public void IfEmpty_WithString_DoNotCallFuncString()
        {
            const string target = "a";

            var result = target.IfEmpty(() => "b");

            Assert.AreEqual(result, "a");
        }

        [TestMethod]
        public void IfEmpty_WithNull_CallFuncString()
        {
            const string target = null;

            var result = target.IfEmpty(() => "b");

            Assert.AreEqual(result, "b");
        }
    }




    [TestClass]
    public class IfNotEmptyTests
    {
        [TestMethod]
        public void IfNotEmpty_WithNullString_DoNotCallFunc()
        {
            string target = null;

            var result = target.IfNotEmpty(x => { Assert.Fail(); return string.Empty; });

            Assert.IsNull(result);
        }

        [TestMethod]
        public void IfNotEmpty_WithString_CallFunc()
        {
            const string target = "a";

            var result = target.IfNotEmpty(x => x + "b");

            Assert.AreEqual(result, "ab");
        }

        [TestMethod]
        public void IfNotEmpty_WithString_CallAction()
        {
            const string target = "a";
            var isActionCalled = false;

            var result = target.IfNotEmpty(() => isActionCalled = true);

            Assert.IsTrue(isActionCalled);
            Assert.AreEqual(result, "a");
        }

        [TestMethod]
        public void IfNotEmpty_WithNullString_DoNotCallAction()
        {
            const string target = null;
            var isActionCalled = false;

            var result = target.IfNotEmpty(() => isActionCalled = true);

            Assert.IsFalse(isActionCalled);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IfNotEmpty_WithNullString_DoNotCallFuncTRet()
        {
            const string target = null;

            SomeTestClass result = target.IfNotEmpty(x => { Assert.Fail(); return new SomeTestClass(); });

            Assert.IsNull(result);
        }

        [TestMethod]
        public void IfNotEmpty_WithString_CallFuncTRet()
        {
            const string target = "a";

            SomeTestClass result = target.IfNotEmpty(x => new SomeTestClass());

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void IfNotEmpty_WithNullString_DoNotCallActionString()
        {
            const string target = null;

            var result = target.IfNotEmpty(x => Assert.Fail());

            Assert.IsNull(result);
        }



        [TestMethod]
        public void IfNotEmpty_WithString_CallActionString()
        {
            const string target = "a";
            var someType = new SomeTestClass();

            var result = target.IfNotEmpty(x => someType.MethodReturnVoid());

            Assert.AreEqual(result, target);
            Assert.IsTrue(someType.SomeMethodCalled);
        }
    }

    [TestClass]
    public class FuncStringTests
    {
        [TestMethod]
        public void FunNull()
        {
            Func<string> func = null;
            Assert.IsTrue(func.Call().IsEmpty());
        }

        [TestMethod]
        public void FuncNotNull()
        {
            Func<string> func = () => "a";
            Assert.IsTrue(func.Call().IsEqualTo("a"));
        }

        [TestMethod]
        public void IfNullEmptyStr()
        {
            string target = null;
            Assert.AreEqual("", target.IfNullEmptyStr());
        }
        
    }



    [TestClass]
    public class StringDateTimeExtensionsTests
    {
        /// <summary>
        /// ToDateTimeCountText
        /// </summary>
        [TestMethod]
        public void TestDateToString()
        {
            Assert.IsTrue((DateTime.Parse("06/03/2013").ToString("yyyy-MM-dd")).Equals("2013-06-03"));
            Assert.IsTrue((DateTime.Parse("06/03/2013 13:55:34").ToString("yyyy-MM-dd.HH-mm-ss")).Equals("2013-06-03.13-55-34"));
        }


        [TestMethod]
        public void TestDateTime()
        {
            var date = "Tue, 10 Jun 2014 15:48:01 EST".ToDateTimeFromStr();
            Assert.IsTrue(date == new DateTime(2014, 06, 10, 16, 48, 01));

            Assert.AreEqual(((string) null).ToDateTimeFromStr().Date, new DateTime(1, 1, 1).Date);
            Assert.IsTrue("Sun, 23 Jun 2013 18:20:01".ToDateTimeFromStr().Date == new DateTime(2013, 06, 23).Date);
            Assert.IsTrue("Sun, 23 Jun 2013 18:20:01 GMT".ToDateTimeFromStr().Date == new DateTime(2013, 06, 23).Date);
            Assert.IsTrue("Mon, 08 Apr 2013 00:02:00".ToDateTimeFromStr().Date == new DateTime(2013,4,8).Date);
            Assert.IsTrue("Tue, 02 Jul 2013 12:00:01 GMT".ToDateTimeFromStr() == "Tue, 02 Jul 2013 08:00:01 EDT".ToDateTimeFromStr());
            Assert.IsTrue("Fri, 28 Jun 2013 19:00:18 +0100".ToDateTimeFromStr() == DateTime.Parse("6/28/2013 2:00:18 PM"));
            Assert.IsTrue("Sun, 23 Jun 2013 20:56:30 EDT".ToDateTimeFromStr() == DateTime.Parse("6/23/2013 8:56:30 PM"));
            Assert.AreEqual(2, "Fri, 07 Feb 2014 11:52:10 EST".ToDateTimeFromStr().Month);
            Assert.AreEqual(2014, "Tue, 7 Jan 2014 10:02:00 -0400".ToDateTimeFromStr().Year);
            Assert.AreEqual(2010, "Thu, 20 May 2010 10:16:00 -0400".ToDateTimeFromStr().Year);
        }
    }
}
