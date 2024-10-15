#if 0
#elif defined(__arm64__) && __arm64__
// Generated by Apple Swift version 6.0 effective-5.10 (swiftlang-6.0.0.9.10 clang-1600.0.26.2)
#ifndef RAPIDSCANCOMPANION_SWIFT_H
#define RAPIDSCANCOMPANION_SWIFT_H
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wgcc-compat"

#if !defined(__has_include)
# define __has_include(x) 0
#endif
#if !defined(__has_attribute)
# define __has_attribute(x) 0
#endif
#if !defined(__has_feature)
# define __has_feature(x) 0
#endif
#if !defined(__has_warning)
# define __has_warning(x) 0
#endif

#if __has_include(<swift/objc-prologue.h>)
# include <swift/objc-prologue.h>
#endif

#pragma clang diagnostic ignored "-Wauto-import"
#if defined(__OBJC__)
#include <Foundation/Foundation.h>
#endif
#if defined(__cplusplus)
#include <cstdint>
#include <cstddef>
#include <cstdbool>
#include <cstring>
#include <stdlib.h>
#include <new>
#include <type_traits>
#else
#include <stdint.h>
#include <stddef.h>
#include <stdbool.h>
#include <string.h>
#endif
#if defined(__cplusplus)
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wnon-modular-include-in-framework-module"
#if defined(__arm64e__) && __has_include(<ptrauth.h>)
# include <ptrauth.h>
#else
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wreserved-macro-identifier"
# ifndef __ptrauth_swift_value_witness_function_pointer
#  define __ptrauth_swift_value_witness_function_pointer(x)
# endif
# ifndef __ptrauth_swift_class_method_pointer
#  define __ptrauth_swift_class_method_pointer(x)
# endif
#pragma clang diagnostic pop
#endif
#pragma clang diagnostic pop
#endif

#if !defined(SWIFT_TYPEDEFS)
# define SWIFT_TYPEDEFS 1
# if __has_include(<uchar.h>)
#  include <uchar.h>
# elif !defined(__cplusplus)
typedef uint_least16_t char16_t;
typedef uint_least32_t char32_t;
# endif
typedef float swift_float2  __attribute__((__ext_vector_type__(2)));
typedef float swift_float3  __attribute__((__ext_vector_type__(3)));
typedef float swift_float4  __attribute__((__ext_vector_type__(4)));
typedef double swift_double2  __attribute__((__ext_vector_type__(2)));
typedef double swift_double3  __attribute__((__ext_vector_type__(3)));
typedef double swift_double4  __attribute__((__ext_vector_type__(4)));
typedef int swift_int2  __attribute__((__ext_vector_type__(2)));
typedef int swift_int3  __attribute__((__ext_vector_type__(3)));
typedef int swift_int4  __attribute__((__ext_vector_type__(4)));
typedef unsigned int swift_uint2  __attribute__((__ext_vector_type__(2)));
typedef unsigned int swift_uint3  __attribute__((__ext_vector_type__(3)));
typedef unsigned int swift_uint4  __attribute__((__ext_vector_type__(4)));
#endif

