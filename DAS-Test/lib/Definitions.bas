Attribute VB_Name = "Module1"

'*********************************************************************
'                   maxon motor ag, CH-6072 Sachseln
'*********************************************************************
'
' File:             Definitions.bas
'
' Description:      Function definitions for EposCmd.dll library for Developer Platform Microsoft Visual Basic
'
' Dev. Platform:    Microsoft Visual Basic 6.0
'
' Target:           Windows Operating Systems
'
' Written by:       maxon motor ag, CH-6072 Sachseln
'
' History:          See chapter History in the document EPOS Command Library
'
' Copyright © 2003 - 2021, maxon motor ag.
' All rights reserved.
'*********************************************************************
'
' Attention!
' Some DLL procedures return a C++ specific unsigned parameter ( WORD, DWORD). They are mapped to a
' Visual Basic specific signed parameter ( Integer, Long). You have to ensure that these values are handled correctly.
' Because the Boolean dimension is 16bit it will use the Long type for BOOL (MS VC++) values.
'*********************************************************************

' --------------------------------------------------------------------------
'                   IMPORTED FUNCTIONS PROTOTYPE
' --------------------------------------------------------------------------

Option Explicit

'*************************************************************************************************************************************
' INITIALISATION FUNCTIONS
'************************************************************************************************************************************/

