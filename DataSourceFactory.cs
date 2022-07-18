using System;

public abstract class DataSourceFactory
{
    protected abstract IDataSource MakeSource();
    public IDataSource CreateSource() 
    {
        return this.MakeSource();
    }

}