$script:ErrorActionPreference = "Stop"
$adminDomain = $ptfpropDomain
$adminName = $ptfpropUser1Name
$adminPassword = $ptfpropUser1Password
$sutVersion = $ptfpropSutVersion

$adminAccount = $adminDomain + "\" + $adminName
$deviceWiped = $false

if($sutVersion -ge "ExchangeServer2010")
{
  $securePassword = ConvertTo-SecureString $adminPassword -AsPlainText -Force
  $credential = new-object Management.Automation.PSCredential($adminAccount,$securePassword)

  #Invoke function remotely
  $ret = invoke-command -computer $serverComputerName -Credential $credential -scriptblock {
	  param(
	       [string]$userEmail,
		   [System.Object]$credential,
		   [string]$serverComputerName,
		   [string]$deviceType
	  )
	   
	  $connectUri = "http://" + $serverComputerName + "/PowerShell"
	  $session = New-PSSession -ConfigurationName Microsoft.Exchange -ConnectionUri $connectUri -Credential $credential -Authentication Kerberos
	  Import-PSSession $session -AllowClobber -DisableNameChecking

	  #Remove the specified device
	  $devices = Get-ActiveSyncDeviceStatistics -Mailbox $userEmail
	  
	  foreach($device in $devices)
	  {
		if($device.DeviceType -eq $deviceType)
		{
			Remove-ActiveSyncDevice -Identity $device.Identity -Confirm:$false
		}
	  }

	  return $true
  }-ArgumentList $userEmail,$credential,$serverComputerName,$deviceType

  return $ret
}
else
{
  cmd /c "winrs -r:$serverComputerName -u:$adminAccount -p:$adminPassword Powershell Add-PSSnapin Microsoft.Exchange.Management.PowerShell.Admin;`$devices = Get-ActiveSyncDeviceStatistics -Mailbox $userEmail;foreach(`$device in `$devices){if(`$device.DeviceType -eq '$deviceType'){ Remove-ActiveSyncDevice -Identity `$device.Identity -Confirm:`$false }}"
  return $true
}