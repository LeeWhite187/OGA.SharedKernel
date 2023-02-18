REM OGA Shared Kernel Library

REM Build the library...
dotnet restore "./OGA.SharedKernel_NET452/OGA.SharedKernel_NET452.csproj"
dotnet build "./OGA.SharedKernel_NET452/OGA.SharedKernel_NET452.csproj" -c DebugLinux --runtime linux-x64 --no-self-contained

dotnet restore "./OGA.SharedKernel_NET47/OGA.SharedKernel_NET47.csproj"
dotnet build "./OGA.SharedKernel_NET47/OGA.SharedKernel_NET47.csproj" -c DebugLinux --runtime linux-x64 --no-self-contained

dotnet restore "./OGA.SharedKernel_NET5/OGA.SharedKernel_NET5.csproj"
dotnet build "./OGA.SharedKernel_NET5/OGA.SharedKernel_NET5.csproj" -c DebugLinux --runtime linux-x64 --no-self-contained

dotnet restore "./OGA.SharedKernel_NET6/OGA.SharedKernel_NET6.csproj"
dotnet build "./OGA.SharedKernel_NET6/OGA.SharedKernel_NET6.csproj" -c DebugLinux --runtime linux-x64 --no-self-contained

dotnet restore "./OGA.SharedKernel_NET452/OGA.SharedKernel_NET452.csproj"
dotnet build "./OGA.SharedKernel_NET452/OGA.SharedKernel_NET452.csproj" -c DebugWin --runtime win-x64 --no-self-contained

dotnet restore "./OGA.SharedKernel_NET47/OGA.SharedKernel_NET47.csproj"
dotnet build "./OGA.SharedKernel_NET47/OGA.SharedKernel_NET47.csproj" -c DebugWin --runtime win-x64 --no-self-contained

dotnet restore "./OGA.SharedKernel_NET5/OGA.SharedKernel_NET5.csproj"
dotnet build "./OGA.SharedKernel_NET5/OGA.SharedKernel_NET5.csproj" -c DebugWin --runtime win-x64 --no-self-contained

dotnet restore "./OGA.SharedKernel_NET6/OGA.SharedKernel_NET6.csproj"
dotnet build "./OGA.SharedKernel_NET6/OGA.SharedKernel_NET6.csproj" -c DebugWin --runtime win-x64 --no-self-contained

REM Create the composite nuget package file from built libraries...
C:\Programs\nuget\nuget.exe pack ./OGA.SharedKernel.nuspec -IncludeReferencedProjects -symbols -SymbolPackageFormat snupkg -OutputDirectory ./Publish -Verbosity detailed

REM To publish nuget package...
dotnet nuget push -s http://192.168.1.161:8080/v3/index.json ".\Publish\OGA.SharedKernel.1.3.1.nupkg"
dotnet nuget push -s http://192.168.1.161:8080/v3/index.json ".\Publish\OGA.SharedKernel.1.3.1.snupkg"
