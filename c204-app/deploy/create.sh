#!/bin/bash

location="germanywestcentral"
rg="pathenk"
as="appservice-pathenk"

# # Account set subscriptio

# # Create resource group
az group create --name $rg --location $location

# # Create service plan
az appservice plan create --name $as --resource-group $rg --sku s1 --is-linux 
    # \ --per-site-scaling # enable app scaling on app level


webappname="webapp-web"
# # Create web app
az webapp list-runtimes # list runtimes
az webapp create --name $webappname --plan $as --resource-group $rg --runtime "DOTNET|5.0" \
    --deployment-source-url https://github.com/pati1892/c204-app
# Use deployment-source-url or
# az webapp deployment source config --name $webapp_name --resource-group $rg \
#     --repo-url https://github.com/pati1892/aspnetcore3.1 --branch master --manual-integration