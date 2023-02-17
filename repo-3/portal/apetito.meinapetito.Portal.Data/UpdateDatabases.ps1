param (
    [string]$connectionString='',
    [string]$context="all"
)

write-host "======================="
write-host "   UPDATING DATABASE"
write-host "======================="
write-host ""
write-host "Connection String: $connectionString" -ForegroundColor Green

$answer = $(Write-Host "Are you sure, that you want to update a database? [yN] " -ForegroundColor red -NoNewLine; Read-Host) 

if ("y" -ne $answer)
{
    write-host ""
    write-host "Aborted."
    exit
}

Get-ChildItem -filter *Context.cs -recurse | ForEach-Object {
    $currentContext = $_.BaseName
         
    if (($context -ne "all") -And ($context -ne $currentContext)) {
        return
    }    
    
    write-host ""
    write-host "Updating context: $currentContext" -ForegroundColor DarkYellow  
    dotnet ef database update -c $currentContext -- --connectionString=$connectionString
}  

write-host ""
write-host "Done."