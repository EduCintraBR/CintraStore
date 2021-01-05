using CintraStore.Shared;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CintraStore.Infra.StoreContext.DataContexts
{
    public class CintraDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public CintraDataContext()
        {
            this.Connection = new SqlConnection(Settings.ConnectionString);

        }

        public int MyProperty { get; set; }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
