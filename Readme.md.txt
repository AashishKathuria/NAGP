----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
#Docker Image creation for Microservice and push to docker hub
>>Open cmd window (Run as administrator)
>>Navigate to dockerfile path(..code\NAGP-ASP-Microservice\NAGP-ASP-Microservice)
>>Login to Docker account and create a public repo
>>https://hub.docker.com/repository/docker/aashishkathuria/aashishnagp/tags?page=1&ordering=last_updated

docker login

docker image build -t  aashishkathuria/aashishnagp:v0 .

docker push aashishkathuria/aashishnagp:v0

>>If you want to pull the image>> docker pull aashishkathuria/aashishnagp:v0
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
#Azure login, create resources and set subscription
>>Navigate to https://portal.azure.com/ and login with the credentials
>>Open cloudshell or use cmd and login

az login

az account set -s "24c58644-925f-4b43-b1db-2a8f55597fe0"

az group create --name NAGPResourceGroup --location "Central India"

az aks create -g NAGPResourceGroup -n nagpakscluster --enable-managed-identity --node-count 1 --enable-addons monitoring --enable-msi-auth-for-monitoring  --generate-ssh-keys

az aks nodepool add --resource-group NAGPResourceGroup  --cluster-name nagpakscluster  --name nagpnodepool  --node-count 1 --node-vm-size Standard_B4ms --mode System --no-wait 
az aks nodepool delete --resource-group NAGPResourceGroup --name nodepool1 --cluster-name nagpakscluster 

az aks get-credentials -n "nagpakscluster" -g "NAGPResourceGroup"
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
#Kubernetes deployments
>>Navigate to yaml files folder and run one by one
kubectl apply -f mssql-secret.yaml
kubectl apply -f configmap.yaml
kubectl apply -f deployment.yaml
kubectl apply -f service.yaml
kubectl apply -f mssql-data.yaml
kubectl apply -f mssql-deployment.yaml
kubectl get pod
------------------------------------------------------------------------------------
------------------------------------------------------------------------------------
#SQL database and table creations
CREATE DATABASE [NAGP];
USE [NAGP]
	CREATE TABLE Product (Id int NOT NULL,
		Name VARCHAR(100) NOT NULL,
		Description VARCHAR(100) NOT NULL,
		Price VARCHAR(100) NOT NULL,
		Category int
		);
INSERT INTO [dbo].[Product] ([Id],[Name],[Description] ,[Price] ,[Category])
 VALUES (1,'Akbar','Phase','200', 1)
INSERT INTO [dbo].[Product] ([Id],[Name],[Description] ,[Price] ,[Category])
     VALUES (2,'Naman','Phase','200', 2)
INSERT INTO [dbo].[Product] ([Id],[Name],[Description] ,[Price] ,[Category])
     VALUES (3,'Aashish','Phase','200', 3)