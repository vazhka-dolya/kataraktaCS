[Прочитать эту страницу по-русски](https://github.com/vazhka-dolya/kataraktaCS/blob/main/README.ru.md) | **Read this page in English**

# kataraktaCS
**kataraktaCS** (**kCS** for short) is an advanced, real-time texture editor for **Super Mario 64** machinimas. Originally starting off in 2023 as a separate, poorly written program simply called [**katarakta**](https://github.com/vazhka-dolya/katarakta), it has evolved over time, and is now a lightweight and full-featured [**Mario 64 Movie Maker 3**](https://github.com/projectcomet64/M64MM) add-on.

<p align="center">
  <img src="https://github.com/vazhka-dolya/kataraktaCS/blob/main/GitHubImg/kataraktaCS1.jpg"/>
</p>
<div align="center">
  <h6>The stage seen on the screenshot is a slightly modified version of Sunny Beach from the Super Mario 74 ROM hack</h6>
</div>

# Installing
1. Make sure you have the [latest version](https://github.com/projectcomet64/M64MM/releases/latest) of M64MM3 installed.
2. Download the [latest version](https://github.com/vazhka-dolya/kataraktaCS/releases/latest) of the add-on. It will be in an archive.
3. Extract the downloaded archive's contents[^1] into the root folder[^2] of M64MM3. If it prompts you to replace files, then do it.
4. That's all.

# Using
kataraktaCS is designed to be (more or less) intuitive, but if you don't understand something, then you can refer to the [Wiki](https://github.com/vazhka-dolya/kataraktaCS/wiki). Also note that some text shows additional information when you hover over it.

# Building prerequisites
<details>
  <summary>Click here to view</summary>
  
- Visual Studio 2022.
- M64MM3's repository in a folder called `M64MM` outside of where this repository is.
  - Example: if the `.sln` for kataraktaCS is in `C:/projects/kataraktaCS/kataraktaCS.sln`, the whole M64MM3 repository must be in `C:/projects/M64MM`.
- If you're on Windows, then, before extracting the archive, make sure to right-click the archive, open **Properties** and see if you have an **Unblock** checkbox. If you do, tick it and press **Apply**. If you don't do this and the archive remains blocked, you may run into issues.
- *Depending on the circumstances*, you *may* have to do the following: go to **Menu** > **Tools** > **NuGet Package Manager** > **Package Manager Console** and enter `Install-Package HtmlRenderer.WinForms`. After that, go to **Menu** > **Project** > **Manage NuGet Packages…**, and make sure that both `HtmlRenderer.Core` and `HtmlRenderer.WinForms` are up-to-date.

</details>

# Special thanks & miscellaneous
- [SDRM45](https://www.youtube.com/channel/UC-3gc0FmQA2_Z2-MIS5sZNQ), [SMG1](https://www.youtube.com/channel/UCSHE37xuK4tKMEIJwpXGVOw), and [14O7](https://www.youtube.com/channel/UCU5kWc-wqBOiAwDYPRvhCHg) — for testing the add-on.

Please star this repository if you found kataraktaCS useful!

Also check out my other add-ons for [M64MM3](https://github.com/projectcomet64/M64MM)—[BodyStates](https://github.com/vazhka-dolya/bodystates), [Tiny-Huge Tweaks](https://github.com/vazhka-dolya/TinyHugeTweaks), [ChameleonCK](https://github.com/vazhka-dolya/ChameleonCK), and [Shapeshift](https://github.com/vazhka-dolya/Shapeshift)!

### “If I use kataraktaCS for my work, do I have to credit you?”
Credit is highly appreciated, but completely optional!

[^1]: That means *all* the contents, including the `deps` folder. If it crashes when opening the **About** window, make sure that you have `HtmlRenderer.dll` and `HtmlRenderer.WinForms.dll` in M64MM's `deps` folder.
[^2]: That's the same folder where the `M64MM.exe` file is located.