'Communication
Declare Function VCS_OpenDevice Lib "EposCmd.dll" Alias "_VCS_OpenDevice@20" (ByVal DeviceName As String, ByVal ProtocolStackName As String, ByVal InterfaceName As String, ByVal PortName As String, ByRef pErrorCode As Long) As Long
Declare Function VCS_OpenDeviceDlg Lib "EposCmd.dll" Alias "_VCS_OpenDeviceDlg@4" (ByRef pErrorCode As Long) As Long
Declare Function VCS_SetProtocolStackSettings Lib "EposCmd.dll" Alias "_VCS_SetProtocolStackSettings@16" (ByVal KeyHandle As Long, ByVal Baudrate As Long, ByVal Timeout As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetProtocolStackSettings Lib "EposCmd.dll" Alias "_VCS_GetProtocolStackSettings@16" (ByVal KeyHandle As Long, ByRef pBaudrate As Long, ByRef pTimeout As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_FindDeviceCommunicationSettings Lib "EposCmd.dll" Alias "_VCS_FindDeviceCommunicationSettings@44" (ByRef KeyHandle As Long, ByVal pDeviceName As String, ByVal pProtocolStackName As String, ByVal pInterfaceName As String, ByVal pPortName As String, ByVal SizeName As Integer, ByRef pBaudrate As Long, ByRef pTimeout As Long, ByRef pNodeId As Integer, ByVal DialogMode As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_CloseAllDevices Lib "EposCmd.dll" Alias "_VCS_CloseAllDevices@4" (ByRef pErrorCode As Long) As Long
Declare Function VCS_CloseDevice Lib "EposCmd.dll" Alias "_VCS_CloseDevice@8" (ByVal KeyHandle As Long, ByRef pErrorCode As Long) As Long

'Gateway
Declare Function VCS_SetGatewaySettings Lib "EposCmd.dll" Alias "_VCS_SetGatewaySettings@12" (ByVal KeyHandle As Long, ByVal Baudrate As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetGatewaySettings Lib "EposCmd.dll" Alias "_VCS_GetGatewaySettings@12" (ByVal KeyHandle As Long, ByRef pBaudrate As Long, ByRef pErrorCode As Long) As Long

'Subdevice
Declare Function VCS_OpenSubDevice Lib "EposCmd.dll" Alias "_VCS_OpenSubDevice@16" (ByVal DeviceHandle As Long, ByVal DeviceName As String, ByVal ProtocolStackName As String, ByRef pErrorCode As Long) As Long
Declare Function VCS_OpenSubDeviceDlg Lib "EposCmd.dll" Alias "_VCS_OpenSubDeviceDlg@8" (ByVal DeviceHandle As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_FindSubDeviceCommunicationSettings Lib "EposCmd.dll" Alias "_VCS_FindSubDeviceCommunicationSettings@36" (ByVal DeviceHandle As Long, ByRef pKeyHandle As Long, ByVal pDeviceName As String, ByVal pProtocolStackName As String, ByVal SizeName As Integer, ByRef pBaudrate As Long, ByRef pNodeId As Integer, ByVal DialogMode As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_CloseSubDevice Lib "EposCmd.dll" Alias "_VCS_CloseSubDevice@8" (ByVal KeyHandle As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_CloseAllSubDevices Lib "EposCmd.dll" Alias "_VCS_CloseAllSubDevices@8" (ByVal DeviceHandle As Long, ByRef pErrorCode As Long) As Long

'Info
Declare Function VCS_GetDriverInfo Lib "EposCmd.dll" Alias "_VCS_GetDriverInfo@20" (ByVal pLibraryName As String, ByVal MaxStrNameSize As Integer, ByVal pLibraryVersion As String, ByVal MaxStrVersionSize As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetVersion Lib "EposCmd.dll" Alias "_VCS_GetVersion@28" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pHardwareVersion As Integer, ByRef pSoftwareVersion As Integer, ByRef pApplicationNumber As Integer, ByRef pApplicationVersion As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetErrorInfo Lib "EposCmd.dll" Alias "_VCS_GetErrorInfo@12" (ByVal ErrorCodeValue As Long, ByVal pErrorInfo As String, ByVal MaxStrSize As Integer) As Long

'Advanced Functions
Declare Function VCS_GetDeviceNameSelection Lib "EposCmd.dll" Alias "_VCS_GetDeviceNameSelection@20" (ByVal StartOfSelection As Long, ByVal pDeviceNameSel As String, ByVal MaxStrSize As Integer, ByRef pEndOfSelection As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetProtocolStackNameSelection Lib "EposCmd.dll" Alias "_VCS_GetProtocolStackNameSelection@24" (ByVal DeviceName As String, ByVal StartOfSelection As Long, ByVal pProtocolStackNameSel As String, ByVal MaxStrSize As Integer, ByRef pEndOfSelection As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetInterfaceNameSelection Lib "EposCmd.dll" Alias "_VCS_GetInterfaceNameSelection@28" (ByVal DeviceName As String, ByVal ProtocolStackName As String, ByVal StartOfSelection As Long, ByVal pInterfaceNameSel As String, ByVal MaxStrSize As Integer, ByRef pEndOfSelection As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetPortNameSelection Lib "EposCmd.dll" Alias "_VCS_GetPortNameSelection@32" (ByVal DeviceName As String, ByVal ProtocolStackName As String, ByVal InterfaceName As String, ByVal StartOfSelection As Long, ByVal pPortSel As String, ByVal MaxStrSize As Integer, ByRef pEndOfSelection As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_ResetPortNameSelection Lib "EposCmd.dll" Alias "_VCS_ResetPortNameSelection@16" (ByVal DeviceName As String, ByVal ProtocolStackName As String, ByVal InterfaceName As String, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetBaudrateSelection Lib "EposCmd.dll" Alias "_VCS_GetBaudrateSelection@32" (ByVal DeviceName As String, ByVal ProtocolStackName As String, ByVal InterfaceName As String, ByVal PortName As String, ByVal StartOfSelection As Long, ByRef pBaudrateSel As Long, ByRef pEndOfSelection As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetKeyHandle Lib "EposCmd.dll" Alias "_VCS_GetKeyHandle@24" (ByVal DeviceName As String, ByVal ProtocolStackName As String, ByVal InterfaceName As String, ByVal PortName As String, ByRef pKeyHandle As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetDeviceName Lib "EposCmd.dll" Alias "_VCS_GetDeviceName@16" (ByVal KeyHandle As Long, ByVal pDeviceName As String, ByVal MaxStrSize As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetProtocolStackName Lib "EposCmd.dll" Alias "_VCS_GetProtocolStackName@16" (ByVal KeyHandle As Long, ByVal pProtocolStackName As String, ByVal MaxStrSize As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetInterfaceName Lib "EposCmd.dll" Alias "_VCS_GetInterfaceName@16" (ByVal KeyHandle As Long, ByVal pInterfaceName As String, ByVal MaxStrSize As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetPortName Lib "EposCmd.dll" Alias "_VCS_GetPortName@16" (ByVal KeyHandle As Long, ByVal pPortName As String, ByVal MaxStrSize As Integer, ByRef pErrorCode As Long) As Long

'*************************************************************************************************************************************
' CONFIGURATION FUNCTIONS
'************************************************************************************************************************************/

'General
Declare Function VCS_ImportParameter Lib "EposCmd.dll" Alias "_VCS_ImportParameter@24" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal pParameterFileName As String, ByVal ShowDlg As Long, ByVal ShowMsg As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_ExportParameter Lib "EposCmd.dll" Alias "_VCS_ExportParameter@36" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal pParameterFileName As String, ByVal pFirmwareFileName As String, ByVal pUserID As String, ByVal pComment As String, ByVal ShowDlg As Long, ByVal ShowMsg As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetObject Lib "EposCmd.dll" Alias "_VCS_SetObject@32" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal ObjectIndex As Integer, ByVal ObjectSubIndex As Byte, ByRef Data As Any, ByVal NbOfBytesToWrite As Long, ByRef pNbOfBytesWritten As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetObject Lib "EposCmd.dll" Alias "_VCS_GetObject@32" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal ObjectIndex As Integer, ByVal ObjectSubIndex As Byte, ByRef pData As Any, ByVal NbOfBytesToRead As Long, ByRef pNbOfBytesRead As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_Restore Lib "EposCmd.dll" Alias "_VCS_Restore@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_Store Lib "EposCmd.dll" Alias "_VCS_Store@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long

'Advanced Functions
'Motor
Declare Function VCS_SetMotorType Lib "EposCmd.dll" Alias "_VCS_SetMotorType@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal MotorType As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetDcMotorParameter Lib "EposCmd.dll" Alias "_VCS_SetDcMotorParameter@24" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal NominalCurrent As Integer, ByVal MaxOutputCurrent As Integer, ByVal ThermalTimeConstant As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetDcMotorParameterEx Lib "EposCmd.dll" Alias "_VCS_SetDcMotorParameterEx@24" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal NominalCurrent As Long, ByVal MaxOutputCurrent As Long, ByVal ThermalTimeConstant As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetEcMotorParameter Lib "EposCmd.dll" Alias "_VCS_SetEcMotorParameter@28" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal NominalCurrent As Integer, ByVal MaxOutputCurrent As Integer, ByVal ThermalTimeConstant As Integer, ByVal NbOfPolePairs As Byte, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetEcMotorParameterEx Lib "EposCmd.dll" Alias "_VCS_SetEcMotorParameterEx@28" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal NominalCurrent As Long, ByVal MaxOutputCurrent As Long, ByVal ThermalTimeConstant As Integer, ByVal NbOfPolePairs As Byte, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetMotorType Lib "EposCmd.dll" Alias "_VCS_GetMotorType@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pMotorType As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetDcMotorParameter Lib "EposCmd.dll" Alias "_VCS_GetDcMotorParameter@24" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pNominalCurrent As Integer, ByRef pMaxOutputCurrent As Integer, ByRef pThermalTimeConstant As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetDcMotorParameterEx Lib "EposCmd.dll" Alias "_VCS_GetDcMotorParameterEx@24" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pNominalCurrent As Long, ByRef pMaxOutputCurrent As Long, ByRef pThermalTimeConstant As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetEcMotorParameter Lib "EposCmd.dll" Alias "_VCS_GetEcMotorParameter@28" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pNominalCurrent As Integer, ByRef pMaxOutputCurrent As Integer, ByRef pThermalTimeConstant As Integer, ByRef pNbOfPolePairs As Byte, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetEcMotorParameterEx Lib "EposCmd.dll" Alias "_VCS_GetEcMotorParameterEx@28" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pNominalCurrent As Long, ByRef pMaxOutputCurrent As Long, ByRef pThermalTimeConstant As Integer, ByRef pNbOfPolePairs As Byte, ByRef pErrorCode As Long) As Long

'Sensor
Declare Function VCS_SetSensorType Lib "EposCmd.dll" Alias "_VCS_SetSensorType@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal SensorType As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetIncEncoderParameter Lib "EposCmd.dll" Alias "_VCS_SetIncEncoderParameter@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal EncoderResolution As Long, ByVal InvertedPolarity As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetHallSensorParameter Lib "EposCmd.dll" Alias "_VCS_SetHallSensorParameter@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal InvertedPolarity As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetSsiAbsEncoderParameter Lib "EposCmd.dll" Alias "_VCS_SetSsiAbsEncoderParameter@28" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal DataRate As Integer, ByVal NbOfMultiTurnDataBits As Integer, ByVal NbOfSingleTurnDataBits As Integer, ByVal InvertedPolarity As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetSsiAbsEncoderParameterEx Lib "EposCmd.dll" Alias "_VCS_SetSsiAbsEncoderParameterEx@40" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal DataRate As Integer, ByVal NbOfMultiTurnDataBits As Integer, ByVal NbOfSingleTurnDataBits As Integer, ByVal NbOfSpecialDataBits As Integer, ByVal InvertedPolarity As Long, ByVal Timeout As UShort, ByVal PowerupTime As UShort, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetSsiAbsEncoderParameterEx2 Lib "EposCmd.dll" Alias "_VCS_SetSsiAbsEncoderParameterEx2@60" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal DataRate As Integer, ByVal NbOfSpecialDataBitsLeading As Integer, ByVal NbOfMultiTurnDataBits As Integer, ByVal NbOfMultiTurnPositionBits As Integer, ByVal NbOfSingleTurnDataBits As Integer, ByVal NbOfSingleTurnPositionBits As Integer, ByVal NbOfSpecialDataBitsTrailing As Integer, ByVal InvertedPolarity As Long, ByVal Timeout As Integer, ByVal PowerupTime As Integer, ByVal CheckFrame As Long, ByVal ReferenceReset As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetSensorType Lib "EposCmd.dll" Alias "_VCS_GetSensorType@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pSensorType As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetIncEncoderParameter Lib "EposCmd.dll" Alias "_VCS_GetIncEncoderParameter@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pEncoderResolution As Long, ByRef pInvertedPolarity As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetHallSensorParameter Lib "EposCmd.dll" Alias "_VCS_GetHallSensorParameter@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pInvertedPolarity As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetSsiAbsEncoderParameter Lib "EposCmd.dll" Alias "_VCS_GetSsiAbsEncoderParameter@28" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pDataRate As Integer, ByRef pNbOfMultiTurnDataBits As Integer, ByRef pNbOfSingleTurnDataBits As Integer, ByRef pInvertedPolarity As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetSsiAbsEncoderParameterEx Lib "EposCmd.dll" Alias "_VCS_GetSsiAbsEncoderParameterEx@40" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pDataRate As Integer, ByRef pNbOfMultiTurnDataBits As Integer, ByRef pNbOfSingleTurnDataBits As Integer, ByRef pNbOfSpecialDataBits As Integer, ByRef pInvertedPolarity As Long, ByRef pTimeout As Integer, ByRef pPowerupTime As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetSsiAbsEncoderParameterEx2 Lib "EposCmd.dll" Alias "_VCS_GetSsiAbsEncoderParameterEx2@60" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pDataRate As Integer, ByRef pNbOfSpecialDataBitsLeading As Integer, ByRef pNbOfMultiTurnDataBits As Integer, ByRef pNbOfMultiTurnPositionBits As Integer, ByRef pNbOfSingleTurnDataBits As Integer, ByRef pNbOfSingleTurnPositionBits As Integer, ByRef pNbOfSpecialDataBitsTrailing As Integer, ByRef pInvertedPolarity As Long, ByRef pTimeout As Integer, ByRef pPowerupTime As Integer, ByRef pCheckFrame As Long, ByRef pReferenceReset As Long, ByRef pErrorCode As Long) As Long

'Safety
Declare Function VCS_SetMaxFollowingError Lib "EposCmd.dll" Alias "_VCS_SetMaxFollowingError@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal MaxFollowingError As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetMaxFollowingError Lib "EposCmd.dll" Alias "_VCS_GetMaxFollowingError@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pMaxFollowingError As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetMaxProfileVelocity Lib "EposCmd.dll" Alias "_VCS_SetMaxProfileVelocity@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal MaxProfileVelocity As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetMaxProfileVelocity Lib "EposCmd.dll" Alias "_VCS_GetMaxProfileVelocity@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pMaxProfileVelocity As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetMaxAcceleration Lib "EposCmd.dll" Alias "_VCS_SetMaxAcceleration@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal MaxAcceleration As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetMaxAcceleration Lib "EposCmd.dll" Alias "_VCS_GetMaxAcceleration@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pMaxAcceleration As Long, ByRef pErrorCode As Long) As Long

'Inputs/Outputs
Declare Function VCS_DigitalInputConfiguration Lib "EposCmd.dll" Alias "_VCS_DigitalInputConfiguration@32" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal DigInputNb As Integer, ByVal Configuration As Integer, ByVal Mask As Long, ByVal Polarity As Long, ByVal ExecutionMask As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_DigitalOutputConfiguration Lib "EposCmd.dll" Alias "_VCS_DigitalOutputConfiguration@32" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal DigOutputNb As Integer, ByVal Configuration As Integer, ByVal State As Long, ByVal Mask As Long, ByVal Polarity As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_AnalogInputConfiguration Lib "EposCmd.dll" Alias "_VCS_AnalogInputConfiguration@24" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal AnalogInputNb As Integer, ByVal Configuration As Integer, ByVal ExecutionMask As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_AnalogOutputConfiguration Lib "EposCmd.dll" Alias "_VCS_AnalogOutputConfiguration@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal AnalogOutputNb As Integer, ByVal Configuration As Integer, ByRef pErrorCode As Long) As Long

'Units
Declare Function VCS_SetVelocityUnits Lib "EposCmd.dll" Alias "_VCS_SetVelocityUnits@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal VelDimension As Byte, ByVal VelNotation As Byte, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetVelocityUnits Lib "EposCmd.dll" Alias "_VCS_GetVelocityUnits@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pVelDimension As Byte, ByRef pVelNotation As Byte, ByRef pErrorCode As Long) As Long

'Compatibility Functions (do not use)
Declare Function VCS_SetMotorParameter Lib "EposCmd.dll" Alias "_VCS_SetMotorParameter@32" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal MotorType As Integer, ByVal ContinuousCurrent As Integer, ByVal PeakCurrent As Integer, ByVal PolePair As Byte, ByVal ThermalTimeConstant As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetMotorParameter Lib "EposCmd.dll" Alias "_VCS_GetMotorParameter@32" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pMotorType As Integer, ByRef pContinuousCurrent As Integer, ByRef pPeakCurrent As Integer, ByRef pPolePair As Byte, ByRef pThermalTimeConstant As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetEncoderParameter Lib "EposCmd.dll" Alias "_VCS_SetEncoderParameter@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal Counts As Integer, ByVal PositionSensorType As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetEncoderParameter Lib "EposCmd.dll" Alias "_VCS_GetEncoderParameter@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pCounts As Integer, ByRef pPositionSensorType As Integer, ByRef pErrorCode As Long) As Long

Declare Function VCS_SetPositionRegulatorGain Lib "EposCmd.dll" Alias "_VCS_SetPositionRegulatorGain@24" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal P As Integer, ByVal I As Integer, ByVal D As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetPositionRegulatorFeedForward Lib "EposCmd.dll" Alias "_VCS_SetPositionRegulatorFeedForward@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal VelocityFeedForward As Integer, ByVal AccelerationFeedForward As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetPositionRegulatorGain Lib "EposCmd.dll" Alias "_VCS_GetPositionRegulatorGain@24" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pP As Integer, ByRef pI As Integer, ByRef pD As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetPositionRegulatorFeedForward Lib "EposCmd.dll" Alias "_VCS_GetPositionRegulatorFeedForward@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pVelocityFeedForward As Integer, ByRef pAccelerationFeedForward As Integer, ByRef pErrorCode As Long) As Long

Declare Function VCS_SetVelocityRegulatorGain Lib "EposCmd.dll" Alias "_VCS_SetVelocityRegulatorGain@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal P As Integer, ByVal I As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetVelocityRegulatorFeedForward Lib "EposCmd.dll" Alias "_VCS_SetVelocityRegulatorFeedForward@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal VelocityFeedForward As Integer, ByVal AccelerationFeedForward As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetVelocityRegulatorGain Lib "EposCmd.dll" Alias "_VCS_GetVelocityRegulatorGain@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pP As Integer, ByRef pI As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetVelocityRegulatorFeedForward Lib "EposCmd.dll" Alias "_VCS_GetVelocityRegulatorFeedForward@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pVelocityFeedForward As Integer, ByRef pAccelerationFeedForward As Integer, ByRef pErrorCode As Long) As Long

Declare Function VCS_SetCurrentRegulatorGain Lib "EposCmd.dll" Alias "_VCS_SetCurrentRegulatorGain@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal P As Integer, ByVal I As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetCurrentRegulatorGain Lib "EposCmd.dll" Alias "_VCS_GetCurrentRegulatorGain@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pP As Integer, ByRef pI As Integer, ByRef pErrorCode As Long) As Long

'*************************************************************************************************************************************
' OPERATION FUNCTIONS
'************************************************************************************************************************************/

'OperationMode
'Attention: Parameter pMode: The DLL returns negative values, but Visual Basic does not have an signed type for size of 1Byte
Declare Function VCS_SetOperationMode Lib "EposCmd.dll" Alias "_VCS_SetOperationMode@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal Mode As Byte, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetOperationMode Lib "EposCmd.dll" Alias "_VCS_GetOperationMode@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pMode As Byte, ByRef pErrorCode As Long) As Long

'StateMachine
Declare Function VCS_ResetDevice Lib "EposCmd.dll" Alias "_VCS_ResetDevice@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetState Lib "EposCmd.dll" Alias "_VCS_SetState@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal State As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetEnableState Lib "EposCmd.dll" Alias "_VCS_SetEnableState@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetDisableState Lib "EposCmd.dll" Alias "_VCS_SetDisableState@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetQuickStopState Lib "EposCmd.dll" Alias "_VCS_SetQuickStopState@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_ClearFault Lib "EposCmd.dll" Alias "_VCS_ClearFault@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetState Lib "EposCmd.dll" Alias "_VCS_GetState@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pState As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetEnableState Lib "EposCmd.dll" Alias "_VCS_GetEnableState@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pIsEnabled As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetDisableState Lib "EposCmd.dll" Alias "_VCS_GetDisableState@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pIsDisabled As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetQuickStopState Lib "EposCmd.dll" Alias "_VCS_GetQuickStopState@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pIsQuickStopped As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetFaultState Lib "EposCmd.dll" Alias "_VCS_GetFaultState@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pIsInFault As Long, ByRef pErrorCode As Long) As Long

'ErrorHandling
Declare Function VCS_GetNbOfDeviceError Lib "EposCmd.dll" Alias "_VCS_GetNbOfDeviceError@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pNbDeviceError As Byte, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetDeviceErrorCode Lib "EposCmd.dll" Alias "_VCS_GetDeviceErrorCode@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal DeviceErrorNumber As Byte, ByRef pDeviceErrorCode As Long, ByRef pErrorCode As Long) As Long

'Motion Info
Declare Function VCS_GetMovementState Lib "EposCmd.dll" Alias "_VCS_GetMovementState@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pTargetReached As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetPositionIs Lib "EposCmd.dll" Alias "_VCS_GetPositionIs@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pPositionIs As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetVelocityIs Lib "EposCmd.dll" Alias "_VCS_GetVelocityIs@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pVelocityIs As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetVelocityIsAveraged Lib "EposCmd.dll" Alias "_VCS_GetVelocityIsAveraged@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pVelocityIsAveraged As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetCurrentIs Lib "EposCmd.dll" Alias "_VCS_GetCurrentIs@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pCurrentIs As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetCurrentIsEx Lib "EposCmd.dll" Alias "_VCS_GetCurrentIsEx@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pCurrentIs As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetCurrentIsAveraged Lib "EposCmd.dll" Alias "_VCS_GetCurrentIsAveraged@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pCurrentIsAveraged As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetCurrentIsAveragedEx Lib "EposCmd.dll" Alias "_VCS_GetCurrentIsAveragedEx@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pCurrentIsAveraged As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_WaitForTargetReached Lib "EposCmd.dll" Alias "_VCS_WaitForTargetReached@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal Timeout As Long, ByRef pErrorCode As Long) As Long

'Profile Position Mode
Declare Function VCS_ActivateProfilePositionMode Lib "EposCmd.dll" Alias "_VCS_ActivateProfilePositionMode@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetPositionProfile Lib "EposCmd.dll" Alias "_VCS_SetPositionProfile@24" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal ProfileVelocity As Long, ByVal ProfileAcceleration As Long, ByVal ProfileDeceleration As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetPositionProfile Lib "EposCmd.dll" Alias "_VCS_GetPositionProfile@24" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pProfileVelocity As Long, ByRef pProfileAcceleration As Long, ByRef pProfileDeceleration As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_MoveToPosition Lib "EposCmd.dll" Alias "_VCS_MoveToPosition@24" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal TargetPosition As Long, ByVal Absolute As Long, ByVal Immediately As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetTargetPosition Lib "EposCmd.dll" Alias "_VCS_GetTargetPosition@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pTargetPosition As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_HaltPositionMovement Lib "EposCmd.dll" Alias "_VCS_HaltPositionMovement@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long

'Advanced Functions
Declare Function VCS_EnablePositionWindow Lib "EposCmd.dll" Alias "_VCS_EnablePositionWindow@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal PositionWindow As Long, ByVal PositionWindowTime As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_DisablePositionWindow Lib "EposCmd.dll" Alias "_VCS_DisablePositionWindow@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long

'Profile Velocity Mode
Declare Function VCS_ActivateProfileVelocityMode Lib "EposCmd.dll" Alias "_VCS_ActivateProfileVelocityMode@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetVelocityProfile Lib "EposCmd.dll" Alias "_VCS_SetVelocityProfile@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal ProfileAcceleration As Long, ByVal ProfileDeceleration As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetVelocityProfile Lib "EposCmd.dll" Alias "_VCS_GetVelocityProfile@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pProfileAcceleration As Long, ByRef pProfileDeceleration As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_MoveWithVelocity Lib "EposCmd.dll" Alias "_VCS_MoveWithVelocity@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal TargetVelocity As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetTargetVelocity Lib "EposCmd.dll" Alias "_VCS_GetTargetVelocity@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pTargetVelocity As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_HaltVelocityMovement Lib "EposCmd.dll" Alias "_VCS_HaltVelocityMovement@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long

'Advanced Functions
Declare Function VCS_EnableVelocityWindow Lib "EposCmd.dll" Alias "_VCS_EnableVelocityWindow@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal VelocityWindow As Long, ByVal VelocityWindowTime As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_DisableVelocityWindow Lib "EposCmd.dll" Alias "_VCS_DisableVelocityWindow@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long

'Homing Mode
'Attention: Parameter HomeMode: The DLL returns negative values, but Visual Basic does not have an signed type for size of 1Byte
Declare Function VCS_ActivateHomingMode Lib "EposCmd.dll" Alias "_VCS_ActivateHomingMode@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetHomingParameter Lib "EposCmd.dll" Alias "_VCS_SetHomingParameter@36" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal HomingAcceleration As Long, ByVal SpeedSwitch As Long, ByVal SpeedIndex As Long, ByVal HomeOffset As Long, ByVal CurrentThreshold As Integer, ByVal HomePosition As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetHomingParameter Lib "EposCmd.dll" Alias "_VCS_GetHomingParameter@36" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pHomingAcceleration As Long, ByRef pSpeedSwitch As Long, ByRef pSpeedIndex As Long, ByRef pHomeOffset As Long, ByRef pCurrentThreshold As Integer, ByRef pHomePosition As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_FindHome Lib "EposCmd.dll" Alias "_VCS_FindHome@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal HomingMode As Byte, ByRef pErrorCode As Long) As Long
Declare Function VCS_StopHoming Lib "EposCmd.dll" Alias "_VCS_StopHoming@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_DefinePosition Lib "EposCmd.dll" Alias "_VCS_DefinePosition@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal HomePosition As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_WaitForHomingAttained Lib "EposCmd.dll" Alias "_VCS_WaitForHomingAttained@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal Timeout As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetHomingState Lib "EposCmd.dll" Alias "_VCS_GetHomingState@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pHomingAttained As Long, ByRef pHomingError As Long, ByRef pErrorCode As Long) As Long

'Interpolated Position Mode
Declare Function VCS_ActivateInterpolatedPositionMode Lib "EposCmd.dll" Alias "_VCS_ActivateInterpolatedPositionMode@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetIpmBufferParameter Lib "EposCmd.dll" Alias "_VCS_SetIpmBufferParameter@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal UnderflowWarningLimit As Integer, ByVal OverflowWarningLimit As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetIpmBufferParameter Lib "EposCmd.dll" Alias "_VCS_GetIpmBufferParameter@24" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pUnderflowWarningLimit As Integer, ByRef pOverflowWarningLimit As Integer, ByRef pMaxBufferSize As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_ClearIpmBuffer Lib "EposCmd.dll" Alias "_VCS_ClearIpmBuffer@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetFreeIpmBufferSize Lib "EposCmd.dll" Alias "_VCS_GetFreeIpmBufferSize@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pBufferSize As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_AddPvtValueToIpmBuffer Lib "EposCmd.dll" Alias "_VCS_AddPvtValueToIpmBuffer@24" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal Position As Long, ByVal Velocity As Long, ByVal Time As Byte, ByRef pErrorCode As Long) As Long
Declare Function VCS_StartIpmTrajectory Lib "EposCmd.dll" Alias "_VCS_StartIpmTrajectory@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_StopIpmTrajectory Lib "EposCmd.dll" Alias "_VCS_StartIpmTrajectory@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetIpmStatus Lib "EposCmd.dll" Alias "_VCS_GetIpmStatus@48" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pTrajectoryRunning As Long, ByRef pIsUnderflowWarning As Long, ByRef pIsOverflowWarning As Long, ByRef pIsVelocityWarning As Long, ByRef pIsAccelerationWarning As Long, ByRef pIsUnderflowError As Long, ByRef pIsOverflowError As Long, ByRef pIsVelocityError As Long, ByRef pIsAccelerationError As Long, ByRef pErrorCode As Long) As Long

'Position Mode
Declare Function VCS_ActivatePositionMode Lib "EposCmd.dll" Alias "_VCS_ActivatePositionMode@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetPositionMust Lib "EposCmd.dll" Alias "_VCS_SetPositionMust@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal PositionMust As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetPositionMust Lib "EposCmd.dll" Alias "_VCS_GetPositionMust@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pPositionMust As Long, ByRef pErrorCode As Long) As Long

'Advanced Functions
Declare Function VCS_ActivateAnalogPositionSetpoint Lib "EposCmd.dll" Alias "_VCS_ActivateAnalogPositionSetpoint@24" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal AnalogInputNumber As Integer, ByVal Scaling As Single, ByVal Offset As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_DeactivateAnalogPositionSetpoint Lib "EposCmd.dll" Alias "_VCS_DeactivateAnalogPositionSetpoint@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal AnalogInputNumber As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_EnableAnalogPositionSetpoint Lib "EposCmd.dll" Alias "_VCS_EnableAnalogPositionSetpoint@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_DisableAnalogPositionSetpoint Lib "EposCmd.dll" Alias "_VCS_DisableAnalogPositionSetpoint@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long

'Velocity Mode
Declare Function VCS_ActivateVelocityMode Lib "EposCmd.dll" Alias "_VCS_ActivateVelocityMode@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetVelocityMust Lib "EposCmd.dll" Alias "_VCS_SetVelocityMust@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal VelocityMust As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetVelocityMust Lib "EposCmd.dll" Alias "_VCS_GetVelocityMust@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pVelocityMust As Long, ByRef pErrorCode As Long) As Long

'Advanced Functions
Declare Function VCS_ActivateAnalogVelocitySetpoint Lib "EposCmd.dll" Alias "_VCS_ActivateAnalogVelocitySetpoint@24" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal AnalogInputNumber As Integer, ByVal Scaling As Single, ByVal Offset As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_DeactivateAnalogVelocitySetpoint Lib "EposCmd.dll" Alias "_VCS_DeactivateAnalogVelocitySetpoint@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal AnalogInputNumber As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_EnableAnalogVelocitySetpoint Lib "EposCmd.dll" Alias "_VCS_EnableAnalogVelocitySetpoint@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_DisableAnalogVelocitySetpoint Lib "EposCmd.dll" Alias "_VCS_DisableAnalogVelocitySetpoint@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long

'Current Mode
Declare Function VCS_ActivateCurrentMode Lib "EposCmd.dll" Alias "_VCS_ActivateCurrentMode@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetCurrentMust Lib "EposCmd.dll" Alias "_VCS_SetCurrentMust@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal CurrentMust As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetCurrentMustEx Lib "EposCmd.dll" Alias "_VCS_SetCurrentMustEx@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal CurrentMust As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetCurrentMust Lib "EposCmd.dll" Alias "_VCS_GetCurrentMust@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pCurrentMust As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetCurrentMustEx Lib "EposCmd.dll" Alias "_VCS_GetCurrentMustEx@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pCurrentMust As Long, ByRef pErrorCode As Long) As Long

'Advanced Functions
Declare Function VCS_ActivateAnalogCurrentSetpoint Lib "EposCmd.dll" Alias "_VCS_ActivateAnalogCurrentSetpoint@24" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal AnalogInputNumber As Integer, ByVal Scaling As Single, ByVal Offset As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_DeactivateAnalogCurrentSetpoint Lib "EposCmd.dll" Alias "_VCS_DeactivateAnalogCurrentSetpoint@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal AnalogInputNumber As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_EnableAnalogCurrentSetpoint Lib "EposCmd.dll" Alias "_VCS_EnableAnalogCurrentSetpoint@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_DisableAnalogCurrentSetpoint Lib "EposCmd.dll" Alias "_VCS_DisableAnalogCurrentSetpoint@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long

'MasterEncoder Mode
Declare Function VCS_ActivateMasterEncoderMode Lib "EposCmd.dll" Alias "_VCS_ActivateMasterEncoderMode@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetMasterEncoderParameter Lib "EposCmd.dll" Alias "_VCS_SetMasterEncoderParameter@32" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal ScalingNumerator As Integer, ByVal ScalingDenominator As Integer, ByVal Polarity As Byte, ByVal MaxVelocity As Long, ByVal MaxAcceleration As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetMasterEncoderParameter Lib "EposCmd.dll" Alias "_VCS_GetMasterEncoderParameter@32" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pScalingNumerator As Integer, ByRef pScalingDenominator As Integer, ByRef pPolarity As Byte, ByRef pMaxVelocity As Long, ByRef pMaxAcceleration As Long, ByRef pErrorCode As Long) As Long

'StepDirection Mode
Declare Function VCS_ActivateStepDirectionMode Lib "EposCmd.dll" Alias "_VCS_ActivateStepDirectionMode@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetStepDirectionParameter Lib "EposCmd.dll" Alias "_VCS_SetStepDirectionParameter@32" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal ScalingNumerator As Integer, ByVal ScalingDenominator As Integer, ByVal Polarity As Byte, ByVal MaxVelocity As Long, ByVal MaxAcceleration As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetStepDirectionParameter Lib "EposCmd.dll" Alias "_VCS_GetStepDirectionParameter@32" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pScalingNumerator As Integer, ByRef pScalingDenominator As Integer, ByRef pPolarity As Byte, ByRef pMaxVelocity As Long, ByRef pMaxAcceleration As Long, ByRef pErrorCode As Long) As Long

'Inputs Outputs
'General
Declare Function VCS_GetAllDigitalInputs Lib "EposCmd.dll" Alias "_VCS_GetAllDigitalInputs@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pInputs As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetAllDigitalOutputs Lib "EposCmd.dll" Alias "_VCS_GetAllDigitalOutputs@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pOutputs As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetAllDigitalOutputs Lib "EposCmd.dll" Alias "_VCS_SetAllDigitalOutputs@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal Outputs As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetAnalogInput Lib "EposCmd.dll" Alias "_VCS_GetAnalogInput@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal Number As Integer, ByRef pAnalog As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetAnalogInputVoltage Lib "EposCmd.dll" Alias "_VCS_GetAnalogInputVoltage@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal Number As Integer, ByRef pVoltageValue As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetAnalogInputState Lib "EposCmd.dll" Alias "_VCS_GetAnalogInputState@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal Configuration As Integer, ByRef pStateValue As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetAnalogOutput Lib "EposCmd.dll" Alias "_VCS_SetAnalogOutput@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal OutputNumber As Integer, ByVal AnalogValue As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetAnalogOutputVoltage Lib "EposCmd.dll" Alias "_VCS_SetAnalogOutputVoltage@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal OutputNumber As Integer, ByVal VoltageValue As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetAnalogOutputState Lib "EposCmd.dll" Alias "_VCS_SetAnalogOutputState@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal Configuration As Integer, ByVal StateValue As Long, ByRef pErrorCode As Long) As Long

'Position Compare
Declare Function VCS_SetPositionCompareParameter Lib "EposCmd.dll" Alias "_VCS_SetPositionCompareParameter@36" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal OperationalMode As Byte, ByVal IntervalMode As Byte, ByVal DirectionDependency As Byte, ByVal IntervalWidth As Integer, ByVal IntervalRepetitions As Integer, ByVal PulseWidth As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetPositionCompareParameter Lib "EposCmd.dll" Alias "_VCS_GetPositionCompareParameter@36" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pOperationalMode As Byte, ByRef pIntervalMode As Byte, ByRef pDirectionDependency As Byte, ByRef pIntervalWidth As Integer, ByRef pIntervalRepetitions As Integer, ByRef pPulseWidth As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_ActivatePositionCompare Lib "EposCmd.dll" Alias "_VCS_ActivatePositionCompare@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal DigitalOutputNumber As Integer, ByVal Polarity As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_DeactivatePositionCompare Lib "EposCmd.dll" Alias "_VCS_DeactivatePositionCompare@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal DigitalOutputNumber As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_EnablePositionCompare Lib "EposCmd.dll" Alias "_VCS_EnablePositionCompare@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_DisablePositionCompare Lib "EposCmd.dll" Alias "_VCS_DisablePositionCompare@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_SetPositionCompareReferencePosition Lib "EposCmd.dll" Alias "_VCS_SetPositionCompareReferencePosition@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal ReferencePosition As Long, ByRef pErrorCode As Long) As Long

'Position Marker
Declare Function VCS_SetPositionMarkerParameter Lib "EposCmd.dll" Alias "_VCS_SetPositionMarkerParameter@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal PositionMarkerEdgeType As Byte, ByVal PositionMarkerMode As Byte, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetPositionMarkerParameter Lib "EposCmd.dll" Alias "_VCS_GetPositionMarkerParameter@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pPositionMarkerEdgeType As Byte, ByRef pPositionMarkerMode As Byte, ByRef pErrorCode As Long) As Long
Declare Function VCS_ActivatePositionMarker Lib "EposCmd.dll" Alias "_VCS_ActivatePositionMarker@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal DigitalInputNumber As Integer, ByVal Polarity As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_DeactivatePositionMarker Lib "EposCmd.dll" Alias "_VCS_DeactivatePositionMarker@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal DigitalInputNumber As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_ReadPositionMarkerCounter Lib "EposCmd.dll" Alias "_VCS_ReadPositionMarkerCounter@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pCount As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_ReadPositionMarkerCapturedPosition Lib "EposCmd.dll" Alias "_VCS_ReadPositionMarkerCapturedPosition@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal CounterIndex As Integer, ByRef pCapturedPosition As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_ResetPositionMarkerCounter Lib "EposCmd.dll" Alias "_VCS_ResetPositionMarkerCounter@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long

'*************************************************************************************************************************************
' DATA RECORDING FUNCTIONS
'************************************************************************************************************************************/

'DataRecorder Setup
Declare Function VCS_SetRecorderParameter Lib "EposCmd.dll" Alias "_VCS_SetRecorderParameter@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal SamplingPeriod As Integer, ByVal NbOfPrecedingSamples As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_GetRecorderParameter Lib "EposCmd.dll" Alias "_VCS_GetRecorderParameter@20" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pSamplingPeriod As Integer, ByRef pNbOfPrecedingSamples As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_EnableTrigger Lib "EposCmd.dll" Alias "_VCS_EnableTrigger@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal TriggerType As Byte, ByRef pErrorCode As Long) As Long
Declare Function VCS_DisableAllTriggers Lib "EposCmd.dll" Alias "_VCS_DisableAllTriggers@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_ActivateChannel Lib "EposCmd.dll" Alias "_VCS_ActivateChannel@28" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal ChannelNumber As Byte, ByVal ObjectIndex As Integer, ByVal ObjectSubIndex As Byte, ByVal ObjectSize As Byte, ByRef pErrorCode As Long) As Long
Declare Function VCS_DeactivateAllChannels Lib "EposCmd.dll" Alias "_VCS_DeactivateAllChannels@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long

'DataRecorder Status
Declare Function VCS_StartRecorder Lib "EposCmd.dll" Alias "_VCS_StartRecorder@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_StopRecorder Lib "EposCmd.dll" Alias "_VCS_StopRecorder@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_ForceTrigger Lib "EposCmd.dll" Alias "_VCS_ForceTrigger@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_IsRecorderRunning Lib "EposCmd.dll" Alias "_VCS_IsRecorderRunning@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pRunning As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_IsRecorderTriggered Lib "EposCmd.dll" Alias "_VCS_IsRecorderTriggered@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pTriggered As Long, ByRef pErrorCode As Long) As Long

'DataRecorder Data
Declare Function VCS_ReadChannelVectorSize Lib "EposCmd.dll" Alias "_VCS_ReadChannelVectorSize@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pVectorSize As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_ReadChannelDataVector Lib "EposCmd.dll" Alias "_VCS_ReadChannelDataVector@24" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal ChannelNumber As Byte, ByRef pDataVectorBuffer As Byte, ByVal VectorBufferSize As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_ShowChannelDataDlg Lib "EposCmd.dll" Alias "_VCS_ShowChannelDataDlg@12" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_ExportChannelDataToFile Lib "EposCmd.dll" Alias "_VCS_ExportChannelDataToFile@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal FileName As String, ByRef pErrorCode As Long) As Long

'Advanced Functions
Declare Function VCS_ReadDataBuffer Lib "EposCmd.dll" Alias "_VCS_ReadDataBuffer@36" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByRef pDataBuffer_FirstElement As Byte, ByVal BufferSizeToRead As Long, ByRef pBufferSizeRead As Long, ByRef pVectorStartOffset As Integer, ByRef pMaxNbOfSamples As Integer, ByRef pNbOfRecordedSamples As Integer, ByRef pErrorCode As Long) As Long
Declare Function VCS_ExtractChannelDataVector Lib "EposCmd.dll" Alias "_VCS_ExtractChannelDataVector@44" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal ChannelNumber As Byte, ByRef pDataBuffer_FirstElement As Byte, ByVal BufferSize As Long, ByVal pDataVectorBuffer_FirstElement As Byte, ByVal VectorBufferSize As Long, ByVal VectorStartOffset As Integer, ByVal MaxNbOfSamples As Integer, ByVal NbOfRecordedSamples As Integer, ByRef pErrorCode As Long) As Long

