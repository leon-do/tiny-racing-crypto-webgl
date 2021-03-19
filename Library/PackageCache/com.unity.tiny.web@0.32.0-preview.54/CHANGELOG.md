# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [0.32.0] - 2020-11-13

### Changed

* Update minimum editor version to 2020.1.2f1

### Fixed

* Eliminated the AudioContext warnings, related to trying to perform the audio unlock procedure right at startup.
* On iOS Safari, audio should now resume correctly in all cases after an app is back-grounded or the device is locked.



## [0.31.0] - 2020-09-24

### Fixed

* Fixed an issue which prevented the renderer from responding to changes to the screen dimensions.

## [0.30.0] - 2020-08-26

### Added

* Support for platform OnQuit and OnSuspendResume

## [0.29.0] - 2020-08-04

### Added

* Add support for managed code debugging with Wasm


## [0.28.0] - 2020-07-10

### Added

* Stats collection for audio
* Stats collection for textures

### Changed

* Updated minimum Unity Editor version to 2020.1.0b15 (40d9420e7de8)

## [0.27.0] - 2020-05-27

### Changed
* Updated minimum Unity Editor version to 2020.1.0b9 (9c0aec301c8d)

## [0.26.0] - 2020-05-15

### Changed

* Update package dependencies

## [0.25.0] - 2020-04-30
* Update package dependencies

## [0.24.0] - 2020-04-09
* Update package dependencies

## [0.23.0] - 2020-03-20
* Update package dependencies

## [0.22.0] - 2020-02-05

* Update package dependencies
* Fix a performance issue where a storm of repeated attempts to unlock the AudioContext would cause Firefox and Chrome to hang.
* Fix old browsers not necessarily having `AudioContext.resume()` or `AudioContext.suspend()` functionality.
* Properly initialize canvas size based on screen size and devicePixelRatio.  DisplayInfo.screenDpiScale can
be used to control the ratio of render resolution and display resolution.

## [0.21.0] - 2020-01-21

* Update package dependencies

## [0.20.0-preview.2] - 2019-12-10

* Update the package to use Unity '2019.3.0f1' or later
* This is the first release of Tiny for web support
