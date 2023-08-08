# RapidScan
![alt text](https://github.com/InfinitePeripherals/RapidScan/blob/main/docs/img/RapidScanGlobe.png?raw=true)

RapidScan is an innovative product bringing the power of backend services directly to the HaloRing (no frontend Android development required). RapidScan will forward barcodes or camera image (+the selected action) to the appropriate backend services using Bluetooth, BLE, WiFi+REST, or WiFi+MQTT for processing. These services can then respond with a "card" describing what to display on the Halo's screen using a simple markup language called RiSL (Ring Scanner Language).

Rapid Development: *This is a "NO HALORING DEVELOPMENT NEEDED" path.*

## Concepts
| Concept    | Description                                                                                                |
| ---------- | ---------------------------------------------------------------------------------------------------------- |
| HaloCard   | A "card" or "screen" to display on the HaloRing.  Can include buttons, graphics, labels etc.  Can also include a ZPL instructions to print |
| Verb / ScanAction | A verb/scan action is a menu item that the user select prior to scanning or picture taken.  Example verbs might include Price Lookup, Warranty Lookup etc. The ScanActions are configured by MDM or by scanning a QR Config Code.  Whereas old art scanners just forward barcode+symbology, RapidScan forwards barcode+symbology+verb so the upstream system can route to the appriopiate buisiness logic.|
| SmartMode  | RapidScan sends Scans/Pics to Backend Systems using WIFI + REST/MQTT. These system then answer with a HaloCard to display (after BusinessLogic). |
| CompanionMode | RapidScan sends Scans/Pics to a connected device like a Mac, PC, IOS, or Android phone.  The connected device can thin run BusinessLogic and compose a HaloCard to display |
| RISL (Ring Scanner Language) | a simple markup language that defines screens to show or printjobs to print on the HaloRing |
| RapidConnect | RapidScan can be easily configured using QR codes.  A QR Code can define verbs, endpoints, and MagicFilters |
| MagicFilter | Any ScanAction can have an associated MagicFilter to help pick the right barcode from they many that might be present.  MagicFilters are written in javascript and can be as simple as only allowing certain symbologies to as complex as you can dream (i.e. USPS label verfication).  A MagicFilter also can take raw a raw scan and convert to a desired output i.e. append/prepend, scrub, alter, format as JSON etc.  Several good examples: Legacy system require barcodes output in a specific format;  A REST service might want the scan in JSON format etc.  /nFurthermore, MagicFilters can silently reject barcodes and leave the scanner on.  This allows users to get the right barcode type without annoying "Invalid Barcode" popups and re-scans. |

## Getting Started

For guides on how to get started with RapidScan, check out the links below.

- [RapidScan Quick Start Guide](https://github.com/InfinitePeripherals/RapidScan/blob/main/docs/IPC-RapidScan-QuickStart-1.4.pdf)
- [RapidScan SPP Guide](https://github.com/InfinitePeripherals/RapidScan/blob/main/docs/IPC-RapidScan-SPP-1.4.pdf)

## Documentation

For a more in-depth look at RiSL and its capabilities, check out the programming guide below.

- [RiSL Programming Guide](https://github.com/InfinitePeripherals/RapidScan/blob/main/docs/IPC-RapidScan-RiSL-1.4.pdf)

## Getting Help

- If you have questions, email us at [mobilesupport@ipcmobile.com](mailto:mobilesupport@ipcmobile.com)
- You can also contact Infinite Peripherals at 001.949.222.0300

## Demo Apps

- MQTT Dashboard Demo - [Dashboard](https://airscan.ipcmobile.com/)
  - This dashboard was made to allow you to demo RapidScan functionality without your own backend system. It acts as a test MQTT server that allows you to receive barcodes/images and send back RiSL cards. You can use this tool to customize your own RiSL cards or see some of our premade ones.
- C# MQTT Demo App - [Overview](https://github.com/InfinitePeripherals/RapidScan/tree/main/demos/C%23%2BEmbeddedMQTT%2BEcho)
  - This is a demo Windows application that runs a MQTT server that you can pair RapidScan to by scanning an on-screen QR Code. Once paired the application has a simple echo job that will receive scanned barcodes and return back a RiSL card with the barcode type & data. 
- C# BLE Demo App - [Overview](https://github.com/InfinitePeripherals/RapidScan/tree/main/demos/C%23%2BBLE%2BEcho)
  - This is a demo Windows application that runs a BLE server that you can pair RapidScan to by scanning an on-screen QR Code. Once paired the application has a simple echo job that will receive scanned barcodes and return back a RiSL card with the barcode type & data. 