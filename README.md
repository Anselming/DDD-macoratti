# DDD-macoratti


Essa versão foi feita com base na solução construída pelo Macoratti (https://www.macoratti.net/20/07/aspnc_ucddd1.htm).
Ela possui características e organizações particulares que prefiro para projetos desse tipo.


docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Admin#PwdAdmin#Pwd" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest


dotnet ef --startup-project ./Presentation/Web/Presentation.Web.csproj  --project ./Infrastructure/Infrastructure.csproj migrations add ContatosInicial

dotnet ef --startup-project ./Presentation/Web/Presentation.Web.csproj --project ./Infrastructure/Infrastructure.csproj database update

dotnet run --project ./Presentation/Web/