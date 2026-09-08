###### Backup #####

Param(
[Parameter(Mandatory= $True, Position=0, ValueFromPipeline = $false)]
[System.String]
$serverName
)

[string]$source ="\\$($serverName)\Pms_Backend1"
[string]$destination ="\\$($serverName)\Pms_Backend_Backup"
[string]$iisWebSiteName="MotabaBackend"

$User = "its\dev-ghanim"
$Password = ConvertTo-SecureString -String Oman@2020 -AsPlainText -Force
[System.Management.Automation.PSCredential]$credintial = New-Object  System.Management.Automation.PSCredential($User, $Password)

#### Start Backup Phases ###

# delete old backup from (Pms_Backend_Backup)

function delete-old-backup(){

Write-Warning "Erasing Old Backup..Please Wait..."
Write-Host""

$files = Get-ChildItem $destination\*

  # Initialize the progress counter
  $totalFiles = $files.Count
  $progressCounter = 0
  foreach ($file in $files) {
    $progressCounter++

    # Determine the progress percentage
    $progressPercentage = [int16](($progressCounter / $totalFiles) * 100)

    # Create the progress bar
    $progressParams = @{
      Activity        = "Erasing Files"
      Status          = "Erasing  $($progressCounter) of $($totalFiles) $( $progressPercentage)%"
      PercentComplete = $progressPercentage
    }
    Write-Progress @progressParams

     # Delete the file
    Remove-Item $destination\* -Recurse -Force

     # Check if the delete operation is complete
    if ($progressCounter -eq $totalFiles) {
      # Complete the progress bar
      Write-Progress -Activity "Erasing Files" -Completed
    }
  }

Write-Host "Info: Erasing Compleated" -ForegroundColor Green
Write-Host""

}

# create new backup from (Pms_Backend) in (Pms_Backend_Backup)

function write-new-backup(){

Write-Host "Info: Start Taking a Backup for Backend files..Please Wait..." -ForegroundColor Blue
Write-Host""

$files = Get-ChildItem $source

  # Initialize the progress counter
  $totalFiles = $files.Count
  $progressCounter = 0
  foreach ($file in $files) {
    $progressCounter++

    # Determine the progress percentage
    $progressPercentage = [int16](($progressCounter / $totalFiles) * 100)

    # Create the progress bar
    $progressParams = @{
      Activity        = "Copying Files"
      Status          = "Copying  $($progressCounter) of $($totalFiles) $( $progressPercentage)%"
      PercentComplete = $progressPercentage
    }
    Write-Progress @progressParams

    # Copy the file
    $destinationFilePath = $file.FullName.Replace($source, $destination)
    Copy-Item -Force -Recurse $files.FullName -Destination $destinationFilePath
    
    # Check if the copy operation is complete
    if ($progressCounter -eq $totalFiles) {
      # Complete the progress bar
      Write-Progress -Activity "Copying Files" -Completed
    }
  }

    Write-Host "Info: Copying Compleated" -ForegroundColor Green
    Write-Host""
      
}

### End Backups ###



### Puplish ###

### Start Publish Phases ###

# Delet old file from (Pms_BackEnd)

function delete-old-files-fromserver (){

# stop iis BackEnd only

Write-Host "Info: Switch-off iis Website Backend" -ForegroundColor Blue
Write-Host""

Invoke-Command -Credential $credintial -ComputerName $serverName -ScriptBlock {
$env:VAR =$using:iisWebSiteName
Stop-Website -Name $env:VAR}

# Delete old files from Pms_BackEnd

Write-Warning "Erasing Old Backend files..Please Wait..."
Write-Host""

$files = Get-ChildItem $source\*

  # Initialize the progress counter
  $totalFiles = $files.Count
  $progressCounter = 0
  foreach ($file in $files) {
    $progressCounter++

    # Determine the progress percentage
    $progressPercentage = [int16](($progressCounter / $totalFiles) * 100)

    # Create the progress bar
    $progressParams = @{
      Activity        = "Erasing Files"
      Status          = "Erasing  $($progressCounter) of $($totalFiles) $( $progressPercentage)%"
      PercentComplete = $progressPercentage
    }
    Write-Progress @progressParams

    # Delete the file
    Remove-Item $source\* -Recurse -Force
    
    # Check if the delete operation is complete
    if ($progressCounter -eq $totalFiles) {
      # Complete the progress bar
      Write-Progress -Activity "Erasing Files" -Completed
    }
  }

  Write-Host "Info: Erasing Compleated " -ForegroundColor Green
  Write-Host " "

}

# Publish files from local PC to Server in (Pms_BackEnd)

function copy-new-files-toserver (){

[string]$serverPath ="\\$($serverName)\Pms_Backend"
  # 1- Stop iis website Backend ONLY
  Write-Host "Info: Switch-off iis Website Backend" -ForegroundColor Blue
  Write-Host " "

  invoke-command -Credential $credintial -computername $serverName -scriptblock {
    $env:VAR = $using:iisWebSiteName
    Stop-Website -Name $env:VAR }

Write-Host "Info: Start Publishing..Please Wait...$($serverPath)" -ForegroundColor Blue

dotnet publish -c Release -f net7.0 -r win-x64 /p:EnvironmentName=Staging -p:PublishDir=$serverPath

 Write-Host "Info: Publish Compleated" -ForegroundColor Green
 Write-Host " "

  # 2- Start iis website Backend ONLY
  invoke-command -Credential $credintial -computername $serverName -scriptblock {
    $env:VAR = $using:iisWebSiteName
    Start-Website -Name $env:VAR }
 

Write-Host "Info: Switch-on iis Website Backend" -ForegroundColor Green
Write-Host " "
}

### End Puplish ###

# call functions

#delete-old-backup -Verbose
#write-new-backup -Verbose
#delete-old-files-fromserver -Verbose
copy-new-files-toserver -Verbose

