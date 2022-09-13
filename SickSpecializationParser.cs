using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Parser
{
	public class SickSpecializationParser : Parser
	{
		public SickSpecializationParser(string readPath, string writePath, string tableName) : base(readPath, writePath, tableName) { }

		public List<string> GetStrings(string intervalFrom, string intervalTo, int dispensaryAccountType, string[] hPostCodes)
		{
			var result = new List<string>();

			var serviceBusConnectionObject = new ServiceBusConnection();
			var kmisConnectionObject = new KmisConnection();

			using (var serviceBusConnection = serviceBusConnectionObject.GetConnection())
			{
				serviceBusConnection.Open();
				var commandSicks = serviceBusConnection.CreateCommand();
				commandSicks.CommandText = "SELECT * FROM hSicks WHERE ICDCode BETWEEN @From AND @To";

				var paramFrom = commandSicks.CreateParameter();
				paramFrom.ParameterName = "From";
				paramFrom.Value = intervalFrom;
				paramFrom.SqlDbType = System.Data.SqlDbType.NVarChar;

				var paramTo = commandSicks.CreateParameter();
				paramTo.ParameterName = "To";
				paramTo.Value = intervalTo;
				paramTo.SqlDbType = System.Data.SqlDbType.NVarChar;

				commandSicks.Parameters.Add(paramFrom);
				commandSicks.Parameters.Add(paramTo);
				var reader = commandSicks.ExecuteReader();

				long sickID;
				int hPostMasterDataID;
				string ICDCode, code;

				using (var kmisConnection = kmisConnectionObject.GetConnection())
				{
					kmisConnection.Open();
					var kmisCommand = kmisConnection.CreateCommand();
					kmisCommand.CommandText = "SELECT TOP(1) * FROM hPost WHERE PublicCode = @Code";

					var paramCode = kmisCommand.CreateParameter();
					paramCode.ParameterName = "Code";

					kmisCommand.Parameters.Add(paramCode);


					while (reader.Read())
					{
						sickID = (long)reader.GetValue(0);
						ICDCode = (string)reader.GetValue(12);

						foreach (var hPostCode in hPostCodes)
						{
							if (string.IsNullOrEmpty(hPostCode)) continue;

							paramCode.Value = hPostCode;
							var kmisReader = kmisCommand.ExecuteReader();

							while (kmisReader.Read())
							{
								hPostMasterDataID = (int)kmisReader.GetValue(9);
								code = (string)kmisReader.GetValue(3);

								var insertString = @$"INSERT INTO SickSpecializations (DispensaryAccountType, SickID, Code, EmployeeSpecializationID, BeginDate, EndDate) VALUES ({dispensaryAccountType}, {sickID}, {code}, {hPostMasterDataID}, GETDATE(), NULL)";
								result.Add(insertString);
							}

							kmisReader.Close();
						}
					}
				}
			}

			return result;
		}
	}
}
