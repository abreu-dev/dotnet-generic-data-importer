docker run -v ~/docker --name sqlserver-generic-importer -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=RfAjiY5LL5" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest