using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TestAssignmentGartner.ParserModel;
using YamlDotNet.Serialization.NamingConventions;

namespace TestAssignmentGartner
{
    public class YamlSourceReader : IDataSource
    {
        public string ExtractData(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            //var fileName = @"C:\Users\AkkiJason\Desktop\software engineer\coding\feed-products\capterra.yaml";

            var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
                                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                                .Build();
            var yamlData = deserializer.Deserialize<List<YamlStructure>>(File.ReadAllText(filePath));

            var stringResult = new StringBuilder();
            if(yamlData?.Count > 0)
            {
                foreach (var product in yamlData)
                {
                    var res = $"importing: Name: \"{product.Name}\"; Categories: {product.Tags}; Twitter: @{product.Twitter}\n";
                    stringResult.Append(res);
                }
            }

            return stringResult.ToString();
        }
    }
}
