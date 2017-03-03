using System;
using System.Linq;
using CSharpBasicExtensionsKitSharedProject;

namespace CSharpVerboseExtensionsNetFramework
{
    public static class StringExtensions
    {
        /// <summary>
        /// IsEmpty - is null or empty
        /// </summary>
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// IsNotEmpty - is not null and is not empty
        /// </summary>
        public static bool IsNotEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Call Action() if string is empty
        /// </summary>
        /// <returns>Always return the same string</returns>
        public static string IfEmpty(this string value, Action action)
        {
            if (IsEmpty(value))
                action();

            return value;
        }

        /// <summary>
        /// Call Func<string>() if string is empty
        /// </summary>
        /// <returns>If empty: return result from Func<string></returns>
        /// <returns>If not empty: return same</returns>
        public static string IfEmpty(this string value, Func<string> action)
        {
            return IsEmpty(value) ? action() : value;
        }


        /// <summary>
        /// Call Action() if string is Not empty
        /// </summary>
        /// <returns>Always return the same string</returns>
        public static string IfNotEmpty(this string value, Action action)
        {
            if (IsNotEmpty(value))
                action();

            return value;
        }

        /// <summary>
        /// Call Action<string>() if string is Not empty
        /// </summary>
        /// <returns>Always return same string</returns>
        public static string IfNotEmpty(this string value, Action<string> action)
        {
            if (IsNotEmpty(value))
                action(value);

            return value;
        }

        /// <summary>
        /// Call Func<string, string>() if string is Not empty
        /// </summary>
        /// <returns>If Not empty: return result from Func<string, string></returns>
        /// <returns>If empty: return same</returns>
        public static string IfNotEmpty(this string value, Func<string, string> action)
        {
            return IsNotEmpty(value) ? action(value) : value;
        }

        /// <summary>
        /// Call Func<string, TRet>() if string is Not empty
        /// </summary>
        /// <returns>If Not empty: return result from Func<string, TRet></returns>
        /// <returns>If empty: return same</returns>
        public static TRet IfNotEmpty<TRet>(this string value, Func<string, TRet> action)
        {
            return IsNotEmpty(value) ? action(value) : default(TRet);
        }

        /// <summary>
        /// Call Null safe
        /// </summary>
        public static string Call(this Func<string> action)
        {
            return action.IsNull() ? string.Empty : action();
        }

        /// <summary>
        /// IfNullEmptyStr
        /// </summary>
        public static string IfNullEmptyStr(this string source)
        {
            return IsEmpty(source) ? string.Empty : source;
        }
    }



    public static class StringEqualityExtensions
    {
        /// <summary>
        /// Are strings the same ? - CurrentCultureIgnoreCase
        /// </summary>
        public static bool IsEqualTo(this string str, string value)
        {
            if (str.IsNull() && value.IsNull()) return true;
            if (str.IsNull() || value.IsNull()) return false;

            return str.Equals(value, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Are strings different ? - CurrentCultureIgnoreCase
        /// </summary>
        public static bool IsNotEqualTo(this string str, string value)
        {
            if (str.IsNull() && value.IsNull()) return false;
            if (str.IsNull() || value.IsNull()) return true;

            return !str.Equals(value, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Execute action if strings are NOT equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="action"></param>
        /// <returns>Always return left string</returns>
        public static string IfNotEqualTo(this string left, string right, Action<string, string> action)
        {
            if (IsNotEqualTo(left, right))
                action(left, right);

            return left;
        }

        /// <summary>
        /// Execute action if strings are NOT equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="func"></param>
        /// <returns>Return default(TRet) if strings not equal, else Func<TRet>()</returns>
        public static TRet IfNotEqualTo<TRet>(this string left, string right, Func<string, string, TRet> func)
        {
            if (IsNotEqualTo(left, right))
                return func(left, right);

            return default(TRet);
        }

        /// <summary>
        /// Execute action if strings are equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="action"></param>
        /// <returns>Always return left string</returns>
        public static string IfEqualTo(this string left, string right, Action<string, string> action)
        {
            if (IsEqualTo(left, right))
                action(left, right);

            return left;
        }

        /// <summary>
        /// Execute Func if strings are equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="func"></param>
        /// <returns>Return default(TRet) if strings equal, else Func<TRet>()</returns>
        public static TRet IfEqualTo<TRet>(this string left, string right, Func<string, string, TRet> func)
        {
            if (IsEqualTo(left, right))
                return func(left, right);

            return default(TRet);
        }

        public static int IndexOfString(this string left, params string[] choices)
        {
            if (StringExtensions.IsEmpty(left)) return -1;
            var idx = -1;
            return choices.Any(choice => 0 <= (idx = left.IndexOf(choice, StringComparison.OrdinalIgnoreCase))) ? idx : idx;
        }

        public static bool StartsWithString(this string left, string right)
        {
            if (StringExtensions.IsEmpty(left) || StringExtensions.IsEmpty(left)) return false;

            return left.StartsWith(right, StringComparison.OrdinalIgnoreCase);
        }

        public static bool ContainsString(this string left, params string [] choices)
        {
            return IndexOfString(left, choices) >= 0;
        }
    }
}
