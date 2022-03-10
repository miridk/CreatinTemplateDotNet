invoke-expression 'cmd /c start powershell -Command { docker compose up --build; set-location ".\"; get-childitem ; sleep 3}'

Start-Process -FilePath http://localhost:14800/swagger/index.html
