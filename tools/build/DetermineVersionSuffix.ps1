$IsReleaseBuild = [System.Convert]::ToBoolean($ENV:WF_IS_RELEASE_BUILD);
if ($IsReleaseBuild) {
	$VersionSuffix = "";
}
else {
	$VersionSuffix = "b$($ENV:GITHUB_RUN_NUMBER)";
}

Write-Output "WF_VERSION_SUFFIX=$VersionSuffix" >> $ENV:GITHUB_ENV;
