FROM Microsoft/dotnet:2.2-sdk as build

ARG BUILDCONFIG=RELASE
ARG VERSION=1.0.0

COPY api.csproj /build/

RUN dotnet restore ./build/api.csproj

COPY . ./build/
WORKDIR /build/
RUN dotnet publish ./api.csproj -c$BUILDCONFIG -o out /p:version=$VERSION