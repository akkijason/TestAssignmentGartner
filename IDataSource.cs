using System;
using System.Threading.Tasks;

public interface IDataSource
{
    string ExtractData(string filePath);
}
