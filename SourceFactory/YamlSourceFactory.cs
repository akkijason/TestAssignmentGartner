using System;
using System.Collections.Generic;
using System.Text;

namespace TestAssignmentGartner.SourceFactory
{
    internal class YamlSourceFactory : DataSourceFactory
    {
        protected override IDataSource MakeSource()
        {
            IDataSource source = new YamlSourceReader();
            return source;
        }
    }
}
