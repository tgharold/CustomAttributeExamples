using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Xunit;

namespace StringConstantsExample
{
    public class StringConstants1Tests
    {
        [Fact]
        public void Name_returns_correct_description()
        {
            var result = AttributeHelper.GetConstFieldAttributeValue<
                StringConstants1,
                string,
                DescriptionAttribute
                >(
                nameof(StringConstants1.Name),
                y => y.Description
                );
            Assert.Equal("Fanciful Foobar", result);
        }
        
        [Fact]
        public void Charlie_returns_correct_description()
        {
            var result = AttributeHelper.GetConstFieldAttributeValue<
                StringConstants1,
                string,
                DescriptionAttribute
            >(
                nameof(StringConstants1.Charlie),
                y => y.Description
            );
            Assert.Equal("Charlie Charles", result);
        }

        [Fact]
        public void Get_both_descriptions_back()
        {
            var fields = typeof(StringConstants1)
                    .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                    .ToList();

            var stringFields = fields.Where(x => x.FieldType == typeof(string)).ToList();

            var literalStringFields = stringFields.Where(x => x.IsLiteral).ToList();
            
            Assert.Equal(2, literalStringFields.Count);
        }

        [Fact]
        public void Build_list_of_field_attributes()
        {
            var fields = typeof(StringConstants1)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.FieldType == typeof(string))
                .Where(x => x.IsLiteral)
                .ToList();

            var results = fields.Select(x => new
                {
                    Name = x.Name,
                    Description = AttributeHelper.GetConstFieldAttributeValue<
                        StringConstants1,
                        string,
                        DescriptionAttribute
                        >(
                        x.Name,
                        y => y.Description
                        )
                })
                .ToList();
            
            Assert.Equal(2, results.Count);
            Assert.Contains("Charlie Charles", results.Select(x => x.Description));
        }
    }
}
