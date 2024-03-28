REM OGA Shared Kernel Library

REM Build the library...
dotnet restore "./OGA.SharedKernel_NET452/OGA.SharedKernel_NET452.csproj"
dotnet build "./OGA.SharedKernel_NET452/OGA.SharedKernel_NET452.csproj" -c DebugLinux --runtime linux --no-self-contained

dotnet restore "./OGA.SharedKernel_NET452/OGA.SharedKernel_NET452.csproj"
dotnet build "./OGA.SharedKernel_NET452/OGA.SharedKernel_NET452.csproj" -c DebugWin --runtime win --no-self-contained
