dotnet publish -c Release -p:PublishAot="true" -p:SelfContained="true" -p:PublishSingleFile="false" -p:Platform="Any CPU" -p:TargetFramework="net8.0" -r win-x64 AvaloniaFreeze.sln
mkdir binaries
copy bin\Release\net8.0\win-x64\publish binaries
move binaries\AvaloniaFreeze.exe binaries\AvaloniaFreezeAot.exe 
dotnet publish -c Release -p:PublishAot="false" -p:SelfContained="true" -p:PublishSingleFile="true" -p:PublishTrimmed="true" -p:Platform="Any CPU" -p:TargetFramework="net8.0" -r win-x64 AvaloniaFreeze.sln
copy bin\Release\net8.0\win-x64\publish\AvaloniaFreeze.exe binaries\AvaloniaFreezeJit.exe
del binaries\AvaloniaFreeze.pdb