<!-- $(
	## Add Poweshell template variables Here ##
	$projectName = "Jlw.AspNetCore.Identity"
) -->
# $projectName

## Pipeline Status

| Test | Alpha | Staging | Release |
|-----|-----|-----|-----|
| [![Build and Test](https://github.com/JasonLWalker/$($projectName)/actions/workflows/build-test.yml/badge.svg)](https://github.com/JasonLWalker/$($projectName)/actions/workflows/build-test.yml) | [![Build and Deploy - Alpha](https://github.com/JasonLWalker/$($projectName)/actions/workflows/build-deploy-alpha.yml/badge.svg)](https://github.com/JasonLWalker/$($projectName)/actions/workflows/build-deploy-alpha.yml) | [![Build and Deploy - RC](https://github.com/JasonLWalker/$($projectName)/actions/workflows/build-deploy-rc.yml/badge.svg?branch=staging)](https://github.com/JasonLWalker/$($projectName)/actions/workflows/build-deploy-rc.yml) |[![Build and Deploy](https://github.com/JasonLWalker/$($projectName)/actions/workflows/build-deploy.yml/badge.svg)](https://github.com/JasonLWalker/$($projectName)/actions/workflows/build-deploy.yml) | 


# Modular DbClient User Store
<!-- $( 
	$projectName = "Jlw.Extensions.Identity.Stores"
	$projectPath = "$($buildPath)**\$($projectName).csproj"
) -->
[![Nuget](https://img.shields.io/nuget/v/$($projectName)?label=$($projectName)%20%28release%29)](https://www.nuget.org/packages/$($projectName)/#versions-body-tab) [![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/$($projectName)?label=$($projectName)%20%28preview%29)](https://www.nuget.org/packages/$($projectName)/#versions-body-tab)

## Information / Requirements
$(Get-ProjectInfoTable $projectName $projectPath)

## Dependencies

$(Get-ProjectDependencyTable $projectPath)


# Identity Mocking Extension
<!-- $( 
	$projectName = "Jlw.Extensions.Identity.Mock"
	$projectPath = "$($buildPath)**\$($projectName).csproj"
) -->
[![Nuget](https://img.shields.io/nuget/v/$($projectName)?label=$($projectName)%20%28release%29)](https://www.nuget.org/packages/$($projectName)/#versions-body-tab) [![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/$($projectName)?label=$($projectName)%20%28preview%29)](https://www.nuget.org/packages/$($projectName)/#versions-body-tab)

## Information / Requirements
$(Get-ProjectInfoTable $projectName $projectPath)

## Dependencies

$(Get-ProjectDependencyTable $projectPath)
