# FOFA Pro SDK 使用说明文档
##  FOFA Pro API

FOFA Pro API 是资产搜索引擎 FOFA Pro 为开发者提供的 RESTful API 接口, 允许开发者在自己的项目中集成 FOFA Pro 的功能。

## FOFA SDK
基于 FOFA Pro API 编写的 c# 版 SDK, 方便 c# 开发者快速将 FOFA Pro 集成到自己的项目中。

# 环境
## 开发环境
windows10 + VS2019
##
## 使用环境
.Net 4.0

# 获取
直接下载

## FOFA SDK
## 安装
直接下载后加入到新项目

## Email & API Key
Email    用户登陆 FOFA Pro 使用的 Email
Key 前往 个人中心 查看 API Key
## Example
```
在Fofa_client.cs文件内填入自己帐号信息后,直接用即可
    public string email = "";//填入自己的email及key
    public string key = "";

    private void test()
    {
        string data1 = Client.get_userinfo()；#获取帐号信息
        string[] data = null;
        string query_str="";
        string fields = "";
        for (int i = 0; i < page; i++)
        {
            string data2 = Client.get_data(query_str, int page, fields);#进行查询 
            data = Unpack_data(data2);#转换成字符数组，后期split分割后foreach进行遍历
            Console.WriteLine(data2);
        }
        
        
        
    }











```
### 具体使用文档见wiki

# 协议
FOFA SDK 遵循 MIT 协议 https://opensource.org/licenses/mit
