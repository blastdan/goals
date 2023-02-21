# Introduction

This application can be used with BambooHr to manage your goals in the performance module.

# Commands

-   whoami - Shows the user Id and name of the owner of the Api key

# Setup and Configuration

You need to apply the following configurations

1.  ApiKey
1.  SubDomain

You can supply this in either BambooHrSettings.json
Or the environment variables

-   bamboo_apikey
-   bamboo_subdomain

# Development

I have included user secrets to store the configuration values

```sh
dotnet user-secrets set "bamboo:subdomain" "{Your Value}"
dotnet user-secrets set "bamboo:apiKey" "{Your Value}"
```
