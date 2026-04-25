# Retail-APIGW
Real world implementation of APIGW for Warehouse  EshopManager and integrations with online services

to manualy install app on any server:
1. copy installation folder to server
2. Install certificates for https
	- manage computer certificates -> personal -> import
	- select .pfx file from installation folder
3. Grant Access to the Private Key:  certutil -repairstore my "THUMBPRINT"