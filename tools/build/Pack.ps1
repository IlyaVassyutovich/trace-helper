Write-Host -ForegroundColor Green "Packing nuget-package..."

$PackArgs = (
	"pack", "./src/TraceHelper/TraceHelper.csproj",
	"--nologo",
	"--configuration", "Release",
	"--output", "./build/",
	"--include-source",
	"--include-symbols"
)

$VersionSuffix = $ENV:WF_VERSION_SUFFIX
if ($ENV:WF_VERSION_SUFFIX) {
	Write-Host "Got version suffix '$VersionSuffix'"
	$PackArgs = $PackArgs + ("--version-suffix", $VersionSuffix)
}
else {
	Write-Host "Version suffix is absent — 'Release' build"
}

dotnet $PackArgs

Write-Host -ForegroundColor Green "Done!"