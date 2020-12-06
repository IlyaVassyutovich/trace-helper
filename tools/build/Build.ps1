Write-Host -ForegroundColor Green "Building project..."

$BuildArgs = (
	"build", "./src/TraceHelper/TraceHelper.csproj",
	"--nologo",
	"--configuration", "Release",
	"--output", "./build/"
)

$VersionSuffix = $ENV:WF_VERSION_SUFFIX
if ($ENV:WF_VERSION_SUFFIX) {
	Write-Host "Got version suffix '$VersionSuffix'"
	$BuildArgs = $BuildArgs + ("--version-suffix", $VersionSuffix)
}
else {
	Write-Host "Version suffix is absent — 'Release' build"
}

dotnet $BuildArgs

Write-Host -ForegroundColor Green "Done!"