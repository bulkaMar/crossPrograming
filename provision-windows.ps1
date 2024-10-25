# Встановлення Chocolatey, якщо його ще немає
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; Invoke-Expression ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))

# Встановлення .NET SDK через Chocolatey
choco install dotnet-sdk

# Перехід до директорії проекту і запуск
cd /vagrant
dotnet run run lab1 --input LAB1/INPUT.TXT --output LAB1/OUTPUT.TXT
