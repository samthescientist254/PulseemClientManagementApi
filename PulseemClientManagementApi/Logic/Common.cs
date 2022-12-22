using System.Reflection;
using System.Text.RegularExpressions;

namespace PulseemClientManagementApi.Logic
{
    public class Common
    {
        public bool EmailIsValid(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }


        public static void LogError(string msg, string fx, string caller, string moreDetails = "")
        {
            try
            {
                if (!msg.Contains("Thread was being aborted.") & !caller.Contains("Callback"))
                {
                    string sPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Logs";
                    ClearOldLogs(sPath, 10);
                    if (!Directory.Exists(sPath)) Directory.CreateDirectory(sPath);
                    sPath = Path.Combine(sPath, DateTime.Now.ToString("yyyyMMdd") + ".log");
                    var errMsg = DateTime.Now.ToString("dd-MMM-yyy HH:mm:ss") + ": Function: " + fx + ": Being Called By: " + caller + ": Error: " + msg + (moreDetails.Length == 0 ? "" : ": More Details: " + moreDetails);
                    /*      if (!string.IsNullOrWhiteSpace(SessionData.Username))
                              errMsg = "User: " + SessionData.Username + " " + errMsg;*/

                    //Get the file for exclusive read/write access
                    using (FileStream fs = new FileStream(sPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        using (StreamWriter sw = new StreamWriter(fs)) { }
                    }

                    //Error Logging Starts
                    using (FileStream fs = new FileStream(sPath, FileMode.Append, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                            sw.WriteLine(errMsg);
                    }
                    ClearOldLogs(sPath, 3);
                }
            }
            catch
            {
            }
        }


        private static void ClearOldLogs(string path, int days)
        {
            try
            {
                var di = new DirectoryInfo(path);
                var itms = di.GetFiles().Where(p => p.LastWriteTime.AddDays(days) < DateTime.Now);
                foreach (var itm in itms)
                    File.Delete(itm.FullName);
            }
            catch
            {
            }
        }

    }
}
