using CSharpVerboseExtensionsNetFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpVerboseExtensionsNetFrameworkTests
{
    [TestClass]
    public class NumeircExtensionsTests
    {
        [TestMethod]
        public void ToInit_WithInt_Validation()
        {
            Assert.IsTrue("1".ToInt() == 1);
            Assert.IsTrue("1.6".ToInt() == 2);
            Assert.IsTrue("1.4".ToInt() == 1);
            Assert.IsTrue("-1.2".ToInt() == -1);
            Assert.IsTrue("-0".ToInt() == 0);
            Assert.IsTrue("0".ToInt() == 0);
            Assert.IsTrue("+0".ToInt() == 0);
            Assert.IsTrue("invalid".ToInt() == 0);
        }

        [TestMethod]
        public void ToInit_WithNullable_Validation()
        {
            Assert.IsTrue("1".ToIntNullable() == 1);
            Assert.IsTrue("1.6".ToIntNullable() == 2);
            Assert.IsTrue("1.4".ToIntNullable() == 1);
            Assert.IsTrue("-1.2".ToIntNullable() == -1);
            Assert.IsTrue("-0".ToIntNullable() == 0);
            Assert.IsTrue("0".ToIntNullable() == 0);
            Assert.IsTrue("+0".ToIntNullable() == 0);

            Assert.IsNull("invalid".ToIntNullable());
        }
        
        [TestMethod]
        public void ToDouble_Validation()
        {
            Assert.IsTrue("1".ToDouble() == 1.0);
            Assert.IsTrue("1.6".ToDouble() == 1.6);
            Assert.IsTrue("1.4".ToDouble() == 1.4);
            Assert.IsTrue("-1.7".ToDouble() == -1.7);
            Assert.IsTrue("-0".ToDouble() == 0);
            Assert.IsTrue("0".ToDouble() == 0);
            Assert.IsTrue("+0".ToDouble() == 0);

            Assert.IsNull("invalid".ToDouble());
        }
    }
}
