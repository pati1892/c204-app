#!/bin/bash

location="westgermanycentral"
rg="pathenk"
as="appservice-pathenk"

# # Account set subscription
az account set --subscription "8537ded7-6867-4da0-b182-bb2fe3c7a315"

# # Create resource group
az create group --name $rg --location $location

# # Create service plan
az appserviceplan create --name $as --resource-name $rg --sku s1 --is-linux 
    # \ --per-site-scaling # enable app scaling on app level
