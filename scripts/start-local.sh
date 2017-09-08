#!/bin/bash
export ASPNETCORE_ENVIRONMENT=local
cd src/Collectively.Services.Blockchain
dotnet run --no-restore --urls "http://*:10008"