'*************************************************************************************************************************************
' LOW LAYER FUNCTIONS
'************************************************************************************************************************************/

'CanLayer Functions
Declare Function VCS_SendCANFrame Lib "EposCmd.dll" Alias "_VCS_SendCANFrame@20" (ByVal KeyHandle As Long, ByVal CobID As Integer, ByVal Length As Integer, ByRef pData_FirstElement As Byte, ByRef pErrorCode As Long) As Long
Declare Function VCS_ReadCANFrame Lib "EposCmd.dll" Alias "_VCS_ReadCANFrame@24" (ByVal KeyHandle As Long, ByVal CobID As Integer, ByVal Length As Integer, ByRef pData_FirstElement As Byte, ByVal Timeout As Long, ByRef pErrorCode As Long) As Long
Declare Function VCS_RequestCANFrame Lib "EposCmd.dll" Alias "_VCS_RequestCANFrame@20" (ByVal KeyHandle As Long, ByVal CobID As Integer, ByVal Length As Integer, ByRef pData_FirstElement As Byte, ByRef pErrorCode As Long) As Long
Declare Function VCS_SendNMTService Lib "EposCmd.dll" Alias "_VCS_SendNMTService@16" (ByVal KeyHandle As Long, ByVal NodeID As Integer, ByVal CommandSpecifier As Integer, ByRef pErrorCode As Long) As Long