#if !defined(SWIFT_PASTE)
# define SWIFT_PASTE_HELPER(x, y) x##y
# define SWIFT_PASTE(x, y) SWIFT_PASTE_HELPER(x, y)
#endif
#if !defined(SWIFT_METATYPE)
# define SWIFT_METATYPE(X) Class
#endif
#if !defined(SWIFT_CLASS_PROPERTY)
# if __has_feature(objc_class_property)
#  define SWIFT_CLASS_PROPERTY(...) __VA_ARGS__
# else
#  define SWIFT_CLASS_PROPERTY(...) 
# endif
#endif
#if !defined(SWIFT_RUNTIME_NAME)
# if __has_attribute(objc_runtime_name)
#  define SWIFT_RUNTIME_NAME(X) __attribute__((objc_runtime_name(X)))
# else
#  define SWIFT_RUNTIME_NAME(X) 
# endif
#endif
#if !defined(SWIFT_COMPILE_NAME)
# if __has_attribute(swift_name)
#  define SWIFT_COMPILE_NAME(X) __attribute__((swift_name(X)))
# else
#  define SWIFT_COMPILE_NAME(X) 
# endif
#endif
#if !defined(SWIFT_METHOD_FAMILY)
# if __has_attribute(objc_method_family)
#  define SWIFT_METHOD_FAMILY(X) __attribute__((objc_method_family(X)))
# else
#  define SWIFT_METHOD_FAMILY(X) 
# endif
#endif
#if !defined(SWIFT_NOESCAPE)
# if __has_attribute(noescape)
#  define SWIFT_NOESCAPE __attribute__((noescape))
# else
#  define SWIFT_NOESCAPE 
# endif
#endif
#if !defined(SWIFT_RELEASES_ARGUMENT)
# if __has_attribute(ns_consumed)
#  define SWIFT_RELEASES_ARGUMENT __attribute__((ns_consumed))
# else
#  define SWIFT_RELEASES_ARGUMENT 
# endif
#endif
#if !defined(SWIFT_WARN_UNUSED_RESULT)
# if __has_attribute(warn_unused_result)
#  define SWIFT_WARN_UNUSED_RESULT __attribute__((warn_unused_result))
# else
#  define SWIFT_WARN_UNUSED_RESULT 
# endif
#endif
#if !defined(SWIFT_NORETURN)
# if __has_attribute(noreturn)
#  define SWIFT_NORETURN __attribute__((noreturn))
# else
#  define SWIFT_NORETURN 
# endif
#endif
#if !defined(SWIFT_CLASS_EXTRA)
# define SWIFT_CLASS_EXTRA 
#endif
#if !defined(SWIFT_PROTOCOL_EXTRA)
# define SWIFT_PROTOCOL_EXTRA 
#endif
#if !defined(SWIFT_ENUM_EXTRA)
# define SWIFT_ENUM_EXTRA 
#endif
#if !defined(SWIFT_CLASS)
# if __has_attribute(objc_subclassing_restricted)
#  define SWIFT_CLASS(SWIFT_NAME) SWIFT_RUNTIME_NAME(SWIFT_NAME) __attribute__((objc_subclassing_restricted)) SWIFT_CLASS_EXTRA
#  define SWIFT_CLASS_NAMED(SWIFT_NAME) __attribute__((objc_subclassing_restricted)) SWIFT_COMPILE_NAME(SWIFT_NAME) SWIFT_CLASS_EXTRA
# else
#  define SWIFT_CLASS(SWIFT_NAME) SWIFT_RUNTIME_NAME(SWIFT_NAME) SWIFT_CLASS_EXTRA
#  define SWIFT_CLASS_NAMED(SWIFT_NAME) SWIFT_COMPILE_NAME(SWIFT_NAME) SWIFT_CLASS_EXTRA
# endif
#endif
#if !defined(SWIFT_RESILIENT_CLASS)
# if __has_attribute(objc_class_stub)
#  define SWIFT_RESILIENT_CLASS(SWIFT_NAME) SWIFT_CLASS(SWIFT_NAME) __attribute__((objc_class_stub))
#  define SWIFT_RESILIENT_CLASS_NAMED(SWIFT_NAME) __attribute__((objc_class_stub)) SWIFT_CLASS_NAMED(SWIFT_NAME)
# else
#  define SWIFT_RESILIENT_CLASS(SWIFT_NAME) SWIFT_CLASS(SWIFT_NAME)
#  define SWIFT_RESILIENT_CLASS_NAMED(SWIFT_NAME) SWIFT_CLASS_NAMED(SWIFT_NAME)
# endif
#endif
#if !defined(SWIFT_PROTOCOL)
# define SWIFT_PROTOCOL(SWIFT_NAME) SWIFT_RUNTIME_NAME(SWIFT_NAME) SWIFT_PROTOCOL_EXTRA
# define SWIFT_PROTOCOL_NAMED(SWIFT_NAME) SWIFT_COMPILE_NAME(SWIFT_NAME) SWIFT_PROTOCOL_EXTRA
#endif
#if !defined(SWIFT_EXTENSION)
# define SWIFT_EXTENSION(M) SWIFT_PASTE(M##_Swift_, __LINE__)
#endif
#if !defined(OBJC_DESIGNATED_INITIALIZER)
# if __has_attribute(objc_designated_initializer)
#  define OBJC_DESIGNATED_INITIALIZER __attribute__((objc_designated_initializer))
# else
#  define OBJC_DESIGNATED_INITIALIZER 
# endif
#endif
#if !defined(SWIFT_ENUM_ATTR)
# if __has_attribute(enum_extensibility)
#  define SWIFT_ENUM_ATTR(_extensibility) __attribute__((enum_extensibility(_extensibility)))
# else
#  define SWIFT_ENUM_ATTR(_extensibility) 
# endif
#endif
#if !defined(SWIFT_ENUM)
# define SWIFT_ENUM(_type, _name, _extensibility) enum _name : _type _name; enum SWIFT_ENUM_ATTR(_extensibility) SWIFT_ENUM_EXTRA _name : _type
# if __has_feature(generalized_swift_name)
#  define SWIFT_ENUM_NAMED(_type, _name, SWIFT_NAME, _extensibility) enum _name : _type _name SWIFT_COMPILE_NAME(SWIFT_NAME); enum SWIFT_COMPILE_NAME(SWIFT_NAME) SWIFT_ENUM_ATTR(_extensibility) SWIFT_ENUM_EXTRA _name : _type
# else
#  define SWIFT_ENUM_NAMED(_type, _name, SWIFT_NAME, _extensibility) SWIFT_ENUM(_type, _name, _extensibility)
# endif
#endif
#if !defined(SWIFT_UNAVAILABLE)
# define SWIFT_UNAVAILABLE __attribute__((unavailable))
#endif
#if !defined(SWIFT_UNAVAILABLE_MSG)
# define SWIFT_UNAVAILABLE_MSG(msg) __attribute__((unavailable(msg)))
#endif
#if !defined(SWIFT_AVAILABILITY)
# define SWIFT_AVAILABILITY(plat, ...) __attribute__((availability(plat, __VA_ARGS__)))
#endif
#if !defined(SWIFT_WEAK_IMPORT)
# define SWIFT_WEAK_IMPORT __attribute__((weak_import))
#endif
#if !defined(SWIFT_DEPRECATED)
# define SWIFT_DEPRECATED __attribute__((deprecated))
#endif
#if !defined(SWIFT_DEPRECATED_MSG)
# define SWIFT_DEPRECATED_MSG(...) __attribute__((deprecated(__VA_ARGS__)))
#endif
#if !defined(SWIFT_DEPRECATED_OBJC)
# if __has_feature(attribute_diagnose_if_objc)
#  define SWIFT_DEPRECATED_OBJC(Msg) __attribute__((diagnose_if(1, Msg, "warning")))
# else
#  define SWIFT_DEPRECATED_OBJC(Msg) SWIFT_DEPRECATED_MSG(Msg)
# endif
#endif
#if defined(__OBJC__)
#if !defined(IBSegueAction)
# define IBSegueAction 
#endif
#endif
#if !defined(SWIFT_EXTERN)
# if defined(__cplusplus)
#  define SWIFT_EXTERN extern "C"
# else
#  define SWIFT_EXTERN extern
# endif
#endif
#if !defined(SWIFT_CALL)
# define SWIFT_CALL __attribute__((swiftcall))
#endif
#if !defined(SWIFT_INDIRECT_RESULT)
# define SWIFT_INDIRECT_RESULT __attribute__((swift_indirect_result))
#endif
#if !defined(SWIFT_CONTEXT)
# define SWIFT_CONTEXT __attribute__((swift_context))
#endif
#if !defined(SWIFT_ERROR_RESULT)
# define SWIFT_ERROR_RESULT __attribute__((swift_error_result))
#endif
#if defined(__cplusplus)
# define SWIFT_NOEXCEPT noexcept
#else
# define SWIFT_NOEXCEPT 
#endif
#if !defined(SWIFT_C_INLINE_THUNK)
# if __has_attribute(always_inline)
# if __has_attribute(nodebug)
#  define SWIFT_C_INLINE_THUNK inline __attribute__((always_inline)) __attribute__((nodebug))
# else
#  define SWIFT_C_INLINE_THUNK inline __attribute__((always_inline))
# endif
# else
#  define SWIFT_C_INLINE_THUNK inline
# endif
#endif
#if defined(_WIN32)
#if !defined(SWIFT_IMPORT_STDLIB_SYMBOL)
# define SWIFT_IMPORT_STDLIB_SYMBOL __declspec(dllimport)
#endif
#else
#if !defined(SWIFT_IMPORT_STDLIB_SYMBOL)
# define SWIFT_IMPORT_STDLIB_SYMBOL 
#endif
#endif
#if defined(__OBJC__)
#if __has_feature(objc_modules)
#if __has_warning("-Watimport-in-framework-header")
#pragma clang diagnostic ignored "-Watimport-in-framework-header"
#endif
@import CoreBluetooth;
@import Foundation;
@import ObjectiveC;
#endif

