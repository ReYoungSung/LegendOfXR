[한국어](README.md) | **English**

# LegendOfXR

A VR educational game for learning and practicing XR studio workflows. Users explore XR studio content in a virtual environment with a VR headset and controllers.

## Background

Team Ditto, part of the Metamong metaverse student group, received an Excellence Award at the Third Advanced-field Innovation Convergence University Metaverse Contest hosted by the National Research Foundation of Korea. Team members with different levels of Unity experience collaborated on planning and implementing the educational content.

## Team

Ditto (Metamong metaverse student group) — 김영빈, 김강산, 이영성 (Youngsung Ree), 이지성, 전은인

## Development environment

| Item | Value |
| --- | --- |
| Unity Editor | **2021.3.27f1** |
| Unity project folder | `Ditto_copy/` |
| Default branch | `MainBranch` |

The Unity version is taken from [ProjectVersion.txt](Ditto_copy/ProjectSettings/ProjectVersion.txt).

- VR headset and controllers
- Git for restoring glTFast and Ready Player Me Git package dependencies
- Runtime and Unity build modules for the selected VR device

## Getting started

```bash
git clone --branch MainBranch https://github.com/ReYoungSung/LegendOfXR.git
```

1. Install the Editor version above through Unity Hub.
2. Add the repository's `Ditto_copy` folder as a project. The repository root and Unity project folder are different.
3. Complete the initial import and Package Manager dependency restoration.
4. Open `Assets/Scenes/StartScene.unity` and enter Play mode.

The build scene order is `StartScene` → `XR_Studio_Combined` → `EndScene`. After import, check the target platform under Project Settings → XR Plug-in Management. Connect the headset and controllers and begin from the start scene.

See [EditorBuildSettings.asset](Ditto_copy/ProjectSettings/EditorBuildSettings.asset) for build configuration and [manifest.json](Ditto_copy/Packages/manifest.json) for dependencies. The `Assets/` paths below are relative to the Unity project folder.

## Main folders

| Path | Contents |
| --- | --- |
| [Assets/Scenes/](Ditto_copy/Assets/Scenes/) | Start, XR studio, and ending scenes |
| [Assets/Scripts/](Ditto_copy/Assets/Scripts/) | Project scripts |

## Main packages

| Package | Repository version |
| --- | --- |
| XR Interaction Toolkit | 2.4.3 |
| XR Plug-in Management | 4.4.0 |
| Oculus XR Plugin | 3.3.0 |
| OpenXR Plugin | 1.7.0 |

Restore all dependencies from `Packages/manifest.json`. Check project compatibility before upgrading individual packages to the latest version.

## Usage

### Educational flow

1. Connect the VR headset and both controllers, then run the start scene.
2. Follow the opening instructions and tutorial to enter the XR studio scene.
3. Choose a navigation target from the menu and locate the destination indicated by the arrow.
4. Interact with the training equipment and complete the displayed missions. In camera practice, select the equipment and use its Activate input to show the camera view and UI. Deactivating it returns to the default view.
5. Check each mission's completion indicator and continue to the next instruction.

| Feature | Control |
| --- | --- |
| Show/hide the menu | Input assigned to `GameMenuManager.showButton` |
| Choose a destination | Select a target in the navigation UI |
| Switch to the practice camera view | Equipment Activate input; Deactivate restores the default view |

The menu is positioned in front of the user's head. Menu and equipment-activation buttons depend on the scene's Input Action bindings. Do not assume a fixed A/B button or trigger; check the scene configuration and device instructions.

If equipment cannot be selected, check controller tracking and XR Interactor/Interactable connections. If the navigation arrow is missing, check whether navigation is visible and which target is selected. Exit Play mode to end the experience in the Editor.

Behavior references: [GameMenuManager.cs](Ditto_copy/Assets/Scripts/GameMenuManager.cs) · [NavSystem.cs](Ditto_copy/Assets/Scripts/NavSystem.cs) · [CameraGrabInteractable.cs](Ditto_copy/Assets/Scripts/CameraGrabInteractable.cs)
