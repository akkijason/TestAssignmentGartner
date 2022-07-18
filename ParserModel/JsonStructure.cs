using System.Collections.Generic;

namespace TestAssignmentGartner.ParserModel
{
    internal class JsonStructure
    {
        public List<Product> Products { get; set; }
    }

    class Product
    {
        public List<string> Categories { get; set; }
        public string Twitter { get; set; }
        public string Title { get; set; }
    }
}
