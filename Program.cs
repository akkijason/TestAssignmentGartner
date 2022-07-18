using System;
using System.IO;
using TestAssignmentGartner.SourceFactory;

namespace TestAssignmentGartner
{
    class Program
    {
        Enum[] enums;
        static void Main(string[] args)
        {
            var options = new string[2];
            string filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            string result = string.Empty;
            IDataSource dataSource;
            try
            {
                Console.WriteLine("Please enter input 1 for capterra and 2 for software");

                var input = Console.ReadLine();
                if(input != null)
                {
                    var inputNum = Convert.ToInt32(input);

                    switch (inputNum)
                    {
                        case 1:
                            filePath += @"\feed-products\capterra.yaml";
                            dataSource = new YamlSourceFactory().CreateSource();
                            result = dataSource.ExtractData(filePath);
                        break;
                        case 2:
                            filePath += @"\feed-products\softwareadvice.json";
                            dataSource = new JsonSourceFactory().CreateSource();
                            result = dataSource.ExtractData(filePath);
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            Console.WriteLine(result);
        }
    }
}
