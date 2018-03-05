using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace SqlLinq
{
    static class TypeHelpers
    {
        public static bool HasEmptyConstructor(this Type type)
        {
            return type.GetConstructor(Type.EmptyTypes) != null;
        }

        public static MemberInfo GetPropertyOrField(this Type type, string propertyOrField)
        {
            MemberInfo member = type.GetProperty(propertyOrField, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (member == null)
                member = type.GetField(propertyOrField, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            Debug.Assert(member != null);
            return member;
        }

        public static Type[] GetPropertyOrFieldTypes(this Type type, IEnumerable<string> fields)
        {
            return fields.Select(field => type.GetPropertyOrFieldType(field)).ToArray();
        }

        public static Type GetPropertyOrFieldType(this Type type, string field)
        {
            PropertyInfo p = type.GetProperty(field, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (p != null)
                return p.PropertyType;

            FieldInfo f = type.GetField(field, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            Debug.Assert(f != null);
            return f.FieldType;
        }
    }
}
