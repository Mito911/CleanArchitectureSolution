# Testowanie REST API
Write-Host "Testing REST API Endpoints..."

# GET /api/user/1
Write-Host "GET /api/user/1"
Invoke-RestMethod -Uri "https://localhost:7293/api/user/1" -Method Get -Headers @{accept="application/json"}

# POST /api/user
Write-Host "POST /api/user"
Invoke-RestMethod -Uri "https://localhost:7293/api/user" -Method Post -Headers @{accept="application/json"; "Content-Type"="application/json"} -Body '{"username": "newuser", "password": "password"}'

# GET /api/order/1
Write-Host "GET /api/order/1"
Invoke-RestMethod -Uri "https://localhost:7293/api/order/1" -Method Get -Headers @{accept="application/json"}

# POST /api/order
Write-Host "POST /api/order"
Invoke-RestMethod -Uri "https://localhost:7293/api/order" -Method Post -Headers @{accept="application/json"; "Content-Type"="application/json"} -Body '{"productId": 2, "quantity": 3, "userId": 1}'

# GET /api/product/1
Write-Host "GET /api/product/1"
Invoke-RestMethod -Uri "https://localhost:7293/api/product/1" -Method Get -Headers @{accept="application/json"}

# POST /api/product
Write-Host "POST /api/product"
Invoke-RestMethod -Uri "https://localhost:7293/api/product" -Method Post -Headers @{accept="application/json"; "Content-Type"="application/json"} -Body '{"name": "Test Product", "price": 10}'

# Testowanie SOAP API
Write-Host "Testing SOAP API..."

# Wymaga zainstalowanego pakietu soapUI lub podobnego narzędzia
# Oto przykład użycia Invoke-WebRequest do wysyłania żądania SOAP
$soapRequest = @"
<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:tem="http://tempuri.org/">
   <soapenv:Header/>
   <soapenv:Body>
      <tem:GetData>
         <tem:value>42</tem:value>
      </tem:GetData>
   </soapenv:Body>
</soapenv:Envelope>
"@

Invoke-WebRequest -Uri "http://localhost:12345/Service.svc" -Method Post -ContentType "text/xml; charset=utf-8" -Headers @{"SOAPAction"="http://tempuri.org/IService/GetData"} -Body $soapRequest