'*************************************************************************************************************************************
' TYPE DEFINITIONS
'************************************************************************************************************************************/

'Communication
    'Dialog Mode
    Const DM_PROGRESS_DLG As Long = 0
    Const DM_PROGRESS_AND_CONFIRM_DLG As Long = 1
    Const DM_CONFIRM_DLG As Long = 2
    Const DM_NO_DLG As Long = 3

'Configuration
    'MotorType
    Const MT_DC_MOTOR As Integer = 1
    Const MT_EC_SINUS_COMMUTATED_MOTOR As Integer = 10
    Const MT_EC_BLOCK_COMMUTATED_MOTOR As Integer = 11

    'SensorType
    Const ST_UNKNOWN As Integer = 0
    Const ST_INC_ENCODER_3CHANNEL As Integer = 1
    Const ST_INC_ENCODER_2CHANNEL As Integer = 2
    Const ST_HALL_SENSORS As Integer = 3
    Const ST_SSI_ABS_ENCODER_BINARY As Integer = 4
    Const ST_SSI_ABS_ENCODER_GREY As Integer = 5
    Const ST_INC_ENCODER2_3CHANNEL As Integer = 6
    Const ST_INC_ENCODER2_2CHANNEL As Integer = 7
    Const ST_ANALOG_INC_ENCODER_3CHANNEL As Integer = 8
    Const ST_ANALOG_INC_ENCODER_2CHANNEL As Integer = 9

