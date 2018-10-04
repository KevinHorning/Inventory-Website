$NugetDirectory = "\\ctg-windows\Nuget"
 
$LocalNugetExists = Test-Path $NugetDirectory
 
if (!$LocalNugetExists) {
    New-Item -ItemType Directory -Path $NugetDirectory
}
 
$projectFile = get-childitem . -Path ..\*.csproj
 
Invoke-Expression "dotnet pack ..\CTG.Database.csproj --include-symbols -o .\.team"
 
$packageExists = Test-Path ".\*.nupkg"
if ($packageExists -eq $false){
    Throw "Unable to generate package"
}
 
$nugetName = Split-Path -Leaf (get-childitem . -Path *.nupkg)
 
$newNugetTestPath = $NugetDirectory +"\"+$nugetName
 
if((Test-Path $newNugetTestPath) -eq $true){
    Remove-Item -Path "*.nupkg"
    Throw "Package already exists. Did you forget to bump the version?"
}
 
Invoke-Expression "dotnet nuget push .\$($nugetName) --source $($NugetDirectory)"
 
Remove-Item -Path "*.nupkg"