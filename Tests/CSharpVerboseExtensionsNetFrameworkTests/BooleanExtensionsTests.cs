using CSharpBasicExtensionsKitSharedProject;
using CSharpBasicExtensionsKitTests.Supporting;
using CSharpVerboseExtensionsNetFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpVerboseExtensionsNetFrameworkTests
{
    [TestClass]
    public class BooleanExtensionsIfTrueTests
    {
        [TestMethod]
        public void IfTrue_WithFalse_DoNotCallAction()
        {
            false.IfTrue(() => Assert.Fail());
        }


        [TestMethod]
        public void IfTrue_WithTrue_CallAction()
        {
            var actionCalled = false;

            true.IfTrue(() => actionCalled = true);

            Assert.IsTrue(actionCalled);
        }


        [TestMethod]
        public void IfTrue_WithFalse_DoNotCallActionBool()
        {
            false.IfTrue(x => Assert.Fail());
        }


        [TestMethod]
        public void IfTrue_WithTrue_CallActionBool()
        {
            var actionCalled = false;

            true.IfTrue(x => actionCalled = x);

            Assert.IsTrue(actionCalled);
        }


        [TestMethod]
        public void IfTrue_WithFalse_DoNotCallFuncT()
        {
            SomeTestClass result = false.IfTrue(x => { Assert.Fail(); return new SomeTestClass(); });
        }


        [TestMethod]
        public void IfTrue_WithTrue_CallFunctT()
        {
            SomeTestClass result = true.IfTrue(x => new SomeTestClass());

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IfTrue_WithFalse_DoNotCallFunctT_ReturnDefaultT()
        {
            SomeTestClass result = false.IfTrue(x => new SomeTestClass());

            Assert.IsTrue(result == default(SomeTestClass));
        }
    }



    [TestClass]
    public class BooleanExtensionsIfFalseTests
    {
        [TestMethod]
        public void IfFalse_WithTrue_DoNotCallAction()
        {
            true.IfFalse(() => Assert.Fail());
        }


        [TestMethod]
        public void IfFalse_WithFalse_CallAction()
        {
            var actionCalled = false;

            false.IfFalse(() => actionCalled = true);

            Assert.IsTrue(actionCalled);
        }


        [TestMethod]
        public void IfFalse_WithTrue_DoNotCallActionBool()
        {
            true.IfFalse(x => Assert.Fail());
        }


        [TestMethod]
        public void IfFalse_WithFalse_CallActionBool()
        {
            var actionCalled = true;

            false.IfFalse(x => actionCalled = x);

            Assert.IsFalse(actionCalled);
        }


        [TestMethod]
        public void IfFalse_WithTrue_DoNotCallFuncT()
        {
            SomeTestClass result = true.IfFalse(x => { Assert.Fail(); return new SomeTestClass(); });
        }


        [TestMethod]
        public void IfFalse_WithFalse_CallFunctT()
        {
            SomeTestClass result = false.IfFalse(x => new SomeTestClass());

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void IfFalse_WithTrue_CallFunctT_ReturnDefault()
        {
            SomeTestClass result = true.IfFalse(x => new SomeTestClass());

            Assert.IsTrue(result == default(SomeTestClass));
        }
    }
}
