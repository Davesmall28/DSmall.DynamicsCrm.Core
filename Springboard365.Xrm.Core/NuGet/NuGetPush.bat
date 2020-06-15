SET packageVersion=2.0.0-beta1

NuGet.exe pack ../Springboard365.Xrm.Core.csproj -Build -Symbols -Version %packageVersion% -Properties Configuration=Release

NuGet.exe push Springboard365.Xrm.Core.%packageVersion%.nupkg -source "https://api.nuget.org/v3/index.json"

pause