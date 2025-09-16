param([string]$sourcePath, [string]$outputPath)

Write-Host "===================== Generating Documentation Markdown ====================="
dotnet tool install xmldoc2markdown
dotnet xmldoc2md $sourcePath\Jlw.Extensions.Identity.Stores.dll --output $outputPath\Jlw.Extensions.Identity.Stores --member-accessibility-level public --back-button --index-page-name README
dotnet xmldoc2md $sourcePath\Jlw.Extensions.Identity.Mock.dll --output $outputPath\Jlw.Extensions.Identity.Mock --member-accessibility-level public --back-button --index-page-name README
