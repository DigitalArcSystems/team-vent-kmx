 Private Sub OperationCycle()
        Dim MyCurrentTarget As Decimal

        'MyCurrentTarget is mA after cal
        MyCurrentTarget = NUDTargetLoad.Text * GetTargetCurrentperLoadmA(CurrentEncoder)

        MotorCurrentTolerance = LoadTolerance * GetTargetCurrentperLoadmA(CurrentEncoder)

        MotorEncoderTolerance = LoadTarget * ForceStepCoeff

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
        Else

            'Send Serial Data and write to file
            If OperationMode = "RampForce" Or OperationMode = "RampDistance" Then
                AddFileLine("Up", "Yes", OperationMode)

                SendSerialData()

            Else
                AddFileLine("Up", "No", OperationMode)
            End If


            'Current is not within tolerance
            If CCurrent < MyCurrentTarget Then
                ' "Up" if current is less than target

                'update screen
                LblMET.Text = SeekUpStep
                LblDecision.Text = " Up"

                ' Up move
                If OperationStatus = "Stop" Then Exit Sub
                MoveToPosition(SeekUpStep)
                Wait(MotorCurrentReadPause)
                GetCurrentData()

                'Check load 
                CheckMaxForce()


            Else
                ' "Down - Up"  Current is greater than target

                'Send Serial Data and write to file
                If OperationMode = "RampForce" Or OperationMode = "RampDistance" Then
                    AddFileLine("Down_Up", "Yes", OperationMode)
                    SendSerialData()
                Else
                    AddFileLine("Down_Up", "No", OperationMode)
                End If

                ' Set target
                MoveDownEncoderStep = LoadTarget * ForceStepCoeff

                ' Update screen

                LblDecision.Text = " Down Up "

                ' Down move
                If OperationStatus = "Stop" Then Exit Sub
                LblMET.Text = "-" & MoveDownEncoderStep

                'down move
                MoveToPosition(-MoveDownEncoderStep) ' change add ramp force

                ' Up move
                If OperationStatus = "Stop" Then Exit Sub
                LblMET.Text = (MoveDownEncoderStep - ForceDownStepNet)

                'up move
                MoveToPosition(MoveDownEncoderStep - ForceDownStepNet)
                Wait(MotorCurrentReadPause)
                GetCurrentData()

                'Check load 
                CheckMaxForce()


            End If
        End If
    End Sub
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

        ' Move by force to % of target load
        MyTargetForce = NUDTargetLoad.Value * (LoadApproachForce / 100)

        'first move
        MoveToPosition(-FirstMoveStep)
        Wait(MotorCurrentReadPause)
        GetCurrentData()

        Do

            'Send write to file
            AddFileLine("Up", "No", OperationMode)

            SendSerialData()

            MoveToPosition(ForceUpStep)
            Wait(MotorCurrentReadPause)
            GetCurrentData()
            Wait(ForceUpPause)

            'Check load 
            CheckMaxForce()

        Loop Until OperationStatus = "Stop" Or CCurrent > MyTargetForce

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
    Private Sub Force()
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

            'Send write to file
            AddFileLine("Up", "No", OperationMode)

            SendSerialData()

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
    Private Sub Distance(MyTargetDistance As Decimal)
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

            'Send write to file
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

        Loop Until OperationStatus = "Stop"

                If InRemoteMode = False Then
                    'Enable buttons
                    ManualPanelState(True)
                    RemotePanelState(False)
                End If


    End Sub