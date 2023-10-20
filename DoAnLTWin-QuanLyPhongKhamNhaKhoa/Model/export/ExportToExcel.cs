using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model.export
{
    class ExportToExcel
    {
        public void ExportToExcelpost(DataGrid dataGrid)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;

            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;

            for (int i = 1; i <= dataGrid.Columns.Count; i++)
            {
                worksheet.Cells[1, i] = dataGrid.Columns[i - 1].Header;
            }

            for (int i = 0; i < dataGrid.Items.Count; i++)
            {
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(i);
                if (row != null)
                {
                    for (int j = 0; j < dataGrid.Columns.Count; j++)
                    {
                        TextBlock cellContent = dataGrid.Columns[j].GetCellContent(row) as TextBlock;
                        if (cellContent != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = cellContent.Text;
                        }
                    }
                }
            }

            // workbook.SaveAs("C:\\example.xlsx");
            workbook.Close();
            excelApp.Quit();
        }
    }
}