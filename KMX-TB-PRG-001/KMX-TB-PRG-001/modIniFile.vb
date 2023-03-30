
Module modIniFile
    <Runtime.InteropServices.DllImport("kernel32")> _
          Private Function WritePrivateProfileString(ByVal section As String, ByVal key As String, ByVal val As String, ByVal filePath As String) As Long
    End Function

    <Runtime.InteropServices.DllImport("kernel32")> _
    Private Function GetPrivateProfileString(ByVal section As String, ByVal key As String, ByVal def As String, ByVal retVal As System.Text.StringBuilder, ByVal size As Integer, ByVal filePath As String) As Integer
    End Function


    '' ini file variables
    'General
    Public DataPath As String
    Public WriteToFile As Integer
    Public InRemoteMode As Boolean
    Public SimulationMode As Boolean
    Public DeviceName As String


    'Motor
    Public MotorVelocity As Integer
    Public MotorAcceleration As Integer
    Public MotorDeceleration As Integer
    Public HomingCurrent As Integer
    Public ClosingCurrent As Integer
    Public DistanceMax As Decimal
    Public DistanceMin As Decimal
    Public HomeHeight As Long
    Public MotorCurrentReadPause As Integer
    Public LoadMax As Integer
    Public EncoderCountMax As Integer
    Public EncoderCountMin As Integer
    Public MotorCurrentMax As Integer
    Public StartHeightEncoder As Integer

    'FormulaCurrentPerLoadVsEncoderCounts
    Public MotorCurrentTarget_a As Decimal              ' Target Motor Current polynomial calculation constants
    Public MotorCurrentTarget_b1 As Decimal
    Public MotorCurrentTarget_b2 As Decimal
    Public MotorCurrentTarget_b3 As Decimal
    Public MotorCurrentTarget_b4 As Decimal
    Public MotorCurrentTarget_K As Decimal              ' Target Motor Current constant, calculated from Encoder reading

    'Formula Get Plate Height from Encoder
    Public PlateHeight_a As Decimal
    Public PlateHeight_b1 As Decimal
    Public PlateHeight_b2 As Decimal
    Public PlateHeight_b3 As Decimal
    Public PlateHeight_b4 As Decimal
    Public PlateHeight_intercept As Decimal
    Public PlateHeight_base As Decimal
    Public PlateHeight_shift As Decimal
    Public PlateHeight_K As Decimal

    'Formula Get Encoder value from Plate Height
    Public EncoderCountsAbsolute_a As Decimal
    Public EncoderCountsAbsolute_b1 As Decimal
    Public EncoderCountsAbsolute_b2 As Decimal
    Public EncoderCountsAbsolute_b3 As Decimal
    Public EncoderCountsAbsolute_b4 As Decimal
    Public EncoderCountsAbsolute_intercept As Decimal
    Public EncoderCountsAbsolute_base As Decimal
    Public EncoderCountsAbsolute_shift As Decimal
    Public EncoderCountsAbsolute_K As Decimal

    'FormulaLoadPerCurrentVsEncoderCounts
    Public LoadAtCurrent_a As Decimal
    Public LoadAtCurrent_b1 As Decimal
    Public LoadAtCurrent_b2 As Decimal
    Public LoadAtCurrent_b3 As Decimal
    Public LoadAtCurrent_b4 As Decimal
    Public LoadAtCurrent_K As Decimal

    'Operation
    Public SeekUpStep As Integer
    Public ForceDownStepNet As Integer
    Public LoadTarget As Decimal
    Public MotorEncoderTolerance As Decimal
    Public LoadTolerance As Decimal
    Public MotorCurrentTolerance As Decimal
    Public ForceStepCoeff As Decimal
    Public LoadApproachForce As Decimal
    Public LoadApproachForceRamp As Decimal
    Public SeekCyclePause As Long
    Public ForceRampPause As Long
    Public ForceRampStep As Long
    Public ForceUpStep As Long
    Public ForceUpPause As Long
    Public DistanceUpStep As Long
    Public DistancePause As Long
    Public DistanceRampStep As Long
    Public DistanceRampPause As Long
    Public LoadMaxSafetyDrop As Long
    Public DistanceStayStep As Long
    Public FirstMoveStep As Long
    Public DistanceTuneStep As Decimal
    Public DistanceTolerance As Decimal


    'Program variables
    Public StopMan As Integer
    Public RecordData As Integer
    Public RecordDataFile As String
    Public ManRecordDataFile As String
    Public CVelocity As Integer
    Public CEncoder As Long                     ' Encoder Count (Current Encoder Count)
    Public CPlateHeight As Decimal
    Public CCurrent As Decimal                  ' Actual Current (Current Current)
    Public OperationStatus As String            
   ' Public CurrentEncoder As Long               ' Encoder Count - SAME AS CEncoder
    Public Mytarget As Integer
    Public RunSeek As Boolean = False
    Public MyIntervalTL As Decimal = 1
    Public MyIntervalSTL As Decimal = 44.48
    Public MyIntervalML As Decimal = 1
    Public MyIntervalMM As Decimal = 1
    Public MyIntervalMJ As Decimal = 1
    Public MyIntervalMMM As Decimal = 1
    Public MyIntervalMTD As Decimal = 1
    Public MyIntervalCFTD As Decimal = 1
    Public RemoteForce As String = ""
    Public LoadCurrentN As Decimal              ' Load calculated from Current and Encoder
    Public OperationMode As String              ' One of 4 Operation Modes: Force, RampedForce, Distance, 
    Public RemoteParameter As String
    Public MoveDownEncoderStep As Integer
    Public HomeStatus As Integer = 0             ' 2 - in process, 1 = is_Homed , 0 Not_Home
    Public ErrorStatus As Integer = 0


    ' Serial variables
    Public PortNumber As Integer
    Public BaudRate As Integer
    Public Parity As Integer
    Public DataBit As Integer
    Public StopBit As Integer
    Public Flow As Integer
    Public Timeout As Integer
    Public SerialLoad As Decimal
    Public SerialHeight As Decimal
    Public SerialWord As Integer


    Public LastRemoteCommand As String
    Public EncoderMax As Long
    Public EncoderMin As Long


    Public Sub OpenIniFile(ByRef name As String)

        'General
        DataPath = (ReadPreferenceString(name, "General", "DataPath", "C:\"))
        WriteToFile = Val(ReadPreferenceString(name, "General", "WriteToFile", 1))
        SimulationMode = Val(ReadPreferenceString(name, "General", "SimulationMode", 1))
        DeviceName = ReadPreferenceString(name, "General", "Device", "Add to General")

        'Motor
        MotorVelocity = Val(ReadPreferenceString(name, "Motor", "MotorVelocity", 7500))
        MotorAcceleration = Val(ReadPreferenceString(name, "Motor", "MotorAcceleration", 50000))
        MotorDeceleration = Val(ReadPreferenceString(name, "Motor", "MotorDeceleration", 50000))
        HomingCurrent = Val(ReadPreferenceString(name, "Motor", "HomingCurrent", 350))
        MotorCurrentReadPause = Val(ReadPreferenceString(name, "Motor", "MotorCurrentReadPause", 50))
        ClosingCurrent = Val(ReadPreferenceString(name, "Motor", "ClosingCurrent", -150))
        DistanceMax = Val(ReadPreferenceString(name, "Motor", "DistanceMax", 20))
        DistanceMin = Val(ReadPreferenceString(name, "Motor", "DistanceMin", 9))
        HomeHeight = Val(ReadPreferenceString(name, "Motor", "HomeHeight", 9))
        LoadMax = Val(ReadPreferenceString(name, "Motor", "LoadMax", 258))
        EncoderCountMax = Val(ReadPreferenceString(name, "Motor", "EncoderCountMax", 275000))
        EncoderCountMin = Val(ReadPreferenceString(name, "Motor", "EncoderCountMin", -100000))
        MotorCurrentMax = Val(ReadPreferenceString(name, "Motor", "MotorCurrentMax", 700))
        StartHeightEncoder = Val(ReadPreferenceString(name, "Motor", "StartHeightEncoder", 10000))

        'FormulaCurrentPerLoadVsEncoderCounts
        MotorCurrentTarget_a = Val(ReadPreferenceString(name, "FormulaCurrentPerLoadVsEncoderCounts", "MotorCurrentTarget_a", 0))
        MotorCurrentTarget_b1 = Val(ReadPreferenceString(name, "FormulaCurrentPerLoadVsEncoderCounts", "MotorCurrentTarget_b1", 0))
        MotorCurrentTarget_b2 = Val(ReadPreferenceString(name, "FormulaCurrentPerLoadVsEncoderCounts", "MotorCurrentTarget_b2", 0))
        MotorCurrentTarget_b3 = Val(ReadPreferenceString(name, "FormulaCurrentPerLoadVsEncoderCounts", "MotorCurrentTarget_b3", 0))
        MotorCurrentTarget_b4 = Val(ReadPreferenceString(name, "FormulaCurrentPerLoadVsEncoderCounts", "MotorCurrentTarget_b4", 0))
        MotorCurrentTarget_K = Val(ReadPreferenceString(name, "FormulaCurrentPerLoadVsEncoderCounts", "MotorCurrentTarget_K", 1))

        'FormulaHeightVsEncoder
        PlateHeight_a = Val(ReadPreferenceString(name, "FormulaHeightVsEncoder", "PlateHeight_a", "0"))
        PlateHeight_b1 = Val(ReadPreferenceString(name, "FormulaHeightVsEncoder", "PlateHeight_b1", "0"))
        PlateHeight_b2 = Val(ReadPreferenceString(name, "FormulaHeightVsEncoder", "PlateHeight_b2", "0"))
        PlateHeight_b3 = Val(ReadPreferenceString(name, "FormulaHeightVsEncoder", "PlateHeight_b3", "0"))
        PlateHeight_b4 = Val(ReadPreferenceString(name, "FormulaHeightVsEncoder", "PlateHeight_b4", "0"))
        PlateHeight_intercept = Val(ReadPreferenceString(name, "FormulaHeightVsEncoder", "PlateHeight_intercept", 9))
        PlateHeight_base = Val(ReadPreferenceString(name, "FormulaHeightVsEncoder", "PlateHeight_base", "0"))
        PlateHeight_shift = Val(ReadPreferenceString(name, "FormulaHeightVsEncoder", "PlateHeight_shift", "0"))
        PlateHeight_K = Val(ReadPreferenceString(name, "FormulaHeightVsEncoder", "PlateHeight_K", "0"))

        'FormulaEncoderVsHeight
        EncoderCountsAbsolute_a = Val(ReadPreferenceString(name, "FormulaEncoderVsHeight", "EncoderCountsAbsolute_a", "0"))
        EncoderCountsAbsolute_b1 = Val(ReadPreferenceString(name, "FormulaEncoderVsHeight", "EncoderCountsAbsolute_b1", "0"))
        EncoderCountsAbsolute_b2 = Val(ReadPreferenceString(name, "FormulaEncoderVsHeight", "EncoderCountsAbsolute_b2", "0"))
        EncoderCountsAbsolute_b3 = Val(ReadPreferenceString(name, "FormulaEncoderVsHeight", "EncoderCountsAbsolute_b3", "0"))
        EncoderCountsAbsolute_b4 = Val(ReadPreferenceString(name, "FormulaEncoderVsHeight", "EncoderCountsAbsolute_b4", "0"))
        EncoderCountsAbsolute_intercept = Val(ReadPreferenceString(name, "FormulaEncoderVsHeight", "EncoderCountsAbsolute_intercept", "0"))
        EncoderCountsAbsolute_base = Val(ReadPreferenceString(name, "FormulaEncoderVsHeight", "EncoderCountsAbsolute_base", "0"))
        EncoderCountsAbsolute_shift = Val(ReadPreferenceString(name, "FormulaEncoderVsHeight", "EncoderCountsAbsolute_shift", "0"))
        EncoderCountsAbsolute_K = Val(ReadPreferenceString(name, "FormulaEncoderVsHeight", "EncoderCountsAbsolute_K", "0"))

        'FormulaLoadPerCurrentVsEncoderCounts
        LoadAtCurrent_a = Val(ReadPreferenceString(name, "FormulaLoadPerCurrentVsEncoderCounts", "LoadAtCurrent_a", "0"))
        LoadAtCurrent_b1 = Val(ReadPreferenceString(name, "FormulaLoadPerCurrentVsEncoderCounts", "LoadAtCurrent_b1", "0"))
        LoadAtCurrent_b2 = Val(ReadPreferenceString(name, "FormulaLoadPerCurrentVsEncoderCounts", "LoadAtCurrent_b2", "0"))
        LoadAtCurrent_b3 = Val(ReadPreferenceString(name, "FormulaLoadPerCurrentVsEncoderCounts", "LoadAtCurrent_b3", "0"))
        LoadAtCurrent_b4 = Val(ReadPreferenceString(name, "FormulaLoadPerCurrentVsEncoderCounts", "LoadAtCurrent_b4", "0"))
        LoadAtCurrent_K = Val(ReadPreferenceString(name, "FormulaLoadPerCurrentVsEncoderCounts", "LoadAtCurrent_K", "0"))

        'Operation
        SeekUpStep = Val(ReadPreferenceString(name, "Operation", "SeekUpStep", 2000))
        ForceDownStepNet = Val(ReadPreferenceString(name, "Operation", "ForceDownStepNet", 4000))
        LoadTarget = Val(ReadPreferenceString(name, "Operation", "LoadTarget", 44.58))
        ForceStepCoeff = Val(ReadPreferenceString(name, "Operation", "ForceStepCoeff", 180))
        LoadTolerance = Val(ReadPreferenceString(name, "Operation", "LoadTolerance", 10))
        LoadApproachForce = Val(ReadPreferenceString(name, "Operation", "LoadApproachForce", 80))
        LoadApproachForceRamp = Val(ReadPreferenceString(name, "Operation", "LoadApproachForceRamp", 85))
        SeekCyclePause = Val(ReadPreferenceString(name, "Operation", "SeekCyclePause", 1))
        ForceRampPause = Val(ReadPreferenceString(name, "Operation", "ForceRampPause", 500))
        ForceRampStep = Val(ReadPreferenceString(name, "Operation", "ForceRampStep", 7500))
        ForceUpStep = Val(ReadPreferenceString(name, "Operation", "ForceUpStep", 15000))
        ForceUpPause = Val(ReadPreferenceString(name, "Operation", "ForceUpPause", 1))
        DistanceUpStep = Val(ReadPreferenceString(name, "Operation", "DistanceUpStep", 10000))
        DistancePause = Val(ReadPreferenceString(name, "Operation", "DistancePause", 1))
        DistanceRampStep = Val(ReadPreferenceString(name, "Operation", "DistanceRampStep", 10000))
        DistanceRampPause = Val(ReadPreferenceString(name, "Operation", "DistanceRampPause", 500))
        LoadMaxSafetyDrop = Val(ReadPreferenceString(name, "Operation", "LoadMaxSafetyDrop", 10000))
        DistanceStayStep = Val(ReadPreferenceString(name, "Operation", "DistanceStayStep", 5000))
        LoadMaxSafetyDrop = Val(ReadPreferenceString(name, "Operation", "LoadMaxSafetyDrop", 100000))
        FirstMoveStep = Val(ReadPreferenceString(name, "Operation", "FirstMoveStep", 25000))
        DistanceTuneStep = Val(ReadPreferenceString(name, "Operation", "DistanceTuneStep", 5000))
        DistanceTolerance = Val(ReadPreferenceString(name, "Operation", "DistanceTolerance", 0.2))


        OperationStatus = "Stop"

        'Serial
        PortNumber = Val(ReadPreferenceString(name, "Serial", "PortNumber", "1"))
        BaudRate = Val(ReadPreferenceString(name, "Serial", "BaudRate", "57600"))
        Parity = Val(ReadPreferenceString(name, "Serial", "Parity", "EVEN"))
        DataBit = Val(ReadPreferenceString(name, "Serial", "DataBit", "8"))
        StopBit = Val(ReadPreferenceString(name, "Serial", "StopBit", "1"))
        Flow = Val(ReadPreferenceString(name, "Serial", "Flow", "1"))


    End Sub
    Public Function ReadPreferenceString(ByVal strFileName As String, ByVal strApplication As String, ByVal strKey As String, ByVal strDefaultValue As String) As String
        '------------------------------------------------------------------------------
        ' Description:
        '   Read a key content of an INI file.
        '
        ' Parameter(s):
        '   Profile file name
        '   Application name (the one in [])
        '   Key name
        '   Default value
        '
        ' Returned Value:
        '   Key content
        '------------------------------------------------------------------------------

        Dim strApplicationName As String
        Dim strKeyName As String
        Dim strDefault As String
        Dim intSize As Integer
        Dim strTempoString As String

        ' Set up parameters for reading profile strings
        strApplicationName = strApplication
        strKeyName = strKey
        strDefault = strDefaultValue
        intSize = 251

        Dim valueString As New System.Text.StringBuilder(intSize)

        ' Build the Profile file name
        'strFileName = System.Windows.Forms.Application.ExecutablePath + "\" + strProfileName

        ' Read profile string
        strTempoString = GetPrivateProfileString(strApplicationName, strKeyName, strDefault, valueString, intSize, strFileName)

        Return valueString.ToString().Trim()

    End Function



End Module
