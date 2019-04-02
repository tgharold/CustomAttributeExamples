using System.ComponentModel;

namespace StringConstantsExample
{
    public class StringConstants1
    {
        [Description("Fanciful Foobar")]
        public const string Name = "Foo";
        
        [Description("Charlie Charles")]
        public const string Charlie = "Charles";

        private const string SomethingElse = "Nada";

        public const int Noddy = 5;
        
        public string Foo { get; set; }
    }
}