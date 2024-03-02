<h1 align="center"><img src="https://foruda.gitee.com/avatar/1677165732744604624/7158691_java-and-net_1677165732.png!avatar100" alt="组织logo.png" /></h1>
<h1 align="center">TopskyHotelManagerSystem-WebApi</h1>
<p align="center">
	<a href='https://github.com/easy-open-meta/TopskyHotelManagerSystem-WebApi/stargazers'><img src='https://img.shields.io/github/stars/easy-open-meta/TopskyHotelManagerSystem-WebApi?style=social
' alt='star'></img></a>
        <a href='https://github.com/easy-open-meta/TopskyHotelManagerSystem-WebApi/forks'><img src='https://img.shields.io/github/forks/easy-open-meta/TopskyHotelManagerSystem-WebApi
' alt='fork'></img></a>
        <a href='https://img.shields.io/badge/license-MIT-000000.svg'><img src="https://img.shields.io/badge/license-MIT-000000.svg" alt=""></img></a>
        <a href='https://img.shields.io/badge/language-C#-red.svg'><img src="https://img.shields.io/badge/language-CSharp-red.svg" alt=""></img></a>
</p>
<div align="center">
	<p>中文文档 | <a src="https://github.com/easy-open-meta/TopskyHotelManagerSystem-WebApi/blob/master/README.en.md">English Document</a></p>
</div>




###  :pray: 感谢以下开源项目：

1. ##### Autofac——An addictive .NET IoC container。[Autofac, MIT开源协议](https://github.com/autofac/Autofac)     

2. ##### SqlSugar——国内最受欢迎ORM框架。 [SQLSugar,Apache-2.0开源协议](https://github.com/DotNetNext/SqlSugar)


### :exclamation: 本项目介绍：

本项目是基于.Net6构建的TS酒店管理系统后端API项目，主要用于2.0升级所用，欢迎Start&Fork

1、一切开发请遵照MIT开源协议进行。

2、有bug欢迎提出issue！

###  :thought_balloon: 开发目的：

主要用于现有的C/S项目酒店管理系统升级2.0后实现前后端分离的WebAPI接口，本项目不包含任何UI界面。

###  :mag_right: 系统开发环境：

操作系统：Windows 11(x64)

开发工具：Microsoft Visual Studio 2022(系统最新版本)

数据库：PostgreSQL v13

数据库管理工具：Navicat 16

开发语言：C#语言、LINQ语言

开发平台：.Net

开发框架：.Net 6

开发技术：.NET 6 WebAPI

### :open_file_folder: 系统结构：

```
EOM.TSHotelManager.Web
├─ .git
├─ .gitignore
├─ EOM.TSHotelManager.Application
│    ├─ Business
│    ├─ EOM.TSHotelManager.Application.csproj
│    ├─ Sys
│    ├─ Worker
│    ├─ Zero
├─ EOM.TSHotelManager.Common
│    ├─ EOM.TSHotelManager.Common.csproj
│    ├─ HttpHelper.cs
│    ├─ RecordHelper
│    ├─ Util
├─ EOM.TSHotelManager.Core
│    ├─ Business
│    ├─ EOM.TSHotelManager.Core.csproj
│    ├─ Sys
│    ├─ Worker
│    ├─ Zero
├─ EOM.TSHotelManager.EntityFramework
│    ├─ AppSettingsJson.cs
│    ├─ EOM.TSHotelManager.EntityFramework.csproj
│    ├─ Repository
│    │    └─ PgRepository.cs
│    ├─ dbsettings.json
├─ EOM.TSHotelManager.Web.sln
├─ EOM.TSHotelManager.WebApi
│    ├─ Controllers
│    │    ├─ Business
│    │    ├─ Sys
│    │    ├─ Worker
│    │    └─ Zero
│    ├─ EOM.TSHotelManager.WebApi.csproj
│    ├─ EOM.TSHotelManager.WebApi.csproj.user
│    ├─ EOM.TSHotelManager.WebApi.xml
│    ├─ MvcOptionsExtensions.cs
│    ├─ Program.cs
│    ├─ RouteConvention.cs
│    ├─ Router_Extension
│    ├─ Startup.cs
│    ├─ appsettings.Development.json
│    ├─ appsettings.json
├─ LICENSE
├─ Library
│    ├─ CK.Common.dll
├─ README.en.md
└─ README.md
```

###  :chart_with_upwards_trend: 系统数据库关系图(由PDMAN软件生成) :loudspeaker: 

[数据库关系图](https://oscode.top/project/tshotel/db_design.html)

###  :exclamation: 项目作者：

**Jackson(即本账号，项目组长,核心代码编写和后期项目整合)**

**Benjamin(开发，项目代码编写)**

**Bin(数据库，提供数据库管理支持)**

**咖啡与网络(后期维护和开发)**

###  :computer: 项目运行部署(执行下面步骤前需先安装.NET 6 SDK和Runtime)：

**下载并安装Microsoft Visual Studio Professional 2022及以上版本，并通过下载Zip包解压，打开.sln后缀格式文件运行。**

###  :inbox_tray: 数据库运行部署(本地)：

**作者及开发团队强烈建议使用PostgreSQL数据库，安装PostgreSQL数据库并开启服务，通过可视化管理工具对数据库进行建立，可通过打开执行数据库脚本文件夹内的.sql后缀格式文件进行快速建立数据表和导入数据，执行步骤(以PostgreSQL数据库为例)：**

**1、通过可视化管理工具打开Table.sql文件进行数据表建立。**

**2、随后打开Data.sql文件进行数据导入。**

​       [![咖啡与网络/TopskyHotelManagerSystem-WebApi](https://gitee.com/java-and-net/topsky-hotel-manager-system-web-api/widgets/widget_card.svg?colors=4183c4,ffffff,ffffff,e3e9ed,666666,9b9b9b)](https://gitee.com/java-and-net/topsky-hotel-manager-system-web-api)
