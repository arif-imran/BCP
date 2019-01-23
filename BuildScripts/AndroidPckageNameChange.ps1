param ([string] $GAsiaDroidProjectDir, [string] $BuildConfiguration, [string] $sourcesDirectory)
Write-Output "GAsiaDroidProjectDir: $GAsiaDroidProjectDir"
Write-Output "ConfigurationName: $BuildConfiguration"

$ManifestPath = $GAsiaDroidProjectDir + "/Properties/AndroidManifest.xml" 
Write-Host "ManifestPath: $ManifestPath"
[xml] $xdoc = Get-Content $ManifestPath
 
$package = $xdoc.manifest.package
$appName = $xdoc.manifest.application.label

Write-Host "package: $package" 
Write-Host "app name: $appName"


If ($BuildConfiguration -eq "Release_Dev" -and $package.EndsWith("droid"))
{
    $package = $package.Replace("droid", "dbcpdroid")
    $appName = $appName.Replace("$appName", "BCP_Dev")
}


If ($BuildConfiguration -eq "HA_Dev" -and $package.EndsWith("droid"))
{
    $package = $package.Replace("droid", "hadbcpdroid")
    $appName = $appName.Replace("GAsia BCP", "BCP_Dev")
}

If ($BuildConfiguration -eq "HA_Staging" -and $package.EndsWith("droid"))
{
    $package = $package.Replace("droid", "hasbcpdroid")
    $appName = $appName.Replace("GAsia BCP", "BCP_Staging")
}


If ($BuildConfiguration -eq "Release_Staging" -and $package.EndsWith("droid"))
{
    $package = $package.Replace("droid", "sbcpdroid")
    $appName = $appName.Replace("$appName", "BCP_Staging")
}
 

 
    $versionCode = $xdoc.manifest.versionCode
    Write-Host "versionCode: $versionCode" 
    [int] $iversion = ([convert]::ToInt32($versionCode, 10) + 1)
    Write-Host "versionCode after inc: $iversion"
    $xdoc.manifest.versionCode = [string] $iversion
    
$xdoc.manifest.package = $package
$xdoc.manifest.application.label = $appName
 
Remove-Item  -force -verbose $ManifestPath
  
 
$xdoc.Save($ManifestPath)
$appName = $xdoc.manifest.application.label
