# LegendOfXR

XR 스튜디오 교육과 실습을 위한 VR 교육 게임입니다. VR 헤드셋과 컨트롤러를 이용해 가상 환경에서 XR 스튜디오 콘텐츠를 체험합니다.

## 프로젝트 배경

메타버스 학회 메타몽 소속 팀 Ditto가 한국연구재단 주최 제3회 첨단분야 혁신융합대학 메타버스 콘테스트에 참가하여 우수상을 수상한 프로젝트입니다. Unity 경험이 다양한 팀원들과 교육 콘텐츠의 기획과 구현을 함께 진행했습니다.

## 팀

Ditto(메타버스 학회 메타몽) — 김영빈, 김강산, 이영성, 이지성, 전은인

## 개발 환경

| 항목 | 값 |
| --- | --- |
| Unity Editor | **2021.3.27f1** |
| Unity 프로젝트 폴더 | `Ditto_copy/` |
| 기본 브랜치 | `MainBranch` |

Unity 버전은 [ProjectVersion.txt](Ditto_copy/ProjectSettings/ProjectVersion.txt)에 기록된 값을 기준으로 합니다.

- VR 헤드셋 및 컨트롤러
- Git: glTFast 및 Ready Player Me Git 패키지 의존성 복원용
- 선택한 VR 기기에 맞는 런타임과 Unity 빌드 모듈

## 시작하기

```bash
git clone --branch MainBranch https://github.com/ReYoungSung/LegendOfXR.git
```

1. Unity Hub에 위 버전의 Editor를 설치합니다.
2. 저장소 안의 `Ditto_copy` 폴더를 프로젝트로 추가합니다. 저장소 최상위 폴더와 Unity 프로젝트 폴더는 서로 다릅니다.
3. 최초 임포트와 Package Manager의 패키지 복원을 완료합니다.
4. `Assets/Scenes/StartScene.unity`을 열고 Play를 실행합니다.

빌드 씬 순서는 `StartScene` → `XR_Studio_Combined` → `EndScene`입니다. 임포트 후 Project Settings의 XR Plug-in Management에서 대상 플랫폼의 설정을 확인하고, 헤드셋과 컨트롤러를 연결해 시작 씬부터 실행합니다.

빌드 구성은 [EditorBuildSettings.asset](Ditto_copy/ProjectSettings/EditorBuildSettings.asset), 패키지 목록은 [manifest.json](Ditto_copy/Packages/manifest.json)에서 확인할 수 있습니다. 아래 `Assets/` 경로는 Unity 프로젝트 폴더 기준입니다.

## 주요 폴더

| 경로 | 내용 |
| --- | --- |
| [Assets/Scenes/](Ditto_copy/Assets/Scenes/) | 시작·XR 스튜디오·종료 씬 |
| [Assets/Scripts/](Ditto_copy/Assets/Scripts/) | 프로젝트 스크립트 |

## 주요 패키지

| 패키지 | 저장소 설정 |
| --- | --- |
| XR Interaction Toolkit | 2.4.3 |
| XR Plug-in Management | 4.4.0 |
| Oculus XR Plugin | 3.3.0 |
| OpenXR Plugin | 1.7.0 |

전체 의존성은 `Packages/manifest.json`을 기준으로 복원합니다. 개별 패키지를 최신 버전으로 교체하기 전에 프로젝트 호환성을 확인합니다.

## 사용법

### 교육 콘텐츠 진행

1. VR 헤드셋과 양손 컨트롤러를 연결한 뒤 시작 씬을 실행합니다.
2. 시작 화면의 안내와 튜토리얼을 따라 XR 스튜디오 씬으로 진행합니다.
3. 메뉴에서 이동할 안내 대상을 선택하고 내비게이션 화살표가 가리키는 목표를 확인합니다.
4. 실습 장비와 상호작용하며 화면에 표시되는 미션을 수행합니다. 카메라 실습에서는 장비를 선택한 뒤 활성화 입력으로 카메라 시점과 UI를 표시하고, 활성화를 해제하면 기본 시점으로 돌아옵니다.
5. 각 미션의 완료 표시를 확인하며 다음 안내를 진행합니다.

| 기능 | 조작 |
| --- | --- |
| 메뉴 표시·숨기기 | `GameMenuManager.showButton`에 연결된 입력 |
| 안내 목표 선택 | 내비게이션 UI에서 목표 선택 |
| 카메라 실습 시점 전환 | 장비의 Activate 입력; Deactivate 시 기본 시점 복귀 |

메뉴는 머리 앞쪽에 나타나도록 배치됩니다. 메뉴 버튼과 장비 활성화 버튼은 씬의 Input Action 바인딩에 따라 달라집니다. 특정 A/B 버튼이나 트리거를 고정값으로 가정하지 말고 해당 씬의 설정과 기기 안내를 확인합니다.

장비 선택이 안 되면 컨트롤러 추적과 XR Interactor/Interactable 연결을 확인합니다. 화살표가 보이지 않으면 안내 기능의 표시 상태와 선택한 목표를 확인합니다. Editor 체험 종료는 Play를 끄면 됩니다.

동작 기준: [GameMenuManager.cs](Ditto_copy/Assets/Scripts/GameMenuManager.cs) · [NavSystem.cs](Ditto_copy/Assets/Scripts/NavSystem.cs) · [CameraGrabInteractable.cs](Ditto_copy/Assets/Scripts/CameraGrabInteractable.cs)
