# Hackathon Submission Entry form



## Team name
⟹ Les Miserables

## Category
⟹ Extend MVP Site

## Description
  - To add a search feature to MVP site for searching the publications and blogs of MVPs
  - The problem to be solved was getting the content of the blogs and extracting the key phrases and searchable content from Html pages of the blogs
    - By making use of Azure Cognitive Search and AI enrichments reading html blobs from an Azure Storage Account

_You can alternately paste a [link here](#docs) to a document within this repo containing the description._

## Video link

⟹ #https://youtu.be/OL8gBH3tWHA



## Pre-requisites and Dependencies

- Sitecore Rendering Host
- Azure Cognitive Search Service
- Azure Blob Storage

Pre-Requisites:

- [.NET Core (>= v 3.1) and .NET Framework 4.8](https://dotnet.microsoft.com/download)
- [MKCert](https://github.com/FiloSottile/mkcert)
- Approx 40gb HD space
- [Okta Developer Account](https://developer.okta.com/signup/)


## Installation instructions

1. Before you can run the solution, you will need to prepare the following
   for the Sitecore container environment:
   * A valid/trusted wildcard certificate for `*.sc.localhost`
   * Hosts file entries for
     * mvp-cd.sc.localhost
     * mvp-cm.sc.localhost
     * mvp-id.sc.localhost
     * mvp.sc.localhost
    
   * Required environment variable values in `.env` for the Sitecore instance
     * (Can be done once, then checked into source control.)

   See Sitecore Containers documentation for more information on these
   preparation steps. The provided `init.ps1` will take care of them,
   but **you should review its contents before running.**

   > You must use an elevated/Administrator Windows PowerShell 5.1 prompt for
   > this command, PowerShell 7 is not supported at this time.

    ```ps1
    .\init.ps1 -InitEnv -LicenseXmlPath "C:\path\to\license.xml" -AdminPassword "DesiredAdminPassword"
    ```

2. At the bottom of the `.env` file you'll find the section for your Okta developer account details. You will need to populate the following values:
   - OKTA_DOMAIN (*must* include protocol, e.g. `OKTA_DOMAIN=https://dev-your-id.okta.com`)
   - OKTA_CLIENT_ID
   - OKTA_CLIENT_SECRET

Note that DOCKER_RESTART defaults to no but can point to always or other values as per this page - https://docs.docker.com/config/containers/start-containers-automatically/

3.   After completing this environment preparation, run the startup script
   from the solution root:
    ```ps1
    .\up.ps1
    ```
Note that the up.ps1 script now automatically detects:
- if running Docker linux daemon and switches to Windows
- and stops IIS if it is running in the machine

4. When prompted, log into Sitecore via your browser, and
   accept the device authorization.

5. Wait for the startup script to open browser tabs for the rendered site
   and Sitecore Launchpad.


## Usage instructions
⟹ ![Documentation](https://github.com/Sitecore-Hackathon/2022-Les-Miserables/blob/main/docs/Extend%20MVP%20Site%20-%20MVP%20Blog%20Search%20Documentation.docx")






