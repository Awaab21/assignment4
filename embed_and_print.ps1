$htmlPath = "c:\Users\ac\Desktop\assignment no 4\documentation.html"
$outputPath = "c:\Users\ac\Desktop\assignment no 4\documentation_inline.html"
$pdfPath = "c:\Users\ac\Desktop\assignment no 4\assignment_no_4_documentation.pdf"

$html = Get-Content -Path $htmlPath -Raw

for ($i = 1; $i -le 8; $i++) {
    $num = "{0:D2}" -f $i
    $imgPath = "c:\Users\ac\Desktop\assignment no 4\images\app$num.png"
    if (Test-Path $imgPath) {
        Write-Host "Converting app$num.png to Base64..."
        $bytes = [System.IO.File]::ReadAllBytes($imgPath)
        $base64 = [System.Convert]::ToBase64String($bytes)
        $dataUri = "data:image/png;base64,$base64"
        $html = $html.Replace("images/app$num.png", $dataUri)
    } else {
        Write-Warning "Image not found: $imgPath"
    }
}

Set-Content -Path $outputPath -Value $html -Encoding utf8
Write-Host "Inlined HTML saved to $outputPath"

# Now print to PDF
Write-Host "Printing inline HTML to PDF..."
$edgePath = "C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe"
if (-not (Test-Path $edgePath)) {
    $edgePath = "C:\Program Files\Microsoft\Edge\Application\msedge.exe"
}

# Use file URI for print
$fileUri = "file:///" + $outputPath.Replace('\', '/')
# Encode spaces in file URI
$fileUri = $fileUri.Replace(' ', '%20')

$tempPdf = "C:\Users\ac\doc_temp.pdf"
if (Test-Path $tempPdf) {
    Remove-Item $tempPdf -Force -ErrorAction SilentlyContinue
}

$process = Start-Process -FilePath $edgePath -ArgumentList "--headless", "--disable-gpu", "--no-sandbox", "--print-to-pdf=$tempPdf", "$fileUri" -Wait -PassThru

if (Test-Path $tempPdf) {
    Move-Item -Path $tempPdf -Destination $pdfPath -Force
    Write-Host "PDF generated successfully at $pdfPath"
    $size = (Get-Item $pdfPath).Length
    Write-Host "PDF size: $size bytes"
} else {
    Write-Error "Failed to generate PDF. Check if Edge process succeeded. Exit code: $($process.ExitCode)"
}

# Clean up
if (Test-Path $outputPath) {
    Remove-Item $outputPath -Force -ErrorAction SilentlyContinue
}
