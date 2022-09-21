namespace Anbima.Infra.Data.Files.Util
{
    public static class FileMessage
    {
        public enum FileStatus
        {
            OK,
            ERROR,
            INFO
        }
        public static string Msg(string typeFile, FileStatus status, string msg)
        {
            var ret = $"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:ffff")}] [{typeFile}] [{status}] [{msg}]";
            return ret;
        }
    }
}
