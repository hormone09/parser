using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Parser
{
	public abstract class Connection
	{
		protected string ConnectionString;
		protected SqlConnection DbConnection;

		public SqlConnection GetConnection()
		{
			if (DbConnection == null)
			{
				DbConnection = new SqlConnection(ConnectionString);
			}

			return DbConnection;
		}
	}

	public class KmisConnection : Connection
	{
		public KmisConnection()
		{
			ConnectionString = "Data Source=192.168.70.131;Initial Catalog=Kmis_dev;Persist Security Info=True;User ID=sa;Password=Qwerty123";
		}
	}
	public class ServiceBusConnection : Connection
	{
		public ServiceBusConnection()
		{
			ConnectionString = "Data Source=192.168.70.131;Initial Catalog=ServiceBus_dev;Persist Security Info=True;User ID=sa;Password=Qwerty123";
		}
	}
}
