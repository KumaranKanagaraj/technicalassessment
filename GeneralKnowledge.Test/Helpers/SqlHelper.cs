using System.Data;
using System.Data.SqlClient;

namespace GeneralKnowledge.Test.App.Helpers
{
	public class SqlHelper
	{
		// TODO: Read from config
		private readonly string CONNECTION_STRING;

		public SqlHelper(string connectionString)
		{
			CONNECTION_STRING = connectionString;
		}
		public void ExecuteNonQuery(string command)
		{
			using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
			{
				connection.Open();

				using (SqlCommand cmd = new SqlCommand(command, connection))
				{
					cmd.ExecuteNonQuery();
				}

			}

		}

		public void ExecuteBulkQuery(string tableName, DataTable dataTable)
		{
			using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
			{
				connection.Open();

				using (SqlBulkCopy s = new SqlBulkCopy(connection))
				{
					s.DestinationTableName = tableName;

					foreach (var column in dataTable.Columns)
						s.ColumnMappings.Add(column.ToString(), column.ToString());

					s.WriteToServer(dataTable);
				}

			}

		}

	}
}
