# RapidScan
![alt text](https://github.com/InfinitePeripherals/RapidScan/blob/main/docs/img/RapidScanGlobe.png?raw=true)

RapidScan is an innovative product bringing the power of backend services directly to the HaloRing (no frontend Android development required). RapidScan will forward barcodes or camera images (+ the selected action) to the appropriate backend services using Bluetooth, BLE, WiFi+REST, or WiFi+MQTT for processing. These services can then respond with a "card" describing what to display on the Halo's screen using a simple markup language called RiSL (Ring Scanner Language).

Rapid Development: *This is a "NO HALORING DEVELOPMENT NEEDED" path.*

## Concepts
| Concept    | Description                                                                                                |
| ---------- | ---------------------------------------------------------------------------------------------------------- |
| HaloCard   | A "card" or "screen" to display on the HaloRing.  Can include buttons, graphics, labels etc.  Can also include a ZPL instructions to print |
| Verb / ScanAction | A verb/scan action is a menu item that the user selects prior to scanning or taking a picture.  Example verbs might include Price Lookup, Warranty Lookup etc. The ScanActions are configured by MDM or by scanning a QR Config Code.  Whereas old scanners just forward barcode+symbology, RapidScan forwards barcode+symbology+verb so the upstream system can route to the appriopiate buisiness logic.|
| SmartMode  | RapidScan sends barcode and images to Backend Systems using WiFi+REST/MQTT. These systems then answer with a HaloCard to display (after BusinessLogic). |
| CompanionMode | RapidScan sends barcode and images to a connected device like a Mac, PC, iOS, or Android phone.  The connected device can then run BusinessLogic and compose a HaloCard to display. |
| RISL (Ring Scanner Language) | A simple markup language that defines screens to show or printjobs to print on the HaloRing |
| RapidConnect | RapidScan can be easily configured using QR codes.  A QR Code can define verbs, endpoints, and MagicFilters |
| MagicFilter | Any ScanAction can have an associated MagicFilter to help pick the right barcode from they many that might be present.  MagicFilters are written in javascript and can be as simple as only allowing certain symbologies to as complex as you can dream (i.e. USPS label verfication).  A MagicFilter also can take raw a raw scan and convert to a desired output i.e. append/prepend, scrub, alter, format as JSON etc.  Several good examples: Legacy system require barcodes output in a specific format;  A REST service might want the scan in JSON format etc.  /nFurthermore, MagicFilters can silently reject barcodes and leave the scanner on.  This allows users to get the right barcode type without annoying "Invalid Barcode" popups and re-scans. |

## Getting Started

For guides on how to get started with RapidScan, check out the links below.

- [RapidScan Quick Start Guide](https://github.com/InfinitePeripherals/RapidScan/blob/main/docs/IPC-RapidScan-QuickStart-1.4.pdf)
- [RapidScan SPP Guide](https://github.com/InfinitePeripherals/RapidScan/blob/main/docs/IPC-RapidScan-SPP-1.4.pdf)
- [RapidScan BLE Guide](https://github.com/InfinitePeripherals/RapidScan/blob/main/docs/IPC-RapidScan-BLE-1.4.pdf)

## Documentation

For a more in-depth look at RiSL and its capabilities, check out the programming guide below.

- [RiSL Programming Guide](https://github.com/InfinitePeripherals/RapidScan/blob/main/docs/IPC-RapidScan-RiSL-1.4.pdf)

## Demo Apps

- Wi-Fi Relay Demo - [Relay Demo](https://utils.ipcmobile.com/rapidscan-relay-demo)
  - This is simple Wi-Fi demo that allows you to connect to a demo MQTT server with RapidScan. Then you can scan any barcode and the Relay Demo will answer back with a random premade RiSL card.
- MQTT Dashboard Demo - [Dashboard](https://utils.ipcmobile.com/rapidscan-mqtt-dashboard-demo)
  - This dashboard allows you to demo RapidScan functionality without your own backend system. It acts as a test MQTT server that allows you to receive barcodes/images and send back RiSL cards. You can use this tool to customize your own RiSL cards or see some of our premade ones.
- C# MQTT Demo App - [Project](https://github.com/InfinitePeripherals/RapidScan/tree/main/demos/C%23%2BEmbeddedMQTT%2BEcho)
  - This is a demo Windows application that runs a MQTT server that you can pair RapidScan to by scanning an on-screen QR Code. Once paired the application has a simple echo job that will receive scanned barcodes and return back a RiSL card with the barcode type & data. 
- C# BLE Demo App - [Project](https://github.com/InfinitePeripherals/RapidScan/tree/main/demos/C%23%2BBLE%2BEcho)
  - This is a demo Windows application that runs a BLE server that you can pair RapidScan to by scanning an on-screen QR Code. Once paired the application has a simple echo job that will receive scanned barcodes and return back a RiSL card with the barcode type & data. 

## Companion Mode

RapidScan can be used in Companion Mode by connecting to an iOS or Android device over BLE. Using one of our native SDKs, apps can easily receive barcodes and respond back with RiSL cards. The SDKs also handle BLE pairing and maintaining the connection. Check out our Companion SDKs for a more in-depth look with sample projects and documenation.

- iOS Companion SDK - [SDK](https://github.com/InfinitePeripherals/RapidScan/tree/main/RapidScan-Companion-iOS)
- Android Companion SDK - [SDK](https://github.com/InfinitePeripherals/RapidScan/tree/main/RapidScan-Companion-Android)

## Getting Help

- If you have questions, email us at [mobilesupport@ipcmobile.com](mailto:mobilesupport@ipcmobile.com)
- You can also contact Infinite Peripherals at 001.949.222.0300