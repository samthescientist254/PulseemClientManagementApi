#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PulseemClientManagementApi/PulseemClientManagementApi.csproj", "PulseemClientManagementApi/"]
RUN dotnet restore "PulseemClientManagementApi/PulseemClientManagementApi.csproj"
COPY . .
WORKDIR "/src/PulseemClientManagementApi"
RUN dotnet build "PulseemClientManagementApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PulseemClientManagementApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PulseemClientManagementApi.dll"]