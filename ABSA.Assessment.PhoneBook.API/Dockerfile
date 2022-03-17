#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ABSA.Assessment.PhoneBook.API/ABSA.Assessment.PhoneBook.API.csproj", "ABSA.Assessment.PhoneBook.API/"]
RUN dotnet restore "ABSA.Assessment.PhoneBook.API/ABSA.Assessment.PhoneBook.API.csproj"
COPY . .
WORKDIR "/src/ABSA.Assessment.PhoneBook.API"
RUN dotnet build "ABSA.Assessment.PhoneBook.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ABSA.Assessment.PhoneBook.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ABSA.Assessment.PhoneBook.API.dll"] 
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false