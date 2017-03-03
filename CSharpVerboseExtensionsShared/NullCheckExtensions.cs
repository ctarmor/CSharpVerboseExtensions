﻿using System;

namespace CSharpVerboseExtensionsNetFramework
{
    public static class NullCheckExtensions
    {
        /// <summary>
        /// If Object is null, return true  else  return false
        /// </summary>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        /// <summary>
        /// If Object is NOT null, return true  else  return false
        /// </summary>
        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }



        /// <summary>
        /// If T is null, call Action, always return source
        /// </summary>
        public static T IfNull<T>(this T value, Action action)
        {
            if (IsNull(value))
                action();

            return value;
        }

        /// <summary>        /// If T is null, return Func<TRet>  else  return default(TRet)
        /// </summary>
        public static TRet IfNull<T, TRet>(this T source, Func<TRet> func) where TRet : class
        {
            return IsNull(source) ? func() : source as TRet;
        }


        /// <summary>
        /// If T is Not null, Call Action, always return source
        /// </summary>
        public static T IfNotNull<T>(this T source, Action action)
        {
            if (IsNotNull(source))
                action();

            return source;
        }

        /// <summary>
        /// If T is Not null, Call Action<T>, always return source
        /// </summary>
        public static T IfNotNull<T>(this T source, Action<T> action)
        {
            if (IsNotNull(source))
                action(source);

            return source;
        }


        /// <summary>
        /// If object is Not null, return Func&lt;T, TR&gt;()   else   return default(TR)
        /// </summary>
        public static TR IfNotNull<T, TR>(this T source, Func<T, TR> action)
        {
            return IsNotNull(source) ? action(source) : default(TR);
        }


        /// <summary>
        /// If T is Not null, return Func&lt;TR&gt;   else   return default(TR)
        /// </summary>
        public static TR IfNotNull<T, TR>(this T source, Func<TR> action)
        {
            if (IsNotNull(source))
                return action();

            return default(TR);
        }
    }
}
