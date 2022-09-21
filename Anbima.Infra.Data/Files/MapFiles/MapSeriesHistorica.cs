using Anbima.Domain.Entities;
using Anbima.Infra.Data.Files.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Anbima.Infra.Data.Files.MapFiles
{
    public class MapSeriesHistorica
    {
        public string TypeFile { get; }
        public MapSeriesHistorica()
        {
            TypeFile = "AnbimaSeriesHistorica";
        } 

        public void GerarArquivo(List<Resgate> lista, string CodigoFundo)
        {
            if (lista == null)
                return;

            var cont = 0;
            var AddressPath = ConfigurationsPath.appSettingsValue(TypeFile);

            IWorkbook workbook = new XSSFWorkbook(); //create .xlsx file
            
            ISheet sheet = workbook.CreateSheet(CodigoFundo);
            
            IRow HeaderRow = sheet.CreateRow(0);

            CreateCell(HeaderRow, 0, "CodigoFundo");
            CreateCell(HeaderRow, 1, "Nome");
            CreateCell(HeaderRow, 2, "Sobrenome");

            foreach (var item in lista)
            {
                cont++;
                IRow row = sheet.CreateRow(cont);

                CreateCell(row, 0, CodigoFundo);
                CreateCell(row, 1, item.Nome.ToString());
                CreateCell(row, 2, item.Sobrenome.ToString());               
            }             

            //saving excel file
            using (FileStream stream = new FileStream($"{AddressPath}\\{CodigoFundo}{DateTime.Now.ToString("ddMMyyyy_HHmmssffff")}.xlsx", FileMode.Create, FileAccess.Write))
            {
                workbook.Write(stream);
            }
        }
       
        public static void CreateCell(IRow CurrentRow, int CellIndex, string Value)
        {
            ICell cell = CurrentRow.CreateCell(CellIndex);
            cell.SetCellValue(Value);          
        }
    }
}

