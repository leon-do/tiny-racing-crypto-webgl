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
- `Unity.Platforms.Web` assembly renamed to `Unity.Build.Web.DotsRuntime`.
- `Unity.Platforms.Web.Build` collapsed into `Unity.Build.Web.DotsRuntime`.

## [0.4.1] - 2020-05-27

### Changed
- Update platforms packages to 0.4.1-preview
- Updated minimum Unity version to 2020.1.

## [0.4.0] - 2020-05-05

### Changed
- Updated `com.unity.platforms` package dependency.

### Fixed
- Fixed error if build and run tries to kill previous process which is already shutdown

## [0.3.1] - 2020-05-04

### Changed
- Update platforms packages to 0.3.1
- Updated `com.unity.platforms` package dependency.
- Build pipeline assets have been replaced by class based build pipelines.

### Fixed
- Fixed the windows paths for running the web server on "Build and Run"
- Fixed web build and run for different output paths
- Fixed web build and run then exit Unity editor

## [0.2.2] - 2020-03-23

### Changed
- Updated `com.unity.platforms` package dependency.
- Debug and develop builds now use `ASSERTIONS=1` instead of `ASSERTIONS=2` for web builds. `ASSERTIONS=2` is too heavy-weight and can prevent most builds from being parsed by the browser.

## [0.2.1] - 2020-02-25

### Added
- Added support for any emcc command line argument
- Updated `com.unity.platforms` package version to `0.2.1-preview.7`.
- Add a UsesIL2CPP property to BuildTarget

## [0.2.0-preview.1] - 2020-01-17

### Changed
- Updated `com.unity.platforms` package version to `0.2.0-preview.2`.

## [0.2.0-preview] - 2020-01-13

### Changed
- Updated `com.unity.platforms` package version to `0.2.0-preview`.

## [0.1.8] - 2019-12-17

### Changed
- Bump com.unity.platforms version to 0.1.8-preview
- Remove reference to com.unity.properties, since com.unity.platforms reference it
- Remove unused dependencies, like com.unity.entities
- Remove redundant sanity checks in emcc compiler

## [0.1.7-preview.6] - 2019-12-10

### Changed
- Fix package dependencies

## [0.1.7-preview.5] - 2019-12-10

### Changed
- Updated `com.unity.platforms` to `0.1.7-preview.3`.
## [0.1.7-preview.4] - 2019-11-21

### Changed
- Updated `Run` to open output folder, for now

## [0.1.7-preview.3] - 2019-11-12

### Changed
- Made fields public on `DotsWebTarget`
- Added Compatibility with new dots runtime build customization framework
- Removed old bad coupling with dots repo

## [0.1.7-preview.2] - 2019-11-04

### Changed
- Added build settings component for emscripten settings. 

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

## [0.1.4-preview] - 2019-09-26
- Bug fixes  
- Add iOS platform support
- Add desktop platforms package

## [0.1.3-preview] - 2019-09-03

- Bug fixes  

## [0.1.2-preview] - 2019-08-13

### Changed

- Support for Unity 2019.1.

## [0.1.1-preview] - 2019-06-10

- Initial release of *Unity.Platforms.Web*.
