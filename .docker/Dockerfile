FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build

# install debugger
WORKDIR /vsdbg
RUN apt update && \
    apt install unzip && \
    curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l /remote_debugger

# build app
WORKDIR /app
COPY . .

RUN dotnet build ./HRP.sln -o build



FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS runtime

# copy builded app and debugger
WORKDIR /app
COPY --from=build /app/build .
COPY --from=build /remote_debugger /remote_debugger

# run app
ENTRYPOINT ["dotnet", "HRP.Host.dll"]