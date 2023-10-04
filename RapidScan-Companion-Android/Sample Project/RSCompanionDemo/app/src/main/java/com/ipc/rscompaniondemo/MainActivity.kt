package com.ipc.rscompaniondemo

import android.Manifest
import android.content.pm.PackageManager
import android.os.Build
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.Button
import android.widget.ImageView
import android.widget.TextView
import androidx.core.app.ActivityCompat
import androidx.core.content.ContextCompat
import com.ipc.rscompanion.RSCompanion
import com.ipc.rscompanion.RSCompanionDelegate
import com.ipc.rscompanion.RSCompanionState
import com.ipc.rscompanion.RSRislCard

private const val TAG = "MainActivity"

class MainActivity : AppCompatActivity(), RSCompanionDelegate {

    private val REQUEST_BLUETOOTH_PERMISSIONS = 1

    // The Halo will scan this config QR to pair
    private lateinit var qrCodeView: ImageView
    private lateinit var clearButton: Button
    private lateinit var randomButton: Button
    private lateinit var statusTextView: TextView

    // This is the RSCompanion
    private lateinit var companion: RSCompanion

    // Using this to keep track of connected devices
    private val connectedDevices = mutableSetOf<String>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        qrCodeView = findViewById(R.id.qr_code)
        clearButton = findViewById(R.id.clearButton)
        randomButton = findViewById(R.id.randomButton)
        statusTextView = findViewById(R.id.statusTextView)

        // Since we need Context for RSCompanion we'll init it in onCreate
        companion = RSCompanion(this)
        companion.delegate = this

        clearButton.setOnClickListener {
            // Here we send the clear command to all connected Halos
            companion.sendClearCommand(connectedDevices.toTypedArray())
        }