#endif
#pragma clang diagnostic ignored "-Wproperty-attribute-mismatch"
#pragma clang diagnostic ignored "-Wduplicate-method-arg"
#if __has_warning("-Wpragma-clang-attribute")
# pragma clang diagnostic ignored "-Wpragma-clang-attribute"
#endif
#pragma clang diagnostic ignored "-Wunknown-pragmas"
#pragma clang diagnostic ignored "-Wnullability"
#pragma clang diagnostic ignored "-Wdollar-in-identifier-extension"
#pragma clang diagnostic ignored "-Wunsafe-buffer-usage"

#if __has_attribute(external_source_symbol)
# pragma push_macro("any")
# undef any
# pragma clang attribute push(__attribute__((external_source_symbol(language="Swift", defined_in="RapidScanCompanion",generated_declaration))), apply_to=any(function,enum,objc_interface,objc_category,objc_protocol))
# pragma pop_macro("any")
#endif

#if defined(__OBJC__)
typedef SWIFT_ENUM(NSInteger, RSButton, open) {
  RSButtonLeft = 0,
  RSButtonCenter = 1,
  RSButtonRight = 2,
};

@protocol RSCompanionDelegate;
@class NSString;
@class CBUUID;
@class RSRislCard;
@class UIImage;

/// This object is responsible for connecting, sending data to, and receiving data from Halo device. It is recommended that this object should be a class instance.
SWIFT_CLASS("_TtC18RapidScanCompanion11RSCompanion")
@interface RSCompanion : NSObject
/// The delegate that will handle the various callbacks from RSCompanion
@property (nonatomic, strong) id <RSCompanionDelegate> _Nullable delegate;
/// This RSCompanion’s BLE advertisement name
@property (nonatomic, readonly, copy) NSString * _Nonnull advertisementName;
/// This RSCompanion’s BLE service UUID
@property (nonatomic, strong) CBUUID * _Nonnull serviceUUID;
/// The pairing QRCode value which will be used to generate the QRCode image
@property (nonatomic, readonly, copy) NSString * _Nonnull pairingQRCodeValue;
/// Initializing the RSCompanion object
- (nonnull instancetype)init OBJC_DESIGNATED_INITIALIZER;
/// Optionally specify a CBUUID for the Service
- (nonnull instancetype)initWithServiceUUID:(CBUUID * _Nullable)serviceUUID OBJC_DESIGNATED_INITIALIZER;
/// Starts advertising when BLE’s state is Powered On. If BLE’s state is not Powered On, function will return false.
///
/// returns:
/// A boolean value indicating whether the RSCompanion object started advertising or not.
- (BOOL)startAdvertising;
/// Stop RSCompanion advertising
///
/// returns:
/// Boolean indicating whether or not function executed successfully.
- (BOOL)stopAdvertising;
/// Send a Risl card to RapidScan on connected Halo devices.
/// \param cards The RSRislCard objects that will be encoded into message for sending.
///
/// \param uuids The UUIDs of connected Halo devices
///
///
/// returns:
/// A boolean indicating whether the risl message is constructed successfully and sent to RapidScan on Halo device.
- (BOOL)sendRislCards:(NSArray<RSRislCard *> * _Nonnull)cards toHalos:(NSArray<NSString *> * _Nonnull)uuids;
/// Send a Risl card to RapidScan on the last active Halo device.
/// \param cards The RSRislCard objects that will be encoded into message for sending.
///
///
/// returns:
/// A boolean indicating whether the risl message is constructed successfully and sent to RapidScan on Halo device.
- (BOOL)sendRislCards:(NSArray<RSRislCard *> * _Nonnull)cards;
/// Send a raw RiSL to RapidScan on Halo devices
///
/// returns:
/// A boolean indicating whether the command was sent to RapidScan on Halo device.
- (BOOL)sendRawRislToHalos:(NSString * _Nonnull)risl uuids:(NSArray<NSString *> * _Nonnull)uuids;
/// Send a raw RiSL to RapidScan on the last active Halo device
///
/// returns:
/// A boolean indicating whether the command was sent to RapidScan on Halo device.
- (BOOL)sendRawRisl:(NSString * _Nonnull)risl;
/// Send a clear screen command to RapidScan on connected Halo devices to clear all RislCards
///
/// returns:
/// A boolean indicating whether the clear command is constructed successfully and sent to RapidScan on Halo device.
- (BOOL)sendClearCommandToHalos:(NSArray<NSString *> * _Nonnull)uuids;
/// Send a clear screen command to RapidScan on the last active Halo device to clear all RislCards
///
/// returns:
/// A boolean indicating whether the clear command is constructed successfully and sent to RapidScan on Halo device.
- (BOOL)sendClearCommand;
/// Generate a pairing QRCode image, so that Halo can scan it to pair.
///
/// returns:
/// The QRCode UIImage object.
- (UIImage * _Nullable)generatePairingQRCodeImage SWIFT_WARN_UNUSED_RESULT;
@end

