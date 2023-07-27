# MethodBox.MBLog

文档地址：
https://MethodBoxAwA.github.io/Docs/MethodBox.MBLog/  
注意：该项目文档目前只支简体持**中文（中国）**。  
您可以使用DeepL、Google翻译等将文档翻译成您需要的语言。  
多语言文档将尽快追加。
  
Document Address:
https://MethodBoxAwA.github.io/Docs/MethodBox.MBLog/  
Caution: The project document currently only supports **Simplified Chinese (China)**.<br>
You can use DeepL, Google Translate, etc. to translate documents into the language you need.<br>
Multilingual documents will be added as soon as possible.
  
    
The Str1fe, "MethodBox"  
您可以通过以下方式联系我们：  
  
You can contact us through the following methods:

- 电子邮件至：`we@methodbox.top`
- 加入群聊：`197257459`

## 项目概述（Project Principle）
一个可拓展性强、功能全面的基于.Net的日志系统。  
该日志系统支持对日志的生成、保存和打印等基本功能，同时允许您自定义日志的格式化方法等，同时支持将日志保存到Json和数据库中以及相应的读取和实例化方法，并支持将日志发送到网络服务器、提供日志筛选和跟踪等诸多方法。

A Net based logging system with strong scalability and comprehensive functionality.  
This logging system supports basic functions such as generating, saving, and printing logs, while allowing you to customize the formatting methods of logs. It also supports saving logs to Json and databases, as well as corresponding reading and instantiation methods. It also supports sending logs to network servers, providing various methods such as log filtering and tracking.
## 项目版权（Project Copyright）
即使我们开源了此NuGet包的所有源代码，但这并不代表您可以无规则使用此代码，根据开源协议您不得进行非法售卖或未经过作者同意随意转发。  
您必须遵守`LGPL`开源许可证的约定，并在其下开展工作。
  
Even if we open source all the source code of this NuGet package, it does not mean that you can use this code without rules. According to the open source agreement, you are not allowed to sell it illegally or forward it without the author's consent.  
You must comply with the provisions of the `GNU Lesser General Public License` open source license and carry out work under it.
## 如何使用（How to use）
您可以下载源代码并将其编译为类库文件，然后在项目中添加引用。  
但是，我们在NuGet.org上提供了编译完成的NuGet包，您可以使用如下方式将该日志库部署在您的项目中：
```.NET CLI
dotnet add package MethodBox.MBLog --version 1.0.2
```
或者访问该包的NuGet链接：  
https://www.nuget.org/packages/MethodBox.MBLog<br>
您可以访问以下网址来获取该类库的文档：  
https://MethodBoxAwA.github.io/Docs/MethodBox.MBLog/
<br><br>
You can download the source code and compile it into a class library file, and then add references in the project  
However, we have provided the compiled NuGet package on NuGet. org, and you can deploy the log library in your project using the following method:
```. NET CLI
dotnet add package MethodBox. MBLog -- version 1.0.2
```
Alternatively, visit the NuGet link of the package:<br>
https://www.nuget.org/packages/MethodBox.MBLog <br>
You can access the documentation for this library at the following website:  
https://MethodBoxAwA.github.io/Docs/MethodBox.MBLog/

## 更新日志（Update Log）
- 1.0.0：对基本的日志读写提供了支持。
- 1.0.1：完成保存日志文件功能；完成保存json文件功能；完成自定义格式化功能。
- 1.0.2：完善项目文档注释；开始开发网络功能。
- 1.0.3：完成了日志异步推送方法；提供了更多的例程；提供了处理等级较高的日志的相关事件。
- 1.0.4：完成了事件跟踪系统的基本搭建，对原有部分功能进行了测试。

- 1.0.0: Provides support for basic log reading and writing.
- 1.0.1: Complete the function of saving log files; Complete the function of saving JSON files; Complete the custom formatting function.
- 1.0.2: Improve project document annotations; Start developing network features.
- 1.0.3: Completed the asynchronous push method for logs; Provided more routines; Provides events related to logs with higher processing levels.
- 1.0.4: Completed the basic construction of the event tracking system and tested some of the original functions.

## 鸣谢（Thanks）
感谢NullTeam工作站对本项目开发的帮助。  
感谢xUnit测试框架的开发者，该测试框架使我们的测试流程方便了很多。  
以及，  
正在阅读这份文档的**你**。

Thanks for the assistance of the NullTeam workstation in the development of this project.  
Thanks for the developers of the xUnit testing framework, which has made our testing process much easier.  
And,  
**You** who are reading this document.

凡是过往，皆为序章。  
2023 MBSoftware-Network,All Copyright Reserved.