# AdissParser

View the website of the documentation [here](https://gldd-se.github.io/AdissParser/).

## Building from source

The following are prerequisites to work with ADISS Parser code:
- [Visual Studio 2017 15.3](https://visualstudio.microsoft.com/downloads/)
- [.NET Framework 4.7.2 Developer Pack](https://www.microsoft.com/net/download/windows)
- [GLDD Sign Tool](https://gldd-se.github.io/help/gldd-sign-tool/)

The following are additional prerequisites to build an installer (.msi):
- [WiX Toolset 3.11.1](http://wixtoolset.org/releases/)

## Deployment

Deployment is done by building an installer (.msi) and uploading it to the [Site Engineering Bullseye assets page](https://bullseye.gldd.com/TeamSites/SiteEngineering/SiteAssets/Forms/AllItems.aspx?FolderCTID=0x012000CA6A6928D6F55B4E9B380803CE108D3D&InitialTabId=Ribbon%2EDocument&VisibilityContext=WSSTabPersistence&View={228f83b2-13ae-4670-9c27-76e31cc5c8c3}&RootFolder=%2FTeamSites%2FSiteEngineering%2FSiteAssets%2FPages%2FInstallation-Programs&SortField=Modified&SortDir=Desc). The installer download link can be sent out to the users via email to notify them an update. The latest released installer is [AdissParser.0.1.15](https://bullseye.gldd.com/TeamSites/SiteEngineering/SiteAssets/Pages/Installation-Programs/AdissParser.0.1.15.msi.zip).

To run a complete build on command line only, execute `src\Installer\build.bat`. This will execute only the part of the build script that downloads and initializes a few required build tools and packages. The output installer file will be located in `src\Installer\bin\Release\AdissParser.msi`. When sending an installer for an update to the user, make sure to update the `Product.Id` and `Product.Version` defined in `src\Installer\Product.wxs` (read the [WiX documentation](http://wixtoolset.org/documentation/) for more info).
