using System;
using System.Collections.Generic;
using System.Text;

namespace TestAssignmentGartner.SourceFactory
{
    internal class JsonSourceFactory : DataSourceFactory
    {
        protected override IDataSource MakeSource()
        {
            IDataSource source = new JsonSourceReader();
            return source;
        }
    }
}
