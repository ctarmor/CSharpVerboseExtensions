using System;
using System.Collections.Generic;
using System.Linq;
using CSharpBasicExtensionsKitSharedProject;
using CSharpBasicExtensionsKitTests.Supporting;
using CSharpVerboseExtensionsNetFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpVerboseExtensionsNetFrameworkTests
{
    [TestClass]
    public class _Samples
    {
        [TestMethod]
        public void WorkingSamples()
        {
            var notNullType = new SomeTestClass();
            var nullType = default(SomeTestClass);

            var action1 = new Action(() => { });
            var action2 = new Action(() => { });

            //
            // I think the null comparison everywhere is a bit of noise.  
            // Below find some samples for null comparison that compresses the code a few lines.
            //

            // ---------------------------------------------
            // Basic null comparision
            // ---------------------------------------------
            if (nullType == null) action1();

            // Less noisy (I think)
            if (nullType.IsNull()) action1();
            if (nullType.IsNotNull()) action2();



            // ---------------------------------------------
            // Else samples
            // ---------------------------------------------
            if (nullType == null)
                action1();
            else
                action2();

            // Replace with
            nullType
                .IfNull(action1)
                .IfNotNull(action2);



            // ---------------------------------------------
            // Avoid null intances
            // ---------------------------------------------
            var someNullType = default(SomeTestClass);
            
            if (someNullType == null)
                someNullType = new SomeTestClass();
            someNullType.MethodReturnVoid();


            // Replace with
            notNullType
                .IfNull(() => new SomeTestClass())
                .MethodReturnVoid();



            // ---------------------------------------------
            // Retrning the same type
            // ---------------------------------------------
            someNullType = default(SomeTestClass);

            if (someNullType == null)
                someNullType = new SomeTestClass();
            someNullType.MethodReturnVoid();
            var otherType = new SomeOtherTestClass();
            otherType.OtherMethodReturnVoid();


            // Replace with
            notNullType
                .IfNull(() => new SomeTestClass())
                .Do(x => x.MethodReturnVoid())
                .Do(x => new SomeOtherTestClass()) 
                .OtherMethodReturnVoid();




            // ---------------------------------------------
            // IEnumerable Samples
            // ---------------------------------------------
            IEnumerable<SomeTestClass> sequenceFull = new SomeTestClass[] { new SomeTestClass(), new SomeTestClass(), };
            IEnumerable<SomeOtherTestClass> otherSequenceFull = new SomeOtherTestClass[] { new SomeOtherTestClass(), new SomeOtherTestClass(), };

            sequenceFull
                .ForEachItem(x => x.MethodReturnVoid())
                .Select(element => new { AnonymousBool = element.SomeMethodCalled })
                .Where(element => !element.AnonymousBool)
                .Do(enumerable => Console.WriteLine("Items in Collection: {0}", enumerable.Count()))
                .IfEnumEmpty(() => sequenceFull)
                .ForEachItem(element => element.MethodReturnVoid())
                .Do(enumerable => Console.WriteLine("Items in Collection: {0}", enumerable.Count()))
                ;





            // ---------------------------------------------
            // String Samples
            // ---------------------------------------------
            var nullStr = default(string);
            var strAction1 = new Action<string>(x => { });
            var strAction2 = new Action<string>(x => { });

            if (nullStr == null)
                action1();
            else
                action2();

            // simple 
            if (nullStr.IsEmpty())
                action1();
            else
                action2();

            // Replace (no much diffrencr but easier on the eyes)
            nullStr
                .IfEmpty(action1)
                .IfNotEmpty(strAction2);

            // Replace with assurance there will be a string
            nullStr
                .IfEmpty(() => "new string")
                .Do(x => strAction1(x));




            // ---------------------------------------------
            // String Samples - Compare strings
            // ---------------------------------------------
            var strOne = "strOne";
            var strone = "strone";
            //var strTwo = "strOne";

            // Strings are different
            if (strone.Equals(strOne))
                Assert.Fail();

            // Replace with Case insenitive extension
            if (strone.IsNotEqualTo(strOne))
                Assert.Fail();

            // More Compressed
            //strone.IfNotEqual(strOne, (X500DistinguishedName, y) => { });

        }
    }
}
