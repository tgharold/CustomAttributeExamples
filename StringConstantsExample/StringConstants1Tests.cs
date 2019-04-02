using System;
using System.ComponentModel;
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
    }
}
