# 備品予約
DDD、モデリングの練習

# SQL Server 構築手順（Docker for Windows がインストールされている前提）
## SQL Server のイメージをダウンロード
docker pull microsoft/mssql-server-windows-developer

## SQL Server のコンテナを起動する
docker run -e ACCEPT_EULA=Y -e SA_PASSWORD=test!234 -e MSSQL_LCID=1041 -e MSSQL_COLLATION=Japanese_CI_AS -p 1433:1433 -d microsoft/mssql-server-windows-developer

## データベースを作成する
docker stop [container id]

docker cp [CreateDatabase.sql のファイルパス] [container id]:C:\
※CreateDatabase.sql のファイルパス とは、本リポジトリを Clone したときの database\CreateDatabase.sql のパスです。

docker start [container id]

docker exec -it [container id] cmd

sqlcmd -S localhost -U SA -P test!234 -i C:\CreateDatabase.sql
