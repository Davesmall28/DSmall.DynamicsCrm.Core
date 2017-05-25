SET packageVersion=1.0.0-beta2

NuGet.exe pack ../Springboard365.Xrm.Core.csproj -Build -symbols -Version %packageVersion%

NuGet.exe push Springboard365.Xrm.Core.%packageVersion%.nupkg

pause