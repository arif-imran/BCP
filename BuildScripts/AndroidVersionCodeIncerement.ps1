param ([string] $GAsiaDroidProjectDir, [string] $worksp, [string] $sourcesDirectory)
Write-Output "GAsiaDroidProjectDir: $GAsiaDroidProjectDir"


$ManifestPath = $GAsiaDroidProjectDir + "/Properties/AndroidManifest.xml"
 
Write-Host "ManifestPath: $ManifestPath"


[xml] $xdoc = Get-Content $ManifestPath
 
$versionCode = $xdoc.manifest.versionCode

Write-Host "versionCode: $versionCode" 
[int] $iversion = ([convert]::ToInt32($versionCode, 10) + 1)
Write-Host "versionCode after inc: $iversion"
 
$xdoc.manifest.versionCode = [string] $iversion

Remove-Item  -force -verbose $ManifestPath
   
$xdoc.Save($ManifestPath)

  #Add-PSSnapin Microsoft.TeamFoundation.Powershell
# Identify the server (might be a better way for this)
 #  $tfsServerString = "https://grosvenorbi.visualstudio.com/GFMClientApp"
  #  $tfsServerString = "https://grosvenorbi.visualstudio.com/GFMClientApp/_git/GEuropeInvestorApp"
   # $tfs = get-tfsserver $tfsServerString
 #   Write-Host ("tfs = " + $tfs)
#Write-Host "sources dir: $sourcesDirectory"
 
#$tfFilePath = "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\TF.exe"

#$comment = "Checked in manifest file after versioncode increment"
#cd $sourcesDirectory
#& $tfFilePath workspaces /collection:$tfsServerString
#& $tfFilePath checkin $ManifestPath /noprompt /comment:$comment
#& tf.exe checkin /noprompt /comment:$comment
#tf.exe checkin $ManifestPath /noprompt /comment:$comment




