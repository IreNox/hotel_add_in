using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;

namespace HotelAddInApp
{
    public class DisplayTextAttribute : Attribute
    {
        private string _textPlural;
        private string _textSingular;

        public DisplayTextAttribute(string singular, string plural)
        {
            _textPlural = plural;
            _textSingular = singular;
        }

        public string TextPlural
        {
            get { return _textPlural; }
        }

        public string TextSingular
        {
            get { return _textSingular; }
        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class FieldDisplayNameAttribute : DisplayNameAttribute
    {
        public FieldDisplayNameAttribute(string text)
            : base(text)
        {
        }
    }

    #region Extensions
    public static class Extensions
    {
        #region Linq
        public static IEnumerable<T> Add<T>(this IEnumerable<T> source, T value)
        {
            if (source != null)
            {
                foreach (T item in source)
                {
                    yield return item;
                }
            }

            yield return value;
        }

        public static IEnumerable<T> AddRange<T>(this IEnumerable<T> source, IEnumerable<T> values)
        {
            foreach (T item in source)
            {
                yield return item;
            }

            foreach (T item in values)
            {
                yield return item;
            }
        }

        public static IEnumerable<T> Remove<T>(this IEnumerable<T> source, T value)
        {
            foreach (T item in source)
            {
                if (!item.Equals(value)) yield return item;
            }
        }

        public static void While<T>(this IEnumerable<T> source, Action<T> func)
        {
            foreach (T value in source)
            {
                func(value);
            }
        }
        #endregion

        #region Reflection
        public static string GetDisplayText(this Enum enumType, string memberName)
        {
            BindingFlags bindingFlags = BindingFlags.Static | BindingFlags.GetField
                       | BindingFlags.Public;


            return enumType.GetType().GetField(memberName, bindingFlags).GetDisplayText();
        }

        public static string GetDisplayText(this MemberInfo source, int count)
        {
            DisplayTextAttribute att = source.GetCustomAttributes(false).OfType<DisplayTextAttribute>().FirstOrDefault();

            if (att != null)
            {
                return (count == 1 ? att.TextSingular : att.TextPlural);
            }

            return source.Name;
        }

        public static string GetDisplayText(this MemberInfo source)
        {
            DisplayNameAttribute att = source.GetCustomAttributes(false).OfType<DisplayNameAttribute>().FirstOrDefault();

            if (att != null)
            {
                return att.DisplayName;
            }

            return source.Name;
        }

        public static bool IsBrowsable(this MemberInfo source)
        {
            BrowsableAttribute att = source.GetCustomAttributes(false).OfType<BrowsableAttribute>().FirstOrDefault();

            if (att != null)
            {
                return att.Browsable;
            }

            return true;
        }
        #endregion
    }
    #endregion
}
