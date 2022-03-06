using Microsoft.Extensions.Configuration;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.IO;
using Topshelf;

namespace Host.Quartz.WindowsService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            #region 运行服务
            try
            {
                // 配置和运行宿主服务
                HostFactory.Run(x =>                              // 1
                {
                    x.Service<Service>();
                    // s =>                         // 2
                                         //{
                                         // 指定服务类型，这里设置为 Service         
                                         //   s.ConstructUsing(name => new Service());    // 3

                    // 当服务启动后执行方法                       
                    //    s.WhenStarted(tc => tc.StartAsync(configuration));       // 4

                    // 当服务停止后执行方法
                    //    s.WhenStopped(tc => tc.Stop());             // 5
                    //});

                    // 服务使用本地账号来运行
                    x.RunAsLocalSystem();                           // 6

                    // 服务描述信息
                    x.SetDescription("控制台Quartz.WindowsService，支持.NET 6.0");      // 7

                    // 服务显示名称
                    x.SetDisplayName("Host.Quartz.WindowsService");           // 8

                    // 服务名称
                    x.SetServiceName("Host.Quartz.WindowsService");         // 9

                    x.EnableServiceRecovery(r => r.RestartService(TimeSpan.FromSeconds(15)));

                    x.StartAutomaticallyDelayed();
                });
                //Console.Read();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion
        }

    }
    public class Service : ServiceControl
    {
        public bool Start(HostControl hostControl)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            // 从工厂中获取调度器实例
            var scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;

            // 自动导入log数据
            IJobDetail joblogDetail = JobBuilder.Create<Log_Job>().Build();

            //读取配置
            joblogDetail.JobDataMap.Add("IntervalHour", configuration["IntervalHour"]);
          
            IMutableTrigger triggerLogData = CronScheduleBuilder.CronSchedule(
                configuration["LogCronSchedule"]).Build();
            triggerLogData.Key = new TriggerKey("triggerLogData");

            // 添加调度
            scheduler.ScheduleJob(joblogDetail, triggerLogData);
            scheduler.Start();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            Console.WriteLine("结束服务:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            return true;
        }
    }
}
