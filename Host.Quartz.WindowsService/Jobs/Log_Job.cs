using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Quartz.WindowsService
{
    public class Log_Job : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var IntervalHour=context.JobDetail.JobDataMap["IntervalHour"].ToString();

            return LogService.Run(IntervalHour);
        }
    }

    public static class LogService
    { 
        public static async Task Run(string agrgus)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{agrgus},{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        }
    }
}
