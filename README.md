<h1 align="center"><img src="https://images.gitee.com/uploads/images/2021/0731/004719_17fd289f_5122554.png" alt="组织logo.png" /></h1>
<h1 align="center">TopskyHotelManagerSystem-WebApi</h1>
<p align="center">
	<a href='https://gitee.com/java-and-net/topsky-hotel-manager-system-web-api/stargazers'><img src='https://gitee.com/java-and-net/topsky-hotel-manager-system-web-api/badge/star.svg?theme=dark' alt='star'></img></a>
        <a href='https://gitee.com/java-and-net/topsky-hotel-manager-system-web-api/fork'><img src='https://gitee.com/java-and-net/topsky-hotel-manager-system-web-api/badge/fork.svg?theme=dark' alt='fork'></img></a>
        <a href='https://img.shields.io/travis/antvis/g2.svg'><img src="https://img.shields.io/travis/antvis/g2.svg" alt=""></img>
        <a href='https://img.shields.io/badge/license-MIT-000000.svg'><img src="https://img.shields.io/badge/license-MIT-000000.svg" alt=""></img></a>
        <a href='https://img.shields.io/badge/language-C#-red.svg'><img src="https://img.shields.io/badge/language-CSharp-red.svg" alt=""></img></a>
</p>

###  :pray: 感谢以下开源项目：

1. ##### Furion——让 .NET 开发更简单，更通用，更流行。[Furion, MulanPSL-2.0开源协议](https://gitee.com/dotnetchina/Furion)      


### :exclamation: 本项目介绍：

本项目是基于Furion框架构建的TS酒店管理系统后端API项目，主要用于2.0升级所用，欢迎Start&Fork

1、一切开发请遵照MIT开源协议进行。

2、有bug欢迎提出issue！

3、本系统基于Furion框架进行创建，在此特别声明！

###  :thought_balloon: 开发目的：

主要用于现有的C/S项目酒店管理系统升级2.0后实现前后端分离的WebAPI接口，本项目不包含任何UI界面。

###  :mag_right: 系统开发环境：

操作系统：Windows 10(x64)

开发工具：Microsoft Visual Studio 2019(系统最新版本)

数据库：MySQL v8.0.23(强烈推荐！)

数据库管理工具：Navicat 15

开发语言：C#语言、LINQ语言

开发平台：.Net

开发框架：.Net 5/Furion

开发技术：.NET 5 WebAPI

### :open_file_folder: 系统结构：

```
HotelManagerSystemWebApi
├─ HotelManagerSystemWebApi.Application
│    ├─ HotelManagerSystemWebApi.Application.csproj
│    ├─ HotelManagerSystemWebApi.Application.xml
│    ├─ Zero
│    │    └─ AdminInfo
│    ├─ applicationsettings.json
├─ HotelManagerSystemWebApi.Core
│    ├─ DtoExtend
│    │    └─ DtoExtend.cs
│    ├─ HotelManagerSystemWebApi.Core.csproj
│    ├─ HotelManagerSystemWebApi.Core.xml
│    ├─ Zero
│    │    └─ AdminInfo.cs
├─ HotelManagerSystemWebApi.EntityFramework.Core
│    ├─ DbContexts
│    │    └─ DefaultDbContext.cs
│    ├─ HotelManagerSystemWebApi.EntityFramework.Core.csproj
│    ├─ Startup.cs
│    ├─ dbsettings.json
├─ HotelManagerSystemWebApi.Web.Core
│    ├─ Handlers
│    │    └─ JwtHandler.cs
│    ├─ HotelManagerSystemWebApi.Web.Core.csproj
│    ├─ HotelManagerSystemWebApi.Web.Core.xml
│    ├─ Startup.cs
├─ HotelManagerSystemWebApi.Web.Entry
│    ├─ HotelManagerSystemWebApi.Web.Entry.csproj
│    ├─ Program.cs
│    ├─ Properties
│    │    └─ launchSettings.json
│    ├─ Startup.cs
│    ├─ appsettings.Development.json
│    ├─ appsettings.json
├─ HotelManagerSystemWebApi.sln
```

###  :chart_with_upwards_trend: 系统数据库关系图(由PDMAN软件生成) :loudspeaker: 

[数据库关系图](https://www.jvnorg.site/tshoteldb.html)

###  :exclamation: 项目作者：

**杨俊杰(即本账号，项目组长,核心代码编写和后期项目整合)**

**熊越明(开发，项目代码编写)**

**宾华安(数据库，提供数据库管理支持)**

**咖啡与网络(后期维护和开发)**

###  :computer: 项目运行部署(执行下面步骤前需先安装.NET 5 SDK和Runtime)：

**下载并安装Microsoft Visual Studio Professional 2019及以上版本，并通过下载Zip包解压，打开.sln后缀格式文件运行。**

###  :inbox_tray: 数据库运行部署(本地)：

**作者及开发团队强烈建议使用MySQL数据库，安装MySQL数据库并开启服务，通过可视化管理工具对数据库进行建立，可通过打开执行数据库脚本文件夹内的.sql后缀格式文件进行快速建立数据表和导入数据，执行步骤(以MySQL数据库为例)：**

**1、通过可视化管理工具打开Table.sql文件进行数据表建立。**

**2、随后打开Data.sql文件进行数据导入。**

### :exclamation: 参与贡献

1.  Fork 本仓库
2.  新建 Feat_xxx 分支
3.  提交代码
4.  新建 Pull Request(https://gitee.com/java-and-net/topsky-hotel-manager-system-web-api/pulls)

1. #  :chart_with_upwards_trend: Star趋势图(感谢[Giteye](https://giteye.net/)提供的趋势图报表功能！)：

   [![Giteye chart](https://chart.giteye.net/gitee/java-and-net/topsky-hotel-manager-system-web-api/QXF965PJ.png)](https://giteye.net/chart/QXF965PJ)](https://giteye.net/chart/Z9DD26VK)

​       [![咖啡与网络/TopskyHotelManagerSystem-WebApi](https://gitee.com/java-and-net/topsky-hotel-manager-system-web-api/widgets/widget_card.svg?colors=4183c4,ffffff,ffffff,e3e9ed,666666,9b9b9b)](https://gitee.com/java-and-net/topsky-hotel-manager-system-web-api)
