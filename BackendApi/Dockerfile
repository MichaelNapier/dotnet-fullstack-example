FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

ENV ASPNETCORE_URLS=http://+:5000

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["BackendApi/BackendApi.csproj", "./"]
RUN dotnet restore "BackendApi.csproj"
COPY BackendApi .
WORKDIR "/src/."
RUN dotnet build "BackendApi.csproj" -c $configuration -o /app/build
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# CMD [ "dotnet", "watch", "--non-interactive", "run", "--launch-profile", "Docker" ]

# FROM build AS dev

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "BackendApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackendApi.dll"]
