###Using Type Providers in dotnet core v2.0

#####Steps:

- Install an F# Compiler that runs on .NET Framework or Mono, see Linux, Windows, OSX. It is likely you already have one installed.

- Add FscToolPath and FscToolExe settings to your project file:

```
  <PropertyGroup>
    <IsWindows Condition="'$(OS)' == 'Windows_NT'">true</IsWindows>
    <IsOSX Condition="'$([System.Runtime.InteropServices.RuntimeInformation]::IsOSPlatform($([System.Runtime.InteropServices.OSPlatform]::OSX)))' == 'true'">true</IsOSX>
    <IsLinux Condition="'$([System.Runtime.InteropServices.RuntimeInformation]::IsOSPlatform($([System.Runtime.InteropServices.OSPlatform]::Linux)))' == 'true'">true</IsLinux>
  </PropertyGroup>
  <PropertyGroup Condition="'$(IsWindows)' == 'true'">
    <FscToolPath>C:\Program Files (x86)\Microsoft SDKs\F#\4.1\Framework\v4.0</FscToolPath>
    <FscToolExe>fsc.exe</FscToolExe>
  </PropertyGroup>
  <PropertyGroup Condition="'$(IsOSX)' == 'true'">
    <FscToolPath>/Library/Frameworks/Mono.framework/Versions/Current/Commands</FscToolPath>
    <FscToolExe>fsharpc</FscToolExe>
  </PropertyGroup>
  <PropertyGroup Condition="'$(IsLinux)' == 'true'">
    <FscToolPath>/usr/bin</FscToolPath>
    <FscToolExe>fsharpc</FscToolExe>
  </PropertyGroup>
```

You can then use "dotnet build", "dotnet restore" etc.


** Shamelessly copied from: https://github.com/Microsoft/visualfsharp/issues/3303