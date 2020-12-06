Write-Host -ForegroundColor Green "Publishing nuget-package..."

$NugetSource = "https://www.myget.org/F/mindbox-private/auth/$($ENV:WF_MYGET_TOKEN)/api/v3/index.json"

$Package = Get-ChildItem -Recurse -Include "*.nupkg"

dotnet nuget push `
	$Package `
	--source $NugetSource

Write-Host -ForegroundColor Green "Done!"