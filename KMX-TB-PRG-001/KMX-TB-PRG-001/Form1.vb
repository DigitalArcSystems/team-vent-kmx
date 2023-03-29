Imports System
'Imports System.Threading
Imports System.IO
Imports System.IO.Ports
Imports System.Net.Sockets
Imports System.Text
Imports System.ComponentModel

Imports EposCmd.Net
Imports EposCmd.Net.DeviceCmdSet.Operation

''' <summary>
''' GUI form class for accepting user input
''' </summary>

Public Class Form1

#Region "Globals"

    ' Globals
    Dim connector As DeviceManager
    Dim epos As Device

    ' Serial Commands
    Private isOpened As Boolean = False
    Dim clientSocket As New System.Net.Sockets.TcpClient()
    Dim serverStream As NetworkStream
    Dim MessageNumber As Integer

    Private transType As String = String.Empty
    
#End Region
    
#Region "Form1"


    ''' <summary>
    ''' Load Form1 using base method
    ''' </summary>
    
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub
    
    ''' <summary>
    ''' Calls when this class (Form1) is closed
    ''' </summary>
    
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing

        If Not connector Is Nothing Then
            connector.Dispose()
        End If
    End Sub

#End Region

#Region "Menu Items"

    ''' <summary>
    ''' "Connect" Button (in Ribbon/strip-menu along top of UI)
    ''' </summary>
    ''' <remarks>
    '''  <list type="bullet">
    '''  <item><description> Opens dialog box that requests .ini configuration file from user </description></item>
    '''  <item><description> Populates UI, using .ini file variables </description></item>
    '''  <item><description> </description></item>
    '''  </list>
    ''' </remarks>
    
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Try

            OpenFileDialog1.Title = "Please Select ini File"
            OpenFileDialog1.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory
            OpenFileDialog1.FileName = ""
            OpenFileDialog1.ShowDialog()

            If OpenFileDialog1.FileName = "" Then Exit Sub
            OpenIniFile(OpenFileDialog1.FileName)

            Try

                Dim sm As StateMachine
                connector = New DeviceManager

                epos = connector.CreateDevice(1)

                sm = epos.Operation.StateMachine

                If sm.GetFaultState() Then
                    sm.ClearFault()
                End If

                sm.SetEnableState()

                GetCurrentData()

                ManualPanelState(True)

                Me.Text = "KMX-TB-PRG-001 - ( " & Path.GetFileName(OpenFileDialog1.FileName) & " )"

                'Update value read from ini file

                EncoderMax = GetEncoderPosition(DistanceMax)
                EncoderMin = GetEncoderPosition(DistanceMin)

                DisconnectToolStripMenuItem.Enabled = True
                RemoteModeToolStripMenuItem.Enabled = True

                ToolTip1.SetToolTip(NUDDistance, "Value: " & DistanceMin & " To " & DistanceMax)
                ToolStripStatusLabel4.Text = "Idle"

                LblDRP.Text = DistanceRampPause.ToString("0000") & " ms"
                LblFRP.Text = ForceRampPause.ToString("0000") & " ms"

                NUDTargetLoad.Maximum = LoadMax
                NUDTargetLoad.Increment = 44.48
                NUDTargetLoad.Value = LoadTarget

                NUDHomingCurrent.Maximum = MotorCurrentMax
                NUDHomingCurrent.Value = HomingCurrent

                NUDEncoderCounts.Maximum = EncoderCountMax
                NUDEncoderCounts.Minimum = EncoderCountMin
                NUDEncoderCounts.Value = 10000

                NUDMM.Maximum = 10

                NUDTargetDistance.Maximum = DistanceMax
                NUDTargetDistance.Minimum = DistanceMin
                NUDTargetDistance.Value = 9.0

                NUDDistance.Maximum = DistanceMax
                NUDDistance.Minimum = DistanceMin

                NUDMCTK.Value = MotorCurrentTarget_K            ' Target Motor Current constant
                NUDPHK.Value = PlateHeight_K
                NUDLACK.Value = LoadAtCurrent_K
                NUDECAK.Value = EncoderCountsAbsolute_K

                NUDSHeight.Maximum = EncoderCountMax
                NUDSHeight.Minimum = EncoderCountMin
                NUDSHeight.Value = StartHeightEncoder

                ToolStripStatusLabel8.Text = DeviceName

            Catch ex As EposCmd.Net.DeviceException

                ShowMessageBox(ex.ErrorMessage, ex.ErrorCode)
            Catch ex As Exception

                MessageBox.Show(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' "Disconnect" Button (in Ribbon/strip-menu along top of UI)
    ''' </summary>
    
    Private Sub DisconnectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisconnectToolStripMenuItem.Click
        If epos Is Nothing Then
            MessageBox.Show("Please connect to the device")
            OperationStatus = "Stop"
            Exit Sub
        Else
            Try
                Dim sm As StateMachine

                sm = epos.Operation.StateMachine

                If sm.GetFaultState() Then
                    sm.ClearFault()
                End If

                If sm.GetDisableState() = False Then
                    sm.SetDisableState()
                End If

                CloseSerialPort()

                ManualPanelState(False)
                RemotePanelState(False)

                Me.Text = "KMX-TB-PRG-001"

                'update HMI value
                NUDHomingCurrent.Value = 0
                NUDTargetLoad.Value = 0
                TSAC.Text = 0
                TSEC.Text = 0
                TSDistance.Text = 0
                LblTargetCurrent.Text = 0

                NUDEncoderCounts.Value = 10000
                NUDMM.Value = 1
                NUDDistance.Value = 10

            Catch ex As EposCmd.Net.DeviceException

                ShowMessageBox(ex.ErrorMessage, ex.ErrorCode)
            Catch ex As Exception

                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' "Remote Control" Button (in Ribbon/strip-menu along top of UI)
    ''' </summary>
    
    Private Sub RemoteModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoteModeToolStripMenuItem.Click

        'Disable buttons
        ManualPanelState(False)
        RemotePanelState(True)
        OpenSerialPort()
        LblComSetting.Text = "ComPort: " & PortNumber & ", BaudRate:" & SerialPort1.BaudRate
        ToolStripStatusLabel2.Text = "Remote"
        InRemoteMode = True

    End Sub

    ''' <summary>
    ''' "Local Control" Button (in Ribbon/strip-menu along top of UI)
    ''' </summary>
    
    Private Sub LocalModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocalModeToolStripMenuItem.Click

        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False

        CloseSerialPort()
        LblComSetting.Text = ""
        LblConnect.BackColor = Color.Empty
        LblDisconnect.BackColor = Color.Empty
        LblRemoteF.BackColor = Color.Empty
        LblRemoteRF.BackColor = Color.Empty
        LblRemoteD.BackColor = Color.Empty
        LblRemoteRD.BackColor = Color.Empty

        ManualPanelState(True)
        RemotePanelState(False)
        ToolStripStatusLabel2.Text = "Local"
        InRemoteMode = False
    End Sub


#End Region

