namespace Anbima.Infra.Data.Files.Util
{
    public class FileMethods
    {
        private string TypeFile;
        public string ExistFile;
        public string? AddressPath;

        public FileMethods(string typeFile)
        {
            TypeFile = typeFile;
            ExistFile = LocationFile();           
        }
        public string LocationFile()
        {
            try
            {
                #region Valid localized file

                 AddressPath = ConfigurationsPath.appSettingsValue(TypeFile);   

                DirectoryInfo diretorio = new DirectoryInfo(AddressPath);
                FileInfo[] Arquivos = diretorio.GetFiles("*.xlsx");

                foreach (FileInfo fileInfo in Arquivos)
                {
                    if (fileInfo.Name.Contains(TypeFile))
                    {
                        using (FileStream stream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            stream.Close();
                        }
                        return ExistFile = $"{AddressPath}\\{fileInfo.Name}";
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                return FileMessage.Msg(TypeFile, FileMessage.FileStatus.ERROR, ex.ToString());
            }
            return String.Empty;
        }
        public string DeleteFile()
        {
            try
            {
                File.Delete(ExistFile);
                return FileMessage.Msg(TypeFile, FileMessage.FileStatus.OK, $"Delete file] [{ExistFile}");
            }
            catch (Exception ex)
            {
                return FileMessage.Msg(TypeFile, FileMessage.FileStatus.ERROR, $"Delete file] [{ExistFile}] [{ex}");
            }
        }
    }
}
