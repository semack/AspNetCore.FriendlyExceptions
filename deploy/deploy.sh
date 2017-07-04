ApiKey=$1
Source=$2

nuget pack ./deploy/AspNetCore.FriendlyExceptions.nuspec -Verbosity detailed
nuget push ./AspNetCore.FriendlyExceptions.*.nupkg -Verbosity detailed -ApiKey $ApiKey -Source $Source
