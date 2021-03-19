# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [0.10.0] - 2020-10-28
### Changed
- Bump minimum Unity version to `2020.1.2f1`.
- Updated `com.unity.platforms` package dependency.

## [0.9.0] - 2020-08-28
### Changed
- Update platforms packages to 0.9.0-preview

## [0.8.0] - 2020-08-07
### Changed
- Update platforms packages to 0.8.0-preview

## [0.7.0] - 2020-07-13
### Changed
- Update platforms packages to 0.7.0-preview

## [0.6.0] - 2020-07-07

### Changed
- Updated `com.unity.platforms` package dependency.

## [0.5.0] - 2020-06-08

### Changed
- `Unity.Platforms.IOS` assembly renamed to `Unity.Build.iOS.DotsRuntime`.
- `Unity.Platforms.IOS.Build` assembly renamed to `Unity.Build.iOS.Classic`.

## [0.4.1] - 2020-05-27

### Changed
- Update platforms packages to 0.4.1-preview
- Updated minimum Unity version to 2020.1.

## [0.4.0] - 2020-05-05

### Changed
- Updated `com.unity.platforms` package dependency.

## [0.3.1] - 2020-05-04

### Changed
- Update platforms packages to 0.3.1

## [0.3.0] - 2020-04-28

### Changed
- Updated `com.unity.platforms` package dependency.
- Build pipeline assets have been replaced by class based build pipelines.

## [0.2.2] - 2020-03-23

### Added
- Added device/screen orientation support
- Added motion sensors support

### Changed
- Updated `com.unity.platforms` package dependency.

## [0.2.1] - 2020-02-25

### Changed
- Updated `com.unity.platforms` package version to `0.2.1-preview.7`.

### Added
- Add a UsesIL2CPP property to BuildTarget

## [0.2.1-preview] - 2020-01-24

### Changed
- Updated `com.unity.platforms` package version to `0.2.1-preview`.

### Fixed
- Fixed issues with run steps and targets with `.` in the name.

## [0.2.0-preview.2] - 2020-01-17

### Changed
- Updated `com.unity.platforms` package version to `0.2.0-preview.2`.

## [0.2.0-preview.1] - 2020-01-15

### Added
- Suspend/Resume/Quit events support
- iOS toolchain code simplified
- Updated `com.unity.platforms` package version to `0.2.0-preview.1`.

## [0.2.0-preview] - 2020-01-13

### Changed
- Updated `com.unity.platforms` package version to `0.2.0-preview`.

## [0.1.8-preview.1] - 2019-12-16

### Changed
- Re-implementing `Using static libs in XCode project instead of dynamic`
- Fixed problem with resources which are not packed to Data files

## [0.1.8-preview] - 2019-12-11

### Changed
- Bump com.unity.platforms version to 0.1.8-preview

## [0.1.7-preview.10] - 2019-12-11

### Changed
- Revert `Using static libs in XCode project instead of dynamic`

## [0.1.7-preview.9] - 2019-12-10

### Changed
- Updated `com.unity.platforms` to `0.1.7-preview.3`.

## [0.1.7-preview.8] - 2019-12-09

### Changed
- Using static libs in XCode project instead of dynamic
- Forced OpenGLES for A7/A8 devices, should be reverted once problem with Metal are solved

## [0.1.7-preview.7] - 2019-12-05

### Changed
- Added missing launch screens for iPhone and iPad to template iOS project

## [0.1.7-preview.6] - 2019-12-04

### Changed
- Added missing file to template iOS project

## [0.1.7-preview.5] - 2019-11-21

### Changed
- Default icons added to template iOS project
- Basic multi-touch support is implemented
- Applications running full-screen on all devices support

## [0.1.7-preview.4] - 2019-11-21

### Changed
- Updated `Run` to open output folder, for now

## [0.1.7-preview.3] - 2019-11-12

### Changed
- Made `Identifier` and `Toolchain` public on `DotsIOSTarget`
- Get rid of iOS platform Run support (due to `ios-deploy` inconsistent behavior)
- `IOSAppToolchain` exports XCode project and opens it in Finder window

## [0.1.7-preview.2] - 2019-11-08

### Changed
- Improved error message when xcode installation is wrong

## [0.1.7-preview] - 2019-10-25

### Changed
- Updated `IOSAppToolchain` to use system iOS SDK
- Updated `com.unity.platforms` to `0.1.7-preview`.

## [0.1.6-preview] - 2019-10-23

### Added
- Added `CanBuild` property to all build targets.

### Changed
- Updated `com.unity.platforms` to `0.1.6-preview`.

## [0.1.5-preview] - 2019-10-22

### Changed
- Updated `com.unity.platforms` to `0.1.5-preview`.
- iOS build targets `HideInBuildTargetPopup` is now `false`.

## [0.1.4-preview] - 2019-09-26
- Bug fixes  
- Add iOS platform support
- Add desktop platforms package

## [0.1.3-preview] - 2019-09-03
Initial release
