# Aspnetcore.Dev.Certs.Generator

[中文](README-cn.md) [English](README.md)

一个用于生成本地调试https证书的工具，这个工具可以生一个dev-certs认可的证书，并且可以添加自己的域名到证书里进行本地调试  
你是否遇到过本地调试的时候只能使用localhost无法使用生产环境的https访问？或者你是否每次都需要用环境变量指定证书位置，现在你可以使用`Aspnetcore.Dev.Certs.Generator`快速生成一个包含你的域名的localhost证书用于你的本地开发  
## 说明
1、下载Release包运行exe并根据提示进行操作  
2、生成证书后默认为pem和key（如果设置了password），如果需要crt证书请直接修改扩展名，如果需要pfx请拉取代码进行修改  
## 注意
该工具生成的证书不仅可以用于AspNetCore开发使用也可以用于Vue、React、Java等，请自行探索 