#Region "File Functions"
    
    ''' <summary>
    '''     Adds a line to local Log file, with:
    ''' 
    ''' <list type="bullet">
    '''     <item>  Timestamp                       </item>
    '''     <item>  Plate Height (mm),              </item>
    '''     <item>  Load (N),                       </item>
    '''     <item>  Current (mA),                   </item>
    '''     <item>  Encoder Counts (cts)            </item>
    '''     <item>  target Current (mA),            </item>
    '''     <item>  target Current Tolerance (mA),  </item>
    '''     <item>  Movement Direction (string)     </item>
    '''     <item>  sending to serial stream (bool) </item>
    '''     <item>  Mode of Operation (string)      </item>
    ''' </list>
    ''' </summary>
    
    Public Sub AddFileLine(MyDecision As String, Optional SerialStream As String = "", Optional OperationMode As String = "")
        ' Write line to file
        Try
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(RecordDataFile, True)
            file.WriteLine(Now.ToString("hh:mm:ss.fff") & " , " & FormatNumber(GetPlateHeight(CEncoder), 2) & " , " & FormatNumber(LoadCurrentN, 1) & " , " & CCurrent & " , " & CEncoder & " , " & FormatNumber(LblTargetCurrent.Text, 1) & " , " & FormatNumber(MotorCurrentTolerance, 2) & " , " & MyDecision & " , " & SerialStream & " , " & OperationMode)
            file.Close()

        Catch ex As ArgumentException

            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    '''     Sends info over serial:
    ''' 
    ''' <list type="bullet">
    '''     <item>  Timestamp             </item>
    '''     <item>  Serial Word (Flags)   </item>
    '''     <item>  Plate Height          </item>
    '''     <item>  Load (min of 0??)     </item>
    ''' </list>
    ''' </summary>
    
    Public Sub SendSerialData()
        ' Send data to serial port

        Dim MyData As String
        Dim MyCheckSumData As String
        Dim SerialLoadMin As Decimal
        Try

            If InRemoteMode = True Then
                If SerialLoad < 0 Then
                    SerialLoadMin = 0
                Else
                    SerialLoadMin = SerialLoad
                End If

                MyData = "070" & Now.ToString("hh:mm:ss.fff") & " " & Val(SerialWord).ToString("000") & " " & SerialHeight.ToString("0000") & " " & SerialLoadMin.ToString("0000")
                MyCheckSumData = GetCheckSum(MyData)
                WriteData(">" & MyData & MyCheckSumData & "<")
            End If
        Catch ex As ArgumentException

            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Save time-stamped file to memory with all current variables and constants.
    ''' </summary>
    '''<remarks>
    ''' ( Good to have saved in case of loss of power or state errors )
    '''</remarks>
    
    Private Sub CreateFile()

        ' Dim DirectoryName as String = DataPath  & "\" & "Data_"

        ' Make sure file location exists file
        ' My.Computer.FileSystem.CreateDirectory(DirectoryName)

        'Make filename with date/time stamp
        RecordDataFile = Now.ToString("MM_dd_yy_hhmmss") & ".csv" ' DirectoryName &


        If WriteToFile = 1 Then
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(RecordDataFile, True)
            'Write current setting
            file.WriteLine(RecordDataFile)
            file.WriteLine("     Motor Setting  ")                                  '   MOTOR SETTINGS
            file.WriteLine("MotorVelocity = " & MotorVelocity)                          ' 7500 rpm
            file.WriteLine("MotorAcceleration = " & MotorAcceleration)                  ' 50000 rpm/s
            file.WriteLine("MotorDeceleration = " & MotorDeceleration)                  ' 50000 rpm/s
            file.WriteLine("HomingCurrent = " & HomingCurrent)                          ' 325 mA.
            file.WriteLine("MotorCurrentReadPause = " & MotorCurrentReadPause)          ' 50 ms
            file.WriteLine("ClosingCurrent = " & ClosingCurrent)                        ' -150 mA
            file.WriteLine("DistanceMax = " & DistanceMax)                              ' 18 mm
            file.WriteLine("DistanceMin = " & DistanceMin)                              ' 9 mm
            file.WriteLine("HomeHeight = " & HomeHeight)                                ' 9 mm
            file.WriteLine("LoadMax = " & LoadMax)                                      ' 300 N (60lb) ; was 267 N (60lb)
            file.WriteLine("EncoderCountMax = " & EncoderCountMax)                      ' 275000 cts                        (was written as mA?)
            file.WriteLine("EncoderCountMin = " & EncoderCountMin)                      ' -150000 cts
            file.WriteLine("MotorCurrentMax = " & MotorCurrentMax)                      ' 700  mA
            file.WriteLine("StartHeightEncoder = " & StartHeightEncoder)                ' -50000 cts
            file.WriteLine("      ")
            file.WriteLine("     FormulaCurrentPerLoadVsEncoderCounts  ")               ' Target Current per Load      <--      Encoder Counts
            file.WriteLine("MotorCurrentTarget_a = " & MotorCurrentTarget_a)            ' MotorCurrentTarget = K * SetLoad * (b3(Counts^3) + b2(Counts^2)+ b1(Counts) + a)
            file.WriteLine("MotorCurrentTarget_b1 = " & MotorCurrentTarget_b1)
            file.WriteLine("MotorCurrentTarget_b2 = " & MotorCurrentTarget_b2)
            file.WriteLine("MotorCurrentTarget_b3 = " & MotorCurrentTarget_b3)
            'file.WriteLine("MotorCurrentTarget_b4 = " & MotorCurrentTarget_b4)
            file.WriteLine("MotorCurrentTarget_K = " & NUDMCTK.Value)
            file.WriteLine("      ")
            file.WriteLine("     FormulaLoadPerCurrentVsEncoderCounts  ")               ' Load      <--      Current
            file.WriteLine("LoadAtCurrent_a = " & LoadAtCurrent_a)                      ' LoadAtCurrent = MeasuredCurrent * (b3(Counts^3) + b2(Counts^2)+ b1(Counts) + a)
            file.WriteLine("LoadAtCurrent_b1 = " & LoadAtCurrent_b1)
            file.WriteLine("LoadAtCurrent_b2 = " & LoadAtCurrent_b2)
            file.WriteLine("LoadAtCurrent_b3 = " & LoadAtCurrent_b3)
            '   file.WriteLine("LoadAtCurrent_b4 = " & LoadAtCurrent_b4)
            file.WriteLine("LoadAtCurrent_K = " & NUDLACK.Value)
            file.WriteLine("      ")
            file.WriteLine("     FormulaHeightVsEncoder  ")                             ' Height    <--     Encoder
            file.WriteLine("PlateHeight_a = " & PlateHeight_a)                          ' PlateHeight = b3(Counts^3) + b2(Counts^2)+ b1(Counts) + a_shift
            file.WriteLine("PlateHeight_b1 = " & PlateHeight_b1)                        '       a_shift = PlateHeight_intercept - ((SetLoad - PlateHeight_base) x PlateHeight_shift)
            file.WriteLine("PlateHeight_b2 = " & PlateHeight_b2)
            file.WriteLine("PlateHeight_b3 = " & PlateHeight_b3)
            '  file.WriteLine("PlateHeight_b4 = " & PlateHeight_b4)
            file.WriteLine("PlateHeight_intercept = " & PlateHeight_intercept)
            file.WriteLine("PlateHeight_base = " & PlateHeight_base)
            file.WriteLine("PlateHeight_shift = " & PlateHeight_shift)
            file.WriteLine("PlateHeight_K = " & NUDPHK.Value)
            file.WriteLine("      ")
            file.WriteLine("     FormulaEncoderVsHeight  ")                             ' Encoder   <---    Height
            file.WriteLine("EncoderCountsAbsolute_a = " & EncoderCountsAbsolute_a)      ' EncoderCountsAbsolute = b3(Height^3) + b2(Height^2)+ b1(Height) + a_off
            file.WriteLine("EncoderCountsAbsolute_b1 = " & EncoderCountsAbsolute_b1)    '       a_off = intercept + ((SetLoad - BaseLoad) x Shift)) 
            file.WriteLine("EncoderCountsAbsolute_b2 = " & EncoderCountsAbsolute_b2)    '       same equation. but different values as:         a_shift = PlateHeight_intercept - ((SetLoad - PlateHeight_base) x PlateHeight_shift)
            file.WriteLine("EncoderCountsAbsolute_b3 = " & EncoderCountsAbsolute_b3)
            '  file.WriteLine("EncoderCountsAbsolute_b4 = " & EncoderCountsAbsolute_b4)
            file.WriteLine("EncoderCountsAbsolute_intercept = " & EncoderCountsAbsolute_intercept)
            file.WriteLine("EncoderCountsAbsolute_base = " & EncoderCountsAbsolute_base)
            file.WriteLine("EncoderCountsAbsolute_shift = " & EncoderCountsAbsolute_shift)
            file.WriteLine("EncoderCountsAbsolute_K = " & NUDECAK.Value)
            file.WriteLine("      ")
            file.WriteLine("     Operation  ")                                      '   OPERATION
            file.WriteLine("ForceStepCoeff        = " & ForceStepCoeff)                 ' 180 cts/N             Value for STAY down&up move. Modes Seek
            file.WriteLine("LoadTarget            = " & LoadTarget)                     ' 180 N (was 44.48 N)   defines a starting target load when the program is initiated
            file.WriteLine("LoadTolerance         = " & LoadTolerance)                  ' 3 N (was 10 N)        Value is multiplied by the look up equation to define what the motor current tolerance band should be ("User-set"??) 
            file.WriteLine("LoadApproachForce     = " & LoadApproachForce)              ' 80 % of N             [HoldForce Mode]     plates continue only upwards in increments of ForceUpStep   until this % of Target load is reached
            file.WriteLine("LoadApproachForceRamp = " & LoadApproachForceRamp)          ' 80 % of N             [Ramped HoldForce M] plates continue only upwards in increments of ForceRampStep until this % of Target load is reached
            file.WriteLine("SeekCyclePause    = " & SeekCyclePause)                     ' 1  ms
            file.WriteLine("ForceUpPause      = " & ForceUpPause)                       ' 1  ms
            file.WriteLine("ForceRampPause    = " & ForceRampPause)                     ' 20 ms
            file.WriteLine("DistancePause     = " & DistancePause)                      ' XX ms                 [ missing from example .ini ]
            file.WriteLine("DistanceRampPause = " & DistanceRampPause)                  ' 25 ms
            file.WriteLine("SeekUpStep        = " & SeekUpStep)                         ' 2000   cts            Move UP when Target Current < Tolerance.                                Modes:  Seek
            file.WriteLine("ForceDownStepNet  = " & ForceDownStepNet)                   ' 4000   cts            Net DOWN move.                                                          Modes:  HoldForce, Ramp-HoldForce, Seek
            file.WriteLine("ForceUpStep       = " & ForceUpStep)                        ' 15000  cts
            file.WriteLine("ForceRampStep     = " & ForceRampStep)                      ' 2000   cts            Move UP when Target Current < Tolerance. Tune the Pause for slowness.   Modes:  Ramp-HoldForce
            file.WriteLine("DistanceUpStep    = " & DistanceUpStep)                     ' 10000  cts
            file.WriteLine("DistanceRampStep  = " & DistanceRampStep)                   ' 10000  cts
            file.WriteLine("DistanceStayStep  = " & DistanceStayStep)                   ' 1000   cts (was 15000)
            file.WriteLine("DistanceTuneStep  = " & DistanceTuneStep)                   ' 1000   cts (was 5000)
            file.WriteLine("LoadMaxSafetyDrop = " & LoadMaxSafetyDrop)                  ' 100000 cts            Every time this param is used, check to not go below EncoderCountMIN
            file.WriteLine("FirstMoveStep     = " & FirstMoveStep)                      ' 25000  cts            Encoder counts move DOWN then UP at the very begining of any mode of operation
            file.WriteLine("DistanceTolerance = " & DistanceTolerance)                  ' 0.2 mm ? That's probably false
            file.WriteLine("      ")
            'file.WriteLine("xxxx = " & xxxx)

            'Write to header to file
            file.WriteLine("Time" & " , " & "Calc'd Height (mm)" & " , " & "Calc'd Load (N)" & " , " & "Actual Current (mA)" & " , " & "Encoder Count" & " , " & "Target Current" & " , " & "Tolerance Current" & " , " & "Decision" & " , " & "Serial Stream" & " , " & "Mode")
            file.Close()
        End If
    End Sub

#End Region

#Region "GUI Functions"

    ''' <summary>
    ''' Enables/Disables all components of Manual Panel (left side) with supplied boolean
    ''' </summary>

    Private Sub ManualPanelState(Mystate As Boolean)
        PanSetHome.Enabled = Mystate
        PanManual.Enabled = Mystate
        PanSeek.Enabled = Mystate
        LblSetHome.Enabled = Mystate
        LblManjog.Enabled = Mystate
        LblSLC.Enabled = Mystate
        If Mystate = True Then
            LblSetHome.BackColor = Color.GreenYellow
            LblManjog.BackColor = Color.GreenYellow
            LblSLC.BackColor = Color.GreenYellow
            LblRemote.BackColor = Color.Empty

            LblSetHome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            LblManjog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            LblSLC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            LblRemote.BorderStyle = System.Windows.Forms.BorderStyle.None
        Else
            LblSetHome.BackColor = Color.Empty
            LblManjog.BackColor = Color.Empty
            LblSLC.BackColor = Color.Empty
            LblRemote.BackColor = Color.GreenYellow

            LblSetHome.BorderStyle = System.Windows.Forms.BorderStyle.None
            LblManjog.BorderStyle = System.Windows.Forms.BorderStyle.None
            LblSLC.BorderStyle = System.Windows.Forms.BorderStyle.None
            LblRemote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        End If
    End Sub

    ''' <summary>
    ''' Enables/Disables all components of Remote Panel (right side) with supplied boolean
    ''' </summary>

    Private Sub RemotePanelState(Mystate As Boolean)
        PanRemoteMode.Enabled = Mystate
        PanStatus.Enabled = Mystate
        LblRemote.Enabled = Mystate
        LblRemoteMode.Enabled = Mystate
        LblRemoteCS.Enabled = Mystate
        LblRemoteM.Enabled = Mystate
        LblRemoteHS.Enabled = Mystate
    End Sub

    ''' <summary>
    ''' Highlight UI element for current type of movement
    ''' </summary>

    Private Sub SetMode(MyMode As String)
        ' set color for mode from serial port
        LblRemoteF.BackColor = Color.Empty
        LblRemoteRF.BackColor = Color.Empty
        LblRemoteD.BackColor = Color.Empty
        LblRemoteRD.BackColor = Color.Empty

        Select Case MyMode
            Case "HoldForce"
                LblRemoteF.BackColor = Color.Orange
            Case "RampForce"
                LblRemoteRF.BackColor = Color.Orange
            Case "HoldDistance"
                LblRemoteD.BackColor = Color.Orange
            Case "RampDistance"
                LblRemoteRD.BackColor = Color.Orange
        End Select
    End Sub

    ''' <summary>
    '''  
    ''' </summary>

    Private Sub UpdateRemoteCommands(MyCommand As String, MyParameter1 As String, MyParameter2 As String, MyParameter3 As String)
        LblRemoteCom.Text = MyCommand
        LblRemotePar1.Text = MyParameter1
    End Sub

    ''' <summary>
    '''  
    ''' </summary>

    Public Sub ShowMessageBox(ByVal text As String, ByVal errorCode As UInteger)
        Dim errorMsg As String

        errorMsg = String.Format("ErrorCode: {1:X8}", text, errorCode)

        MessageBox.Show(text + Environment.NewLine + errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ''' <summary>
    '''  
    ''' </summary>

    Public Property DisplayWindow() As RichTextBox
        Get
            Return _displayWindow
        End Get
        Set(ByVal value As RichTextBox)
            _displayWindow = value
        End Set
    End Property

    ''' <summary>
    '''  
    ''' </summary>

    Private Sub DisplayData(ByVal type As MessageType, ByVal msg As String)
        RichTextBox1.Invoke(New EventHandler(AddressOf DoDisplay))
    End Sub

    ''' <summary>
    '''  
    ''' </summary>

    Private Sub DoDisplay(ByVal sender As Object, ByVal e As EventArgs)
        RichTextBox1.SelectedText = String.Empty
        RichTextBox1.AppendText(_msg)
        RichTextBox1.ScrollToCaret()
    End Sub

    ''' <summary>
    '''  
    ''' </summary>

    Public Property Message() As String
        Get
            Return _msg
        End Get
        Set(ByVal value As String)
            _msg = value
        End Set
    End Property

    ''' <summary>
    '''  
    ''' </summary>

    Public Property Type() As MessageType
        Get
            Return _type
        End Get
        Set(ByVal value As MessageType)
            _type = value
        End Set
    End Property

#End Region

#Region "Formulas"

    ''' <summary>
    '''     Calculates required "Motor Current per Load" based on motor's present Encoder Count.
    '''     (Motor Current required to apply a given HoldForce changes based on plate's height.) 
    ''' </summary>
    ''' <param name="EncoderVal">
    '''     Encoder counts (cts) at present
    ''' </param>
    ''' <returns>
    '''     Current per Load (mA/N)
    ''' </returns>
    ''' <remarks>
    '''     MotorCurrentTarget = K * SetLoad * (b3(Counts^3) + b2(Counts^2)+ b1(Counts) + a)
    ''' </remarks>

    Public Function GetTargetCurrentperLoadmA(EncoderValue As Decimal) As Decimal
        'FormulaCurrentPerLoadVsEncoderCounts
        Dim myvalue As Decimal
        'x = Encoder count
        'myvalue = mA/N

        myvalue = NUDMCTK.Value * ((MotorCurrentTarget_b4 * (EncoderValue) ^ 4 + MotorCurrentTarget_b3 * (EncoderValue) ^ 3 + MotorCurrentTarget_b2 * (EncoderValue) ^ 2 + MotorCurrentTarget_b1 * (EncoderValue) + MotorCurrentTarget_a))

        Return myvalue
    End Function

    ''' <summary>
    '''     Calculates Plate Height from Encoder Count
    ''' </summary>

    Public Function GetPlateHeight(EncoderPosition As Decimal) As Decimal
        'FormulaHeightVsEncoder

        Dim myvalue As Decimal
        Dim a_off As Decimal

        a_off = PlateHeight_intercept - ((CalculateLoadAtCurrent(CurrentEncoder, CCurrent) - PlateHeight_base) * PlateHeight_shift)
        myvalue = NUDPHK.Value * (PlateHeight_b4 * (EncoderPosition) ^ 4 + PlateHeight_b3 * ((EncoderPosition) ^ 3) + PlateHeight_b2 * ((EncoderPosition) ^ 2) + PlateHeight_b1 * (EncoderPosition) + a_off)

        Return myvalue
    End Function

    ''' <summary>
    '''     Calculates Encoder Count (cts) from Plate Height (mm or 0.1 mm?) (distraction)
    ''' </summary>

    Public Function GetEncoderPosition(PlateHeight As Decimal) As Decimal
        'FormulaEncoderVsHeight
        Dim myvalue As Decimal
        Dim a_off As Decimal

        a_off = EncoderCountsAbsolute_intercept + ((NUDTargetLoad.Value - EncoderCountsAbsolute_base) * EncoderCountsAbsolute_shift)

        myvalue = NUDECAK.Value * (EncoderCountsAbsolute_b4 * (PlateHeight) ^ 4 + EncoderCountsAbsolute_b3 * ((PlateHeight) ^ 3) + EncoderCountsAbsolute_b2 * ((PlateHeight) ^ 2) + EncoderCountsAbsolute_b1 * (PlateHeight) + a_off)

        Return myvalue
    End Function

    ''' <summary>
    '''     Calculates HoldForce of Load on plates using Motor Current and Encoder Counts
    ''' </summary>

    Public Function CalculateLoadAtCurrent(EncoderCounts As Decimal, MyCurrent As Decimal) As Decimal
        'FormulaLoadPerCurrentVsEncoderCounts
        Dim myvalue As Decimal

        myvalue = NUDLACK.Value * MyCurrent * (LoadAtCurrent_b3 * (EncoderCounts) ^ 3 + LoadAtCurrent_b2 * (EncoderCounts) ^ 2 + LoadAtCurrent_b1 * (EncoderCounts) + LoadAtCurrent_a)

        Return myvalue
    End Function

#End Region

#Region "Commands For Maxon"

    ''' <summary>
    '''     Set Motor Controller to Current Mode, and control with given Current
    ''' </summary>

    Public Sub SetCurrent(ICurrent As Integer)
        'Set current
        If epos Is Nothing Then
            MessageBox.Show("Please connect to the device")
            OperationStatus = "Stop"
            Exit Sub
        Else
            Try
                Dim ppm As CurrentMode
                ppm = epos.Operation.CurrentMode
                ppm.ActivateCurrentMode()
                ppm.SetCurrentMustEx(ICurrent)

            Catch eb As EposCmd.Net.DeviceException
                ShowMessageBox(eb.ErrorMessage, eb.ErrorCode)
            Catch eb As OverflowException
                MessageBox.Show(eb.Message)
            Catch eb As FormatException
                MessageBox.Show(eb.Message)
            Catch eb As Exception
                MessageBox.Show(eb.Message)
            End Try
        End If
    End Sub

    ''' <summary>
    '''  If OperationStatus is "Pause", wait in 1 second increments
    ''' </summary>

    Public Sub CheckForPause()
        'Pause
        Do While OperationStatus = "Pause"
            Wait(1000)
        Loop
    End Sub

    '''<summary>
    '''     Set Motor Controller to Profile Positiion Mode,
    '''     and set its parameters for velocity, acceleration, and deceleration
    '''</summary>

    Private Sub SetMoveParameter()
        'Set move parameters
        If epos Is Nothing Then
            MessageBox.Show("Please connect to the device")
            OperationStatus = "Stop"
            Exit Sub
        Else
            Try
                Dim ppm As ProfilePositionMode
                ppm = epos.Operation.ProfilePositionMode
                ppm.ActivateProfilePositionMode()
                ppm.SetPositionProfile(MotorVelocity, MotorAcceleration, MotorDeceleration)

            Catch eb As EposCmd.Net.DeviceException
                ShowMessageBox(eb.ErrorMessage, eb.ErrorCode)
            Catch eb As OverflowException
                MessageBox.Show(eb.Message)
            Catch eb As FormatException
                MessageBox.Show(eb.Message)
            Catch eb As Exception
                MessageBox.Show(eb.Message)
            End Try
        End If
    End Sub

    ''' <summary>
    '''  Moves to relative position by amount specified (as opposed to absolute postion via MoveToPositionABS)
    ''' </summary>
    ''' <remarks>
    ''' Combine with ABS, add bool param for absolute
    ''' </remarks>

    Private Sub MoveToPosition(EncoderNum As Integer)
        If epos Is Nothing Then
            MessageBox.Show("Please connect to the device")
            OperationStatus = "Stop"
            Exit Sub
        End If

        Try
            Dim ppm As ProfilePositionMode

            'Dim TargetCount As Long ' Unused
            'get current position and add new encoder value
            'TargetCount = epos.Operation.MotionInfo.GetPositionIs() + EncoderNum ' Unused

            ppm = epos.Operation.ProfilePositionMode
            ppm.ActivateProfilePositionMode()
            ppm.MoveToPosition(EncoderNum, 0, True)

            epos.Operation.MotionInfo.WaitForTargetReached(10000) ' timeout = 10 seconds
        Catch eb As EposCmd.Net.DeviceException
            ShowMessageBox(eb.ErrorMessage, eb.ErrorCode)
        Catch eb As OverflowException
            MessageBox.Show(eb.Message)
        Catch eb As FormatException
            MessageBox.Show(eb.Message)
        Catch eb As Exception
            MessageBox.Show(eb.Message)
        End Try
    End Sub

    ''' <summary>
    '''  Move to absolute position on encoder (as opposed to relative postion via MoveToPosition)
    ''' </summary>
    ''' <remarks>
    ''' Combine into other, add bool param for absolute
    '''</remarks>

    Private Sub MoveToPositionABS(EncoderNum As Integer)
        If epos Is Nothing Then
            MessageBox.Show("Please connect to the device")
            OperationStatus = "Stop"
            Exit Sub
        End If

        Try
            Dim ppm As ProfilePositionMode
            '  Dim CurrentECCount As Long

            ppm = epos.Operation.ProfilePositionMode
            ppm.ActivateProfilePositionMode()
            ppm.MoveToPosition(EncoderNum, True, True)

            epos.Operation.MotionInfo.WaitForTargetReached(10000)
        Catch eb As EposCmd.Net.DeviceException
            ShowMessageBox(eb.ErrorMessage, eb.ErrorCode)
        Catch eb As OverflowException
            MessageBox.Show(eb.Message)
        Catch eb As FormatException
            MessageBox.Show(eb.Message)
        Catch eb As Exception
            MessageBox.Show(eb.Message)
        End Try
    End Sub

    ''' <summary>
    '''     Gets values for Encoder and Current, 
    '''     Calculates Height and Load, 
    '''     Sets SerialWord flags,
    '''     Stores in respective public vars, 
    '''     and Updates local gui
    ''' </summary>

    Private Sub GetCurrentData()        ' Rename GetMotorData()
        If epos Is Nothing Then
            ' object doesn't exist yet
        Else
            Try
                ' Get current encoder count from Maxon
                CurrentEncoder = epos.Operation.MotionInfo.GetPositionIs()
                ' Get Active electrical current (returns the current actual averaged value)
                CCurrent = epos.Operation.MotionInfo.GetCurrentIsAveragedEx()

                ' Get encoder count
                CEncoder = CurrentEncoder               ' REDUNDANT (?)
                TSEC.Text = CurrentEncoder

                ' Calculate height from encoder counts
                CPlateHeight = GetPlateHeight(CurrentEncoder)
                TSDistance.Text = FormatNumber(CPlateHeight, 2) & " mm"

                ' Calculate current from encoder counts
                LblTargetCurrent.Text = NUDTargetLoad.Value * GetTargetCurrentperLoadmA(CurrentEncoder)

                LoadCurrentN = CalculateLoadAtCurrent(CurrentEncoder, CCurrent)                                         ' Load calculated from Current

                TSLoadN.Text = Math.Round(LoadCurrentN) & " N"
                TSLoadLB.Text = FormatNumber(Math.Round(LoadCurrentN) * 0.2248, 2) & " lb"

                TSAC.Text = CCurrent & " mA" ' Actual Current - Toolstrip

                SerialLoad = Math.Round(LoadCurrentN).ToString("0000")
                SerialHeight = ((GetPlateHeight(CEncoder) * 10).ToString("0000"))

                'Status
                SerialWord = 1
                If ToolStripStatusLabel4.Text = "Idle" Then
                    SerialWord = SerialWord + 4
                End If
                If ToolStripStatusLabel4.Text = "Busy" Then
                    SerialWord = SerialWord + 8
                End If

                Select Case OperationMode
                    Case "HoldForce"
                        SerialWord = SerialWord + 16
                    Case "HoldDistance"
                        SerialWord = SerialWord + 32
                    Case "RampForce"
                        SerialWord = SerialWord + 64
                    Case "RampDistance"
                        SerialWord = SerialWord + 128
                End Select

                CheckForPause()
                CheckForPause()

            Catch ex As EposCmd.Net.DeviceException

                ShowMessageBox(ex.ErrorMessage, ex.ErrorCode)
            Catch ex As Exception

                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    ''' <summary>
    '''     Sets epos to Homing Mode,
    '''     Defines current position as Home
    ''' </summary>

    Private Sub BtnSetZero_Click(sender As Object, e As EventArgs) Handles BtnSetZero.Click
        If epos Is Nothing Then
            MessageBox.Show("Please connect to the device")
            Exit Sub
        Else
            Try
                Dim ppm As HomingMode

                ppm = epos.Operation.HomingMode

                ppm.ActivateHomingMode()

                ppm.DefinePosition(0)

                GetCurrentData()

                HomeStatus = 1

            Catch eb As EposCmd.Net.DeviceException
                ShowMessageBox(eb.ErrorMessage, eb.ErrorCode)
            Catch eb As OverflowException
                MessageBox.Show(eb.Message)
            Catch eb As FormatException
                MessageBox.Show(eb.Message)
            Catch eb As Exception
                MessageBox.Show(eb.Message)
            End Try
        End If
    End Sub


#End Region

#Region "Button Click"

    ''' <summary>
    '''     Start Button - Event handler (makes decision based on which mode's checkbox is selected)
    ''' </summary>

    Private Sub BtnStartOC_Click(sender As Object, e As EventArgs) Handles BtnStartOC.Click
        ToolStripStatusLabel4.Text = "Busy"

        LblMET.Text = ""
        'Seek
        If RBTNCFSC.Checked Then
            OperationMode = "Seek"
            Seek()
        End If

        'Load Hold
        If RBTNCFLH.Checked Then
            OperationMode = "LoadHold"
            LoadOperation()
        End If

        'HoldForce
        If RBTNCFF.Checked Then
            OperationMode = "HoldForce"
            HoldForce()
        End If

        'Ramp HoldForce
        If RBTNCFRF.Checked Then
            OperationMode = "RampForce"
            RampForce(NUDTargetLoad.Value)
        End If

        'HoldDistance
        If RBTNCFD.Checked Then
            OperationMode = "HoldDistance"
            HoldDistance(NUDTargetDistance.Value)
        End If

        'Ramp HoldDistance
        If RBTNCFRD.Checked Then
            OperationMode = "RampDistance"
            RampDistance(NUDTargetDistance.Value)
        End If

        'Enable buttons
        ManualPanelState(True)
        ToolStripStatusLabel4.Text = "Idle"
    End Sub

    ''' <summary>
    '''     Pause Button - Event handler
    ''' </summary>

    Private Sub BtnPauseOc_Click(sender As Object, e As EventArgs) Handles BtnPauseOc.Click
        OperationStatus = "Pause"
        ToolStripStatusLabel4.Text = "Pause"
    End Sub

    ''' <summary>
    '''     Resume Button - Event handler
    ''' </summary>

    Private Sub BtnResumeOc_Click(sender As Object, e As EventArgs) Handles BtnResumeOc.Click
        OperationStatus = "Start"
        ToolStripStatusLabel4.Text = "Busy"
    End Sub

    ''' <summary>
    '''     Stop Button - Event handler
    ''' </summary>

    Private Sub BtnStopOc_Click(sender As Object, e As EventArgs) Handles BtnStopOc.Click
        'Stop Operation cycle
        OperationStatus = "Stop"
        ToolStripStatusLabel4.Text = "Idle"
    End Sub

    ''' <summary>
    '''     Remote Stop Button - Event handler
    ''' </summary>

    Private Sub BtnRemoteStop_Click(sender As Object, e As EventArgs) Handles BtnRemoteStop.Click
        'Stop Operation cycle
        OperationStatus = "Stop"
        ToolStripStatusLabel4.Text = "Idle"
    End Sub

    ''' <summary>
    '''     Close Button - Event handler
    ''' </summary>

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        ToolStripStatusLabel4.Text = "Busy"
        CollapsePlates()
        ToolStripStatusLabel4.Text = "Idle"
    End Sub

    ''' <summary>
    '''     "Retract Plates" Button (Control Functions) - Event handler
    ''' </summary>

    Private Sub BtnRetractOc_Click(sender As Object, e As EventArgs) Handles BtnRetractOc.Click
        ToolStripStatusLabel4.Text = "Busy"
        CollapsePlates()
        ToolStripStatusLabel4.Text = "Idle"
    End Sub

    ''' <summary>
    '''     "Stop" Button (Set Home) - Event handler 
    ''' </summary>

    Private Sub BtnAZC_Click(sender As Object, e As EventArgs) Handles BtnAZC.Click
        OperationStatus = "Stop"
        SetCurrent(0)
        Wait(MotorCurrentReadPause)
        GetCurrentData()
        CloseSerialPort()
        ToolStripStatusLabel4.Text = "Idle"
    End Sub

    ''' <summary>
    '''      "Power Off" Button (Control Functions) - Event handler
    ''' </summary>
    ''' <remarks>
    '''     actually Halt function
    ''' </remarks>

    Private Sub BtnStopPlatesOc_Click(sender As Object, e As EventArgs) Handles BtnStopPlatesOc.Click
        OperationStatus = "Stop"
        SetCurrent(0)
        Wait(MotorCurrentReadPause)
        GetCurrentData()
        ToolStripStatusLabel4.Text = "Idle"
    End Sub

    ''' <summary>
    '''     "Apply Current" Button - Event handler
    ''' </summary>

    Private Sub BtnApplyCurrent_Click(sender As Object, e As EventArgs) Handles BtnApplyCurrent.Click
        If epos Is Nothing Then
            MessageBox.Show("Please connect to the device")

            Exit Sub
        Else
            Try
                OperationStatus = "Start"
                ToolStripStatusLabel4.Text = "Busy"
                SetCurrent(NUDHomingCurrent.Value)

                'Set focus to Stop button
                BtnAZC.Focus()

                Do

                    GetCurrentData()
                    Wait(250)
                Loop Until OperationStatus = "Stop"
                ToolStripStatusLabel4.Text = "Idle"
            Catch eb As EposCmd.Net.DeviceException

                ShowMessageBox(eb.ErrorMessage, eb.ErrorCode)
            Catch eb As OverflowException
                MessageBox.Show(eb.Message)
            Catch eb As FormatException
                MessageBox.Show(eb.Message)
            Catch eb As Exception

                MessageBox.Show(eb.Message)
            End Try
        End If
    End Sub

    ''' <summary>
    '''      "Manual Jog Up (Encoder cts)" Button - Event handler
    ''' </summary>

    Private Sub BtnMoveUP_Click(sender As Object, e As EventArgs) Handles BtnMoveUp.Click
        ToolStripStatusLabel4.Text = "Busy"
        MoveToPosition(NUDEncoderCounts.Value)
        Wait(MotorCurrentReadPause)
        GetCurrentData()
        ToolStripStatusLabel4.Text = "Idle"
    End Sub

    ''' <summary>
    '''     "Manual Jog Down (Encoder cts)" Button - Event handler
    ''' </summary>

    Private Sub BtnMoveDown_Click(sender As Object, e As EventArgs) Handles BtnMoveDown.Click
        ToolStripStatusLabel4.Text = "Busy"
        MoveToPosition(-NUDEncoderCounts.Value)
        Wait(MotorCurrentReadPause)
        GetCurrentData()
        ToolStripStatusLabel4.Text = "Idle"
    End Sub

    ''' <summary>
    '''     "Manual Jog Up (mm)" Button - Event handler
    ''' </summary>

    Private Sub BtnMoveUpmm_Click(sender As Object, e As EventArgs) Handles BtnMoveUpmm.Click
        Dim NewHeight As Decimal
        Dim TargetEncoderNum As Decimal
        ToolStripStatusLabel4.Text = "Busy"

        NewHeight = CPlateHeight + NUDMM.Value

        TargetEncoderNum = GetEncoderPosition(NewHeight)

        MoveToPositionABS(TargetEncoderNum)

        Wait(MotorCurrentReadPause)
        GetCurrentData()

        ToolStripStatusLabel4.Text = "Idle"
    End Sub

    ''' <summary>
    '''     "Manual Jog Down (mm)" Button - Event handler
    ''' </summary>

    Private Sub BtnMoveDownmm_Click(sender As Object, e As EventArgs) Handles BtnMoveDownmm.Click
        Dim NewHeight As Decimal
        Dim TargetEncoderNum As Decimal
        ToolStripStatusLabel4.Text = "Busy"

        NewHeight = CPlateHeight - NUDMM.Value

        TargetEncoderNum = GetEncoderPosition(NewHeight)

        MoveToPositionABS(TargetEncoderNum)

        Wait(MotorCurrentReadPause)
        GetCurrentData()

        ToolStripStatusLabel4.Text = "Idle"
    End Sub

    ''' <summary>
    '''     "Move to HoldDistance" Button (mm) - Event handler
    ''' </summary>

    Private Sub BtnMtD_Click(sender As Object, e As EventArgs) Handles BtnMtD.Click
        Dim TargetEncoderNum As Decimal
        ToolStripStatusLabel4.Text = "Busy"
        Wait(250)
        TargetEncoderNum = GetEncoderPosition(NUDDistance.Value)
        MoveToPositionABS(TargetEncoderNum)
        Wait(MotorCurrentReadPause)
        GetCurrentData()
        ToolStripStatusLabel4.Text = "Idle"
    End Sub

    ''' <summary>
    '''     "Move to Start Height" Button (cts) - Event handler  
    ''' </summary>
    ''' <remarks>
    '''     AKA: "Move to Encoder Zero"
    ''' </remarks>

    Private Sub BtnMtEZ_Click(sender As Object, e As EventArgs) Handles BtnMtEZ.Click
        ToolStripStatusLabel4.Text = "Busy"
        Wait(500)
        MoveToPositionABS(NUDSHeight.Value)
        Wait(MotorCurrentReadPause)
        GetCurrentData()
        ToolStripStatusLabel4.Text = "Idle"
    End Sub

#End Region

#Region "Arrow Buttons"

    ''' <summary>
    '''     "Target Load" Field Up/Down Increment Buttons (Control Functions) - Event handler
    ''' </summary>

    Private Sub NUDTargetLoad_MouseDown(sender As Object, e As MouseEventArgs) Handles NUDTargetLoad.MouseDown
        If e.Button = MouseButtons.Right Then
            NUDTargetLoad.Increment = InputBox("Enter new step value", "Step Value", NUDTargetLoad.Increment)
        End If
    End Sub

    ''' <summary>
    '''     "Target HoldDistance" Field Up/Down Increment Buttons (Control Functions) - Event handler
    ''' </summary>

    Private Sub NUDTargetDistance_MouseDown(sender As Object, e As MouseEventArgs) Handles NUDTargetDistance.MouseDown
        If e.Button = MouseButtons.Right Then
            NUDTargetDistance.Increment = InputBox("Enter new step value", "Step Value", NUDTargetDistance.Increment)
        End If
    End Sub

    ''' <summary>
    '''     "HoldDistance" Field Up/Down Increment Buttons (Manual Jog) - Event handler
    ''' </summary>

    Private Sub NUDDistance_MouseDown(sender As Object, e As MouseEventArgs) Handles NUDDistance.MouseDown
        If e.Button = MouseButtons.Right Then
            NUDDistance.Increment = InputBox("Enter new step value", "Step Value", NUDDistance.Increment)
        End If
    End Sub

    ''' <summary>
    '''     "Homing Current" Field Up/Down Increment Buttons (Set Home) - Event handler
    ''' </summary>

    Private Sub NUDHomingCurrent_MouseDown(sender As Object, e As MouseEventArgs) Handles NUDHomingCurrent.MouseDown
        If e.Button = MouseButtons.Right Then
            NUDHomingCurrent.Increment = InputBox("Enter new step value", "Step Value", NUDHomingCurrent.Increment)
        End If
    End Sub

    ''' <summary>
    '''     "Millimeter" Field Up/Down Increment Buttons (Manual Jog) - Event handler
    ''' </summary>

    Private Sub NUDMM_MouseDown(sender As Object, e As MouseEventArgs) Handles NUDMM.MouseDown
        If e.Button = MouseButtons.Right Then
            NUDMM.Increment = InputBox("Enter new step value", "Step Value", NUDMM.Increment)
        End If
    End Sub

    ''' <summary>
    '''     "MotorCurrentTarget_K" Field Up/Down Increment Buttons (Control Functions) - Event handler
    ''' </summary>

    Private Sub NUDMCTK_MouseDown(sender As Object, e As MouseEventArgs) Handles NUDMCTK.MouseDown
        If e.Button = MouseButtons.Right Then
            NUDMCTK.Increment = InputBox("Enter new step value", "Step Value", NUDMCTK.Increment)
        End If
    End Sub

    ''' <summary>
    '''     "PlateHeight_K" Field Up/Down Increment Buttons (Control Functions) - Event handler
    ''' </summary>

    Private Sub NUDPHK_MouseDown(sender As Object, e As MouseEventArgs) Handles NUDPHK.MouseDown
        If e.Button = MouseButtons.Right Then
            NUDPHK.Increment = InputBox("Enter new step value", "Step Value", NUDPHK.Increment)
        End If
    End Sub

    ''' <summary>
    '''     "LoadAtCurrent_K" Field Up/Down Increment Buttons (Control Functions) - Event handler
    ''' </summary>

    Private Sub NUDLACK_MouseDown(sender As Object, e As MouseEventArgs) Handles NUDLACK.MouseDown
        If e.Button = MouseButtons.Right Then
            NUDLACK.Increment = InputBox("Enter new step value", "Step Value", NUDLACK.Increment)
        End If
    End Sub

    ''' <summary>
    '''     "EncoderCountsAbsolute_K" Field Up/Down Increment Buttons (Control Functions) - Event handler
    ''' </summary>

    Private Sub NUDECAK_MouseDown(sender As Object, e As MouseEventArgs) Handles NUDECAK.MouseDown
        If e.Button = MouseButtons.Right Then
            NUDECAK.Increment = InputBox("Enter new step value", "Step Value", NUDECAK.Increment)
        End If
    End Sub

    ''' <summary>
    '''     "Target Load" Field number change (Control Functions) - Event handler
    ''' </summary>

    Private Sub NUDTargetLoad_ValueChanged(sender As Object, e As EventArgs) Handles NUDTargetLoad.ValueChanged

        LblTargetCurrent.Text = (Val(NUDTargetLoad.Text)) * GetTargetCurrentperLoadmA(CurrentEncoder)
        LoadTarget = NUDTargetLoad.Value
        LblTargetEC.Text = Math.Round(GetEncoderPosition(NUDTargetDistance.Value))
        LblTargetLoadLB.Text = FormatNumber(NUDTargetLoad.Value * 0.2248, 2)
    End Sub

    ''' <summary>
    '''     "Target HoldDistance" Field number change (Control Functions) - Event handler
    ''' </summary>

    Private Sub NUDTargetDistance_ValueChanged(sender As Object, e As EventArgs) Handles NUDTargetDistance.ValueChanged

        LblTargetEC.Text = Math.Round(GetEncoderPosition(NUDTargetDistance.Value))
    End Sub

#End Region

#Region "Operations"

    ''' <summary>
    '''  ONLY used for Seek() and HoldForce Operations [ HoldForce(), RampedForce(), LoadOperation() ]
    ''' </summary>

    Private Sub OperationCycle()
        Dim MyCurrentTarget As Decimal

        'MyCurrentTarget is mA after cal
        MyCurrentTarget = NUDTargetLoad.Text * GetTargetCurrentperLoadmA(CurrentEncoder)

        MotorCurrentTolerance = LoadTolerance * GetTargetCurrentperLoadmA(CurrentEncoder)

        MotorEncoderTolerance = LoadTarget * ForceStepCoeff

        ' Current is within Tolerance of Target:
        ' Target - Tolerance < CCurrent < Target + Tolerance
        If MyCurrentTarget - MotorCurrentTolerance < CCurrent And CCurrent < MyCurrentTarget + MotorCurrentTolerance Then

            ' if current is within tolerance move down and up same amount For "Seek Cycle"
            LblDecision.Text = "Stay"
            If RunSeek = True Then

                'Send Serial Data and write to file
                AddFileLine("Stay", "Yes", OperationMode)

                SendSerialData()

                'Down move
                If OperationStatus = "Stop" Then Exit Sub
                LblMET.Text = "-" & MotorEncoderTolerance
                MoveToPosition(-MotorEncoderTolerance)
                Wait(MotorCurrentReadPause)

                'Up move
                If OperationStatus = "Stop" Then Exit Sub
                LblMET.Text = MotorEncoderTolerance
                MoveToPosition(MotorEncoderTolerance)
                Wait(MotorCurrentReadPause)
                GetCurrentData()

                If RBTNCFLH.Checked Then
                    OperationStatus = "Stop"
                    Exit Sub
                End If
            End If

        Else 'Current is not within tolerance

            If CCurrent < MyCurrentTarget Then
                ' "Up" if current is less than target

                'Send Serial Data and write to file
                If OperationMode = "RampForce" Or OperationMode = "RampDistance" Then
                    AddFileLine("Up", "Yes", OperationMode)

                    SendSerialData()

                Else
                    AddFileLine("Up", "No", OperationMode)
                End If

                'update screen
                LblMET.Text = SeekUpStep
                LblDecision.Text = " Up"

                ' Move UP
                If OperationStatus = "Stop" Then Exit Sub
                MoveToPosition(SeekUpStep)
                Wait(MotorCurrentReadPause)
                GetCurrentData()

                'Check load 
                CheckMaxForce()
            Else ' CCurrent >= MyCurrentTarget
                ' "Down - Up"  to lower Height


                'Send Serial Data and write to file
                If OperationMode = "RampForce" Or OperationMode = "RampDistance" Then
                    AddFileLine("Down_Up", "Yes", OperationMode)
                    SendSerialData()
                Else
                    AddFileLine("Down_Up", "No", OperationMode)
                End If


                ' Set target
                MoveDownEncoderStep = LoadTarget * ForceStepCoeff

                'Update screen
                LblDecision.Text = " Down Up "

                ' Move DOWN
                If OperationStatus = "Stop" Then Exit Sub
                LblMET.Text = "-" & MoveDownEncoderStep
                MoveToPosition(-MoveDownEncoderStep) ' change add ramp force

                ' Move UP by lesser amount
                If OperationStatus = "Stop" Then Exit Sub
                LblMET.Text = (MoveDownEncoderStep - ForceDownStepNet)
                MoveToPosition(MoveDownEncoderStep - ForceDownStepNet)
                Wait(MotorCurrentReadPause)
                GetCurrentData()

                'Check load 
                CheckMaxForce()
            End If
        End If
    End Sub

    ''' <summary>
    '''     Closes plates using ClosingCurrent(-150 mA)
    ''' </summary>

    Public Sub CollapsePlates()
        If epos Is Nothing Then
            MessageBox.Show("Please connect to the device")
            Exit Sub
        Else
            '  Try
            OperationStatus = "Start"

            SetCurrent(ClosingCurrent)

            'Set focus to Stop button
            BtnAZC.Focus()

            Do
                GetCurrentData()
                Wait(400)
            Loop Until OperationStatus = "Stop"
        End If
    End Sub

    ''' <summary>
    '''     [Bad Function / FACTORY MODE] "Load Hold" Operation
    ''' </summary>
    ''' <remarks>
    '''     - exactly the same as Load(), but compares MyTargetForce to CCurrent (instantaneous Current) instead of LoadCurrentN (Load HoldForce calc'd from Current)
    '''     - not currently used by any modes, only internal use
    '''</remarks>

    Public Sub LoadOperation()
        Dim MyTargetForce As Decimal

        OperationStatus = "Start"

        CreateFile()

        'Set focus to Stop button
        BtnStopOc.Focus()

        'Seek Cycle runs "Down - Up"
        RunSeek = True

        'Set move Vel,Accel,Deccel
        SetMoveParameter()

        'Disable buttons
        PanSetHome.Enabled = False
        PanManual.Enabled = False

        ' ------------------ TEST BED ----------------------------




        '        ' Move by force to % of target load
        '        MyTargetForce = NUDTargetLoad.Value * (LoadApproachForce / 100)
        '
        'first move
        MoveToPosition(-FirstMoveStep)
        Wait(MotorCurrentReadPause)
        GetCurrentData()

        Do
            GetCurrentData()
            MoveToPosition(50000)
            GetCurrentData()
            MoveToPosition(50000)
            GetCurrentData()
            Wait(1000)
            MoveToPosition(-50000)
            GetCurrentData()
            Wait(1000)
            MoveToPosition(-50000)
            GetCurrentData()
            Wait(1000)
        Loop Until OperationStatus = "Stop"

        '
        '        Do
        '            'Send write to file
        '            AddFileLine("Up", "No", OperationMode)
        '
        '            SendSerialData()
        '
        '            MoveToPosition(ForceUpStep)
        '            Wait(MotorCurrentReadPause)
        '            GetCurrentData()
        '            Wait(ForceUpPause)
        '
        '            'Check load 
        '            CheckMaxForce()
        '        Loop Until OperationStatus = "Stop" Or CCurrent > MyTargetForce
        '
        '        'loop until "Stop Cycle" button is click
        '        Do
        '            OperationCycle()
        '            Wait(SeekCyclePause)
        '        Loop Until OperationStatus = "Stop"



        ' ------------------ / TEST BED ----------------------------

        If InRemoteMode = False Then
            'Enable buttons
            ManualPanelState(True)
            RemotePanelState(False)
        End If
    End Sub

    ''' <summary>
    '''  Extra function to start Seek without entering full operational mode
    ''' </summary>
    
    Public Sub Seek()


        OperationStatus = "Start"

        CreateFile()

        'Set focus to Stop button
        BtnStopOc.Focus()

        'Seek Cycle runs "Down - Up"
        RunSeek = True

        'Set move Vel,Accel,Deccel
        SetMoveParameter()

        'Disable buttons
        PanSetHome.Enabled = False
        PanManual.Enabled = False

        'loop until "Stop Cycle" button is click
        Do
            OperationCycle()
            Wait(SeekCyclePause)
        Loop Until OperationStatus = "Stop"
    End Sub

    ''' <summary>
    '''  Seek Force
    ''' </summary>
    
    Private Sub HoldForce()
        Dim MyTargetForce As Decimal

        OperationStatus = "Start"

        CreateFile()

        'Set focus to Stop button
        '     BtnStopOc.Focus()

        'Seek Cycle runs "Down - Up"
        RunSeek = True

        'Set move Vel,Accel,Deccel
        SetMoveParameter()

        'Disable buttons
        PanSetHome.Enabled = False
        PanManual.Enabled = False

        ' Move by force to % of target load
        MyTargetForce = NUDTargetLoad.Value * (LoadApproachForce / 100)

        'first move
        MoveToPosition(-FirstMoveStep)
        Wait(MotorCurrentReadPause)
        GetCurrentData()

        Do
            'Write to file, but... do not send Serial Data?
            AddFileLine("Up", "No", OperationMode)

            SendSerialData() ' but actually do send data...

            MoveToPosition(ForceUpStep)
            Wait(MotorCurrentReadPause)
            GetCurrentData()
            Wait(ForceUpPause)

            'Check load 
            CheckMaxForce()
        Loop Until OperationStatus = "Stop" Or LoadCurrentN > MyTargetForce

        'loop until "Stop Cycle" button is click
        Do
            OperationCycle()
            Wait(SeekCyclePause)
        Loop Until OperationStatus = "Stop"

        If InRemoteMode = False Then
            'Enable buttons
            ManualPanelState(True)
            RemotePanelState(False)
        End If
    End Sub

    ''' <summary>
    '''  Seek Distance
    ''' </summary>
    
    Private Sub HoldDistance(MyTargetDistance As Decimal)
        Dim newtarget As Decimal

        OperationStatus = "Start"

        CreateFile()

        'Set focus to Stop button
        BtnStopOc.Focus()

        'Set move Vel,Accel,Deccel
        SetMoveParameter()

        'Disable buttons
        PanSetHome.Enabled = False
        PanManual.Enabled = False

        'first move
        MoveToPosition(-FirstMoveStep)
        Wait(MotorCurrentReadPause)
        GetCurrentData()

        Do
            'Write to file, but... do not send Serial Data?
            AddFileLine("Up", "No", OperationMode)

            MoveToPosition(DistanceUpStep)
            Wait(MotorCurrentReadPause)
            GetCurrentData()
            Wait(DistancePause)

            'Check load 
            CheckMaxForce()
        Loop Until OperationStatus = "Stop" Or GetPlateHeight(CEncoder) >= MyTargetDistance

        Do
            ' Send Serial Data And write to file
            AddFileLine("Stay", "Yes", OperationMode)
            SendSerialData()

            newtarget = MyTargetDistance - GetPlateHeight(CEncoder)         ' Rename to RelationToTarget and swap subtraction

            If newtarget > DistanceTolerance Then           ' plate is BELOW target, must move UP

                MoveToPosition(DistanceTuneStep)
                Wait(MotorCurrentReadPause)
            ElseIf newtarget < -DistanceTolerance Then      ' plate is ABOVE target, must move DOWN

                MoveToPosition(-DistanceStayStep)           ' this seems wrong
                Wait(MotorCurrentReadPause)
                MoveToPosition(DistanceTuneStep)
                Wait(MotorCurrentReadPause)
            Else                                            ' plate is WITHIN TOLERANCE, move down a little and back up

                MoveToPosition(-DistanceStayStep)
                Wait(MotorCurrentReadPause)
                MoveToPosition(DistanceStayStep)
                Wait(MotorCurrentReadPause)
            End If

            GetCurrentData()
            Wait(DistancePause)

            '  Check Load 
            CheckMaxForce()
        Loop Until OperationStatus = "Stop"

        If InRemoteMode = False Then
            'Enable buttons
            ManualPanelState(True)
            RemotePanelState(False)
        End If
    End Sub

    ''' <summary>
    ''' Increments position in steps until Load matches or exceeds target force
    ''' ( Parameter MyTargetForce is overwritten without being used )
    ''' </summary>

    Private Sub RampForce(MyTargetForce As Decimal)
    

        OperationStatus = "Start"

        CreateFile()

        'Set focus to Stop button
        BtnStopOc.Focus()

        'Seek Cycle runs "Down - Up"
        RunSeek = True

        'Set move Vel,Accel,Deccel
        SetMoveParameter()

        'Disable buttons
        PanSetHome.Enabled = False
        PanManual.Enabled = False

        ' Move by force to % of target load
        MyTargetForce = NUDTargetLoad.Value * (LoadApproachForceRamp / 100)

        'first move
        MoveToPosition(-FirstMoveStep)
        Wait(MotorCurrentReadPause)
        GetCurrentData()

        Do
            'Send Serial Data and write to file
            AddFileLine("Up", "Yes", OperationMode)

            SendSerialData()

            MoveToPosition(ForceRampStep)
            Wait(MotorCurrentReadPause)
            GetCurrentData()
            Wait(ForceRampPause)

            'Check load 
            CheckMaxForce()
        Loop Until OperationStatus = "Stop" Or LoadCurrentN > MyTargetForce

        'loop until "Stop Cycle" button is clicked
        Do
            OperationCycle()
            Wait(SeekCyclePause)
        Loop Until OperationStatus = "Stop"

        If InRemoteMode = False Then
            'Enable buttons
            ManualPanelState(True)
            RemotePanelState(False)
        End If
    End Sub

    ''' <summary>
    ''' Increments position in steps until Position matches or exceeds target position
    ''' </summary>

    Private Sub RampDistance(MyTargetDistance As Decimal)
        Dim newtarget As Decimal

        OperationStatus = "Start"

        CreateFile()

        'Set focus to Stop button
        BtnStopOc.Focus()

        'Set move Vel,Accel,Deccel
        SetMoveParameter()

        'Disable buttons
        PanSetHome.Enabled = False
        PanManual.Enabled = False

        'first move
        MoveToPosition(-FirstMoveStep)
        Wait(MotorCurrentReadPause)
        GetCurrentData()
        
        Do
            'Send Serial Data and write to file
            AddFileLine("Up", "Yes", OperationMode)
            SendSerialData()

            MoveToPosition(DistanceRampStep)
            Wait(MotorCurrentReadPause)
            GetCurrentData()
            Wait(DistanceRampPause)

            'Check load 
            CheckMaxForce()
        Loop Until OperationStatus = "Stop" Or GetPlateHeight(CEncoder) >= MyTargetDistance

        Do
            'Send Serial Data and write to file
            AddFileLine("Stay", "Yes", OperationMode)
            SendSerialData()

            newtarget = MyTargetDistance - GetPlateHeight(CEncoder)

            If newtarget > DistanceTolerance Then

                MoveToPosition(DistanceTuneStep)
                Wait(MotorCurrentReadPause)
            ElseIf newtarget < -DistanceTolerance Then

                MoveToPosition(-DistanceStayStep)
                Wait(MotorCurrentReadPause)
                MoveToPosition(DistanceTuneStep)
                Wait(MotorCurrentReadPause)
            Else

                MoveToPosition(-DistanceStayStep)
                Wait(MotorCurrentReadPause)
                MoveToPosition(DistanceStayStep)
                Wait(MotorCurrentReadPause)
            End If

            GetCurrentData()
            Wait(DistanceRampPause)

            '  Check Load
            CheckMaxForce()  ' <- Graeme's adding, JIC, b/c this check seems important)
        Loop Until OperationStatus = "Stop"

        If InRemoteMode = False Then
            'Enable buttons
            ManualPanelState(True)
            RemotePanelState(False)
        End If
    End Sub

    ''' <summary>
    '''     Safety check that verifies current load is within limit
    ''' </summary>
    ''' <remarks>
    '''     If load is above limit
    ''' <list type="bullet">
    '''     <item>      Output safety warning to terminal.                          </item>
    '''     <item>      Move down to predefined position or by predefined amount.   </item>
    '''     <item>      Temp Pause reading Motor current, either for current protection or avoid bad reading feedback. </item>
    ''' </list>
    ''' </remarks>
    
    Private Sub CheckMaxForce()
        'Check load     
        If LoadCurrentN > LoadMax Then
            AddFileLine("Safety", "No", OperationMode)
            MoveToPosition(-LoadMaxSafetyDrop)
            Wait(MotorCurrentReadPause)
            GetCurrentData()
        End If
    End Sub
    
    ''' <summary>
    '''     Moves to absolute encoder position 0 (As calibrated with Homing)
    ''' </summary>
    
    Public Sub MoveToHomeZero()
        OperationStatus = "Start"
        MoveToPositionABS(0)

        Wait(MotorCurrentReadPause)
        GetCurrentData()
        OperationStatus = "Stop"
    End Sub
    
    ''' <summary>
    '''     (Inteneded to) Move to "Start Height" set in Manual Jon menu
    ''' </summary>
    ''' <remarks>
    '''     (Not actually called by "Move To Start Height" button <c>BtnMtEZ_Click</c> )
    ''' </remarks>
    
    Public Sub MoveToStartHeight()
        OperationStatus = "Start"
        MoveToPositionABS(NUDSHeight.Value)
        Wait(MotorCurrentReadPause)
        GetCurrentData()
        OperationStatus = "Stop"
    End Sub

    ''' <summary>
    '''     (Inteneded to) Move to "HoldDistance" set in Manual Jog menu.
    ''' </summary>
    ''' <remarks>
    '''     (Not actually called by "Move To HoldDistance" button <c>BtnMtD_Click</c> )
    ''' </remarks>
    Public Sub RemoteDistance()

        MoveToPositionABS(GetEncoderPosition(NUDDistance.Value))
        Wait(MotorCurrentReadPause)
        GetCurrentData()
    End Sub
    
#End Region

#Region "Timers"
    
    ''' <summary>
    '''     State machine:  4 Operation Modes 
    ''' </summary>
    ''' <remarks>
    '''     Updates UI with Busy/Idle state.
    ''' </remarks>
    
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If ToolStripStatusLabel4.Text = "Busy" Then Exit Sub

        ToolStripStatusLabel4.Text = "Busy"

        Select Case OperationMode
            Case "HoldForce"
                HoldForce()
            Case "HoldDistance"
                HoldDistance(RemoteParameter / 10)
            Case "RampForce"
                RampForce(RemoteParameter)
            Case "RampDistance"
                RampDistance(RemoteParameter / 10)
        End Select

        ToolStripStatusLabel4.Text = "Idle"
        Timer1.Enabled = False
    End Sub
    
    ''' <summary>
    '''     State machine:  Collapse Plastes
    ''' </summary>
    ''' <remarks>
    '''     Updates UI with Busy/Idle state.
    ''' </remarks>
    
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If OperationStatus = "Start" Then Exit Sub
        ToolStripStatusLabel4.Text = "Busy"
        CollapsePlates()
        Timer2.Enabled = False
        ToolStripStatusLabel4.Text = "Idle"
    End Sub
    
    ''' <summary>
    '''     State machine:  Move Home
    ''' </summary>
    ''' <remarks>
    '''     Updates UI with Busy/Idle state.
    ''' </remarks>

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If OperationStatus = "Start" Then Exit Sub
        ToolStripStatusLabel4.Text = "Busy"
        MoveToStartHeight()
        Timer3.Enabled = False
        ToolStripStatusLabel4.Text = "Idle"
    End Sub

#End Region

#Region "Serial"
    
    ' enumeration to hold our message types
    Public Enum TransmissionType
        Text
        Hex
    End Enum
    
    Public Enum MessageType
        Incoming
        Outgoing
        Normal
        Warning
        [Error]
    End Enum

    Private write As Boolean = True

    Private _baudRate As String = String.Empty
    Private _parity As String = String.Empty
    Private _stopBits As String = String.Empty
    Private _dataBits As String = String.Empty
    Private _portName As String = String.Empty

    Private _transType As TransmissionType
    Private _displayWindow As RichTextBox
    Private _msg As String
    Private _type As MessageType

    Private Sub OpenSerialPort()
        If Not isOpened Then

            SerialPort1.PortName = "COM" & PortNumber
            SerialPort1.BaudRate = BaudRate
            SerialPort1.Parity = Parity
            SerialPort1.StopBits = StopBit
            SerialPort1.DataBits = DataBit
            SerialPort1.Handshake = Flow
            '' SerialPort1.DisplayWindow = RichTextBox1

            Try
                ' Open the serial port.
                SerialPort1.Open()
                ' comm.DtrEnable = True
                isOpened = True
                'AddHandler SerialPort1.DataReceived, AddressOf ReceiveSerialData
            Catch
                MessageBox.Show("Failed to open serial port!")
            End Try
        Else

            Try
                ' Close the serial port.
                SerialPort1.Close()
                isOpened = False
            Catch
                MessageBox.Show("Failed to close the serial port!")
            End Try
        End If
    End Sub

    Private Sub CloseSerialPort()
        Try
            If SerialPort1.IsOpen Then
                ' Close the serial port.
                SerialPort1.Close()
                isOpened = False
            End If
        Catch
            MessageBox.Show("Failed to close the serial port!")
        End Try
    End Sub


    Private Sub ReceiveSerialData(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim Mydata As String
        Dim MyCheckSumData As String
        '      Dim thread1 As System.Threading.Thread

        CurrentTransmissionType = TransmissionType.Text

        Select Case CurrentTransmissionType
            Case TransmissionType.Text
                'user chose string
                'read data waiting in the buffer
                Dim msg As String = SerialPort1.ReadExisting()
                'display the data to the user
                _type = MessageType.Incoming
                _msg = msg
                DisplayData(MessageType.Incoming, msg + "" + Environment.NewLine + "")
                Exit Select
            Case TransmissionType.Hex
                'user chose binary
                'retrieve number of bytes in the buffer
                Dim bytes As Integer = SerialPort1.BytesToRead
                'create a byte array to hold the awaiting data
                Dim comBuffer As Byte() = New Byte(bytes - 1) {}
                'read the data and store it
                SerialPort1.Read(comBuffer, 0, bytes)
                'display the data to the user
                _type = MessageType.Incoming
                _msg = ByteToHex(comBuffer) + "" + Environment.NewLine + ""
                DisplayData(MessageType.Incoming, ByteToHex(comBuffer) + "" + Environment.NewLine + "")
                Exit Select
            Case Else
                'read data waiting in the buffer
                Dim str As String = SerialPort1.ReadExisting()
                'display the data to the user
                _type = MessageType.Incoming
                _msg = str + "" + Environment.NewLine + ""
                DisplayData(MessageType.Incoming, str + "" + Environment.NewLine + "")
                Exit Select
        End Select

        If _msg.Length < 5 Then
            Exit Sub
        End If
        ' make sure check sum is good
        If GetCheckSum(_msg.Substring(1, _msg.Length - 4)) <> _msg.Substring(_msg.Length - 3, 2) Then
            Me.Invoke(Sub()
                          ToolStripStatusLabel4.Text = "Error: Bad CheckSum"
                      End Sub)
            WriteData(">50095<")
            Exit Sub
        End If

        Select Case _msg.Substring(1, 3)

            Case "000" 'Connect ">00090<"

                Mydata = "000" & "KINEMAX"
                MyCheckSumData = GetCheckSum(Mydata)
                WriteData(">" & Mydata & MyCheckSumData & "<")

                Me.Invoke(Sub()
                              LblRemoteCom.Text = "Connect  (000)"
                              LblRemotePar1.Text = "NA"
                              LblConnect.BackColor = Color.GreenYellow
                              LblDisconnect.BackColor = Color.Empty
                          End Sub)

            Case "001" 'Disconnect ">00191<"

                OperationStatus = "Stop"
                Timer1.Enabled = False
                Timer2.Enabled = False
                Timer3.Enabled = False

                Mydata = "001" & "GOODBYE"
                MyCheckSumData = GetCheckSum(Mydata)
                WriteData(">" & Mydata & MyCheckSumData & "<")
                Me.Invoke(Sub()
                              OperationStatus = "Stop"
                              LblRemoteCom.Text = "Disconnect   (001)"
                              LblRemotePar1.Text = "NA"
                              'LblRemotePar2.Text = "NA"
                              'LblRemotePar3.Text = "NA"
                              ToolStripStatusLabel4.Text = "Idle"
                              LblConnect.BackColor = Color.Empty
                              LblDisconnect.BackColor = Color.Red
                          End Sub)

            Case "002" '002 home

                Me.Invoke(Sub()
                              LblRemoteCom.Text = "Home  (002)"
                              LblRemotePar1.Text = "NA"
                              'LblRemotePar2.Text = "NA"
                              'LblRemotePar3.Text = "NA"
                              Timer3.Enabled = True
                          End Sub)

                Mydata = "002" & 1
                MyCheckSumData = GetCheckSum(Mydata)
                WriteData(">" & Mydata & MyCheckSumData & "<")


            Case "003" '003 GetHomeStatus

                Mydata = "003" & HomeStatus
                MyCheckSumData = GetCheckSum(Mydata)
                WriteData(">" & Mydata & MyCheckSumData & "<")

            Case "005" '005 GetCurrentError 

                Mydata = "005" & ErrorStatus
                MyCheckSumData = GetCheckSum(Mydata)
                WriteData(">" & Mydata & MyCheckSumData & "<")

            Case "010" '010 Mode HoldForce

                Me.Invoke(Sub()
                              OperationMode = "HoldForce"

                              ' get force
                              If _msg.Length > 7 Then
                                  RemoteParameter = _msg.Substring(4, _msg.Length - 7)
                                  NUDTargetLoad.Value = Val(RemoteParameter)
                              Else
                                  RemoteForce = LoadTarget
                              End If

                              LblRemoteCom.Text = "HoldForce    (010)"
                              LblRemotePar1.Text = Math.Round(Val(RemoteParameter)) & " N"

                              SetMode("HoldForce")
                          End Sub)

                Mydata = "010" & Val(RemoteParameter).ToString("0000")
                MyCheckSumData = GetCheckSum(Mydata)
                WriteData(">" & Mydata & MyCheckSumData & "<")


            Case "012" '012 ModeDistance

                Me.Invoke(Sub()
                              OperationMode = "HoldDistance"

                              ' get HoldDistance
                              If _msg.Length > 7 Then
                                  RemoteParameter = _msg.Substring(4, _msg.Length - 7)
                              Else
                                  RemoteParameter = 0
                              End If

                              NUDTargetDistance.Value = Val(RemoteParameter / 10)
                              LblRemoteCom.Text = "HoldDistance     (012)"
                              LblRemotePar1.Text = "Target " & RemoteParameter / 10 & " mm"
                              SetMode("HoldDistance")
                          End Sub)

                Mydata = "012" & Val(RemoteParameter).ToString("0000")
                MyCheckSumData = GetCheckSum(Mydata)
                WriteData(">" & Mydata & MyCheckSumData & "<")

            Case "020" '020 ModeRampForce

                Me.Invoke(Sub()
                              OperationMode = "RampForce"

                              ' get ModeRampForce
                              If _msg.Length > 7 Then
                                  RemoteParameter = _msg.Substring(4, _msg.Length - 7)
                                  NUDTargetLoad.Value = Val(RemoteParameter)
                              Else
                                  RemoteParameter = LoadTarget
                              End If

                              LblRemoteCom.Text = "Ramp HoldForce   (020)"
                              LblRemotePar1.Text = Math.Round(Val(RemoteParameter)) & " N"

                              SetMode("RampForce")
                          End Sub)

                Mydata = "020" & Val(RemoteParameter).ToString("0000")
                MyCheckSumData = GetCheckSum(Mydata)
                WriteData(">" & Mydata & MyCheckSumData & "<")

            Case "022" '022 ModeRampDistance

                Me.Invoke(Sub()
                              OperationMode = "RampDistance"

                              ' get ModeRampDistance
                              If _msg.Length > 7 Then
                                  RemoteParameter = _msg.Substring(4, _msg.Length - 7)
                              Else
                                  RemoteParameter = 0
                              End If

                              NUDTargetDistance.Value = Val(RemoteParameter / 10)

                              LblRemoteCom.Text = "Ramp HoldDistance    (022)"
                              LblRemotePar1.Text = "HoldDistance: " & RemoteParameter / 10 & " mm"

                              SetMode("RampDistance")

                          End Sub)

                Mydata = "022" & Val(RemoteParameter).ToString("0000")
                MyCheckSumData = GetCheckSum(Mydata)
                WriteData(">" & Mydata & MyCheckSumData & "<")

            Case "040" '044 Start_Cycle

                Mydata = "040" & 1
                MyCheckSumData = GetCheckSum(Mydata)
                WriteData(">" & Mydata & MyCheckSumData & "<")

                'thread1 = New System.Threading.Thread(AddressOf test)
                'thread1.Start()

                Me.Invoke(Sub()
                              ToolStripStatusLabel4.Text = "Idle"
                              Timer1.Enabled = True

                          End Sub)


            Case "050" 'Stop Cycle ">05095<"

                Me.Invoke(Sub()
                              OperationStatus = "Stop"
                              ToolStripStatusLabel4.Text = "Idle"
                              Timer1.Enabled = False
                              Timer2.Enabled = False
                              Timer3.Enabled = False

                          End Sub)
                ToolStripStatusLabel4.Text = "Idle"
                OperationStatus = "Stop"
                ' thread1.Abort()

                Mydata = "050" & 1
                MyCheckSumData = GetCheckSum(Mydata)
                WriteData(">" & Mydata & MyCheckSumData & "<")

            Case "060" '006 Collapse 

                Mydata = "060" & 1
                MyCheckSumData = GetCheckSum(Mydata)
                WriteData(">" & Mydata & MyCheckSumData & "<")
                Me.Invoke(Sub()

                              Timer2.Enabled = True
                          End Sub)

            Case "070" '070 GetStatus

                Mydata = "070" & Now.ToString("hh:mm:ss.fff") & " " & Val(SerialWord).ToString("000") & " " & (Math.Round(GetPlateHeight(CEncoder), 1) * 10).ToString("0000") & " " & LoadCurrentN.ToString("0000")
                MyCheckSumData = GetCheckSum(Mydata)
                WriteData(">" & Mydata & MyCheckSumData & "<")

            Case "074" '074 GetStatusWord

                Mydata = "074" & Val(SerialWord).ToString("0000")
                MyCheckSumData = GetCheckSum(Mydata)
                WriteData(">" & Mydata & MyCheckSumData & "<")

            Case "100" '100 Get Version
                Mydata = "100" & "Version" & LblVersion.Text
                MyCheckSumData = GetCheckSum(Mydata)
                WriteData(">" & Mydata & MyCheckSumData & "<")

            Case Else
                ' bad command
                WriteData(">50196<")
        End Select
    End Sub

    Public Sub WriteData(ByVal msg As String)
        Select Case CurrentTransmissionType
            Case TransmissionType.Text
                'first make sure the port is open
                'if its not open then open it
                If Not (SerialPort1.IsOpen = True) Then
                    SerialPort1.Open()
                End If
                'send the message to the port
                SerialPort1.Write(msg)
                'display the message
                _type = MessageType.Outgoing
                _msg = msg + "" + Environment.NewLine + ""
                DisplayData(_type, _msg)
                Exit Select
            Case TransmissionType.Hex
                Try
                    'convert the message to byte array
                    Dim newMsg As Byte() = HexToByte(msg)
                    If Not write Then
                        DisplayData(_type, _msg)
                        Exit Sub
                    End If
                    'send the message to the port
                    SerialPort1.Write(newMsg, 0, newMsg.Length)
                    'convert back to hex and display
                    _type = MessageType.Outgoing
                    _msg = ByteToHex(newMsg) + "" + Environment.NewLine + ""
                    DisplayData(_type, _msg)
                Catch ex As FormatException
                    'display error message
                    _type = MessageType.Error
                    _msg = ex.Message + "" + Environment.NewLine + ""
                    DisplayData(_type, _msg)
                Finally
                    _displayWindow.SelectAll()
                End Try
                Exit Select
            Case Else
                'first make sure the port is open
                'if its not open then open it
                If Not (SerialPort1.IsOpen = True) Then
                    SerialPort1.Open()
                End If
                'send the message to the port
                SerialPort1.Write(msg)
                'display the message
                _type = MessageType.Outgoing
                _msg = msg + "" + Environment.NewLine + ""
                DisplayData(MessageType.Outgoing, msg + "" + Environment.NewLine + "")
                Exit Select
        End Select
    End Sub

    Public Property CurrentTransmissionType() As TransmissionType
        Get
            Return _transType
        End Get
        Set(ByVal value As TransmissionType)
            _transType = value
        End Set
    End Property
#End Region

#Region "MathFunctions"

    Private Function ByteToHex(ByVal comByte As Byte()) As String
        'create a new StringBuilder object
        Dim builder As New StringBuilder(comByte.Length * 3)
        'loop through each byte in the array
        For Each data As Byte In comByte
            builder.Append(Convert.ToString(data, 16).PadLeft(2, "0"c).PadRight(3, " "c))
            'convert the byte to a string and add to the stringbuilder
        Next
        'return the converted value
        Return builder.ToString().ToUpper()
    End Function
    Private Function HexToByte(ByVal msg As String) As Byte()
        If msg.Length Mod 2 = 0 Then
            'remove any spaces from the string
            _msg = msg
            _msg = msg.Replace(" ", "")
            'create a byte array the length of the
            'divided by 2 (Hex is 2 characters in length)
            Dim comBuffer As Byte() = New Byte(_msg.Length / 2 - 1) {}
            For i As Integer = 0 To _msg.Length - 1 Step 2
                comBuffer(i / 2) = CByte(Convert.ToByte(_msg.Substring(i, 2), 16))
            Next
            write = True
            'loop through the length of the provided string
            'convert each set of 2 characters to a byte
            'and add to the array
            'return the array
            Return comBuffer
        Else
            _msg = "Invalid format"
            _type = MessageType.Error
            ' DisplayData(_Type, _msg)
            write = False
            Return Nothing
        End If
    End Function
    Private Function GetCheckSum(MyData As String) As String
        Dim Myvalue As String
        Dim byteArray() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(MyData)
        Dim total As Integer

        For x As Integer = 0 To byteArray.Length - 1
            total += byteArray(x)
        Next

        Myvalue = Strings.Right(total.ToString("X"), 2)

        Return Myvalue

    End Function


#End Region

#Region "Testing"

    '' test class for Timer1_Tick() 
    Public Sub test()
    '    If ToolStripStatusLabel4.Text = "Busy" Then Exit Sub

    '    ToolStripStatusLabel4.Text = "Busy"

    '    Select Case OperationMode
    '        Case "HoldForce"
    '            HoldForce()
    '        Case "HoldDistance"
    '            HoldDistance(RemoteParameter / 10)
    '        Case "RampForce"
    '            RampForce(RemoteParameter)
    '        Case "RampDistance"
    '            RampDistance(RemoteParameter / 10)
    '    End Select

    '    ToolStripStatusLabel4.Text = "zzIdle"
    '    Timer1.Enabled = False
    End Sub



#End Region

End Class
