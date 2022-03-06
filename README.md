## axiangweixinwork

## 企业微信，微信公众号封装api


## 接口文档：https://open.work.weixin.qq.com/api/doc/90000/90135/90664

## 接口文档：https://developers.weixin.qq.com/doc/offiaccount/Getting_Started/Overview.html

## 对外引用，BLL

## HTML网页富文本转文档=HtmlAgilityPack

## .NET 5/.NET 6控制台转windows服务 （topshelf/nlog.config）

C:\Users>cd \Host.Quartz.WindowsService\bin\Debug\net6.0

## 安装服务
C:\Users>Host.Quartz.WindowsService.exe install

Hello World!
Configuration Result:
[Success] Name Host.Quartz.WindowsService
[Success] Description 控制台Quartz.WindowsService，支持.NET 6.0
[Success] ServiceName Host.Quartz.WindowsService
Topshelf v4.3.0.0, .NET 6.0.2 (6.0.2)

Running a transacted installation.

Beginning the Install phase of the installation.
Installing Host.Quartz.WindowsService service
Installing service Host.Quartz.WindowsService...
Service Host.Quartz.WindowsService has been successfully installed.

The Install phase completed successfully, and the Commit phase is beginning.

The Commit phase completed successfully.

The transacted install has completed.

## 启动服务

C:\Users>Host.Quartz.WindowsService.exe start

Hello World!
Configuration Result:
[Success] Name Host.Quartz.WindowsService
[Success] Description 控制台Quartz.WindowsService，支持.NET 6.0
[Success] ServiceName Host.Quartz.WindowsService
Topshelf v4.3.0.0, .NET 6.0.2 (6.0.2)
The Host.Quartz.WindowsService service was started.

## 日志级别 nlog.config

 internalLogLevel="Info"

 <rules>
    <logger name="*" minlevel="Info" writeTo="logfile,logconsole" />
  </rules>
