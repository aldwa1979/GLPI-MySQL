using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace GLPI_MySQL.Models
{
    public class PhoneReport
    {
        public IEnumerable<PhoneRow> PhoneNumberRows { get; set; }

        public byte[] Export()
        {
            using (var excelPackage = new ExcelPackage())
            {
                var sheet = excelPackage.Workbook.Worksheets.Add("Raport");
                sheet = CreateHeader(sheet);
                sheet = CreateContent(sheet, PhoneNumberRows);
                return excelPackage.GetAsByteArray();
            }
        }

        private static ExcelWorksheet CreateHeader(ExcelWorksheet sheet)
        {
            sheet.Cells["A1"].Value = "Nazwisko";
            sheet.Cells["B1"].Value = "Imie";
            sheet.Cells["C1"].Value = "Stanowisko";
            sheet.Cells["D1"].Value = "Dział";
            sheet.Cells["E1"].Value = "Zespół";
            sheet.Cells["F1"].Value = "Numer telefonu";
            return sheet;
        }

        private static ExcelWorksheet CreateContent(ExcelWorksheet sheet, IEnumerable<PhoneRow> phoneRows)
        {
            var currentRow = 2;

            foreach (var row in phoneRows)
            {
                sheet.Cells[$"A{currentRow}"].Value = row.PhoneNumber.Realname;
                sheet.Cells[$"B{currentRow}"].Value = row.PhoneNumber.Firstname;
                sheet.Cells[$"C{currentRow}"].Value = row.PhoneNumber.Position;
                sheet.Cells[$"D{currentRow}"].Value = row.PhoneNumber.Department;
                sheet.Cells[$"E{currentRow}"].Value = row.PhoneNumber.Team;
                sheet.Cells[$"F{currentRow}"].Value = row.PhoneNumber.ContactNumber;
                currentRow++;
            }

            return sheet;
        }
    }
}
