//
//  ViewController.swift
//  RSCompanionDemo
//
//  Created by Kyle Mai on 3/7/23.
//

import UIKit
import CoreBluetooth
import RapidScanCompanion

class ViewController: UIViewController {
    
    @IBOutlet weak var qrCodeImageView: UIImageView!
    @IBOutlet weak var companionStatus: UILabel!
    @IBOutlet weak var companionLog: UITextView!
    
    var connectedHalos: [String] = [String]()
    
    //let companion = RSCompanion()
    
    // You can optionally specify a UUID instead of using the randomly generated UUID RSCompanion provides
    let companion = RSCompanion(serviceUUID: CBUUID(string: "f7b5a183-772f-4990-8b36-b98a4c40f890"))

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
        
        self.companion.delegate = self
    }

    override func viewDidAppear(_ animated: Bool) {
        // Display pairing QRCode
        self.qrCodeImageView.image = self.companion.generatePairingQRCodeImage()
    }
    
    @IBAction func actionClear() {
        // Sends a command to clear RapidScan's screen of all cards
        self.companion.sendClearCommandToHalos(self.connectedHalos)
    }
    
    @IBAction func actionSendRawRisl() {
        self.companion.sendRawRisl("^PlaySound|Alert^Vibrate|2")
    }
    
    @IBAction func actionVibrateCustom() {
        let card = RSRislCard(width: 290, height: 150)
        card.setBackgroundColor("#004F94")
        card.setFont(size: 40, color: "#FFFFFF", bold: true, underline: false)
        card.textCenter(y: 10, text: "\\^Custom \\| Vibrate\\^")
        card.vibrateCustom(pattern: [200, 100, 200, 100, 200], amplitudes: [255, 0, 255, 0, 255])
        card.showCard()
        
        self.companion.sendRislCards([card])
    }
    
    @IBAction func actionSendRandomCard() {
        let rislCard: RSRislCard
        
        // We're just sending a random card back
        switch Int.random(in: 0...7) {
        case 1:
            rislCard = RSRislCard(width: 290, height: 185)
            rislCard.setBackgroundColor("#FF0000")
            rislCard.setFont(size: 54, color: "#FFFFFF", bold: true, underline: false)
            rislCard.textCenter(y: 2, text: "Out of")
            rislCard.textCenter(y: 60, text: "Stock")
            rislCard.setFont(size: 26, color: "#FFFFFF", bold: false, underline: false)
            rislCard.textCenter(y: 140, text: "000110026598")
            rislCard.playAlertSound()
            rislCard.vibrate(intensity: 2)
            rislCard.showCard()
        case 2:
            rislCard = RSRislCard(width: 290, height: 180)
            rislCard.setBackgroundColor("#006400")
            rislCard.setFont(size: 46, color: "#FFFFFF", bold: true, underline: false)
            rislCard.textLeft(y: 2, text: " Inventory")
            rislCard.setFont(size: 26, color: "#FFFFFF", bold: false, underline: false)
            rislCard.textLeft(y: 72, text: " Current Stock: 12")
            rislCard.textLeft(y: 106, text: " On Order: 40")
            rislCard.textLeft(y: 140, text: " UPC: 000104025854")
            rislCard.playGoodSound()
            rislCard.showCard()
        case 3:
            rislCard = RSRislCard(width: 290, height: 180)
            rislCard.setBackgroundColor("#fd6a00")
            rislCard.setFont(size: 46, color: "#FFFFFF", bold: true, underline: false)
            rislCard.textLeft(y: 2, text: " Low Stock")
            rislCard.setFont(size: 26, color: "#FFFFFF", bold: false, underline: false)
            rislCard.textLeft(y: 72, text: " Current Stock: 2")
            rislCard.textLeft(y: 106, text: " On Order: 0")
            rislCard.textLeft(y: 140, text: " UPC: 000147808752")
            rislCard.playBadSound()
            rislCard.vibrate(intensity: 1)
            rislCard.showCard()
        case 4:
            rislCard = RSRislCard(width: 290, height: 210)
            rislCard.setBackgroundColor("#594D5B")
            rislCard.setFont(size: 28, color: "#FFFFFF", bold: false, underline: false)
            rislCard.textCenter(y: 6, text: " Active Short 7 BLK")
            rislCard.setFont(size: 64, color: "#FFFFFF", bold: true, underline: false)
            rislCard.textCenter(y: 44, text: "$39.95")
            rislCard.setFont(size: 32, color: "#FFFFFF", bold: true, underline: false)
            rislCard.button(x: 10, y: 142, width: 270, height: 60, color: "#008000", text: "Print Label", id: "print")
            rislCard.playGoodSound()
            rislCard.showCard()
        case 5:
            rislCard = RSRislCard(width: 290, height: 180)
            rislCard.setBackgroundColor("#5151ae")
            rislCard.setFont(size: 28, color: "#FFFFFF", bold: true, underline: false)
            rislCard.textLeft(y: 16, text: " Andrea Piacquadio")
            rislCard.setFont(size: 28, color: "#FFFFFF", bold: false, underline: false)
            rislCard.textLeft(y: 54, text: " #6HTL345")
            rislCard.setFont(size: 26, color: "#000000", bold: true, underline: false)
            rislCard.button(x: 1, y: 110, width: 140, height: 70, color: "#ffc105", text: "Clock Out", id: "clockOut")
            rislCard.setFont(size: 26, color: "#FFFFFF", bold: true, underline: false)
            rislCard.button(x: 148, y: 110, width: 140, height: 70, color: "#116efd", text: "Clock In", id: "clockIn")
            rislCard.playGoodSound()
            rislCard.showCard()
        case 6:
            rislCard = RSRislCard(width: 290, height: 140)
            rislCard.setBackgroundColor("#ffe100")
            rislCard.setFont(size: 32, color: "#000000", bold: true, underline: false)
            rislCard.textLeft(y: 5, text: " WARNING!")
            rislCard.setFont(size: 22, color: "#000000", bold: false, underline: false)
            rislCard.textLeft(y: 56, text: " Warehouse Aisle 5 Closed")
            rislCard.setFont(size: 20, color: "#000000", bold: false, underline: false)
            rislCard.textLeft(y: 100, text: " Cleanup is underway")
            rislCard.playBadSound()
            rislCard.vibrate(intensity: 2)
            rislCard.showCard()
        default:
            rislCard = RSRislCard(width: 290, height: 180)
            rislCard.setBackgroundColor("#004F94")
            rislCard.setFont(size: 32, color: "#FFFFFF", bold: false, underline: false)
            rislCard.textCenter(y: 4, text: "Drawer #")
            rislCard.setFont(size: 74, color: "#FFFFFF", bold: true, underline: false)
            rislCard.textCenter(y: 36, text: "C-04")
            rislCard.setFont(size: 26, color: "#FFFFFF", bold: false, underline: false)
            rislCard.textCenter(y: 135, text: "000134508710")
            rislCard.playGoodSound()
            rislCard.showCard()
        }
        
        companion.sendRislCards([rislCard], toHalos: connectedHalos)
    }
    
    func sendBarcodeResponse(barcode: String, symbology: String) {
        // Just echo back the barcode and symbology
        let card1 = RSRislCard(width: 290, height: 150)
        card1.setBackgroundColor("#84D400")
        card1.text(barcode, verticlePosition: 8, alignment: .center, font: RSRislCard.encodeFont(size: 36, color: "#000000", bold: true, underline: false))
        card1.text("Symbology: " + symbology, verticlePosition: 100, alignment: .center, font: RSRislCard.encodeFont(size: 28, color: "#000000", bold: false, underline: false))
        card1.playGoodSound()
        card1.showCard()
        
        self.companion.sendRislCards([card1])
    }
    
    func prependLogText(_ newLine: String) {
        DispatchQueue.main.async {
            let currentText = self.companionLog.text ?? ""
            let newText = newLine + "\n" + currentText
            self.companionLog.text = newText
        }
    }
}

