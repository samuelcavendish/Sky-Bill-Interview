using Microsoft.Extensions.OptionsModel;
using Sky.Models.Configuration;
using System;
using System.IO;

namespace Sky.Services.LogManagers
{
    public class LogManager : ILogManager
    {
        private readonly IOptions<LogSettings> _logSettings;
        public LogManager(IOptions<LogSettings> logSettings)
        {
            _logSettings = logSettings;
        }

        public void LogError(String errorMessage, Exception ex = null)
        {
            try
            {
                var logEntry = $"{DateTime.Now}\t{errorMessage}\t{ex?.ToString()}";

                var fileInfo = new FileInfo(Path.Combine(_logSettings?.Value?.LogDirectory ?? "../Log",
                    _logSettings?.Value?.LogFileName ?? "SkyBillLog.txt"));
                if (!fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                }

                using (var sw = fileInfo.AppendText())
                {
                    sw.WriteLine(logEntry);
                }
            }
            catch (Exception)
            {
                //If we fail to log then don't impact the site
            }
        }
    }
}