@class CBPeripheralManager;
@class CBService;
@class CBCentral;
@class CBCharacteristic;
@class CBATTRequest;

@interface RSCompanion (SWIFT_EXTENSION(RapidScanCompanion)) <CBPeripheralManagerDelegate>
- (void)peripheralManagerDidUpdateState:(CBPeripheralManager * _Nonnull)peripheral;
- (void)peripheralManager:(CBPeripheralManager * _Nonnull)peripheral didAddService:(CBService * _Nonnull)service error:(NSError * _Nullable)error;
- (void)peripheralManager:(CBPeripheralManager * _Nonnull)peripheral central:(CBCentral * _Nonnull)central didSubscribeToCharacteristic:(CBCharacteristic * _Nonnull)characteristic;
- (void)peripheralManager:(CBPeripheralManager * _Nonnull)peripheral central:(CBCentral * _Nonnull)central didUnsubscribeFromCharacteristic:(CBCharacteristic * _Nonnull)characteristic;
- (void)peripheralManagerDidStartAdvertising:(CBPeripheralManager * _Nonnull)peripheral error:(NSError * _Nullable)error;
- (void)peripheralManager:(CBPeripheralManager * _Nonnull)peripheral didReceiveWriteRequests:(NSArray<CBATTRequest *> * _Nonnull)requests;
- (void)peripheralManager:(CBPeripheralManager * _Nonnull)peripheral didReceiveReadRequest:(CBATTRequest * _Nonnull)request;
@end