'In- and outputs
    'Digital input configuration
    Const DIC_NEGATIVE_LIMIT_SWITCH As Integer = 0
    Const DIC_POSITIVE_LIMIT_SWITCH As Integer = 1
    Const DIC_HOME_SWITCH As Integer = 2
    Const DIC_POSITION_MARKER As Integer = 3
    Const DIC_DRIVE_ENABLE As Integer = 4
    Const DIC_QUICK_STOP As Integer = 5
    Const DIC_GENERAL_PURPOSE_J As Integer = 6
    Const DIC_GENERAL_PURPOSE_I As Integer = 7
    Const DIC_GENERAL_PURPOSE_H As Integer = 8
    Const DIC_GENERAL_PURPOSE_G As Integer = 9
    Const DIC_GENERAL_PURPOSE_F As Integer = 10
    Const DIC_GENERAL_PURPOSE_E As Integer = 11
    Const DIC_GENERAL_PURPOSE_D As Integer = 12
    Const DIC_GENERAL_PURPOSE_C As Integer = 13
    Const DIC_GENERAL_PURPOSE_B As Integer = 14
    Const DIC_GENERAL_PURPOSE_A As Integer = 15

    'Digital output configuration
    Const DOC_READY_FAULT As Integer = 0
    Const DOC_POSITION_COMPARE As Integer = 1
    Const DOC_GENERAL_PURPOSE_H As Integer = 8
    Const DOC_GENERAL_PURPOSE_G As Integer = 9
    Const DOC_GENERAL_PURPOSE_F As Integer = 10
    Const DOC_GENERAL_PURPOSE_E As Integer = 11
    Const DOC_GENERAL_PURPOSE_D As Integer = 12
    Const DOC_GENERAL_PURPOSE_C As Integer = 13
    Const DOC_GENERAL_PURPOSE_B As Integer = 14
    Const DOC_GENERAL_PURPOSE_A As Integer = 15

    'Analog input configuration
    Const AIC_ANALOG_CURRENT_SETPOINT As Integer = 0
    Const AIC_ANALOG_VELOCITY_SETPOINT As Integer = 1
    Const AIC_ANALOG_POSITION_SETPOINT As Integer = 2
    Const AIC_GENERAL_PURPOSE_H As Integer = 8
    Const AIC_GENERAL_PURPOSE_G As Integer = 9
    Const AIC_GENERAL_PURPOSE_F As Integer = 10
    Const AIC_GENERAL_PURPOSE_E As Integer = 11
    Const AIC_GENERAL_PURPOSE_D As Integer = 12
    Const AIC_GENERAL_PURPOSE_C As Integer = 13
    Const AIC_GENERAL_PURPOSE_B As Integer = 14
    Const AIC_GENERAL_PURPOSE_A As Integer = 15

    'Analog output configuration
    Const AOC_GENERAL_PURPOSE_A As Integer = 0
    Const AOC_GENERAL_PURPOSE_B As Integer = 1

