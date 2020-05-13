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
## pip
安装 FOFA SDK 之前，请先确认已经安装 pip.

点击 pip documentation 了解详细的说明

## FOFA SDK
## 安装

pip install fofa
or

git clone https://github.com/fofapro/fofa-py.git
cd fofa-py   
python setup.py install
## 依赖
## Library
目前全部采用的是python内置包，可直接安装使用。

## Email & API Key
Email    用户登陆 FOFA Pro 使用的 Email
Key 前往 个人中心 查看 API Key
## Example

#-- coding: utf-8 --
import fofa

if __name__ == "__main__":
    email, key = ('test@test.com','xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx') #输入email和key
    client = fofa.Client(email, key)                                  #将email和key传入fofa.Client类进行初始化和验证，并得到一个fofa client对象
    query_str = 'header="thinkphp" || header="think_template"'
    for page in range(1,51):                                          #从第1页查到第50页
        fcoin = client.get_userinfo()["fcoin"]                        #查询F币剩余数量
        if fcoin <= 249:
            break                                                     #当F币剩249个时，不再获取数据
        data = client.get_data(query_str,page=page,fields="ip,city")  #查询第page页数据的ip和城市
        for ip,city in data["results"]:
            print "%s,%s"%(ip,city)                                   #打印出每条数据的ip和城市

### 具体使用文档见wiki

# 协议
FOFA SDK 遵循 MIT 协议 https://opensource.org/licenses/mit
