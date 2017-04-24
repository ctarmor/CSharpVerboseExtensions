using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasicExtensionsKitTests.Supporting
{
    internal class SomeTestClass
    {
        public bool SomeMethodCalled = false;

        public void MethodReturnVoid()
        {
            SomeMethodCalled = true;
        }
    }

    internal class SomeOtherTestClass
    {
        public bool SomeMethodCalled = false;

        public void OtherMethodReturnVoid()
        {
            SomeMethodCalled = true;
        }
    }
}