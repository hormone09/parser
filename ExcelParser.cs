using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Parser
{
	public class ExcelParser : Parser
	{
		public ExcelParser(string readPath, string writePath, string tableName) : base(readPath, writePath, tableName) { }

		public override DataTable ReadFile()
		{
			using (SpreadsheetDocument doc = SpreadsheetDocument.Open(ReadFilePath, false))
			{
				Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
				Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
				IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();

				DataTable dt = new DataTable();

				foreach (Row row in rows)
				{
					if (row.RowIndex.Value == 1)
					{
						foreach (Cell cell in row.Descendants<Cell>())
						{
							dt.Columns.Add(GetValue(doc, cell));
						}
					}
					else
					{
						dt.Rows.Add();
						int i = 0;
						foreach (Cell cell in row.Descendants<Cell>())
						{
							dt.Rows[dt.Rows.Count - 1][i] = GetValue(doc, cell);
							i++;
						}
					}
				}

				return dt;
			}
		}

		private string GetValue(SpreadsheetDocument doc, Cell cell)
		{
			string value = cell.CellValue.InnerText;
			if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
			{
				return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
			}
			return value;
		}
	}
}
