#!/bin/bash

# Testowanie REST API
echo "Testing REST API Endpoints..."

# GET /api/user/1
echo "GET /api/user/1"
curl -X GET "https://localhost:7293/api/user/1" -H "accept: application/json"
echo -e "\n"

# POST /api/user
echo "POST /api/user"
curl -X POST "https://localhost:7293/api/user" -H "accept: application/json" -H "Content-Type: application/json" -d "{\"username\": \"newuser\", \"password\": \"password\"}"
echo -e "\n"

# GET /api/order/1
echo "GET /api/order/1"
curl -X GET "https://localhost:7293/api/order/1" -H "accept: application/json"
echo -e "\n"

# POST /api/order
echo "POST /api/order"
curl -X POST "https://localhost:7293/api/order" -H "accept: application/json" -H "Content-Type: application/json" -d "{\"productId\": 2, \"quantity\": 3, \"userId\": 1}"
echo -e "\n"

# GET /api/product/1
echo "GET /api/product/1"
curl -X GET "https://localhost:7293/api/product/1" -H "accept: application/json"
echo -e "\n"

# POST /api/product
echo "POST /api/product"
curl -X POST "https://localhost:7293/api/product" -H "accept: application/json" -H "Content-Type: application/json" -d "{\"name\": \"Test Product\", \"price\": 10}"
echo -e "\n"

# Testowanie SOAP API
echo "Testing SOAP API..."

# Wymaga zainstalowanego pakietu soapUI lub podobnego narzêdzia
# Oto przyk³ad u¿ycia curl do wysy³ania ¿¹dania SOAP
echo "Sending SOAP request..."
soap_request="<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:tem=\"http://tempuri.org/\">
   <soapenv:Header/>
   <soapenv:Body>
      <tem:GetData>
         <tem:value>42</tem:value>
      </tem:GetData>
   </soapenv:Body>
</soapenv:Envelope>"

curl -X POST "http://localhost:12345/Service.svc" -H "Content-Type: text/xml; charset=utf-8" -H "SOAPAction: \"http://tempuri.org/IService/GetData\"" -d "$soap_request"
