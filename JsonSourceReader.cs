using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using TestAssignmentGartner.ParserModel;

public class JsonSourceReader : IDataSource
{
    public string ExtractData(string filePath)
    {
       if(filePath == null)
       {
            throw new ArgumentNullException(nameof(filePath));
       }

        //var fileName = @"C:\Users\AkkiJason\Desktop\software engineer\coding\feed-products\softwareadvice.json";

        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        var memoryStream = new MemoryStream();

        // Use the .CopyTo() method and write current filestream to memory stream
        fileStream.CopyTo(memoryStream);

        // Convert Stream To Array
        byte[] byteArray = memoryStream.ToArray();

        //var stringData = Convert.ToBase64String(byteArray);
        var stringData = Encoding.UTF8.GetString(byteArray);

        // getting the deserialized data from byte array
        var finalData = new JsonStructure();
        finalData = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonStructure>(stringData);

        // creating the result to be returned
        var stringResult = new StringBuilder();
        if(finalData.Products.Count > 0)
        {
            foreach(var product in finalData.Products)
            {
                var categoriesString = string.Join(',', product?.Categories);
                if(product?.Twitter != null)
                {
                    stringResult.
                        Append($"importing: Name: \"{product?.Title}\"; Categories: {categoriesString}; Twitter: {product?.Twitter}\n");
                }
                else
                {
                    stringResult.
                        Append($"importing: Name: {product?.Title}; Categories: {categoriesString}\n");
                }
            }
        }

        return stringResult.ToString();
    }
}