'Units
    'VelocityDimension
    Const VD_RPM As Byte = &HA4

    'VelocityNotation
    Const VN_STANDARD As Byte = &H0
    Const VN_DECI As Byte = &HFF
    Const VN_CENTI As Byte = &HFE
    Const VN_MILLI As Byte = &HFD

'Operational mode
    Const OMD_PROFILE_POSITION_MODE As Byte = &H1
    Const OMD_PROFILE_VELOCITY_MODE As Byte = &H3
    Const OMD_HOMING_MODE As Byte = &H6
    Const OMD_INTERPOLATED_POSITION_MODE As Byte = &H7
    Const OMD_POSITION_MODE As Byte = &HFF
    Const OMD_VELOCITY_MODE As Byte = &HFE
    Const OMD_CURRENT_MODE As Byte = &HFD
    Const OMD_MASTER_ENCODER_MODE As Byte = &HFB
    Const OMD_STEP_DIRECTION_MODE As Byte = &HFA

'States
    Const ST_DISABLED As Integer = 0
    Const ST_ENABLED As Integer = 1
    Const ST_QUICKSTOP As Integer = 2
    Const ST_FAULT As Integer = 3

'Homing mode
    'Homing method
    Const HM_ACTUAL_POSITION As Byte = &H23
    Const HM_NEGATIVE_LIMIT_SWITCH As Byte = &H11
    Const HM_NEGATIVE_LIMIT_SWITCH_AND_INDEX As Byte = &H1
    Const HM_POSITIVE_LIMIT_SWITCH As Byte = &H12
    Const HM_POSITIVE_LIMIT_SWITCH_AND_INDEX As Byte = &H2
    Const HM_HOME_SWITCH_POSITIVE_SPEED As Byte = &H17
    Const HM_HOME_SWITCH_POSITIVE_SPEED_AND_INDEX As Byte = &H7
    Const HM_HOME_SWITCH_NEGATIVE_SPEED As Byte = &H1B
    Const HM_HOME_SWITCH_NEGATIVE_SPEED_AND_INDEX As Byte = &HB
    Const HM_CURRENT_THRESHOLD_POSITIVE_SPEED As Byte = &HFD
    Const HM_CURRENT_THRESHOLD_POSITIVE_SPEED_AND_INDEX As Byte = &HFF
    Const HM_CURRENT_THRESHOLD_NEGATIVE_SPEED As Byte = &HFC
    Const HM_CURRENT_THRESHOLD_NEGATIVE_SPEED_AND_INDEX As Byte = &HFE
    Const HM_INDEX_POSITIVE_SPEED As Byte = &H22
    Const HM_INDEX_NEGATIVE_SPEED As Byte = &H21

