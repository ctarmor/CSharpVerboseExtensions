using CSharpBasicExtensionsKitTests.Supporting;
using CSharpVerboseExtensionsNetFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpVerboseExtensionsNetFrameworkTests
{
    [TestClass]
    public class NullCheckExtensionsTests
    {
        [TestMethod]
        public void Null_Extension_Tests()
        {
            object target = null;

            Assert.IsTrue(target.IsNull());
            Assert.IsFalse(target.IsNotNull());
        }

        [TestMethod]
        public void NotNull_Extension_Tests()
        {
            var target = new object();

            Assert.IsFalse(target.IsNull());
            Assert.IsTrue(target.IsNotNull());
        }

        [TestMethod]
        public void IfNull_WithNullTarget_CallAction_ReturnSameType()
        {
            var target = default(SomeTestClass);
            var targetOther = new SomeOtherTestClass();

            var rtn = target.IfNull(() => targetOther.OtherMethodReturnVoid());

            Assert.AreSame(rtn, target);
            Assert.IsTrue(targetOther.SomeMethodCalled);
        }

        [TestMethod]
        public void IfNull_WithNullTarget_CallFuncT_ReturnSameType()
        {
            var target = default(SomeTestClass);

            SomeTestClass rtn = target.IfNull(() => new SomeTestClass());

            Assert.AreNotSame(target, rtn);
        }

        [TestMethod]
        public void IfNull_WithNullTarget_CallFuncTR_ReturnOtherType()
        {
            var target = default(SomeTestClass);

            SomeOtherTestClass rtn = target.IfNull(() => new SomeOtherTestClass());

            Assert.IsNotNull(rtn);
        }

        [TestMethod]
        public void IfNull_WithTarget_CallAction_ReturnTarget()
        {
            var target = new SomeTestClass();

            // If T is null, call Action, always return T
            var rtn = target.IfNull(() => Assert.Fail());

            Assert.AreSame(rtn, target);
        }

        [TestMethod]
        public void IfNull_WithTarget_DoNotCallAction_ReturnSameTypeNull()
        {
            var target = new SomeTestClass();

            SomeTestClass rtn = target.IfNull(() => new SomeTestClass());

            Assert.AreSame(rtn, target);
        }

        [TestMethod]
        public void IfNull_WithTarget_DoNotCallFuncTR_ReturnOtherTypeNull()
        {
            var target = new SomeTestClass();

            SomeOtherTestClass rtn = target.IfNull(() => new SomeOtherTestClass());

            Assert.IsNull(rtn);
        }

        [TestMethod]
        public void IfNotNull_WithNullTarget_DoNotCallAction_ReturnSameTypeNull()
        {
            var target = default(SomeTestClass);

            // Do not call Action, return source
            var rtn = target.IfNotNull(() => Assert.Fail());

            Assert.IsNull(rtn);
        }

        [TestMethod]
        public void IfNotNull_WithNullTarget_DoNotCallActionT_ReturnSameTypeNull()
        {
            var target = default(SomeTestClass);

            // Do not call Action<T>, always return source
            var rtn = target.IfNotNull(x => x.MethodReturnVoid());

            Assert.IsNull(rtn);
        }


        [TestMethod]
        public void IfNotNull_WithNullTarget_DoNotCallFuncTTR_ReturnOtherTypeNull()
        {
            var target = default(SomeTestClass);

            // Do not call Func<T,TR>(), return default(TR)
            SomeOtherTestClass otherRtn = target.IfNotNull(x => new SomeOtherTestClass());

            Assert.IsNull(otherRtn);
        }


        [TestMethod]
        public void IfNotNull_WithNullTarget_DoNotCallFuncTR_ReturnOtherTypeNull()
        {
            var target = default(SomeTestClass);

            // Do not call Func<TR>(), return default(TR)
            SomeOtherTestClass otherRtn = target.IfNotNull(() => new SomeOtherTestClass());

            Assert.IsNull(otherRtn);
        }

        [TestMethod]
        public void IfNotNull_WithTarget_CallAction_ReturnSameType()
        {
            var target = new SomeTestClass();

            var rtn = target.IfNotNull(() => target.MethodReturnVoid());

            Assert.IsNotNull(rtn);
            Assert.AreSame(rtn, target);
            Assert.IsTrue(target.SomeMethodCalled);
        }

        [TestMethod]
        public void IfNotNull_WithTarget_CallActionT_ReturnSameType()
        {
            var target = new SomeTestClass();

            // Do not call Action<T>, always return source
            var rtn = target.IfNotNull(x => x.MethodReturnVoid());

            Assert.IsNotNull(rtn);
            Assert.AreSame(rtn, target);
            Assert.IsTrue(target.SomeMethodCalled);
        }

        [TestMethod]
        public void IfNotNull_WithTarget_CallFuncTTR_ReturnOtherType()
        {
            var target = new SomeTestClass();

            SomeOtherTestClass otherRtn = target.IfNotNull(x => new SomeOtherTestClass());

            Assert.IsNotNull(otherRtn);
        }

        [TestMethod]
        public void IfNotNull_WithTarget_CallFuncTR_ReturnOtherType()
        {
            var target = new SomeTestClass();

            // Do not call Func<TR>(), return default(TR)
            SomeOtherTestClass otherRtn = target.IfNotNull(() => new SomeOtherTestClass());

            Assert.IsNotNull(otherRtn);
        }
    }
}
