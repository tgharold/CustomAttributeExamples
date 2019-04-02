using System;
using System.Linq;
using System.Reflection;

namespace StringConstantsExample
{
    // https://stackoverflow.com/questions/33485932/extract-description-attribute-from-const-fields
    
    public static class AttributeHelper
    {
        public static TOut GetConstFieldAttributeValue<T, TOut, TAttribute>(
            string fieldName,
            Func<TAttribute, TOut> valueSelector)
            where TAttribute : Attribute
        {
            var fieldInfo = typeof(T).GetField(fieldName, BindingFlags.Public | BindingFlags.Static);
            if (fieldInfo == null)
            {
                return default(TOut);
            }
            var att = fieldInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            return att != null ? valueSelector(att) : default(TOut);
        }
    }
}