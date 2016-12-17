using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.Interfaces.Service;
using log4net;
using System.Net;
using System.IO;
using System.Configuration;

namespace Assetto.Service
{
    public class LogService : ILogService
    {
        private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly string MachineName = Environment.MachineName;

        // TODO: Use MachineName

        public void Log(string text)
        {
            Log4Net.Info(text);
            SendLog(MachineName, 1, text);

        }

        public void Error(string text)
        {
            Log4Net.Error(text);
            SendLog(MachineName, 4, text);

        }

        public void Fatal(string text)
        {
            Log4Net.Fatal(text);
            SendLog(MachineName, 5, text);
        }

        private void SendLog(string machineName, int severity, string message) {
            var url = string.Format(ConfigurationManager.AppSettings["LogUrl"]
                , MachineName
                , severity
                , message.Replace(" ", string.Empty).Replace(".", string.Empty));


            HttpGet(url);

        }

        private static async Task<string> HttpGet(string url)
        {
            try
            {
                var request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                WebResponse responseObject = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request);
                var responseStream = responseObject.GetResponseStream();
                var sr = new StreamReader(responseStream);
                string received = await sr.ReadToEndAsync();

                return received;
            }
            catch (Exception ex)
            {
                Log4Net.Error("Error while sendings logs: "+ex);
            }
            return null;
           
        }
    }
}
