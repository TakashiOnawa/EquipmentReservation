# 概要
　このプロジェクトは、備品予約を題材としたドメイン駆動設計の戦術的設計のサンプルプロジェクトです。



# 要件

* 利用者は備品を予約できる。
  * 備品には USB, ポケットWifi, 携帯電話 がある。
  * 備品、予約時間、利用目的を指定して予約する。
  * 予約対象の備品がすでに同一時間帯に予約されている場合は予約できない。

- 利用者は予約をキャンセルできる。
- 利用者は予約を変更できる。



# ドメインモデル

　TODO



# 採用技術

Framework ： ASP .NET Core MVC

ORM ： Entity Framework, Dapper

Database : PostgreSQL



# レイヤー構造

![](https://github.com/TakashiOnawa/EquipmentReservation/blob/master/modeling/Architecture/Architecture.png)



## EquipmentReservation.Domain

- DomainObject（Entity、ValueObject）、DomainService、Repository の Interface を格納する。
- 集約ルートごとに Repository の Interface を用意する。



## EquipmentReservation.Application

* ApplicationService を格納する。
* CQRS の考え方を利用して、Command と Query の ApplicationService を分ける。ただし、DB は分けていない。（Command は ApplicationService、Query は QueryService という名前にしている。）
* ApplicationService では、Unit of Work トランザクション管理を行う。
* QueryService では、直接 SQL を実装するのではなく、Interface（IQuery）を定義して Infrastructure 層で実装する。



## EquipmentReservation.Infrastructure

* Repository、Query の実装を格納する。
* DB アクセスは Entity Framework、Dapper を利用している。
* Unit of Work の実装を格納する。



## EquipmentReservation

- ASP .NET Core MVC の Web アプリケーションの入り口。
- View、Controller を格納する。
- DI（依存性の注入）を行う。



# データベースの構築

1. Docker for Windows をインストールする
2. 「database_posgtresql\CreateContainer.bat」 を実行する。