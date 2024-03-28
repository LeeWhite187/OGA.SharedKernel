REM OGA Shared Kernel Library

REM Build the library...
dotnet restore "./OGA.SharedKernel_NET48/OGA.SharedKernel_NET48.csproj"
dotnet build "./OGA.SharedKernel_NET48/OGA.SharedKernel_NET48.csproj" -c DebugLinux --runtime linux-x64 --no-self-contained
dotnet build "./OGA.SharedKernel_NET48/OGA.SharedKernel_NET48.csproj" -c DebugLinux --runtime linux-arm --no-self-contained
dotnet build "./OGA.SharedKernel_NET48/OGA.SharedKernel_NET48.csproj" -c DebugLinux --runtime linux-arm64 --no-self-contained

dotnet restore "./OGA.SharedKernel_NET48/OGA.SharedKernel_NET48.csproj"
dotnet build "./OGA.SharedKernel_NET48/OGA.SharedKernel_NET48.csproj" -c DebugWin --runtime win-x64 --no-self-contained
dotnet build "./OGA.SharedKernel_NET48/OGA.SharedKernel_NET48.csproj" -c DebugWin --runtime win-x86 --no-self-contained
dotnet build "./OGA.SharedKernel_NET48/OGA.SharedKernel_NET48.csproj" -c DebugWin --runtime win-arm64 --no-self-contained
