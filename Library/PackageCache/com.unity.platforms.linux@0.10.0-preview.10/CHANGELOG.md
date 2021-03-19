# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [0.10.0] - 2020-10-28
### Changed
- Bump minimum Unity version to `2020.1.2f1`.
- Updated `com.unity.platforms` package dependency.
- Updated `com.unity.platforms.desktop` package dependency.

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
- Updated `com.unity.platforms.desktop` package dependency.

## [0.5.0] - 2020-06-08

### Changed
- `Unity.Platforms.Linux` assembly renamed to `Unity.Build.Linux.DotsRuntime`.

## [0.4.1] - 2020-05-27

### Changed
- Update platforms packages to 0.4.1-preview
- Updated minimum Unity version to 2020.1.

## [0.4.0] - 2020-05-05

### Changed
- Updated `com.unity.platforms` package dependency.
- Updated `com.unity.platforms.desktop` package dependency.

## [0.3.1] - 2020-05-04

### Changed
- Update platforms packages to 0.3.1

## [0.3.0] - 2020-04-28

### Changed
- Updated `com.unity.platforms` package dependency.
- Updated `com.unity.platforms.desktop` package dependency.
- Build pipeline assets have been replaced by class based build pipelines.

## [0.2.2] - 2020-03-23

### Changed
- Updated `com.unity.platforms` package dependency.
- Updated `com.unity.platforms.desktop` package dependency.
- Renamed 'Linux .NET' build target to 'Linux .NET - Tiny'.
- Renamed 'Linux IL2CPP' build target to 'Linux IL2CPP - Tiny'.

### Added
- Added 'Linux .NET - .NET Standard 2.0' build target.

## [0.2.1] - 2020-02-25

### Changed
- Updated `com.unity.platforms` package version to `0.2.1-preview.7`.
- Updated `com.unity.platforms.desktop` package version to `0.2.1-preview.7`.
- Removed stdout redirect to Unity Console.

### Added
- Add a UsesIL2CPP property to BuildTarget.

## [0.2.1-preview] - 2020-01-24

### Changed
- Updated `com.unity.platforms` package version to `0.2.1-preview`.
- Updated `com.unity.platforms.desktop` package version to `0.2.1-preview`.

## [0.2.0-preview.1] - 2020-01-17

### Changed
- Updated `com.unity.platforms` package version to `0.2.0-preview.2`.
- Updated `com.unity.platforms.desktop` package version to `0.2.0-preview.1`.

## [0.2.0-preview] - 2020-01-13

### Changed
- Updated `com.unity.platforms` package version to `0.2.0-preview`.
- Updated `com.unity.platforms.desktop` package version to `0.2.0-preview`.

## [0.1.8-preview] - 2019-12-11

### Changed
- Bump com.unity.platforms version to 0.1.8-preview.

## [0.1.7-preview.3] - 2019-12-10

### Changed
- Updated `com.unity.platforms` to `0.1.7-preview.3`.

## [0.1.7-preview.2] - 2019-11-12

### Changed
- Made fields public on `DotsLinuxTarget`

## [0.1.7-preview] - 2019-10-25

### Changed
- Updated `com.unity.platforms` to `0.1.7-preview`.

## [0.1.6-preview] - 2019-10-23

### Added
- Added `CanBuild` property to all build targets.

### Changed
- Updated `com.unity.platforms` to `0.1.6-preview`.

## [0.1.5-preview] - 2019-10-22

### Changed
- Updated `com.unity.platforms` to `0.1.5-preview`.
- Linux build targets `HideInBuildTargetPopup` is now `false`.

## [0.1.4-preview] - 2019-09-26
- Bug fixes  
- Add iOS platform support
- Add desktop platforms package

## [0.1.3-preview] - 2019-09-03

- Bug fixes  

## [0.1.2-preview] - 2019-08-13

### Added

- The static property `BuildTarget.DefaultBuildTarget` is set to `DotNetLinuxBuildTarget` when running Unity editor on Linux platform.

### Changed

- Support for Unity 2019.1.

## [0.1.1-preview] - 2019-06-10

- Initial release of *Unity.Platforms.Linux*.
