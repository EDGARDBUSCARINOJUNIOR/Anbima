using Anbima.Domain.Entities;
using Anbima.Infra.Data.Files.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Anbima.Infra.Data.Files.MapFiles
{
    public class MapParametrosEntrada
    {
        public string TypeFile { get; }

        public MapParametrosEntrada()
        {
            TypeFile = "AnbimaParametrosEntrada";
        }

        public List<ParametrosEntrada> CarregarParametrosEntrada()
        {
            var ret = new List<ParametrosEntrada>();
            var rowCount = 0;
            FileMethods file;

            file = new FileMethods(TypeFile);
            try
            {
                if (string.IsNullOrEmpty(file.ExistFile))
                    return ret;

                if (file.ExistFile.Contains("System.IO.IOException"))
                    return ret;               

                var workbook = new XSSFWorkbook(new FileStream(file.ExistFile, FileMode.Open, FileAccess.Read));

                ISheet sheet = workbook.GetSheetAt(0);

                if (sheet != null)
                {
                    var ParametrosEntradaObj = new ParametrosEntrada();
                    var ParametrosEntradalist = new List<ParametrosEntrada>();

                    rowCount = sheet.LastRowNum;

                    for (int i = 1; i <= rowCount; i++)
                    {
                        if (i > 0)
                        {
                            IRow curRow = sheet.GetRow(i);

                            #region Assigner values

                            ParametrosEntradaObj.CodigoFundo = curRow.GetCell(0).NumericCellValue.ToString();
                            ParametrosEntradaObj.DataInicio = curRow.GetCell(1).DateCellValue.Date;
                            ParametrosEntradaObj.DataFim = curRow.GetCell(2).DateCellValue.Date;

                            ParametrosEntradalist.Add(ParametrosEntradaObj);
                            ParametrosEntradaObj = new ParametrosEntrada();

                            #endregion
                        }
                    }
                    return ParametrosEntradalist;
                }              
            }
            catch (Exception)
            {
                //gravar erro
            }           
            return ret;
        }
    }
}
