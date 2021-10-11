using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using GeneralKnowledge.Test.App.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Configuration;

namespace GeneralKnowledge.Test.App.Tests
{
	public class Asset
	{
		public Guid Id { get; set; }
		public string MimeType { get; set; }
		public string Country { get; set; }
	}
	public class CsvAssetModel
	{
		public Guid Id { get; set; }
		public string FileName { get; set; }
		public string MimeType { get; set; }
		public string CreatedBy { get; set; }
		public string Email { get; set; }
		public string Country { get; set; }
		public string Description { get; set; }
		public DateTime CreatedOn { get; set; }
	}

	public class CsvAssetModelMap : ClassMap<CsvAssetModel>
	{
		public CsvAssetModelMap()
		{
			Map(m => m.Id).Name("asset id");
			Map(m => m.FileName).Name("file_name");
			Map(m => m.MimeType).Name("mime_type");
			Map(m => m.CreatedBy).Name("created_by");
			Map(m => m.Email).Name("email");
			Map(m => m.Country).Name("country");
			Map(m => m.Description).Name("description");
		}
	}

	/// <summary>
	/// CSV processing test
	/// </summary>
	public class CsvProcessingTest : ITest
	{
		// NOTE: Run EF migration commands, as decided to create table using it and for seeding we can use this console app.
		public void Run()
		{
			var dataTable = CreateCsvDataTable();
			var helper = new SqlHelper(ConfigurationManager.AppSettings["connectionStrings"]);
			//CreateAssetImportTable(helper);
			helper.ExecuteBulkQuery(tableName: "Assets", dataTable);

		}


		public void CreateAssetImportTable(SqlHelper helper)
		{
			var commandTextBuilder = new StringBuilder($"DROP TABLE IF EXISTS Assets;");
			commandTextBuilder.Append(@"CREATE TABLE Assets(
                Id UNIQUEIDENTIFIER  NOT NULL PRIMARY KEY,
				FileName VARCHAR(255) NOT NULL,
				MimeType VARCHAR(255) NOT NULL,
				CreatedBy VARCHAR(255) NOT NULL,
				Email VARCHAR(255) NOT NULL,
                Country VARCHAR(255) NOT NULL,
                Description ntext NOT NULL,
				CreatedOn DATETIME NOT NULL
            )");
			helper.ExecuteNonQuery(commandTextBuilder.ToString());
		}
		public DataTable CreateCsvDataTable()
		{
			DataTable csvDataTable = new DataTable();

			using (TextReader reader = new StreamReader(new MemoryStream(Encoding.ASCII.GetBytes(Resources.AssetImport)), true))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				csv.Context.RegisterClassMap<CsvAssetModelMap>();
				var recordModel = new CsvAssetModel();
				var records = csv.EnumerateRecords(recordModel);

				var columns = records.First().GetType().GetProperties();
				foreach (var column in columns)
				{
					csvDataTable.Columns.Add(new DataColumn(column.Name, column.PropertyType));
				}

				foreach (var record in records)
				{
					DataRow row = csvDataTable.NewRow();
					row["Id"] = record.Id;
					row["FileName"] = record.FileName;
					row["MimeType"] = record.MimeType;
					row["CreatedBy"] = record.CreatedBy;
					row["Email"] = record.Email;
					row["Country"] = record.Country;
					row["Description"] = record.Description;
					row["CreatedOn"] = DateTime.Now;

					csvDataTable.Rows.Add(row);
				}
			}
			return csvDataTable;
		}
	}

}
