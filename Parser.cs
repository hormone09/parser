using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Parser
{
	public abstract class Parser
	{
		public string ReadFilePath;
		public string WriteFilePath;
		public string TableName;

		public Parser(string readPath, string writePath, string tableName)
		{
			//ReadFilePath = readPath ?? Path.GetFullPath(readPath);
			WriteFilePath = Path.GetFullPath(writePath);
			//TableName = tableName;
		}

		public virtual DataTable ReadFile() { throw new Exception(); }

		public virtual void WriteFile(List<string> strings)
		{
			string result = string.Empty;
			foreach (string str in strings)
			{
				result += str + "\n";
			}

			File.WriteAllText(WriteFilePath, result);
		}

		public virtual List<string> Add(DataTable table)
		{
			List<string> strings = new List<string>();
			int ID = 1175;
			foreach (DataRow row in table.Rows)
			{
				string code = row["Code"].ToString();
				string name = row["Name"].ToString();
				string clearCode = code.Replace("/", string.Empty);
				strings.Add($@"INSERT INTO {TableName} (ID, NameRU, NameKZ, PublicCode, BeginDate, ParentID, MkbOCode) VALUES ('{ID}', '{name}', '{name}', '{clearCode}', GETDATE(), NULL, '{code}')");

				ID++;
			}

			return strings;

			/*List<string> strings = new List<string>();
			int ID = 420, publicCode = 42000;

			foreach (DataRow row in table.Rows)
			{
				var name = row["Диагноз"].ToString();
				var code = row["Код"].ToString();
				strings.Add(
					$@"INSERT INTO {TableName} (ID, NameRU, NameKZ, PublicCode, BeginDate, MkbOCode) VALUES ({ID}, '{name}', '{name}', '{publicCode}', GETDATE(), '{code}')");

				ID++; 
				publicCode += 100;
			}

			return strings;*/
		}

		public virtual List<string> Delete(DataTable table)
		{
			List<string> strings = new List<string>();
			foreach (DataRow row in table.Rows)
			{
				var code = row["Code"];
				strings.Add($@"UPDATE {TableName} SET EndDate = GETDATE() WHERE MkbOCode = '{code}'");
			}

			return strings;
		}

		public virtual List<string> Update(DataTable table)
		{
			List<string> strings = new List<string>();
			foreach(DataRow row in table.Rows)
			{
				var code = row["код"];
				var name = row["Новое наименование"];
				strings.Add($@"UPDATE {TableName} SET NameRU = '{name}', NameKZ = '{name}' WHERE MkbOCode = '{code}'");
			}

			return strings;
			/*List<string> strings = new List<string>();
			foreach(DataRow row in table.Rows)
			{
				string paramName1 = "NameRU", paramName2 = "NameKZ";
				var code = row["Код"];
				var name = row["Новое наименование диагноза"];
				strings.Add(
					$@"UPDATE {TableName} SET {paramName1} = '{name}', {paramName2} = '{name}' WHERE MkbOCode = '{code}'");
			}

			return strings;*/


		}
	}
}