        randomButton.setOnClickListener {
            val rand = (0..7).random()
            val rislCard: RSRislCard

            // Here are a few examples of RiSL cards
            when (rand) {
                1 -> {
                    rislCard = RSRislCard(width = 290, height = 185)
                    rislCard.setBackgroundColor("#FF0000")
                    rislCard.setFont(size = 54, color = "#FFFFFF", bold = true, underline = false)
                    rislCard.textCenter(y = 2, text = "Out of")
                    rislCard.textCenter(y = 60, text = "Stock")
                    rislCard.setFont(size = 26, color = "#FFFFFF", bold = false, underline = false)
                    rislCard.textCenter(y = 140, text = "000110026598")
                    rislCard.playAlertSound()
                    rislCard.vibrate(intensity = 2)
                    rislCard.showCard()
                }
                2 -> {
                    rislCard = RSRislCard(width = 290, height = 180)
                    rislCard.setBackgroundColor("#006400")
                    rislCard.setFont(size = 46, color = "#FFFFFF", bold = true, underline = false)
                    rislCard.textLeft(y = 2, text = " Inventory")
                    rislCard.setFont(size = 26, color = "#FFFFFF", bold = false, underline = false)
                    rislCard.textLeft(y = 72, text = " Current Stock: 12")
                    rislCard.textLeft(y = 106, text = " On Order: 40")
                    rislCard.textLeft(y = 140, text = " UPC: 000104025854")
                    rislCard.playGoodSound()
                    rislCard.showCard()
                }
                3 -> {
                    rislCard = RSRislCard(width = 290, height = 180)
                    rislCard.setBackgroundColor("#fd6a00")
                    rislCard.setFont(size = 46, color = "#FFFFFF", bold = true, underline = false)
                    rislCard.textLeft(y = 2, text = " Low Stock")
                    rislCard.setFont(size = 26, color = "#FFFFFF", bold = false, underline = false)
                    rislCard.textLeft(y = 72, text = " Current Stock: 2")
                    rislCard.textLeft(y = 106, text = " On Order: 0")
                    rislCard.textLeft(y = 140, text = " UPC: 000147808752")
                    rislCard.playBadSound()
                    rislCard.vibrate(intensity = 1)
                    rislCard.showCard()
                }
                4 -> {
                    rislCard = RSRislCard(width = 290, height = 210)
                    rislCard.setBackgroundColor("#594D5B")
                    rislCard.setFont(size = 28, color = "#FFFFFF", bold = false, underline = false)
                    rislCard.textCenter(y = 6, text = " Active Short 7 BLK")
                    rislCard.setFont(size = 64, color = "#FFFFFF", bold = true, underline = false)
                    rislCard.textCenter(y = 44, text = "$39.95")
                    rislCard.setFont(size = 32, color = "#FFFFFF", bold = true, underline = false)
                    rislCard.button(x = 10, y = 142, width = 270, height = 60, color = "#008000", text = "Print Label", id = "print")
                    rislCard.playGoodSound()
                    rislCard.showCard()
                }
                5 -> {
                    rislCard = RSRislCard(width = 290, height = 180)
                    rislCard.setBackgroundColor("#5151ae")
                    rislCard.setFont(size = 28, color = "#FFFFFF", bold = true, underline = false)
                    rislCard.textLeft(y = 16, text = " Andrea Piacquadio")
                    rislCard.setFont(size = 28, color = "#FFFFFF", bold = false, underline = false)
                    rislCard.textLeft(y = 54, text = " #6HTL345")
                    rislCard.setFont(size = 26, color = "#000000", bold = true, underline = false)
                    rislCard.button(x = 1, y = 110, width = 140, height = 70, color = "#ffc105", text = "Clock Out", id = "clockOut")
                    rislCard.setFont(size = 26, color = "#FFFFFF", bold = true, underline = false)
                    rislCard.button(x = 148, y = 110, width = 140, height = 70, color = "#116efd", text = "Clock In", id = "clockIn")
                    rislCard.playGoodSound()
                    rislCard.showCard()
                }
                6 -> {
                    rislCard = RSRislCard(width = 290, height = 140)
                    rislCard.setBackgroundColor("#ffe100")
                    rislCard.setFont(size = 32, color = "#000000", bold = true, underline = false)
                    rislCard.textLeft(y = 5, text = " WARNING!")
                    rislCard.setFont(size = 22, color = "#000000", bold = false, underline = false)
                    rislCard.textLeft(y = 56, text = " Warehouse Aisle 5 Closed")
                    rislCard.setFont(size = 20, color = "#000000", bold = false, underline = false)
                    rislCard.textLeft(y = 100, text = " Cleanup is underway")
                    rislCard.playBadSound()
                    rislCard.vibrate(intensity = 2)
                    rislCard.showCard()
                }
                else -> {
                    rislCard = RSRislCard(width = 290, height = 180)
                    rislCard.setBackgroundColor("#004F94")
                    rislCard.setFont(size = 32, color = "#FFFFFF", bold = false, underline = false)
                    rislCard.textCenter(y = 4, text = "Drawer #")
                    rislCard.setFont(size = 74, color = "#FFFFFF", bold = true, underline = false)
                    rislCard.textCenter(y = 36, text = "C-04")
                    rislCard.setFont(size = 26, color = "#FFFFFF", bold = false, underline = false)
                    rislCard.textCenter(y = 135, text = "000134508710")
                    rislCard.playGoodSound()
                    rislCard.showCard()
                }
            }

            companion.sendRislCard(rislCard, connectedDevices.toTypedArray())
        }
    }

    override fun onStart() {
        super.onStart()

        // First make sure Bluetooth permissions are granted. These are required.
        checkBluetoothPermissions()
    }

    override fun onStop() {
        super.onStop()

        companion.stopBleServer()
    }

    override fun rsCompanionState(state: RSCompanionState) {
        Log.d(TAG, "Companion state: $state")

        if (state == RSCompanionState.READY) {
            /*
            * RSCompanion is set up and in the READY state. This indicates that the device has
            * the proper level of Bluetooth support from the hardware and that Bluetooth is ON.
            * We can now start advertising our services.
            */
            companion.startBleServer()
        } else if (state == RSCompanionState.ADVERTISING) {
            // Now that we know we are advertising we can set the QR
            qrCodeView.setImageBitmap(companion.generateCompanionQR(200))
        }
    }

    override fun rsCompanionConnectedHalo(mac: String) {
        Log.d(TAG, "Halo connected: $mac")


        connectedDevices.add(mac)
    }

    override fun rsCompanionDisconnectedHalo(mac: String) {
        Log.d(TAG, "Halo disconnected: $mac")

        connectedDevices.remove(mac)
    }

    override fun rsCompanionDidReceiveBarcode(
        barcode: String,
        symbology: String,
        serial: String,
        verb: String,
        mac: String
    ) {
        Log.d(TAG, "Barcode scanned: $barcode")

        val card = RSRislCard(width = 290, height = 150)
        card.setBackgroundColor("#84D400")
        card.setFont(size = 36, color = "#000000", bold = true, underline = false)
        card.textCenter(8, barcode)
        card.setFont(size = 28, color = "#000000", bold = false, underline = false)
        card.textCenter(100, "Symbology = $symbology")
        card.playGoodSound()
        card.showCard()

        // Here we respond to the barcode scan with an echo-style RiSL card
        //companion.sendRislCard(card)

        // Alternatively we can specify to send the RiSL card to the given MAC address
        companion.sendRislCard(card, arrayOf(mac))
    }

    // Check runtime permissions
    private fun checkBluetoothPermissions() {
        val permissionsToRequest = mutableListOf<String>()

        if (ContextCompat.checkSelfPermission(this, Manifest.permission.BLUETOOTH_ADMIN)
            != PackageManager.PERMISSION_GRANTED
        ) {
            permissionsToRequest.add(Manifest.permission.BLUETOOTH_ADMIN)
        }

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.S) {
            if (ContextCompat.checkSelfPermission(this, Manifest.permission.BLUETOOTH_ADVERTISE)
                != PackageManager.PERMISSION_GRANTED
            ) {
                permissionsToRequest.add(Manifest.permission.BLUETOOTH_ADVERTISE)
            }

            if (ContextCompat.checkSelfPermission(this, Manifest.permission.BLUETOOTH_CONNECT)
                != PackageManager.PERMISSION_GRANTED
            ) {
                permissionsToRequest.add(Manifest.permission.BLUETOOTH_CONNECT)
            }
        }

        if (permissionsToRequest.isNotEmpty()) {
            ActivityCompat.requestPermissions(
                this,
                permissionsToRequest.toTypedArray(),
                REQUEST_BLUETOOTH_PERMISSIONS
            )
        } else {
            // Permissions are already granted, we can setup RSCompanion's Bluetooth now.
            companion.setupBluetooth()
        }
    }

    override fun onRequestPermissionsResult(
        requestCode: Int,
        permissions: Array<out String>,
        grantResults: IntArray
    ) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults)

        if (requestCode == REQUEST_BLUETOOTH_PERMISSIONS) {
            if (grantResults.isNotEmpty() && grantResults.all { it == PackageManager.PERMISSION_GRANTED }) {
                // All required permissions are now granted, we can setup RSCompanion's Bluetooth now.
                companion.setupBluetooth()
            } else {
                // Handle the case where permissions are not granted.
                // You may want to show a message to the user or disable Bluetooth functionality.
            }
        }
    }
}