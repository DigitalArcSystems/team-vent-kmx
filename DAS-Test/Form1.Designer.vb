<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisconnectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoteModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LocalModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnMoveDownmm = New System.Windows.Forms.Button()
        Me.BtnMoveUpmm = New System.Windows.Forms.Button()
        Me.BtnMoveDown = New System.Windows.Forms.Button()
        Me.BtnMoveUp = New System.Windows.Forms.Button()
        Me.BtnAZC = New System.Windows.Forms.Button()
        Me.BtnApplyCurrent = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSetZero = New System.Windows.Forms.Button()
        Me.BtnStartOC = New System.Windows.Forms.Button()
        Me.BtnStopOc = New System.Windows.Forms.Button()
        Me.BtnMtEZ = New System.Windows.Forms.Button()
        Me.BtnMtD = New System.Windows.Forms.Button()
        Me.BtnRemoteStop = New System.Windows.Forms.Button()
        Me.BtnPauseOc = New System.Windows.Forms.Button()
        Me.BtnResumeOc = New System.Windows.Forms.Button()
        Me.BtnRetractOc = New System.Windows.Forms.Button()
        Me.BtnStopPlatesOc = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PanSetHome = New System.Windows.Forms.Panel()
        Me.NUDHomingCurrent = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PanSeek = New System.Windows.Forms.Panel()
        Me.NUDECAK = New System.Windows.Forms.NumericUpDown()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.NUDLACK = New System.Windows.Forms.NumericUpDown()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.NUDPHK = New System.Windows.Forms.NumericUpDown()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LblTargetEC = New System.Windows.Forms.Label()
        Me.LblTargetCurrent = New System.Windows.Forms.Label()
        Me.LblTargetLoadLB = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.NUDMCTK = New System.Windows.Forms.NumericUpDown()
        Me.NUDTargetDistance = New System.Windows.Forms.NumericUpDown()
        Me.NUDTargetLoad = New System.Windows.Forms.NumericUpDown()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LblFRP = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblDRP = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblMET = New System.Windows.Forms.Label()
        Me.LblDecision = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.RBTNCFRD = New System.Windows.Forms.RadioButton()
        Me.RBTNCFD = New System.Windows.Forms.RadioButton()
        Me.RBTNCFRF = New System.Windows.Forms.RadioButton()
        Me.RBTNCFF = New System.Windows.Forms.RadioButton()
        Me.RBTNCFLH = New System.Windows.Forms.RadioButton()
        Me.RBTNCFSC = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblLbs = New System.Windows.Forms.Label()
        Me.LblStl = New System.Windows.Forms.Label()
        Me.PanManual = New System.Windows.Forms.Panel()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.NUDSHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.NUDMM = New System.Windows.Forms.NumericUpDown()
        Me.NUDEncoderCounts = New System.Windows.Forms.NumericUpDown()
        Me.NUDDistance = New System.Windows.Forms.NumericUpDown()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblSetHome = New System.Windows.Forms.Label()
        Me.LblSLC = New System.Windows.Forms.Label()
        Me.LblManjog = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.LblRemote = New System.Windows.Forms.Label()
        Me.PanRemoteMode = New System.Windows.Forms.Panel()
        Me.LblRemotePar1 = New System.Windows.Forms.Label()
        Me.LblRemoteP1 = New System.Windows.Forms.Label()
        Me.LblRemoteCom = New System.Windows.Forms.Label()
        Me.LblRcommand = New System.Windows.Forms.Label()
        Me.LblRemoteMode = New System.Windows.Forms.Label()
        Me.PanStatus = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.LblRemoteCS = New System.Windows.Forms.Label()
        Me.LblConnect = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblDisconnect = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.LblRemoteD = New System.Windows.Forms.Label()
        Me.LblRemoteRD = New System.Windows.Forms.Label()
        Me.LblRemoteRF = New System.Windows.Forms.Label()
        Me.LblRemoteF = New System.Windows.Forms.Label()
        Me.LblRemoteM = New System.Windows.Forms.Label()
        Me.LblRemoteHS = New System.Windows.Forms.Label()
        Me.LblComSetting = New System.Windows.Forms.Label()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSAC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSEC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel9 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSDistance = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel11 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSLoadN = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSLoadLB = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblVersion = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.PanSetHome.SuspendLayout()
        CType(Me.NUDHomingCurrent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanSeek.SuspendLayout()
        CType(Me.NUDECAK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDLACK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDPHK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDMCTK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDTargetDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDTargetLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanManual.SuspendLayout()
        CType(Me.NUDSHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDMM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDEncoderCounts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanRemoteMode.SuspendLayout()
        Me.PanStatus.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.DisconnectToolStripMenuItem, Me.RemoteModeToolStripMenuItem, Me.LocalModeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1595, 26)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(78, 22)
        Me.OpenToolStripMenuItem.Text = "Connect"
        '
        'DisconnectToolStripMenuItem
        '
        Me.DisconnectToolStripMenuItem.Enabled = False
        Me.DisconnectToolStripMenuItem.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DisconnectToolStripMenuItem.Name = "DisconnectToolStripMenuItem"
        Me.DisconnectToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.DisconnectToolStripMenuItem.Text = "Disconnect"
        '
        'RemoteModeToolStripMenuItem
        '
        Me.RemoteModeToolStripMenuItem.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemoteModeToolStripMenuItem.Name = "RemoteModeToolStripMenuItem"
        Me.RemoteModeToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.RemoteModeToolStripMenuItem.Text = "Remote Control"
        '
        'LocalModeToolStripMenuItem
        '
        Me.LocalModeToolStripMenuItem.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LocalModeToolStripMenuItem.Name = "LocalModeToolStripMenuItem"
        Me.LocalModeToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.LocalModeToolStripMenuItem.Text = "Local Control"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'BtnMoveDownmm
        '
        Me.BtnMoveDownmm.BackColor = System.Drawing.Color.MediumBlue
        Me.BtnMoveDownmm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnMoveDownmm.FlatAppearance.BorderSize = 3
        Me.BtnMoveDownmm.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMoveDownmm.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnMoveDownmm.Location = New System.Drawing.Point(360, 89)
        Me.BtnMoveDownmm.Name = "BtnMoveDownmm"
        Me.BtnMoveDownmm.Size = New System.Drawing.Size(70, 36)
        Me.BtnMoveDownmm.TabIndex = 179
        Me.BtnMoveDownmm.Text = "-"
        Me.BtnMoveDownmm.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.BtnMoveDownmm, "Right click to change step value ")
        Me.BtnMoveDownmm.UseVisualStyleBackColor = False
        '
        'BtnMoveUpmm
        '
        Me.BtnMoveUpmm.BackColor = System.Drawing.Color.MediumBlue
        Me.BtnMoveUpmm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnMoveUpmm.FlatAppearance.BorderSize = 3
        Me.BtnMoveUpmm.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMoveUpmm.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnMoveUpmm.Location = New System.Drawing.Point(362, 17)
        Me.BtnMoveUpmm.Name = "BtnMoveUpmm"
        Me.BtnMoveUpmm.Size = New System.Drawing.Size(70, 36)
        Me.BtnMoveUpmm.TabIndex = 178
        Me.BtnMoveUpmm.Text = "+"
        Me.BtnMoveUpmm.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.BtnMoveUpmm, "Right click to change step value ")
        Me.BtnMoveUpmm.UseVisualStyleBackColor = False
        '
        'BtnMoveDown
        '
        Me.BtnMoveDown.BackColor = System.Drawing.Color.MediumBlue
        Me.BtnMoveDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnMoveDown.FlatAppearance.BorderSize = 3
        Me.BtnMoveDown.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMoveDown.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnMoveDown.Location = New System.Drawing.Point(138, 88)
        Me.BtnMoveDown.Name = "BtnMoveDown"
        Me.BtnMoveDown.Size = New System.Drawing.Size(112, 34)
        Me.BtnMoveDown.TabIndex = 171
        Me.BtnMoveDown.Text = "-"
        Me.BtnMoveDown.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.BtnMoveDown, "Right click to change step value ")
        Me.BtnMoveDown.UseVisualStyleBackColor = False
        '
        'BtnMoveUp
        '
        Me.BtnMoveUp.BackColor = System.Drawing.Color.MediumBlue
        Me.BtnMoveUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnMoveUp.FlatAppearance.BorderSize = 3
        Me.BtnMoveUp.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMoveUp.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnMoveUp.Location = New System.Drawing.Point(141, 16)
        Me.BtnMoveUp.Name = "BtnMoveUp"
        Me.BtnMoveUp.Size = New System.Drawing.Size(109, 36)
        Me.BtnMoveUp.TabIndex = 170
        Me.BtnMoveUp.Text = "+"
        Me.BtnMoveUp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.BtnMoveUp, "Right click to change step value ")
        Me.BtnMoveUp.UseVisualStyleBackColor = False
        '
        'BtnAZC
        '
        Me.BtnAZC.BackColor = System.Drawing.Color.MediumBlue
        Me.BtnAZC.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnAZC.FlatAppearance.BorderSize = 3
        Me.BtnAZC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAZC.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnAZC.Location = New System.Drawing.Point(17, 138)
        Me.BtnAZC.Name = "BtnAZC"
        Me.BtnAZC.Size = New System.Drawing.Size(200, 40)
        Me.BtnAZC.TabIndex = 112
        Me.BtnAZC.Text = "Stop"
        Me.ToolTip1.SetToolTip(Me.BtnAZC, "Set Current to Zero")
        Me.BtnAZC.UseVisualStyleBackColor = False
        '
        'BtnApplyCurrent
        '
        Me.BtnApplyCurrent.BackColor = System.Drawing.Color.MediumBlue
        Me.BtnApplyCurrent.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnApplyCurrent.FlatAppearance.BorderSize = 3
        Me.BtnApplyCurrent.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApplyCurrent.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnApplyCurrent.Location = New System.Drawing.Point(225, 75)
        Me.BtnApplyCurrent.Name = "BtnApplyCurrent"
        Me.BtnApplyCurrent.Size = New System.Drawing.Size(200, 40)
        Me.BtnApplyCurrent.TabIndex = 111
        Me.BtnApplyCurrent.Text = "Apply Homing Current"
        Me.ToolTip1.SetToolTip(Me.BtnApplyCurrent, "Set current to homing current")
        Me.BtnApplyCurrent.UseVisualStyleBackColor = False
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.Color.MediumBlue
        Me.BtnClose.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnClose.FlatAppearance.BorderSize = 3
        Me.BtnClose.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnClose.Location = New System.Drawing.Point(17, 73)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(200, 40)
        Me.BtnClose.TabIndex = 110
        Me.BtnClose.Text = "Collapse Plates"
        Me.ToolTip1.SetToolTip(Me.BtnClose, "Set Current to closing current")
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'BtnSetZero
        '
        Me.BtnSetZero.BackColor = System.Drawing.Color.MediumBlue
        Me.BtnSetZero.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnSetZero.FlatAppearance.BorderSize = 3
        Me.BtnSetZero.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSetZero.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnSetZero.Location = New System.Drawing.Point(225, 138)
        Me.BtnSetZero.Name = "BtnSetZero"
        Me.BtnSetZero.Size = New System.Drawing.Size(200, 40)
        Me.BtnSetZero.TabIndex = 109
        Me.BtnSetZero.Text = "Set Home Zero "
        Me.ToolTip1.SetToolTip(Me.BtnSetZero, "Set current encoder position to zero")
        Me.BtnSetZero.UseVisualStyleBackColor = False
        '
        'BtnStartOC
        '
        Me.BtnStartOC.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnStartOC.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnStartOC.FlatAppearance.BorderSize = 3
        Me.BtnStartOC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStartOC.ForeColor = System.Drawing.Color.Black
        Me.BtnStartOC.Location = New System.Drawing.Point(98, 195)
        Me.BtnStartOC.Name = "BtnStartOC"
        Me.BtnStartOC.Size = New System.Drawing.Size(140, 40)
        Me.BtnStartOC.TabIndex = 120
        Me.BtnStartOC.Text = "Start Cycle"
        Me.ToolTip1.SetToolTip(Me.BtnStartOC, "Moves until system reach a certain current")
        Me.BtnStartOC.UseVisualStyleBackColor = False
        '
        'BtnStopOc
        '
        Me.BtnStopOc.BackColor = System.Drawing.Color.Red
        Me.BtnStopOc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnStopOc.FlatAppearance.BorderSize = 3
        Me.BtnStopOc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStopOc.ForeColor = System.Drawing.Color.Black
        Me.BtnStopOc.Location = New System.Drawing.Point(99, 241)
        Me.BtnStopOc.Name = "BtnStopOc"
        Me.BtnStopOc.Size = New System.Drawing.Size(140, 40)
        Me.BtnStopOc.TabIndex = 118
        Me.BtnStopOc.Text = "Stop Cycle"
        Me.ToolTip1.SetToolTip(Me.BtnStopOc, "Stop the system")
        Me.BtnStopOc.UseVisualStyleBackColor = False
        '
        'BtnMtEZ
        '
        Me.BtnMtEZ.BackColor = System.Drawing.Color.MediumBlue
        Me.BtnMtEZ.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnMtEZ.FlatAppearance.BorderSize = 3
        Me.BtnMtEZ.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMtEZ.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnMtEZ.Location = New System.Drawing.Point(257, 204)
        Me.BtnMtEZ.Name = "BtnMtEZ"
        Me.BtnMtEZ.Size = New System.Drawing.Size(200, 40)
        Me.BtnMtEZ.TabIndex = 192
        Me.BtnMtEZ.Text = "Move to Start Height"
        Me.ToolTip1.SetToolTip(Me.BtnMtEZ, "Moves to encoder zero postition")
        Me.BtnMtEZ.UseVisualStyleBackColor = False
        '
        'BtnMtD
        '
        Me.BtnMtD.BackColor = System.Drawing.Color.MediumBlue
        Me.BtnMtD.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnMtD.FlatAppearance.BorderSize = 3
        Me.BtnMtD.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMtD.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnMtD.Location = New System.Drawing.Point(257, 149)
        Me.BtnMtD.Name = "BtnMtD"
        Me.BtnMtD.Size = New System.Drawing.Size(200, 40)
        Me.BtnMtD.TabIndex = 188
        Me.BtnMtD.Text = "Move to Distance"
        Me.ToolTip1.SetToolTip(Me.BtnMtD, "Move to distance")
        Me.BtnMtD.UseVisualStyleBackColor = False
        '
        'BtnRemoteStop
        '
        Me.BtnRemoteStop.BackColor = System.Drawing.Color.MediumBlue
        Me.BtnRemoteStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnRemoteStop.FlatAppearance.BorderSize = 3
        Me.BtnRemoteStop.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRemoteStop.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnRemoteStop.Location = New System.Drawing.Point(1342, 305)
        Me.BtnRemoteStop.Name = "BtnRemoteStop"
        Me.BtnRemoteStop.Size = New System.Drawing.Size(188, 40)
        Me.BtnRemoteStop.TabIndex = 216
        Me.BtnRemoteStop.Text = "Stop Cycle"
        Me.ToolTip1.SetToolTip(Me.BtnRemoteStop, "Stop the system")
        Me.BtnRemoteStop.UseVisualStyleBackColor = False
        '
        'BtnPauseOc
        '
        Me.BtnPauseOc.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnPauseOc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnPauseOc.FlatAppearance.BorderSize = 3
        Me.BtnPauseOc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPauseOc.ForeColor = System.Drawing.Color.Black
        Me.BtnPauseOc.Location = New System.Drawing.Point(249, 195)
        Me.BtnPauseOc.Name = "BtnPauseOc"
        Me.BtnPauseOc.Size = New System.Drawing.Size(140, 40)
        Me.BtnPauseOc.TabIndex = 229
        Me.BtnPauseOc.Text = "Pause Cycle"
        Me.ToolTip1.SetToolTip(Me.BtnPauseOc, "Stop the system")
        Me.BtnPauseOc.UseVisualStyleBackColor = False
        '
        'BtnResumeOc
        '
        Me.BtnResumeOc.BackColor = System.Drawing.Color.MediumBlue
        Me.BtnResumeOc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnResumeOc.FlatAppearance.BorderSize = 3
        Me.BtnResumeOc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnResumeOc.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnResumeOc.Location = New System.Drawing.Point(249, 241)
        Me.BtnResumeOc.Name = "BtnResumeOc"
        Me.BtnResumeOc.Size = New System.Drawing.Size(140, 40)
        Me.BtnResumeOc.TabIndex = 236
        Me.BtnResumeOc.Text = "Resume Cycle"
        Me.ToolTip1.SetToolTip(Me.BtnResumeOc, "Stop the system")
        Me.BtnResumeOc.UseVisualStyleBackColor = False
        '
        'BtnRetractOc
        '
        Me.BtnRetractOc.BackColor = System.Drawing.Color.MediumBlue
        Me.BtnRetractOc.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.BtnRetractOc.FlatAppearance.BorderSize = 3
        Me.BtnRetractOc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRetractOc.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnRetractOc.Location = New System.Drawing.Point(452, 195)
        Me.BtnRetractOc.Name = "BtnRetractOc"
        Me.BtnRetractOc.Size = New System.Drawing.Size(140, 40)
        Me.BtnRetractOc.TabIndex = 243
        Me.BtnRetractOc.Text = "Retract Plates"
        Me.ToolTip1.SetToolTip(Me.BtnRetractOc, "Set Current to closing current")
        Me.BtnRetractOc.UseVisualStyleBackColor = False
        '
        'BtnStopPlatesOc
        '
        Me.BtnStopPlatesOc.BackColor = System.Drawing.Color.Black
        Me.BtnStopPlatesOc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnStopPlatesOc.FlatAppearance.BorderSize = 3
        Me.BtnStopPlatesOc.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStopPlatesOc.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnStopPlatesOc.Location = New System.Drawing.Point(452, 242)
        Me.BtnStopPlatesOc.Name = "BtnStopPlatesOc"
        Me.BtnStopPlatesOc.Size = New System.Drawing.Size(140, 40)
        Me.BtnStopPlatesOc.TabIndex = 244
        Me.BtnStopPlatesOc.Text = "Power off"
        Me.ToolTip1.SetToolTip(Me.BtnStopPlatesOc, "Set Current to Zero")
        Me.BtnStopPlatesOc.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1482, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 16)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Ver:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PanSetHome
        '
        Me.PanSetHome.Controls.Add(Me.NUDHomingCurrent)
        Me.PanSetHome.Controls.Add(Me.BtnAZC)
        Me.PanSetHome.Controls.Add(Me.BtnApplyCurrent)
        Me.PanSetHome.Controls.Add(Me.BtnClose)
        Me.PanSetHome.Controls.Add(Me.BtnSetZero)
        Me.PanSetHome.Controls.Add(Me.Label2)
        Me.PanSetHome.Controls.Add(Me.Label9)
        Me.PanSetHome.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanSetHome.Location = New System.Drawing.Point(12, 79)
        Me.PanSetHome.Name = "PanSetHome"
        Me.PanSetHome.Size = New System.Drawing.Size(445, 206)
        Me.PanSetHome.TabIndex = 110
        '
        'NUDHomingCurrent
        '
        Me.NUDHomingCurrent.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NUDHomingCurrent.Location = New System.Drawing.Point(207, 15)
        Me.NUDHomingCurrent.Name = "NUDHomingCurrent"
        Me.NUDHomingCurrent.Size = New System.Drawing.Size(60, 26)
        Me.NUDHomingCurrent.TabIndex = 113
        Me.NUDHomingCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label2.Location = New System.Drawing.Point(79, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 18)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Homing Current:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(273, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 18)
        Me.Label9.TabIndex = 105
        Me.Label9.Text = "mA"
        '
        'PanSeek
        '
        Me.PanSeek.Controls.Add(Me.BtnStopPlatesOc)
        Me.PanSeek.Controls.Add(Me.BtnRetractOc)
        Me.PanSeek.Controls.Add(Me.NUDECAK)
        Me.PanSeek.Controls.Add(Me.Label21)
        Me.PanSeek.Controls.Add(Me.NUDLACK)
        Me.PanSeek.Controls.Add(Me.Label20)
        Me.PanSeek.Controls.Add(Me.NUDPHK)
        Me.PanSeek.Controls.Add(Me.Label14)
        Me.PanSeek.Controls.Add(Me.BtnResumeOc)
        Me.PanSeek.Controls.Add(Me.LblTargetEC)
        Me.PanSeek.Controls.Add(Me.LblTargetCurrent)
        Me.PanSeek.Controls.Add(Me.LblTargetLoadLB)
        Me.PanSeek.Controls.Add(Me.Label13)
        Me.PanSeek.Controls.Add(Me.NUDMCTK)
        Me.PanSeek.Controls.Add(Me.BtnPauseOc)
        Me.PanSeek.Controls.Add(Me.NUDTargetDistance)
        Me.PanSeek.Controls.Add(Me.NUDTargetLoad)
        Me.PanSeek.Controls.Add(Me.Label19)
        Me.PanSeek.Controls.Add(Me.LblFRP)
        Me.PanSeek.Controls.Add(Me.Label4)
        Me.PanSeek.Controls.Add(Me.LblDRP)
        Me.PanSeek.Controls.Add(Me.Label18)
        Me.PanSeek.Controls.Add(Me.Label8)
        Me.PanSeek.Controls.Add(Me.LblMET)
        Me.PanSeek.Controls.Add(Me.LblDecision)
        Me.PanSeek.Controls.Add(Me.Label3)
        Me.PanSeek.Controls.Add(Me.Label40)
        Me.PanSeek.Controls.Add(Me.Label41)
        Me.PanSeek.Controls.Add(Me.Label23)
        Me.PanSeek.Controls.Add(Me.Label11)
        Me.PanSeek.Controls.Add(Me.Label12)
        Me.PanSeek.Controls.Add(Me.RBTNCFRD)
        Me.PanSeek.Controls.Add(Me.RBTNCFD)
        Me.PanSeek.Controls.Add(Me.RBTNCFRF)
        Me.PanSeek.Controls.Add(Me.RBTNCFF)
        Me.PanSeek.Controls.Add(Me.RBTNCFLH)
        Me.PanSeek.Controls.Add(Me.RBTNCFSC)
        Me.PanSeek.Controls.Add(Me.BtnStartOC)
        Me.PanSeek.Controls.Add(Me.BtnStopOc)
        Me.PanSeek.Controls.Add(Me.Label6)
        Me.PanSeek.Controls.Add(Me.Label10)
        Me.PanSeek.Controls.Add(Me.LblLbs)
        Me.PanSeek.Controls.Add(Me.LblStl)
        Me.PanSeek.Location = New System.Drawing.Point(10, 377)
        Me.PanSeek.Name = "PanSeek"
        Me.PanSeek.Size = New System.Drawing.Size(948, 302)
        Me.PanSeek.TabIndex = 111
        '
        'NUDECAK
        '
        Me.NUDECAK.DecimalPlaces = 3
        Me.NUDECAK.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NUDECAK.Increment = New Decimal(New Integer() {5, 0, 0, 196608})
        Me.NUDECAK.Location = New System.Drawing.Point(831, 267)
        Me.NUDECAK.Name = "NUDECAK"
        Me.NUDECAK.Size = New System.Drawing.Size(101, 26)
        Me.NUDECAK.TabIndex = 242
        Me.NUDECAK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label21.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(614, 270)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(211, 20)
        Me.Label21.TabIndex = 241
        Me.Label21.Text = "EncoderCountsAbsolute_K"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NUDLACK
        '
        Me.NUDLACK.DecimalPlaces = 3
        Me.NUDLACK.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NUDLACK.Increment = New Decimal(New Integer() {5, 0, 0, 196608})
        Me.NUDLACK.Location = New System.Drawing.Point(831, 235)
        Me.NUDLACK.Name = "NUDLACK"
        Me.NUDLACK.Size = New System.Drawing.Size(101, 26)
        Me.NUDLACK.TabIndex = 240
        Me.NUDLACK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label20.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(630, 238)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(195, 20)
        Me.Label20.TabIndex = 239
        Me.Label20.Text = "LoadAtCurrent_K:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NUDPHK
        '
        Me.NUDPHK.DecimalPlaces = 3
        Me.NUDPHK.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NUDPHK.Increment = New Decimal(New Integer() {5, 0, 0, 196608})
        Me.NUDPHK.Location = New System.Drawing.Point(830, 204)
        Me.NUDPHK.Name = "NUDPHK"
        Me.NUDPHK.Size = New System.Drawing.Size(101, 26)
        Me.NUDPHK.TabIndex = 238
        Me.NUDPHK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label14.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(633, 207)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(191, 20)
        Me.Label14.TabIndex = 237
        Me.Label14.Text = "PlateHeight_K:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTargetEC
        '
        Me.LblTargetEC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblTargetEC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTargetEC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTargetEC.Location = New System.Drawing.Point(496, 79)
        Me.LblTargetEC.Name = "LblTargetEC"
        Me.LblTargetEC.Size = New System.Drawing.Size(80, 20)
        Me.LblTargetEC.TabIndex = 235
        Me.LblTargetEC.Text = "0"
        Me.LblTargetEC.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'LblTargetCurrent
        '
        Me.LblTargetCurrent.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblTargetCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTargetCurrent.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTargetCurrent.Location = New System.Drawing.Point(124, 80)
        Me.LblTargetCurrent.Name = "LblTargetCurrent"
        Me.LblTargetCurrent.Size = New System.Drawing.Size(71, 20)
        Me.LblTargetCurrent.TabIndex = 234
        Me.LblTargetCurrent.Text = "0"
        Me.LblTargetCurrent.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'LblTargetLoadLB
        '
        Me.LblTargetLoadLB.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblTargetLoadLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTargetLoadLB.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTargetLoadLB.Location = New System.Drawing.Point(244, 28)
        Me.LblTargetLoadLB.Name = "LblTargetLoadLB"
        Me.LblTargetLoadLB.Size = New System.Drawing.Size(60, 20)
        Me.LblTargetLoadLB.TabIndex = 233
        Me.LblTargetLoadLB.Text = "0"
        Me.LblTargetLoadLB.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label13
        '
        Me.Label13.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label13.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(310, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(26, 20)
        Me.Label13.TabIndex = 232
        Me.Label13.Text = "lb"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NUDMCTK
        '
        Me.NUDMCTK.DecimalPlaces = 3
        Me.NUDMCTK.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NUDMCTK.Increment = New Decimal(New Integer() {5, 0, 0, 196608})
        Me.NUDMCTK.Location = New System.Drawing.Point(831, 172)
        Me.NUDMCTK.Name = "NUDMCTK"
        Me.NUDMCTK.Size = New System.Drawing.Size(101, 26)
        Me.NUDMCTK.TabIndex = 230
        Me.NUDMCTK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NUDTargetDistance
        '
        Me.NUDTargetDistance.DecimalPlaces = 2
        Me.NUDTargetDistance.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NUDTargetDistance.Location = New System.Drawing.Point(496, 24)
        Me.NUDTargetDistance.Name = "NUDTargetDistance"
        Me.NUDTargetDistance.Size = New System.Drawing.Size(78, 26)
        Me.NUDTargetDistance.TabIndex = 228
        Me.NUDTargetDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NUDTargetLoad
        '
        Me.NUDTargetLoad.DecimalPlaces = 2
        Me.NUDTargetLoad.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NUDTargetLoad.Increment = New Decimal(New Integer() {4448, 0, 0, 131072})
        Me.NUDTargetLoad.Location = New System.Drawing.Point(127, 24)
        Me.NUDTargetLoad.Name = "NUDTargetLoad"
        Me.NUDTargetLoad.Size = New System.Drawing.Size(78, 26)
        Me.NUDTargetLoad.TabIndex = 227
        Me.NUDTargetLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label19.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(669, 132)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(156, 20)
        Me.Label19.TabIndex = 226
        Me.Label19.Text = "Force Ramp Pause:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblFRP
        '
        Me.LblFRP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblFRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblFRP.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFRP.Location = New System.Drawing.Point(831, 128)
        Me.LblFRP.Name = "LblFRP"
        Me.LblFRP.Size = New System.Drawing.Size(100, 30)
        Me.LblFRP.TabIndex = 225
        Me.LblFRP.Text = "0"
        Me.LblFRP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(647, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(178, 20)
        Me.Label4.TabIndex = 224
        Me.Label4.Text = "Distance Ramp Pause:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDRP
        '
        Me.LblDRP.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblDRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblDRP.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDRP.Location = New System.Drawing.Point(831, 89)
        Me.LblDRP.Name = "LblDRP"
        Me.LblDRP.Size = New System.Drawing.Size(100, 30)
        Me.LblDRP.TabIndex = 223
        Me.LblDRP.Text = "0"
        Me.LblDRP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label18.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(633, 175)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(192, 20)
        Me.Label18.TabIndex = 221
        Me.Label18.Text = "MotorCurrentTarget_K:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(713, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 20)
        Me.Label8.TabIndex = 220
        Me.Label8.Text = "Move Value:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblMET
        '
        Me.LblMET.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblMET.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblMET.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMET.Location = New System.Drawing.Point(831, 51)
        Me.LblMET.Name = "LblMET"
        Me.LblMET.Size = New System.Drawing.Size(100, 30)
        Me.LblMET.TabIndex = 219
        Me.LblMET.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDecision
        '
        Me.LblDecision.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblDecision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblDecision.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDecision.Location = New System.Drawing.Point(831, 12)
        Me.LblDecision.Name = "LblDecision"
        Me.LblDecision.Size = New System.Drawing.Size(100, 30)
        Me.LblDecision.TabIndex = 218
        Me.LblDecision.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(750, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 20)
        Me.Label3.TabIndex = 217
        Me.Label3.Text = "Decision:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label40
        '
        Me.Label40.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label40.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(588, 80)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(39, 20)
        Me.Label40.TabIndex = 215
        Me.Label40.Text = "cts"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label41
        '
        Me.Label41.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label41.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(305, 78)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(179, 20)
        Me.Label41.TabIndex = 214
        Me.Label41.Text = "Target Encoder Counts:"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label23.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(63, 126)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(114, 20)
        Me.Label23.TabIndex = 211
        Me.Label23.Text = "Internal use only"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label11.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(588, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 20)
        Me.Label11.TabIndex = 198
        Me.Label11.Text = "mm"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label12.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(368, 30)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(116, 27)
        Me.Label12.TabIndex = 197
        Me.Label12.Text = "Target Distance:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RBTNCFRD
        '
        Me.RBTNCFRD.AutoSize = True
        Me.RBTNCFRD.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBTNCFRD.Location = New System.Drawing.Point(369, 152)
        Me.RBTNCFRD.Name = "RBTNCFRD"
        Me.RBTNCFRD.Size = New System.Drawing.Size(156, 22)
        Me.RBTNCFRD.TabIndex = 195
        Me.RBTNCFRD.TabStop = True
        Me.RBTNCFRD.Text = "Ramped Distance "
        Me.RBTNCFRD.UseVisualStyleBackColor = True
        '
        'RBTNCFD
        '
        Me.RBTNCFD.AutoSize = True
        Me.RBTNCFD.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBTNCFD.Location = New System.Drawing.Point(269, 153)
        Me.RBTNCFD.Name = "RBTNCFD"
        Me.RBTNCFD.Size = New System.Drawing.Size(88, 22)
        Me.RBTNCFD.TabIndex = 194
        Me.RBTNCFD.TabStop = True
        Me.RBTNCFD.Text = "Distance"
        Me.RBTNCFD.UseVisualStyleBackColor = True
        '
        'RBTNCFRF
        '
        Me.RBTNCFRF.AutoSize = True
        Me.RBTNCFRF.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBTNCFRF.Location = New System.Drawing.Point(366, 125)
        Me.RBTNCFRF.Name = "RBTNCFRF"
        Me.RBTNCFRF.Size = New System.Drawing.Size(131, 22)
        Me.RBTNCFRF.TabIndex = 193
        Me.RBTNCFRF.TabStop = True
        Me.RBTNCFRF.Text = "Ramped Force"
        Me.RBTNCFRF.UseVisualStyleBackColor = True
        '
        'RBTNCFF
        '
        Me.RBTNCFF.AutoSize = True
        Me.RBTNCFF.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBTNCFF.Location = New System.Drawing.Point(269, 126)
        Me.RBTNCFF.Name = "RBTNCFF"
        Me.RBTNCFF.Size = New System.Drawing.Size(67, 22)
        Me.RBTNCFF.TabIndex = 192
        Me.RBTNCFF.TabStop = True
        Me.RBTNCFF.Text = "Force"
        Me.RBTNCFF.UseVisualStyleBackColor = True
        '
        'RBTNCFLH
        '
        Me.RBTNCFLH.AutoSize = True
        Me.RBTNCFLH.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBTNCFLH.Location = New System.Drawing.Point(20, 148)
        Me.RBTNCFLH.Name = "RBTNCFLH"
        Me.RBTNCFLH.Size = New System.Drawing.Size(98, 22)
        Me.RBTNCFLH.TabIndex = 191
        Me.RBTNCFLH.TabStop = True
        Me.RBTNCFLH.Text = "Load Hold"
        Me.RBTNCFLH.UseVisualStyleBackColor = True
        '
        'RBTNCFSC
        '
        Me.RBTNCFSC.AutoSize = True
        Me.RBTNCFSC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBTNCFSC.Location = New System.Drawing.Point(134, 149)
        Me.RBTNCFSC.Name = "RBTNCFSC"
        Me.RBTNCFSC.Size = New System.Drawing.Size(106, 22)
        Me.RBTNCFSC.TabIndex = 190
        Me.RBTNCFSC.TabStop = True
        Me.RBTNCFSC.Text = "Seek Cycle"
        Me.RBTNCFSC.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(204, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 20)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "mA"
        '
        'Label10
        '
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(-12, 82)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(130, 20)
        Me.Label10.TabIndex = 113
        Me.Label10.Text = "Target Current:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblLbs
        '
        Me.LblLbs.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LblLbs.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLbs.Location = New System.Drawing.Point(211, 30)
        Me.LblLbs.Name = "LblLbs"
        Me.LblLbs.Size = New System.Drawing.Size(27, 23)
        Me.LblLbs.TabIndex = 108
        Me.LblLbs.Text = "N"
        Me.LblLbs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblStl
        '
        Me.LblStl.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LblStl.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStl.Location = New System.Drawing.Point(7, 30)
        Me.LblStl.Name = "LblStl"
        Me.LblStl.Size = New System.Drawing.Size(111, 27)
        Me.LblStl.TabIndex = 107
        Me.LblStl.Text = "Target Load:"
        Me.LblStl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanManual
        '
        Me.PanManual.Controls.Add(Me.Label24)
        Me.PanManual.Controls.Add(Me.NUDSHeight)
        Me.PanManual.Controls.Add(Me.Label22)
        Me.PanManual.Controls.Add(Me.NUDMM)
        Me.PanManual.Controls.Add(Me.NUDEncoderCounts)
        Me.PanManual.Controls.Add(Me.NUDDistance)
        Me.PanManual.Controls.Add(Me.BtnMtEZ)
        Me.PanManual.Controls.Add(Me.Label15)
        Me.PanManual.Controls.Add(Me.BtnMtD)
        Me.PanManual.Controls.Add(Me.Label5)
        Me.PanManual.Controls.Add(Me.Label16)
        Me.PanManual.Controls.Add(Me.Label7)
        Me.PanManual.Controls.Add(Me.BtnMoveDownmm)
        Me.PanManual.Controls.Add(Me.BtnMoveUpmm)
        Me.PanManual.Controls.Add(Me.BtnMoveDown)
        Me.PanManual.Controls.Add(Me.BtnMoveUp)
        Me.PanManual.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanManual.Location = New System.Drawing.Point(472, 79)
        Me.PanManual.Name = "PanManual"
        Me.PanManual.Size = New System.Drawing.Size(490, 255)
        Me.PanManual.TabIndex = 112
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(216, 210)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(28, 18)
        Me.Label24.TabIndex = 220
        Me.Label24.Text = "cts"
        '
        'NUDSHeight
        '
        Me.NUDSHeight.DecimalPlaces = 1
        Me.NUDSHeight.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NUDSHeight.Location = New System.Drawing.Point(126, 208)
        Me.NUDSHeight.Name = "NUDSHeight"
        Me.NUDSHeight.Size = New System.Drawing.Size(84, 26)
        Me.NUDSHeight.TabIndex = 219
        Me.NUDSHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label22.Location = New System.Drawing.Point(26, 210)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(94, 18)
        Me.Label22.TabIndex = 218
        Me.Label22.Text = "Start Height:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'NUDMM
        '
        Me.NUDMM.DecimalPlaces = 1
        Me.NUDMM.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NUDMM.Location = New System.Drawing.Point(362, 55)
        Me.NUDMM.Name = "NUDMM"
        Me.NUDMM.Size = New System.Drawing.Size(70, 26)
        Me.NUDMM.TabIndex = 217
        Me.NUDMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NUDEncoderCounts
        '
        Me.NUDEncoderCounts.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NUDEncoderCounts.Location = New System.Drawing.Point(143, 55)
        Me.NUDEncoderCounts.Name = "NUDEncoderCounts"
        Me.NUDEncoderCounts.Size = New System.Drawing.Size(107, 26)
        Me.NUDEncoderCounts.TabIndex = 216
        Me.NUDEncoderCounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NUDDistance
        '
        Me.NUDDistance.DecimalPlaces = 1
        Me.NUDDistance.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NUDDistance.Location = New System.Drawing.Point(126, 154)
        Me.NUDDistance.Name = "NUDDistance"
        Me.NUDDistance.Size = New System.Drawing.Size(84, 26)
        Me.NUDDistance.TabIndex = 193
        Me.NUDDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(216, 159)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 18)
        Me.Label15.TabIndex = 189
        Me.Label15.Text = "mm"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label5.Location = New System.Drawing.Point(42, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 18)
        Me.Label5.TabIndex = 182
        Me.Label5.Text = "Distance:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(3, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(129, 20)
        Me.Label16.TabIndex = 181
        Me.Label16.Text = "Encoder Counts:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(258, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 20)
        Me.Label7.TabIndex = 180
        Me.Label7.Text = "Millimeter:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblSetHome
        '
        Me.LblSetHome.Enabled = False
        Me.LblSetHome.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSetHome.Location = New System.Drawing.Point(111, 48)
        Me.LblSetHome.Name = "LblSetHome"
        Me.LblSetHome.Size = New System.Drawing.Size(258, 28)
        Me.LblSetHome.TabIndex = 113
        Me.LblSetHome.Text = " Set Home - 9mm"
        Me.LblSetHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblSLC
        '
        Me.LblSLC.Enabled = False
        Me.LblSLC.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSLC.Location = New System.Drawing.Point(330, 346)
        Me.LblSLC.Name = "LblSLC"
        Me.LblSLC.Size = New System.Drawing.Size(258, 28)
        Me.LblSLC.TabIndex = 114
        Me.LblSLC.Text = "Control Functions "
        Me.LblSLC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblManjog
        '
        Me.LblManjog.Enabled = False
        Me.LblManjog.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManjog.Location = New System.Drawing.Point(606, 48)
        Me.LblManjog.Name = "LblManjog"
        Me.LblManjog.Size = New System.Drawing.Size(258, 28)
        Me.LblManjog.TabIndex = 115
        Me.LblManjog.Text = " Manual Jog "
        Me.LblManjog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DimGray
        Me.Panel2.Location = New System.Drawing.Point(10, 28)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1550, 3)
        Me.Panel2.TabIndex = 169
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DimGray
        Me.Panel3.Location = New System.Drawing.Point(0, 340)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(960, 3)
        Me.Panel3.TabIndex = 170
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DimGray
        Me.Panel4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(464, 85)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(3, 220)
        Me.Panel4.TabIndex = 171
        '
        'SerialPort1
        '
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DimGray
        Me.Panel5.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel5.Location = New System.Drawing.Point(977, 48)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(3, 600)
        Me.Panel5.TabIndex = 183
        '
        'LblRemote
        '
        Me.LblRemote.Enabled = False
        Me.LblRemote.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemote.Location = New System.Drawing.Point(1177, 48)
        Me.LblRemote.Name = "LblRemote"
        Me.LblRemote.Size = New System.Drawing.Size(258, 28)
        Me.LblRemote.TabIndex = 184
        Me.LblRemote.Text = "Remote"
        Me.LblRemote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanRemoteMode
        '
        Me.PanRemoteMode.Controls.Add(Me.LblRemotePar1)
        Me.PanRemoteMode.Controls.Add(Me.LblRemoteP1)
        Me.PanRemoteMode.Controls.Add(Me.LblRemoteCom)
        Me.PanRemoteMode.Controls.Add(Me.LblRcommand)
        Me.PanRemoteMode.Enabled = False
        Me.PanRemoteMode.Location = New System.Drawing.Point(993, 261)
        Me.PanRemoteMode.Name = "PanRemoteMode"
        Me.PanRemoteMode.Size = New System.Drawing.Size(316, 73)
        Me.PanRemoteMode.TabIndex = 193
        '
        'LblRemotePar1
        '
        Me.LblRemotePar1.AutoSize = True
        Me.LblRemotePar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblRemotePar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblRemotePar1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemotePar1.Location = New System.Drawing.Point(114, 42)
        Me.LblRemotePar1.Name = "LblRemotePar1"
        Me.LblRemotePar1.Size = New System.Drawing.Size(14, 20)
        Me.LblRemotePar1.TabIndex = 199
        Me.LblRemotePar1.Text = " "
        '
        'LblRemoteP1
        '
        Me.LblRemoteP1.AutoSize = True
        Me.LblRemoteP1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemoteP1.Location = New System.Drawing.Point(9, 44)
        Me.LblRemoteP1.Name = "LblRemoteP1"
        Me.LblRemoteP1.Size = New System.Drawing.Size(99, 18)
        Me.LblRemoteP1.TabIndex = 198
        Me.LblRemoteP1.Text = "Parameter 1:"
        '
        'LblRemoteCom
        '
        Me.LblRemoteCom.AutoSize = True
        Me.LblRemoteCom.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblRemoteCom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblRemoteCom.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemoteCom.Location = New System.Drawing.Point(114, 15)
        Me.LblRemoteCom.Name = "LblRemoteCom"
        Me.LblRemoteCom.Size = New System.Drawing.Size(14, 20)
        Me.LblRemoteCom.TabIndex = 197
        Me.LblRemoteCom.Text = " "
        '
        'LblRcommand
        '
        Me.LblRcommand.AutoSize = True
        Me.LblRcommand.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRcommand.Location = New System.Drawing.Point(9, 17)
        Me.LblRcommand.Name = "LblRcommand"
        Me.LblRcommand.Size = New System.Drawing.Size(85, 18)
        Me.LblRcommand.TabIndex = 196
        Me.LblRcommand.Text = "Command:"
        '
        'LblRemoteMode
        '
        Me.LblRemoteMode.AutoSize = True
        Me.LblRemoteMode.Enabled = False
        Me.LblRemoteMode.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemoteMode.Location = New System.Drawing.Point(994, 236)
        Me.LblRemoteMode.Name = "LblRemoteMode"
        Me.LblRemoteMode.Size = New System.Drawing.Size(184, 22)
        Me.LblRemoteMode.TabIndex = 194
        Me.LblRemoteMode.Text = "Command Received"
        '
        'PanStatus
        '
        Me.PanStatus.Controls.Add(Me.Label17)
        Me.PanStatus.Controls.Add(Me.RichTextBox1)
        Me.PanStatus.Enabled = False
        Me.PanStatus.Location = New System.Drawing.Point(1003, 353)
        Me.PanStatus.Name = "PanStatus"
        Me.PanStatus.Size = New System.Drawing.Size(581, 317)
        Me.PanStatus.TabIndex = 195
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(164, 27)
        Me.Label17.TabIndex = 187
        Me.Label17.Text = "Serial Com Log: "
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(10, 35)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(527, 256)
        Me.RichTextBox1.TabIndex = 186
        Me.RichTextBox1.Text = ""
        '
        'LblRemoteCS
        '
        Me.LblRemoteCS.Enabled = False
        Me.LblRemoteCS.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemoteCS.Location = New System.Drawing.Point(999, 95)
        Me.LblRemoteCS.Name = "LblRemoteCS"
        Me.LblRemoteCS.Size = New System.Drawing.Size(245, 22)
        Me.LblRemoteCS.TabIndex = 196
        Me.LblRemoteCS.Text = "Connection Status"
        Me.LblRemoteCS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblConnect
        '
        Me.LblConnect.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblConnect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblConnect.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblConnect.Location = New System.Drawing.Point(999, 127)
        Me.LblConnect.Name = "LblConnect"
        Me.LblConnect.Size = New System.Drawing.Size(115, 30)
        Me.LblConnect.TabIndex = 197
        Me.LblConnect.Text = "Connected"
        Me.LblConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel6, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 723)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1595, 40)
        Me.StatusStrip1.TabIndex = 200
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(80, 35)
        Me.ToolStripStatusLabel1.Text = "Control:"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.AutoSize = False
        Me.ToolStripStatusLabel2.BorderSides = CType(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(100, 35)
        Me.ToolStripStatusLabel2.Text = "Local"
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(72, 35)
        Me.ToolStripStatusLabel3.Text = "Status:"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.AutoSize = False
        Me.ToolStripStatusLabel4.BorderSides = CType(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(750, 35)
        Me.ToolStripStatusLabel4.Text = "Not Connected"
        Me.ToolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.BorderSides = CType(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel6.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(78, 35)
        Me.ToolStripStatusLabel6.Text = "Device:"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.AutoSize = False
        Me.ToolStripStatusLabel8.BorderSides = CType(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(120, 35)
        Me.ToolStripStatusLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblDisconnect
        '
        Me.LblDisconnect.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblDisconnect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblDisconnect.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDisconnect.Location = New System.Drawing.Point(1129, 127)
        Me.LblDisconnect.Name = "LblDisconnect"
        Me.LblDisconnect.Size = New System.Drawing.Size(115, 30)
        Me.LblDisconnect.TabIndex = 201
        Me.LblDisconnect.Text = "Disconnected"
        Me.LblDisconnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(1315, 266)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(120, 30)
        Me.Label28.TabIndex = 203
        Me.Label28.Text = "In Progress"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(1451, 266)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(120, 30)
        Me.Label29.TabIndex = 202
        Me.Label29.Text = "At Home"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblRemoteD
        '
        Me.LblRemoteD.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblRemoteD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblRemoteD.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemoteD.Location = New System.Drawing.Point(1315, 173)
        Me.LblRemoteD.Name = "LblRemoteD"
        Me.LblRemoteD.Size = New System.Drawing.Size(120, 30)
        Me.LblRemoteD.TabIndex = 207
        Me.LblRemoteD.Text = "Distance"
        Me.LblRemoteD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblRemoteRD
        '
        Me.LblRemoteRD.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblRemoteRD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblRemoteRD.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemoteRD.Location = New System.Drawing.Point(1452, 173)
        Me.LblRemoteRD.Name = "LblRemoteRD"
        Me.LblRemoteRD.Size = New System.Drawing.Size(120, 30)
        Me.LblRemoteRD.TabIndex = 206
        Me.LblRemoteRD.Text = "Ramp Distance"
        Me.LblRemoteRD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblRemoteRF
        '
        Me.LblRemoteRF.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblRemoteRF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblRemoteRF.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemoteRF.Location = New System.Drawing.Point(1449, 127)
        Me.LblRemoteRF.Name = "LblRemoteRF"
        Me.LblRemoteRF.Size = New System.Drawing.Size(120, 30)
        Me.LblRemoteRF.TabIndex = 205
        Me.LblRemoteRF.Text = "Ramp Force"
        Me.LblRemoteRF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblRemoteF
        '
        Me.LblRemoteF.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblRemoteF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblRemoteF.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemoteF.Location = New System.Drawing.Point(1315, 127)
        Me.LblRemoteF.Name = "LblRemoteF"
        Me.LblRemoteF.Size = New System.Drawing.Size(120, 30)
        Me.LblRemoteF.TabIndex = 204
        Me.LblRemoteF.Text = "Force"
        Me.LblRemoteF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblRemoteM
        '
        Me.LblRemoteM.Enabled = False
        Me.LblRemoteM.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemoteM.Location = New System.Drawing.Point(1311, 95)
        Me.LblRemoteM.Name = "LblRemoteM"
        Me.LblRemoteM.Size = New System.Drawing.Size(272, 22)
        Me.LblRemoteM.TabIndex = 208
        Me.LblRemoteM.Text = "Mode"
        Me.LblRemoteM.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblRemoteHS
        '
        Me.LblRemoteHS.Enabled = False
        Me.LblRemoteHS.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemoteHS.Location = New System.Drawing.Point(1321, 231)
        Me.LblRemoteHS.Name = "LblRemoteHS"
        Me.LblRemoteHS.Size = New System.Drawing.Size(245, 22)
        Me.LblRemoteHS.TabIndex = 209
        Me.LblRemoteHS.Text = "Home Status"
        Me.LblRemoteHS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblComSetting
        '
        Me.LblComSetting.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LblComSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblComSetting.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblComSetting.Location = New System.Drawing.Point(998, 174)
        Me.LblComSetting.Name = "LblComSetting"
        Me.LblComSetting.Size = New System.Drawing.Size(246, 30)
        Me.LblComSetting.TabIndex = 214
        Me.LblComSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel5, Me.TSAC, Me.ToolStripStatusLabel7, Me.TSEC, Me.ToolStripStatusLabel9, Me.TSDistance, Me.ToolStripStatusLabel11, Me.TSLoadN, Me.TSLoadLB})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 683)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(1595, 40)
        Me.StatusStrip2.TabIndex = 215
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(138, 35)
        Me.ToolStripStatusLabel5.Text = "Actual Current:"
        '
        'TSAC
        '
        Me.TSAC.AutoSize = False
        Me.TSAC.BorderSides = CType(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.TSAC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSAC.Name = "TSAC"
        Me.TSAC.Size = New System.Drawing.Size(100, 35)
        Me.TSAC.Text = "000 mA"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.AutoSize = False
        Me.ToolStripStatusLabel7.BorderSides = CType(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(147, 35)
        Me.ToolStripStatusLabel7.Text = "Encoder Counts:"
        '
        'TSEC
        '
        Me.TSEC.AutoSize = False
        Me.TSEC.BorderSides = CType(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.TSEC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSEC.Name = "TSEC"
        Me.TSEC.Size = New System.Drawing.Size(109, 35)
        Me.TSEC.Text = "000000000"
        '
        'ToolStripStatusLabel9
        '
        Me.ToolStripStatusLabel9.BorderSides = CType(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel9.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel9.Name = "ToolStripStatusLabel9"
        Me.ToolStripStatusLabel9.Size = New System.Drawing.Size(93, 35)
        Me.ToolStripStatusLabel9.Text = "Distance:"
        '
        'TSDistance
        '
        Me.TSDistance.AutoSize = False
        Me.TSDistance.BackColor = System.Drawing.Color.DimGray
        Me.TSDistance.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.TSDistance.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSDistance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TSDistance.Name = "TSDistance"
        Me.TSDistance.Size = New System.Drawing.Size(120, 35)
        Me.TSDistance.Text = "000 mm"
        '
        'ToolStripStatusLabel11
        '
        Me.ToolStripStatusLabel11.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel11.Name = "ToolStripStatusLabel11"
        Me.ToolStripStatusLabel11.Size = New System.Drawing.Size(58, 35)
        Me.ToolStripStatusLabel11.Text = "Load:"
        '
        'TSLoadN
        '
        Me.TSLoadN.AutoSize = False
        Me.TSLoadN.BackColor = System.Drawing.Color.DimGray
        Me.TSLoadN.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSLoadN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TSLoadN.Name = "TSLoadN"
        Me.TSLoadN.Size = New System.Drawing.Size(100, 35)
        Me.TSLoadN.Text = "0000 N"
        '
        'TSLoadLB
        '
        Me.TSLoadLB.AutoSize = False
        Me.TSLoadLB.BackColor = System.Drawing.Color.DimGray
        Me.TSLoadLB.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.TSLoadLB.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSLoadLB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TSLoadLB.Name = "TSLoadLB"
        Me.TSLoadLB.Size = New System.Drawing.Size(100, 35)
        Me.TSLoadLB.Text = "0000 lb"
        '
        'LblVersion
        '
        Me.LblVersion.AutoSize = True
        Me.LblVersion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVersion.Location = New System.Drawing.Point(1512, 9)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(32, 16)
        Me.LblVersion.TabIndex = 217
        Me.LblVersion.Text = "7.15"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1595, 763)
        Me.Controls.Add(Me.LblVersion)
        Me.Controls.Add(Me.BtnRemoteStop)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.LblComSetting)
        Me.Controls.Add(Me.LblRemoteHS)
        Me.Controls.Add(Me.LblRemoteM)
        Me.Controls.Add(Me.LblRemoteD)
        Me.Controls.Add(Me.LblRemoteRD)
        Me.Controls.Add(Me.LblRemoteRF)
        Me.Controls.Add(Me.LblRemoteF)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.LblDisconnect)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.LblConnect)
        Me.Controls.Add(Me.LblRemoteCS)
        Me.Controls.Add(Me.PanStatus)
        Me.Controls.Add(Me.LblRemoteMode)
        Me.Controls.Add(Me.PanRemoteMode)
        Me.Controls.Add(Me.LblRemote)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LblManjog)
        Me.Controls.Add(Me.LblSLC)
        Me.Controls.Add(Me.LblSetHome)
        Me.Controls.Add(Me.PanManual)
        Me.Controls.Add(Me.PanSeek)
        Me.Controls.Add(Me.PanSetHome)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = " "
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.PanSetHome.ResumeLayout(False)
        Me.PanSetHome.PerformLayout()
        CType(Me.NUDHomingCurrent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanSeek.ResumeLayout(False)
        Me.PanSeek.PerformLayout()
        CType(Me.NUDECAK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDLACK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDPHK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDMCTK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDTargetDistance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDTargetLoad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanManual.ResumeLayout(False)
        Me.PanManual.PerformLayout()
        CType(Me.NUDSHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDMM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDEncoderCounts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDDistance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanRemoteMode.ResumeLayout(False)
        Me.PanRemoteMode.PerformLayout()
        Me.PanStatus.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DisconnectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label1 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents PanSetHome As Panel
    Friend WithEvents BtnAZC As Button
    Friend WithEvents BtnApplyCurrent As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSetZero As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PanSeek As Panel
    Friend WithEvents BtnStopOc As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents LblLbs As Label
    Friend WithEvents LblStl As Label
    Friend WithEvents PanManual As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents BtnMoveDownmm As Button
    Friend WithEvents BtnMoveUpmm As Button
    Friend WithEvents BtnMoveDown As Button
    Friend WithEvents BtnMoveUp As Button
    Friend WithEvents LblSetHome As Label
    Friend WithEvents LblSLC As Label
    Friend WithEvents LblManjog As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents BtnMtD As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnMtEZ As Button
    Friend WithEvents RemoteModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BtnStartOC As Button
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents LocalModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Timer3 As Timer
    Friend WithEvents Panel5 As Panel
    Friend WithEvents LblRemote As Label
    Friend WithEvents RBTNCFF As RadioButton
    Friend WithEvents RBTNCFLH As RadioButton
    Friend WithEvents RBTNCFSC As RadioButton
    Friend WithEvents PanRemoteMode As Panel
    Friend WithEvents LblRemoteMode As Label
    Friend WithEvents PanStatus As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents LblRemoteCom As Label
    Friend WithEvents LblRcommand As Label
    Friend WithEvents LblRemotePar1 As Label
    Friend WithEvents LblRemoteP1 As Label
    Friend WithEvents LblRemoteCS As Label
    Friend WithEvents LblConnect As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents RBTNCFRD As RadioButton
    Friend WithEvents RBTNCFD As RadioButton
    Friend WithEvents RBTNCFRF As RadioButton
    Friend WithEvents Label23 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblDisconnect As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents LblRemoteD As Label
    Friend WithEvents LblRemoteRD As Label
    Friend WithEvents LblRemoteRF As Label
    Friend WithEvents LblRemoteF As Label
    Friend WithEvents LblRemoteM As Label
    Friend WithEvents LblRemoteHS As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents LblComSetting As Label
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents StatusStrip2 As StatusStrip
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents TSAC As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As ToolStripStatusLabel
    Friend WithEvents TSEC As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel9 As ToolStripStatusLabel
    Friend WithEvents TSDistance As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel11 As ToolStripStatusLabel
    Friend WithEvents TSLoadN As ToolStripStatusLabel
    Friend WithEvents LblDecision As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents LblMET As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents LblFRP As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LblDRP As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents NUDTargetLoad As NumericUpDown
    Friend WithEvents NUDTargetDistance As NumericUpDown
    Friend WithEvents NUDDistance As NumericUpDown
    Friend WithEvents NUDHomingCurrent As NumericUpDown
    Friend WithEvents NUDEncoderCounts As NumericUpDown
    Friend WithEvents NUDMM As NumericUpDown
    Friend WithEvents BtnRemoteStop As Button
    Friend WithEvents BtnPauseOc As Button
    Friend WithEvents ToolStripStatusLabel6 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As ToolStripStatusLabel
    Friend WithEvents NUDMCTK As NumericUpDown
    Friend WithEvents LblTargetLoadLB As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TSLoadLB As ToolStripStatusLabel
    Friend WithEvents LblTargetCurrent As Label
    Friend WithEvents LblTargetEC As Label
    Friend WithEvents BtnResumeOc As Button
    Friend WithEvents LblVersion As Label
    Friend WithEvents NUDECAK As NumericUpDown
    Friend WithEvents Label21 As Label
    Friend WithEvents NUDLACK As NumericUpDown
    Friend WithEvents Label20 As Label
    Friend WithEvents NUDPHK As NumericUpDown
    Friend WithEvents Label14 As Label
    Friend WithEvents BtnRetractOc As Button
    Friend WithEvents BtnStopPlatesOc As Button
    Friend WithEvents Label24 As Label
    Friend WithEvents NUDSHeight As NumericUpDown
    Friend WithEvents Label22 As Label
End Class
