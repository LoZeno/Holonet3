param($target = "D:\SVILUPPO SOFTWARE\Holonet3\trunk", $companyname = "SWLive.it")

#[System.Globalization.CultureInfo] $ci = [System.Globalization.CultureInfo]::GetCultureInfo("pt-BR")

[System.Globalization.CultureInfo] $ci = [System.Globalization.CultureInfo]::GetCurrentCulture

# Full date pattern with a given CultureInfo
# Look here for available String date patterns: http://www.csharp-examples.net/string-format-datetime/
$date = (Get-Date).ToString("F", $ci);

# Header template
$header = "//-----------------------------------------------------------------------

// <copyright file=""{0}"" company=""{1}"">

// Copyright (c) {1}. All rights reserved.

// <author>Luca ""Lo Zeno"" Zenari</author>

// <date>{2}</date>

// </copyright>

//-----------------------------------------------------------------------`r`n"

function Write-Header ($file)
{
    # Get the file content as as Array object that contains the file lines
    $content = Get-Content $file
    
    # Getting the content as a String
    $contentAsString =  $content | Out-String
    
    <# If content starts with // then the file has a copyright notice already
       Let's Skip the first 14 lines of the copyright notice template... #>
    if($contentAsString.StartsWith("//"))
    {
       $content = $content | Select-Object -skip 14
    }

    # Splitting the file path and getting the leaf/last part, that is, the file name
    $filename = Split-Path -Leaf $file

    # $fileheader is assigned the value of $header with dynamic values passed as parameters after -f
    $fileheader = $header -f $filename, $companyname, $date

    # Writing the header to the file
    Set-Content $file $fileheader -encoding UTF8

    # Append the content to the file
    Add-Content $file $content
}

#Filter files getting only .cs ones and exclude specific file extensions
Get-ChildItem $target -Filter *.cs -Exclude *.Designer.cs,T4MVC.cs,*.generated.cs,*.ModelUnbinder.cs -Recurse | % `
{
    <# For each file on the $target directory that matches the filter,
       let's call the Write-Header function defined above passing the file as parameter #>
    Write-Header $_.PSPath.Split(":", 3)[2]
}