enum RSCompanionState : NSInteger;

SWIFT_PROTOCOL("_TtP18RapidScanCompanion19RSCompanionDelegate_")
@protocol RSCompanionDelegate
/// Called when the RSCompanion object updates its state
/// <ul>
///   <li>
///     Parameters:
///   </li>
///   <li>
///     state: The current state. One of RSCompanionState.
///   </li>
///   <li>
///     uuid: The UUID of the Halo device
///   </li>
/// </ul>
- (void)rsCompanionState:(enum RSCompanionState)state uuid:(NSString * _Nonnull)uuid;
/// Called when a barcode is received
/// <ul>
///   <li>
///     Parameters:
///   </li>
///   <li>
///     barcode: The received barcode
///   </li>
///   <li>
///     symbology: The symbology of the barcode
///   </li>
///   <li>
///     serial: The serial of the Halo device
///   </li>
///   <li>
///     verb: The current verb when the barcode was scanned
///   </li>
///   <li>
///     uuid: The UUID of the Halo device
///   </li>
/// </ul>
- (void)rsCompanionDidReceiveBarcode:(NSString * _Nonnull)barcode symbology:(NSString * _Nonnull)symbology serial:(NSString * _Nonnull)serial verb:(NSString * _Nonnull)verb uuid:(NSString * _Nonnull)uuid;
/// Called when an image is received
/// <ul>
///   <li>
///     Parameters:
///   </li>
///   <li>
///     image: The received image
///   </li>
/// </ul>
- (void)rsCompanionDidReceiveImage:(UIImage * _Nonnull)image;
/// Called when a hardware button press is received
/// <ul>
///   <li>
///     Parameters:
///   </li>
///   <li>
///     button: The button pressed. One of RSButton.
///   </li>
///   <li>
///     serial: The serial of the Halo device
///   </li>
///   <li>
///     uuid: The UUID of the Halo device
///   </li>
/// </ul>
- (void)rsCompanionDidReceiveButtonPress:(enum RSButton)button serial:(NSString * _Nonnull)serial uuid:(NSString * _Nonnull)uuid;
/// Called when a RiSL button press is received
/// <ul>
///   <li>
///     Parameters:
///   </li>
///   <li>
///     button: The ID of the button pressed
///   </li>
///   <li>
///     serial: The serial of the Halo device
///   </li>
///   <li>
///     uuid: The UUID of the Halo device
///   </li>
/// </ul>
- (void)rsCompanionDidReceiveRislButtonPress:(NSString * _Nonnull)button serial:(NSString * _Nonnull)serial uuid:(NSString * _Nonnull)uuid;
/// Called when a Halo device selects a verb
/// <ul>
///   <li>
///     Parameters:
///   </li>
///   <li>
///     verb: The verb selected
///   </li>
///   <li>
///     serial: The serial of the Halo device
///   </li>
///   <li>
///     uuid: The UUID of the Halo device
///   </li>
/// </ul>
- (void)rsCompanionDidReceiveVerbSelection:(NSString * _Nonnull)verb serial:(NSString * _Nonnull)serial uuid:(NSString * _Nonnull)uuid;
@end

