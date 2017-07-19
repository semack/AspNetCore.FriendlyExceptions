#!/usr/bin/env bash

#exit if any command fails
set -e

dotnet restore

revision=${TRAVIS_JOB_ID:=1}  
revision=$(printf "%04d" $revision) 

dotnet pack --configuration release --output nupkgs --version-suffix $revision
#$revision  
dotnet nuget push ./src/nupkgs/AspNetCore.FriendlyExceptions.*.nupkg --api-key $NUGET_API_KEY --source $NUGET_SOURCE