extension ViewController: RSCompanionDelegate {
    func rsCompanionState(_ state: RSCompanionState, uuid: String) {
        //self.companionStatus.text = "\(uuid)\n\(state)"
        
        if state == .ready {
            self.companion.startAdvertising()
            self.companionStatus.text = "\(uuid)\nReady"
        }
        else if state == .disconnected  {
            if !self.connectedHalos.contains(uuid) {
                self.connectedHalos.removeAll { $0 == uuid }
            }
            
            self.companionStatus.text = "\(uuid)\nDisconnected"
        }
        else if state == .connected {
            if !self.connectedHalos.contains(uuid) {
                self.connectedHalos.append(uuid)
            }
            
            self.companionStatus.text = "\(uuid)\nConnected"
        }
        else if state == .advertising {
            self.companionStatus.text = "\(uuid)\nAdvertising"
        }
        else {
            self.companionStatus.text = "\(uuid)\nNot Ready"
        }
    }
    
    func rsCompanionDidReceiveBarcode(_ barcode: String, symbology: String, serial: String, verb: String, uuid: String) {
        prependLogText("Barcode Scanned: \(barcode)\nSymbology: \(symbology)\nVerb: \(verb)")
        
        self.sendBarcodeResponse(barcode: barcode, symbology: symbology)
    }
    
    func rsCompanionDidReceiveButtonPress(_ button: RapidScanCompanion.RSButton, serial: String, uuid: String) {
        prependLogText("Halo Button Pressed: \(button)")
    }
    
    func rsCompanionDidReceiveRislButtonPress(_ button: String, serial: String, uuid: String) {
        prependLogText("RiSL Button Pressed: \(button)")
    }
    
    func rsCompanionDidReceiveVerbSelection(_ verb: String, serial: String, uuid: String) {
        prependLogText("Verb Selected: \(verb)")
    }
}