'Input Output PositionMarker
    'PositionMarkerEdgeType
    Const PET_BOTH_EDGES As Byte = 0
    Const PET_RISING_EDGE As Byte = 1
    Const PET_FALLING_EDGE As Byte = 2

    'PositionMarkerMode
    Const PM_CONTINUOUS As Byte = 0
    Const PM_SINGLE As Byte = 1
    Const PM_MULTIPLE As Byte = 2

'Input Output PositionCompare
    'PositionCompareOperationalMode
    Const PCO_SINGLE_POSITION_MODE As Byte = 0
    Const PCO_POSITION_SEQUENCE_MODE As Byte = 1

    'PositionCompareIntervalMode
    Const PCI_NEGATIVE_DIR_TO_REFPOS As Byte = 0
    Const PCI_POSITIVE_DIR_TO_REFPOS As Byte = 1
    Const PCI_BOTH_DIR_TO_REFPOS As Byte = 2

    'PositionCompareDirectionDependency
    Const PCD_MOTOR_DIRECTION_NEGATIVE As Byte = 0
    Const PCD_MOTOR_DIRECTION_POSITIVE As Byte = 1
    Const PCD_MOTOR_DIRECTION_BOTH As Byte = 2

'Data recorder
    'Trigger type
    Const DR_MOVEMENT_START_TRIGGER As Byte = 1
    Const DR_ERROR_TRIGGER As Byte = 2
    Const DR_DIGITAL_INPUT_TRIGGER As Byte = 4
    Const DR_MOVEMENT_END_TRIGGER As Byte = 8

