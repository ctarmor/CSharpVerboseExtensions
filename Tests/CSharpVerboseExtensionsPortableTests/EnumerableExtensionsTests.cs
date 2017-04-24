using System.Collections.Generic;
using System.Linq;
using CSharpBasicExtensionsKitTests.Supporting;
using CSharpVerboseExtensionsNetFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpVerboseExtensionsNetFrameworkTests
{
    [TestClass]
    public class EnumerableIsEmptyTests
    {
        [TestMethod]
        public void IsEmpty_WithNull_ReturnTrue()
        {
            var result = _sequenceNull.IsEnumEmpty();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEmpty_WithEmpty_ReturnTrue()
        {
            var result = _sequenceEmpty.IsEnumEmpty();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEmpty_WithFull_ReturnFalse()
        {
            var result = _sequenceFull.IsEnumEmpty();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotEmpty_WithNull_ReturnFalse()
        {
            var result = _sequenceNull.IsEnumNotEmpty();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotEmpty_WithEmpty_ReturnFalse()
        {
            var result = _sequenceEmpty.IsEnumNotEmpty();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNotEmpty_WithFull_ReturnTrue()
        {
            var result = _sequenceFull.IsEnumNotEmpty();

            Assert.IsTrue(result);
        }


        private readonly IEnumerable<string> _sequenceNull = null;
        private readonly IEnumerable<string> _sequenceEmpty = new string[] { };
        private readonly IEnumerable<string> _sequenceFull = new string[] { "a", "b" };
    }


    [TestClass]
    public class EnumerableIfNotEmptyTests
    {
        [TestMethod]
        public void IfNotEmpty_WithNull_DoNotCallAction_ReturnEmpty()
        {
            var result = _sequenceNull.IfEnumNotEmpty(x => Assert.Fail());

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void IfNotEmpty_WithEmpty_DoNotCallAction_ReturnNull()
        {
            var result = _sequenceEmpty.IfEnumNotEmpty(x => Assert.Fail());

            Assert.AreSame(result, _sequenceEmpty);
        }


        [TestMethod]
        public void IfNotEmpty_WithFull_DoNotCallAction_ReturnNull()
        {
            var target = new SomeTestClass();

            var result = _sequenceFull.IfEnumNotEmpty(x => target.MethodReturnVoid());

            Assert.IsTrue(target.SomeMethodCalled);
            Assert.AreSame(result, _sequenceFull);
        }


        [TestMethod]
        public void IfNotEmpty_WithNull_DoNotCallFunc_ReturnOtherType_Empty()
        {
            var result = _sequenceNull.IfEnumNotEmpty(x => { Assert.Fail(); return _othetTypeSequence; });

            Assert.IsFalse(result.Any());
            Assert.IsTrue(result is IEnumerable<SomeTestClass>);
        }


        [TestMethod]
        public void IfNotEmpty_WithEmpty_DoNotCallFunc_ReturnOtherType_Empty()
        {
            var result = _sequenceEmpty.IfEnumNotEmpty(x => { Assert.Fail(); return _othetTypeSequence; });

            Assert.IsFalse(result.Any());
            Assert.IsTrue(result is IEnumerable<SomeTestClass>);
        }


        [TestMethod]
        public void IfNotEmpty_WithFull_DoNotCallFunc_ReturnOtherType_Empty()
        {
            var result = _sequenceFull.IfEnumNotEmpty(x => _othetTypeSequence);

            Assert.IsTrue(result.Any());
            Assert.IsTrue(result is IEnumerable<SomeTestClass>);
        }


        private readonly IEnumerable<string> _sequenceNull = null;
        private readonly IEnumerable<string> _sequenceEmpty = new string[] { };
        private readonly IEnumerable<string> _sequenceFull = new string[] { "a", "b" };

        private readonly IEnumerable<SomeTestClass> _othetTypeSequence = new[] { new SomeTestClass() };
    }


    [TestClass]
    public class EnumerableIfEmptyTests
    {
        [TestMethod]
        public void IfEmpty_WithNull_CallAction_ReturnEmpty()
        {
            var target = new SomeTestClass();

            IEnumerable<string> result = _sequenceNull.IfEnumEmpty(() => target.MethodReturnVoid());

            Assert.IsFalse(result.Any());
            Assert.IsTrue(target.SomeMethodCalled);
        }


        [TestMethod]
        public void IfEmpty_WithEmpty_CallAction_ReturnEmpty()
        {
            var target = new SomeTestClass();

            IEnumerable<string> result = _sequenceEmpty.IfEnumEmpty(() => target.MethodReturnVoid());

            Assert.IsFalse(result.Any());
            Assert.IsTrue(target.SomeMethodCalled);
        }


        [TestMethod]
        public void IfEmpty_WithFull_DoNotCallAction_ReturnEmpty()
        {
            var target = new SomeTestClass();

            var result = _sequenceFull.IfEnumEmpty(() => { Assert.Fail(); target.MethodReturnVoid(); });

            Assert.AreSame(result, _sequenceFull);
        }


        [TestMethod]
        public void IfEmpty_WithNull_CallFunc_ReturnOtherType_Full()
        {
            IEnumerable<SomeTestClass> result = _sequenceNull.IfEnumEmpty(() => _othetTypeSequence);

            Assert.IsTrue(result.Any());
        }


        [TestMethod]
        public void IfEmpty_WithEmpty_CallFunc_ReturnOtherType_Full()
        {
            IEnumerable<SomeTestClass> result = _sequenceEmpty.IfEnumEmpty(() => _othetTypeSequence);

            Assert.IsTrue(result.Any());
        }


        [TestMethod]
        public void IfEmpty_WithEmpty_CallFunc_ReturnType_Null()
        {
            IEnumerable<SomeTestClass> result = _sequenceEmpty.IfEnumEmpty(() => default(SomeTestClass[]));

            Assert.IsFalse(result.Any());
        }


        [TestMethod]
        public void IfEmpty_WithEmpty_CallFunc_ReturnOtherType_Null()
        {
            IEnumerable<SomeOtherTestClass> result = _sequenceEmpty.IfEnumEmpty(() => default(SomeOtherTestClass[]));

            Assert.IsFalse(result.Any());
        }


        [TestMethod]
        public void IfEmpty_WithFull_DoNotCallFunc_ReturnOtherType_Empty()
        {
            IEnumerable<SomeTestClass> result = _sequenceFull.IfEnumEmpty(() => { Assert.Fail(); return _othetTypeSequence; });

            Assert.IsFalse(result.Any());
        }


        private readonly IEnumerable<string> _sequenceNull = null;
        private readonly IEnumerable<string> _sequenceEmpty = new string[] { };
        private readonly IEnumerable<string> _sequenceFull = new string[] { "a", "b" };

        private readonly IEnumerable<SomeTestClass> _othetTypeSequence = new[] { new SomeTestClass() };
    }


    [TestClass]
    public class EnumerableForEachTests
    {
        [TestMethod]
        public void ForEach_WithNull_DoNotCallAction_ReturnEmpty()
        {
            var result = _sequenceNull.ForEachItem(x => Assert.Fail());

            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void ForEach_WithEmpty_DoNotCallAction_ReturnSame()
        {
            var result = _sequenceEmpty.ForEachItem(x => Assert.Fail());

            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void ForEach_WithFull_CallAction_ReturnSame()
        {
            var iCallTimes = 0;

            var result = _sequenceFull.ForEachItem(x => ++iCallTimes);

            Assert.IsTrue(iCallTimes > 0);
            Assert.IsTrue(iCallTimes == _sequenceFull.Count());
            Assert.AreSame(result, _sequenceFull);
        }

        private readonly IEnumerable<string> _sequenceNull = null;
        private readonly IEnumerable<string> _sequenceEmpty = new string[] { };
        private readonly IEnumerable<string> _sequenceFull = new string[] { "a", "b" };
    }



    [TestClass]
    public class EnumerableDoTests
    {
        [TestMethod]
        public void Do_WithNull_CallActionOnce_ReturnEmpty()
        {
            bool wasMethodCalled = false;
            IEnumerable<string> result = _sequenceNull.Do(x =>
                                           {
                                               wasMethodCalled = true;
                                               return;
                                           });

            Assert.AreSame(_sequenceNull, result);
            Assert.IsTrue(wasMethodCalled);
        }

        [TestMethod]
        public void Do_WithEmpty_CallActionOnce_ReturnEmpty()
        {
            bool wasMethodCalled = false;
            IEnumerable<string> result = _sequenceEmpty.Do(x =>
                                                          {
                                                              wasMethodCalled = true;
                                                              return;
                                                          });

            Assert.AreSame(_sequenceEmpty, result);
            Assert.IsTrue(wasMethodCalled);
        }

        [TestMethod]
        public void Do_WithFull_CallActionOnce_ReturnSame()
        {
            bool wasMethodCalled = false;
            IEnumerable<string> result = _sequenceFull.Do(x =>
                                                           {
                                                               wasMethodCalled = true;
                                                               return;
                                                           });

            Assert.AreSame(_sequenceFull, result);
            Assert.IsTrue(wasMethodCalled);
        }

        [TestMethod]
        public void Do_WithNull_CallFuncTRetOnce_ReturnEmpty()
        {
            bool wasMethodCalled = false;
            bool result = _sequenceNull.Do(x =>
                                           {
                                               wasMethodCalled = true;
                                               return x.IsEnumEmpty();
                                           });

            Assert.IsTrue(result);
            Assert.IsTrue(wasMethodCalled);
        }

        [TestMethod]
        public void Do_WithEmpty_CallFuncTRetOnce_ReturnEmpty()
        {
            bool wasMethodCalled = false;
            bool result = _sequenceEmpty.Do(x =>
                                            {
                                                wasMethodCalled = true;
                                                return x.IsEnumEmpty();
                                            });

            Assert.IsTrue(result);
            Assert.IsTrue(wasMethodCalled);
        }

        [TestMethod]
        public void Do_WithFull_CallFuncTRetOnce_ReturnSame()
        {
            bool wasMethodCalled = false;
            bool result = _sequenceFull.Do(x =>
                                           {
                                               wasMethodCalled = true;
                                               return x.IsEnumEmpty();
                                           });

            Assert.IsFalse(result);
            Assert.IsTrue(wasMethodCalled);
        }

        private readonly IEnumerable<string> _sequenceNull = null;
        private readonly IEnumerable<string> _sequenceEmpty = new string[] { };
        private readonly IEnumerable<string> _sequenceFull = new[] { "a", "b" };
    }
}