/// RSCompanion state
typedef SWIFT_ENUM(NSInteger, RSCompanionState, open) {
  RSCompanionStateUnknown = -1,
  RSCompanionStateNotReady = 0,
  RSCompanionStateReady = 1,
  RSCompanionStateAdvertising = 2,
  RSCompanionStateConnected = 3,
  RSCompanionStateDisconnected = 4,
  RSCompanionStateResetting = 5,
  RSCompanionStateUnauthorized = 6,
  RSCompanionStateUnsupported = 7,
};

enum RSRislTextAlignment : NSInteger;

/// The RislCard object to send to RapidScan on Halo.
SWIFT_CLASS("_TtC18RapidScanCompanion10RSRislCard")
@interface RSRislCard : NSObject
- (nonnull instancetype)init SWIFT_UNAVAILABLE;
+ (nonnull instancetype)new SWIFT_UNAVAILABLE_MSG("-init is unavailable");
/// Create a new RislCard with specified width and height
/// <ul>
///   <li>
///     Parameters:
///   </li>
///   <li>
///     width: The width of RislCard shown on Halo device. Max is 290.
///   </li>
///   <li>
///     height: The height of the RislCard shown on Halo device
///   </li>
/// </ul>
- (nonnull instancetype)initWithWidth:(NSInteger)width height:(NSInteger)height OBJC_DESIGNATED_INITIALIZER;
/// Append final command to display RislCard on Halo device
///
/// returns:
/// RSRislCard for affluent acces
- (RSRislCard * _Nonnull)showCard;
/// Append final command to save RislCard on Halo device
/// \param name The name to save this RislCard on Halo device
///
///
/// returns:
/// RSRislCard for affluent acces
- (RSRislCard * _Nonnull)saveCardWithName:(NSString * _Nonnull)name;
/// Load a saved RislCard on Halo device with the corresponding name
/// \param name The name of RislCard to load on Halo device
///
///
/// returns:
/// RSRislCard for affluent acces
+ (RSRislCard * _Nonnull)loadCardWithName:(NSString * _Nonnull)name SWIFT_WARN_UNUSED_RESULT;
/// Get the command string value of this RislCard
///
/// returns:
/// The command string value of this RislCard
- (NSString * _Nonnull)toString SWIFT_WARN_UNUSED_RESULT;
/// Set background color for the RislCard on Halo device
/// \param color The hex color value (e.g.: #0000FF)
///
///
/// returns:
/// RSRislCard for affluent access
- (RSRislCard * _Nonnull)setBackgroundColor:(NSString * _Nonnull)color;
/// Set font for text. This must be added prior to the text to take affect. If font is not provided, the last available font will be used.
- (RSRislCard * _Nonnull)setFontWithSize:(NSInteger)size color:(NSString * _Nullable)color bold:(BOOL)bold underline:(BOOL)underline;
- (RSRislCard * _Nonnull)textCenterWithY:(NSInteger)y text:(NSString * _Nonnull)text;
- (RSRislCard * _Nonnull)textLeftWithY:(NSInteger)y text:(NSString * _Nonnull)text;
- (RSRislCard * _Nonnull)textRightWithY:(NSInteger)y text:(NSString * _Nonnull)text;
/// Generate an encoded font string for the text which will be added to RislCard. This value is used in combination with <code>text(...)</code>
/// <ul>
///   <li>
///     Parameters:
///   </li>
///   <li>
///     size: Text size
///   </li>
///   <li>
///     color: Color in hex string value (e.g.: #000000)
///   </li>
///   <li>
///     bold: Make text bold
///   </li>
///   <li>
///     underline: Add underline to text
///   </li>
/// </ul>
///
/// returns:
/// The encoded font string for RislCard
+ (NSString * _Nonnull)encodeFontWithSize:(NSInteger)size color:(NSString * _Nullable)color bold:(BOOL)bold underline:(BOOL)underline SWIFT_WARN_UNUSED_RESULT;
/// Add a new text to the RislCard
/// <ul>
///   <li>
///     Parameters:
///   </li>
///   <li>
///     text: The text value
///   </li>
///   <li>
///     verticlePosition: The Y-Axis position of the text on the RislCard
///   </li>
///   <li>
///     alignment: The text alignment. One of <code>RSRislTextAlignment</code>
///   </li>
///   <li>
///     encodedFont: The encoded font string from <code>encodeFont(...)</code>
///   </li>
/// </ul>
///
/// returns:
/// RSRislCard for affluent access
- (RSRislCard * _Nonnull)text:(NSString * _Nonnull)text verticlePosition:(NSInteger)verticlePosition alignment:(enum RSRislTextAlignment)alignment font:(NSString * _Nullable)font;
/// Add a button to the RislCard
/// <ul>
///   <li>
///     Parameters:
///   </li>
///   <li>
///     x: Start x position
///   </li>
///   <li>
///     y: Start y position
///   </li>
///   <li>
///     width: Width of button
///   </li>
///   <li>
///     height: Height of button
///   </li>
///   <li>
///     color: The color for button in hex value (e.g.: #000FFF)
///   </li>
///   <li>
///     id: Identifier for the button
///   </li>
/// </ul>
///
/// returns:
/// RSRislCard object for affluent access
- (RSRislCard * _Nonnull)buttonWithX:(NSInteger)x y:(NSInteger)y width:(NSInteger)width height:(NSInteger)height color:(NSString * _Nonnull)color text:(NSString * _Nonnull)text id:(NSString * _Nonnull)id;
/// Play sound on Halo device
/// <ul>
///   <li>
///     Parameters:
///   </li>
///   <li>
///     sound: Name of sound
///   </li>
/// </ul>
///
/// returns:
/// RSRislCard object for affluent access
- (RSRislCard * _Nonnull)playSoundWithSound:(NSString * _Nonnull)sound;
/// Play sound on Halo device for specified amout of time
/// <ul>
///   <li>
///     Parameters:
///   </li>
///   <li>
///     sound: Name of sound
///   </li>
///   <li>
///     duration: Duration in ms
///   </li>
/// </ul>
///
/// returns:
/// RSRislCard object for affluent access
- (RSRislCard * _Nonnull)playSoundWithSound:(NSString * _Nonnull)sound duration:(NSInteger)duration;
/// Play good sound when displaying the RislCard on Halo device
///
/// returns:
/// RSRislCard object for affluent access
- (RSRislCard * _Nonnull)playGoodSound;
/// Play good sound #2 when displaying the RislCard on Halo device
///
/// returns:
/// RSRislCard object for affluent access
- (RSRislCard * _Nonnull)playGood2Sound;
/// Play bad sound when displaying the RislCard on Halo device
///
/// returns:
/// RSRislCard object for affluent access
- (RSRislCard * _Nonnull)playBadSound;
/// Play alert sound when displaying the RislCard on Halo device
///
/// returns:
/// RSRislCard object for affluent access
- (RSRislCard * _Nonnull)playAlertSound;
/// Vibrate the Halo device when displaying the RislCard
/// \param intensity The vibration intensity from 1 to 4
///
///
/// returns:
/// RSRislCard object for affluent access
- (RSRislCard * _Nonnull)vibrateWithIntensity:(NSInteger)intensity;
/// Custom vibration for the Halo device
/// \param pattern Array of integers representing the duration of each vibration segment in milliseconds
///
/// \param amplitudes Array of integers specifying the strength of the vibration for each corresponding segment (0-255)
///
///
/// returns:
/// RSRislCard object for affluent access
- (RSRislCard * _Nonnull)vibrateCustomWithPattern:(NSArray<NSNumber *> * _Nonnull)pattern amplitudes:(NSArray<NSNumber *> * _Nonnull)amplitudes;
- (RSRislCard * _Nonnull)launchCamera;
- (RSRislCard * _Nonnull)enableCameraButton;
- (RSRislCard * _Nonnull)disableCameraButton;
- (RSRislCard * _Nonnull)clear;
- (RSRislCard * _Nonnull)appendRawCommand:(NSString * _Nonnull)command;
@end

typedef SWIFT_ENUM(NSInteger, RSRislTextAlignment, open) {
  RSRislTextAlignmentLeft = 0,
  RSRislTextAlignmentCenter = 1,
  RSRislTextAlignmentRight = 2,
};

#endif
#if __has_attribute(external_source_symbol)
# pragma clang attribute pop
#endif
#if defined(__cplusplus)
#endif
#pragma clang diagnostic pop
#endif

#else
#error unsupported Swift architecture
#endif
