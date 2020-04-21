<!-- Metadata 
{
  "order": 1,
  "title": "Ant Design - Blazor"
}
-->
<div align="center">
  <img src="https://github.com/Append-IT/ant-design-blazor/blob/master/infrastructure/ant-design-blazor-logo.svg">
  <h3>Ant Design Blazor</h3>
  <span>A Blazor Component Library based on Ant Design</span>
</div>

Following the Ant Design specification, we developed a Blazor component library `ant-design-blazor` that contains a set of high quality components and demos for building rich, interactive user interfaces.

<div align="center">

## ✨ Features

- 🌈 Enterprise-class UI designed for web applications.
- 📦 Out-of-the-box, high-quality Blazor components that can be shared in **all** hosting models.
- 🛡 Written in C# with predictable static types, JavaScript is kept to a bare minimum.
- ⚙️ Whole package of design resources and development tools.
- 🌍 Icons and styles are synchronized with the core libraries of Ant Design.
- 🎨 Powerful theme customization.

## Environment Support

- .NET Core 3.1
- Blazor WebAssembly 3.2 Preview 4.
- Support for server-side environments.
- Support for WebAssembly static file deployments.
- Support for 4 major browsers engines, and Internet Explorer 11+ ([Blazor server-side](https://docs.microsoft.com/en-us/aspnet/core/blazor/supported-platforms?view=aspnetcore-3.1) only).
- Runs directly on [Electron](http://electron.atom.io/) and other Web standard-based environments like [Web Window](https://github.com/SteveSandersonMS/WebWindow).

| [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/edge/edge_48x48.png" alt="IE / Edge" width="24px" height="24px" />](http://godban.github.io/browsers-support-badges/)</br> Edge / IE | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/firefox/firefox_48x48.png" alt="Firefox" width="24px" height="24px" />](http://godban.github.io/browsers-support-badges/)</br>Firefox | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/chrome/chrome_48x48.png" alt="Chrome" width="24px" height="24px" />](http://godban.github.io/browsers-support-badges/)</br>Chrome | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/safari/safari_48x48.png" alt="Safari" width="24px" height="24px" />](http://godban.github.io/browsers-support-badges/)</br>Safari | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/opera/opera_48x48.png" alt="Opera" width="24px" height="24px" />](http://godban.github.io/browsers-support-badges/)</br>Opera | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/electron/electron_48x48.png" alt="Electron" width="24px" height="24px" />](http://godban.github.io/browsers-support-badges/)</br>Electron |
| :---------: | :---------: | :---------: | :---------: | :---------: | :---------: |
| Edge 16 / IE 11† | 522 | 57 | 11 | 44 | Chromium 57

> Due to the [WebAssembly](https://webassembly.org) restriction, Blazor WebAssembly doesn't support Internet Explore, but Blazor Server supports IE 11† with additional polyfills. See [official documentation](https://docs.microsoft.com/en-us/aspnet/core/blazor/supported-platforms?view=aspnetcore-3.1) 

## Examples

WebAssembly static hosting examples on GitHub Pages:

- [GitHub](https://append-it.github.io/ant-design-blazor)

## Version
- Install-Package Append.AntDesign -Version 1.0.0
## Installation

- Install [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1) 3.1.201 or later

- Install the Blazor WebAssembly Templates

  ```bash
  $ dotnet new -i Microsoft.AspNetCore.Components.WebAssembly.Templates::3.2.0-preview4.20210.8
  ```

- Create a Blazor WebAssembly Project

  ```bash
  $ dotnet new blazorwasm -o YourCoolApp
  ```
  
- Go to the project folder of the application and install the Nuget package reference

  ```bash
  $ cd YourCoolApp
  $ dotnet add package Append.AntDesign
  ```

- Register the services

  ```csharp
  services.AddAntDesign();
  ```

- Link the static files in `wwwroot/index.html` (WebAssembly) or `Pages/_Host.razor` (Server)

  ```html
    <link rel="stylesheet" href="_content/Append.AntDesign.Documentation/css/documentation-styles.min.css" />
    <script type="text/javascript" src="_content/Append.AntDesign/js/scripts.min.js"></script>
    <!-- Blazor Framework Script Here -->
  ```
  > Later we'll compress and package the js files.

- Add namespace in `_Imports.razor`

  ```razor
  @using AntDesign.Components
  @using AntDesign.Services
  ```

- Finally, use any of the components

  ```html
  <Button Type="ButtonType.Primary" Label="Hello Ant Design">
    <Icon Type="IconType.Outlined.GitHub"/>
  </Button>
  ```

## Local Development

- Install [.NET Core SDK](https://dotnet.microsoft.com/download) 3.1.102 or later.
- Clone to local development


  ```bash
  $ git clone https://github.com/Append-IT/ant-design-blazor.git
  ```
- Run the `Append.AntDesign.Standalone` or `Append.AntDesign.Server`
- Visit https://localhost:5001 in your supported browser.
  
  > The latest version of Visual Studio 2019 is recommended for development.


## Links

- [Ant Design Blazor Documentation](https://append-it.github.io/ant-design-blazor)
- [Official Ant Design Home page](https://ant.design/)
- [Official Blazor Documentation](https://blazor.net)
- [Ant Design Icons](https://github.com/ant-design/ant-design-icons)
- [Ant Design Colors](https://github.com/ant-design/ant-design-colors)
- [Dark Theme](https://github.com/ant-design/ant-design-dark-theme)
- [Landing Pages](https://landing.ant.design)
- [Motion](https://motion.ant.design)

## Contributing

If you'd like to help us improve `ant-design-blazor`, just create a [Pull Request](https://github.com/append-it/ant-design-blazor/pulls). Feel free to report bugs and issues [here](https://github.com/Append-IT/ant-design-blazor/issues/new).

> If you're new to posting issues, we ask that you read [_How To Ask Questions The Smart Way_](http://www.catb.org/~esr/faqs/smart-questions.html) and [How to Ask a Question in Open Source Community](https://github.com/seajs/seajs/issues/545) and [How to Report Bugs Effectively](http://www.chiark.greenend.org.uk/~sgtatham/bugs.html) prior to posting. Well written bug reports help us help you!
