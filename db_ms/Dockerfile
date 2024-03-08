FROM mcr.microsoft.com/mssql/server

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=abcDEF123#
ENV MSSQL_TCP_PORT=1433


WORKDIR /src
COPY script.sql ./script.sql


# define ALL sql scripts that should be run to setup the db separated with && (and \ to make the newline work)!
RUN (/opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" && \
 /opt/mssql-tools/bin/sqlcmd -S127.0.0.1 -Usa -PabcDEF123# -i script.sql