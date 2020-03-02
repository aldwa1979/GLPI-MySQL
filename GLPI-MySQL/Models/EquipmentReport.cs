using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace GLPI_MySQL.Models
{
    public class EquipmentReport
    {
        public IEnumerable<EquipmentRow> EquipmentRow { get; set; }

        public byte[] Export ()
        {
            using (var excelPackage = new ExcelPackage())
            {
                var sheet = excelPackage.Workbook.Worksheets.Add("ListaSprzetu");
                sheet = CreateHeader(sheet);
                sheet = CreateContent(sheet, EquipmentRow);
                return excelPackage.GetAsByteArray();
            }
        }

        private ExcelWorksheet CreateHeader(ExcelWorksheet sheet)
        {
            sheet.Cells["A1"].Value = "Nazwisko";
            sheet.Cells["B1"].Value = "Imie";
            sheet.Cells["C1"].Value = "Typ";
            sheet.Cells["D1"].Value = "Producent";
            sheet.Cells["E1"].Value = "Kod";
            sheet.Cells["F1"].Value = "Model";
            sheet.Cells["G1"].Value = "Numer seryjny";
            return sheet;
        }

        private ExcelWorksheet CreateContent(ExcelWorksheet sheet, IEnumerable<EquipmentRow> equipmentRow)
        {
            var currentRow = 2;

            foreach (var row in equipmentRow)
            {
                sheet.Cells[$"A{currentRow}"].Value = row.Computer.Realname;
                sheet.Cells[$"B{currentRow}"].Value = row.Computer.Firstname;
                sheet.Cells[$"C{currentRow}"].Value = row.Computer.Type;
                sheet.Cells[$"D{currentRow}"].Value = row.Computer.Producer;
                sheet.Cells[$"E{currentRow}"].Value = row.Computer.Code;
                sheet.Cells[$"F{currentRow}"].Value = row.Computer.Model;
                sheet.Cells[$"G{currentRow}"].Value = row.Computer.Serial;

                currentRow++;
            }
            return sheet;
        }
    }
}
