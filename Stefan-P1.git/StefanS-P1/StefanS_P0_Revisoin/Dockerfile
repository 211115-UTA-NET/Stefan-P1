FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /StefanS_P0_Revisoin

# #Change the images current working directory
COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /StefanS_P0_Revisoin
EXPOSE 80
COPY  --from=build-env /StefanS_P0_Revisoin/out .

ENTRYPOINT ["dotnet", "StefanS_P0_Revisoin.dll"]