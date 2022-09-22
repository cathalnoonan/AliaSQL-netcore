# Provides a sample for building the app and testing a database build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY ./source /src
WORKDIR /src
RUN dotnet publish --use-current-runtime

FROM mcr.microsoft.com/azure-sql-edge AS test
COPY ./test /test
COPY --from=build /src/AliaSQL.Console/bin/Debug/net6.0 /app
ARG ACCEPT_EULA=Y
ARG SA_PASSWORD=P@ssword1
USER root
RUN apt update -y && apt install -y netcat
WORKDIR /test
RUN set -xe \
    # Start SQL Server
    && (/opt/mssql/bin/sqlservr -c &) \
    && (while ! nc -z 127.0.0.1 1433; do sleep 10; echo "Waiting for SQL Server"; done) \
    # Perform testing
    && export ALIASQL="$(find /app -iname AliaSQL.Console | head -n1)" \
    && $ALIASQL Create localhost test /test sa $SA_PASSWORD
