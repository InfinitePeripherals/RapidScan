# RapidScan
![alt text](https://github.com/InfinitePeripherals/RapidScan/blob/main/docs/img/RapidScanGlobe.png?raw=true)

RapidScan is an innovative product bringing the power of backend services directly to the HaloRing (no frontend Android development required). RapidScan will forward barcodes or camera image (+the selected action) to the appropriate backend services using Bluetooth, BLE, WiFi+REST, or WiFi+MQTT for processing. These services can then respond with a "card" describing what to display on the Halo's screen using a simple markup language called RiSL (Ring Scanner Language).

*This is a "NO HALORING DEVELOPMENT NEEDED" path.*

## Concepts
| Concept    | Description                                                                                                |
| ---------- | ---------------------------------------------------------------------------------------------------------- |
| HaloCard   | A "card" or "screen" to display on the HaloRing.  Can include buttons, graphics, labels etc.  Can also include a ZPL instructions to print |
| Verb / ScanAction | A verb/scan action is a menu item that the user selected prior to scanning or picture taken.  Examples might include Price Lookup, Warranty Lookup etc. The ScanActions are configured by MDM or by scanning a QR Config Code|
| SmartMode  | RapidScan sends Scans/Pics to Backend Systems using WIFI + REST/MQTT. These system then answer with a HaloCard to display (after BusinessLogic). |
| CompanionMode | RapidScan sends Scans/Pics to a connected device like a PC, IOS, or Android phone.  The connected device can thin run BusinessLogic and compose a HaloCard to display |
| RISL (Ring Scanner Language) | - a simple markup language that defines screens to show or printjobs to print on the HaloRing |

## Getting Started

For guides on how to get started with RapidScan, check out the links below.

- [RapidScan Quick Start Guide](https://github.com/InfinitePeripherals/RapidScan/blob/main/docs/IPC-RapidScan-QuickStart-1.3.pdf)
- [Bluetooth SPP Guide](https://github.com/InfinitePeripherals/RapidScan/blob/main/docs/IPC-RapidScan-SPP-1.4.pdf)

## Documentation

For a more in-depth look at RiSL and its capabilities, check out the programming guide below.

- [RiSL Programming Guide](https://github.com/InfinitePeripherals/RapidScan/blob/main/docs/IPC-RapidScan-RiSL-1.3.pdf)

## Getting Help

- If you have questions, email us at [mobilesupport@ipcmobile.com](mailto:mobilesupport@ipcmobile.com)
- You can also contact Infinite Peripherals at 001.949.222.0300

## Demo Apps

- MQTT Dashboard Demo - [Dashboard](https://airscan.ipcmobile.com/)
- BLE Demo App - [Overview]()
- C# Demo App - [Overview]()
