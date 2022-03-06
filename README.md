# 🥇 Extending Sitecore MVP Program Site

# 💗 Contributions

MVP Site is extended to include search feature in the MVP's publications. Users are able to search the contents of the articles published by MVPs using Azure Cognitive Search

# ✋ PreRequisites
- [.NET Core (>= v 3.1) and .NET Framework 4.8](https://dotnet.microsoft.com/download)
- [MKCert](https://github.com/FiloSottile/mkcert)
- Approx 40gb HD space
- [Okta Developer Account](https://developer.okta.com/signup/)

# 💻 Initial Setup

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


