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
- `Unity.Platforms.Android` assembly renamed to `Unity.Build.Android.DotsRuntime`.
- `Unity.Platforms.Android.Build` assembly split into `Unity.Build.Android` and `Unity.Build.Android.Classic`.

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

- Added device/screen orientation support
- Added motion sensors support
- Enable burst for android

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
- Fixed issues with run steps and targets with `.` in them

## [0.2.0-preview.3] - 2020-01-17

### Changed
- Updated `com.unity.platforms` package version to `0.2.0-preview.2`.

## [0.2.0-preview.2] - 2020-01-16

### Fixed
- Fix warning "Couldn't delete Packages/com.unity.platforms.android/Editor/Unity.Build.Android.meta because it's in an immutable folder."

## [0.2.0-preview.1] - 2020-01-15

### Added
- Suspend/Resume/Quit events support
- Android toolchain code simplified
- Updated `com.unity.platforms` package version to `0.2.0-preview.1`.

## [0.2.0-preview] - 2020-01-13

### Changed
- Updated `com.unity.platforms` package version to `0.2.0-preview`.

## [0.1.8-preview.2] - 2019-12-16

### Changed
- Statically link all code to one dynamic library

## [0.1.8-preview.1] - 2019-12-12

### Changed
- Fixed problem with replacing APK on a device if this app has been previously installed from another computer 
- Fixed problem with memory allocation when loading assets

## [0.1.8-preview] - 2019-12-11

### Changed
- Bump com.unity.platforms version to 0.1.8-preview

## [0.1.7-preview.6] - 2019-12-09

### Changed
- Rename the rendering library dependency 

## [0.1.7-preview.5] - 2019-12-04

### Changed
- Fix errors shown while building other platforms if the Android toolchain is not installed.

## [0.1.7-preview.4] - 2019-11-28

### Changed
- Got rid of GLES dependency
- Disabled thumb for Debug configuration to solve problem with Android Studio debugging
- Fixed problem with device volume keys not working

## [0.1.7-preview.3] - 2019-11-19

### Changed
- Show errors if `AndroidApkToolchain` is not found

## [0.1.7-preview.2] - 2019-11-12

### Changed
- Made `Identifier` and `Toolchain` public on `DotsAndroidTarget`
- Draft keyboard support is implemented
- Suspend/Resume support is implemented

## [0.1.7-preview] - 2019-10-25

### Added
- Added `WriteBeeConfigFile` method to pass Android SDK/NDK/JDK/Gradle paths to Bee

### Changed
- Updated `AndroidApkToolchain` to use Android SDK/NDK/JDK/Gradle from androidsettings.json file
- Updated `AndroidApkToolchain` to use NDK r19
- Updated `com.unity.platforms` to `0.1.7-preview`.

## [0.1.6-preview] - 2019-10-23

### Added
- Added `CanBuild` property to all build targets.

### Changed
- Updated `com.unity.platforms` to `0.1.6-preview`.

## [0.1.5-preview] - 2019-10-22

### Changed
- Updated `com.unity.platforms` to `0.1.5-preview`.

## [0.1.4-preview] - 2019-09-26
- Bug fixes  
- Add iOS platform support
- Add desktop platforms package

## [0.1.3-preview] - 2019-09-03

- Bug fixes  

## [0.1.2-preview] - 2019-08-13

### Changed

- Support for Unity 2019.1.

## [0.1.1-preview] - 2019-07-01

- Initial release of *Unity.Platforms.Android*.
