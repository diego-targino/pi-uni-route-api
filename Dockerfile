# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos de projeto individualmente
COPY UniRoute/UniRoute.API/UniRoute.API.csproj UniRoute/UniRoute.API/
COPY UniRoute/UniRoute.Application/UniRoute.Application.csproj UniRoute/UniRoute.Application/
COPY UniRoute/UniRoute.CrossCutting/UniRoute.CrossCutting.csproj UniRoute/UniRoute.CrossCutting/
COPY UniRoute/UniRoute.Domain/UniRoute.Domain.csproj UniRoute/UniRoute.Domain/
COPY UniRoute/UniRoute.Infrastructure/UniRoute.Infrastructure.csproj UniRoute/UniRoute.Infrastructure/

# Restaura as dependências
RUN dotnet restore UniRoute/UniRoute.API/UniRoute.API.csproj

# Copia o restante dos arquivos
COPY UniRoute/ UniRoute/

# Define diretório de trabalho do projeto principal
WORKDIR /src/UniRoute/UniRoute.API

# Publica a aplicação
RUN dotnet publish UniRoute.API.csproj -c Release -o /app/publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Expõe a porta usada pelo Railway
EXPOSE 80

# Executa o projeto
ENTRYPOINT ["dotnet", "UniRoute.API.dll"]
