using System;

namespace CSharpVerboseExtensionsNetFramework
{
    public static class DoExtensions
    {
        public static T Do<T>(this T target, Action<T> action) where T : class
        {
            action(target);

            return target;
        }

        public static TRet Do<T, TRet>(this T target, Func<T, TRet> action) where T : class
        {
            return action(target);
        }
    }
}