'CanLayer Functions
    Const NCS_START_REMOTE_NODE As Integer = 1
    Const NCS_STOP_REMOTE_NODE As Integer = 2
    Const NCS_ENTER_PRE_OPERATIONAL As Integer = 128
    Const NCS_RESET_NODE As Integer = 129
    Const NCS_RESET_COMMUNICATION As Integer = 130

'Controller Gains
    'EController
    Const EC_PI_CURRENT_CONTROLLER As Integer = 1
    Const EC_PI_VELOCITY_CONTROLLER As Integer = 10
    Const EC_PI_VELOCITY_CONTROLLER_WITH_OBSERVER As Integer = 11
    Const EC_PID_POSITION_CONTROLLER As Integer = 20
    Const EC_DUAL_LOOP_POSITION_CONTROLLER As Integer = 21

    'EGain (EC_PI_CURRENT_CONTROLLER)
    Const EG_PICC_P_GAIN As Integer = 1
    Const EG_PICC_I_GAIN As Integer = 2

    'EGain (EC_PI_VELOCITY_CONTROLLER)
    Const EG_PIVC_P_GAIN As Integer = 1
    Const EG_PIVC_I_GAIN As Integer = 2
    Const EG_PIVC_FEED_FORWARD_VELOCITY_GAIN As Integer = 10
    Const EG_PIVC_FEED_FORWARD_ACCELERATION_GAIN As Integer = 11

    'EGain (EC_PI_VELOCITY_CONTROLLER_WITH_OBSERVER)
    Const EG_PIVCWO_P_GAIN As Integer = 1
    Const EG_PIVCWO_I_GAIN As Integer = 2
    Const EG_PIVCWO_FEED_FORWARD_VELOCITY_GAIN As Integer = 10
    Const EG_PIVCWO_FEED_FORWARD_ACCELERATION_GAIN As Integer = 11
    Const EG_PIVCWO_OBSERVER_THETA_GAIN As Integer = 20
    Const EG_PIVCWO_OBSERVER_OMEGA_GAIN As Integer = 21
    Const EG_PIVCWO_OBSERVER_TAU_GAIN As Integer = 22

    'EGain (EC_PID_POSITION_CONTROLLER)
    Const EG_PIDPC_P_GAIN As Integer = 1
    Const EG_PIDPC_I_GAIN As Integer = 2
    Const EG_PIDPC_D_GAIN As Integer = 3
    Const EG_PIDPC_FEED_FORWARD_VELOCITY_GAIN As Integer = 10
    Const EG_PIDPC_FEED_FORWARD_ACCELERATION_GAIN As Integer = 11

    'EGain (EC_DUAL_LOOP_POSITION_CONTROLLER)
    Const EG_DLPC_AUXILIARY_LOOP_P_GAIN As Integer = 1
    Const EG_DLPC_AUXILIARY_LOOP_I_GAIN As Integer = 2
    Const EG_DLPC_AUXILIARY_LOOP_FEED_FORWARD_VELOCITY_GAIN As Integer = 10
    Const EG_DLPC_AUXILIARY_LOOP_FEED_FORWARD_ACCELERATION_GAIN As Integer = 11
    Const EG_DLPC_AUXILIARY_LOOP_OBSERVER_THETA_GAIN As Integer = 20
    Const EG_DLPC_AUXILIARY_LOOP_OBSERVER_OMEGA_GAIN As Integer = 21
    Const EG_DLPC_AUXILIARY_LOOP_OBSERVER_TAU_GAIN As Integer = 22
    Const EG_DLPC_MAIN_LOOP_P_GAIN_LOW As Integer = 101
    Const EG_DLPC_MAIN_LOOP_P_GAIN_HIGH As Integer = 102
    Const EG_DLPC_MAIN_LOOP_GAIN_SCHEDULING_WEIGHT As Integer = 110
    Const EG_DLPC_MAIN_LOOP_FILTER_COEFFICIENT_A As Integer = 120
    Const EG_DLPC_MAIN_LOOP_FILTER_COEFFICIENT_B As Integer = 121
    Const EG_DLPC_MAIN_LOOP_FILTER_COEFFICIENT_C As Integer = 122
    Const EG_DLPC_MAIN_LOOP_FILTER_COEFFICIENT_D As Integer = 123
    Const EG_DLPC_MAIN_LOOP_FILTER_COEFFICIENT_E As Integer = 124
