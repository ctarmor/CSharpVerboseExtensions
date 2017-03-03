using System;

namespace CSharpVerboseExtensionsNetFramework
{
    public static class BooleanExtensions
    {
        public static bool IfTrue(this bool expression, Action action)
        {
            if (expression) action();

            return expression;
        }

        public static bool IfTrue(this bool expression, Action<bool> action)
        {
            if (expression) action(expression);

            return expression;
        }

        public static T IfTrue<T>(this bool expression, Func<bool, T> action)
        {
            if (expression)
                return action(expression);

            return default(T);
        }

        public static bool IfFalse(this bool expression, Action action)
        {
            if (!expression) action();

            return expression;
        }

        public static bool IfFalse(this bool expression, Action<bool> action)
        {
            if (!expression) action(expression);

            return expression;
        }

        public static T IfFalse<T>(this bool expression, Func<bool, T> action)
        {
            if (!expression) 
                return action(expression);

            return default(T);
        }

    }
}
