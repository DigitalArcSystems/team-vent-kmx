Option Explicit On
Module mdlApi32


    ' API32 declaration
    Declare Function GetTickCount Lib "kernel32" () As Long

    ' Profiles commands
    Declare Function GetPrivateProfileSection Lib "kernel32" Alias "GetPrivateProfileSectionA" (ByVal lpAppName As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32

    '  Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Long, ByVal lpFileName As String) As Long
    Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32

    Declare Function GetPrivateProfileInt Lib "kernel32" Alias "GetPrivateProfileIntA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal nDefault As Int32, ByVal lpFileName As String) As Int32

    Declare Function WritePrivateProfileSection Lib "kernel32" Alias "WritePrivateProfileSectionA" (ByVal lpAppName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32

    Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32

    Declare Function WriteProfileString Lib "kernel32" Alias "WriteProfileStringA" (ByVal lpszSection As String, ByVal lpszKeyName As String, ByVal lpszString As String) As Int32

    Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32

    Declare Function WinExec Lib "kernel32" (ByVal lpCmdLine As String, ByVal nCExcelhow As Int32) As Int32

    Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Int32

    Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal hwnd As Int32, ByVal nIndex As Long) As Int32

    Structure SECURITY_ATTRIBUTES
        Public nLength As Long
        Public lpSecurityDescriptor As Long
        Public bInheritHandle As Long
    End Structure

    Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" (ByVal lpFileName As String, ByVal dwDesiredAccess As Long, ByVal dwShareMode As Long, ByVal lpSecurityAttributes As Long, ByVal dwCreationDisposition As Long, ByVal dwFlagsAndAttributes As Long, ByVal hTemplateFile As Long) As Long

    Public Const GENERIC_READ = &H80000000
    Public Const GENERIC_WRITE = &H40000000
    Public Const OPEN_EXISTING = 3

    Public Const ERROR_PIPE_BUSY = 231&
    Public Const ERROR_PIPE_NOT_CONNECTED = 233&
    Public Const ERROR_PIPE_LISTENING = 536&
    Public Const ERROR_PIPE_CONNECTED = 535&
    Public Const ERROR_MORE_DATA = 234

    Public Const PIPE_READMODE_MESSAGE = &H2
    Public Const INVALID_HANDLE_VALUE = -1

    Declare Function GetLastError Lib "kernel32" () As Long

    Declare Function WaitNamedPipe Lib "kernel32" Alias "WaitNamedPipeA" (ByVal lpNamedPipeName As String, ByVal nTimeOut As Long) As Long

    Declare Function SetNamedPipeHandleState Lib "kernel32" (ByVal hNamedPipe As Long, ByVal lpMode As Long, ByVal lpMaxCollectionCount As Long, ByVal lpCollectDataTimeout As Long) As Long

    Declare Function CloseHandle Lib "kernel32" (ByVal hObject As Long) As Long

    Structure OVERLAPPED
        Public Internal As Long
        Public InternalHigh As Long
        Public offset As Long
        Public OffsetHigh As Long
        Public hEvent As Long
    End Structure

    Declare Function WriteFile Lib "kernel32" (ByVal hFile As Long, ByVal lpBuffer As String, ByVal nNumberOfBytesToWrite As Long, ByVal lpNumberOfBytesWritten As Long, ByVal lpOverlapped As Long) As Long

    Declare Function ReadFile Lib "kernel32" (ByVal hFile As Long, ByVal lpBuffer As String, ByVal nNumberOfBytesToRead As Long, ByVal lpNumberOfBytesRead As Long, ByVal lpOverlapped As Long) As Long

    Declare Function FlushFileBuffers Lib "kernel32" (ByVal hFile As Long) As Long

    Declare Function GetDesktopWindow Lib "user32" () As Long

    Declare Function GetWindow Lib "user32" (ByVal hwnd As Long, ByVal wCmd As Long) As Long

    Declare Function GetClassName Lib "user32" Alias "GetClassNameA" (ByVal hwnd As Long, ByVal lpClassName As String, ByVal nMaxCount As Long) As Long

    Public Const GW_CHILD = 5
    Public Const GW_HWNDNEXT = 2

    ' Need to install the DLL
    Declare Function agGetStringFromLPSTR$ Lib "apigid32.dll" (ByVal src$)

    Declare Function IsIconic Lib "user32" (ByVal hwnd As Long) As Long

    Declare Function OpenIcon Lib "user32" (ByVal hwnd As Long) As Long

    Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As Long) As Long

    Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

    Public Sub Wait(ByVal lngMilliseconds As Long)
        '------------------------------------------------------------------------------
        ' Description:
        '   Provide an active wait of N milliseconds given in parameter.
        '
        ' Parameter(s):
        '   Duration for the active wait
        '------------------------------------------------------------------------------


        Dim CurrentTime As Long
        Dim TargetTime As Long

        TargetTime = My.Computer.Clock.TickCount + lngMilliseconds

        Do
            ' System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            CurrentTime = My.Computer.Clock.TickCount
        Loop Until CurrentTime > TargetTime


    End Sub

    Public Sub WaitForSeconds(ByVal Seconds As Long)
        '------------------------------------------------------------------------------
        ' Description:
        '   Provide an active wait of N milliseconds given in parameter.
        '
        ' Parameter(s):
        '   Duration for the active wait
        '------------------------------------------------------------------------------

        For i = 1 To 2 * Seconds

            System.Threading.Thread.Sleep(500)
            Application.DoEvents()

        Next i

    End Sub

    Public Function ReadPreferenceString(ByVal strProfileName As String, ByVal strApplication As String, ByVal strKey As String, ByVal strDefaultValue As String) As String
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

        Dim strFileName As String
        Dim strApplicationName As String
        Dim strKeyName As String
        Dim strDefault As String
        Dim strReturnedString As String
        Dim intSize As Integer
        Dim strTempoString As String


        ' Set up parameters for reading profile strings
        strApplicationName = strApplication
        strKeyName = strKey
        strDefault = strDefaultValue
        strReturnedString = Space(251)
        intSize = 251

        ' Build the Profile file name
        strFileName = Application.StartupPath + "\" + strProfileName + ".ini"

        ' Read profile string
        strTempoString = GetPrivateProfileString(strApplicationName, strKeyName, strDefault, strReturnedString, intSize, strFileName)

        ' Trim string at C string terminator (NULL char)
        ReadPreferenceString = Left(strReturnedString, InStr(strReturnedString, Chr(0)) - 1)

    End Function

    Public Function ReadConfigurationString(ByVal strProfileName As String, ByVal strApplication As String, ByVal strKey As String, ByVal strDefaultValue As String) As String
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
        Dim strReturnedString As String
        Dim intSize As Integer
        Dim strTempoString As String

        ' Set up parameters for reading profile strings
        strApplicationName = strApplication
        strKeyName = strKey
        strDefault = strDefaultValue
        strReturnedString = Space(251)
        intSize = 251

        ' Read profile string
        strTempoString = GetPrivateProfileString(strApplicationName, strKeyName, _
          strDefault, strReturnedString, intSize, strProfileName)

        ' Trim string at C string terminator (NULL char)
        ReadConfigurationString = Left(strReturnedString, InStr(strReturnedString, Chr(0)) - 1)

    End Function

    Public Function WritePreferenceString(ByVal strProfileName As String, _
                                          ByVal strApplication As String, _
                                          ByVal strKey As String, _
                                          ByVal strValue As String) As Boolean
        '------------------------------------------------------------------------------
        ' Description:
        '   Write a key content in an INI file.
        '
        ' Parameter(s):
        '   Profile file name
        '   Application name (the one in [])
        '   Key name
        '   Key value
        '
        ' Returned Value:
        '   Command Status
        '------------------------------------------------------------------------------

        Dim strFileName As String
        Dim strApplicationName As String
        Dim strKeyName As String
        Dim intStatus As Integer
        Dim bolStatus As Boolean

        ' Set up parameters for reading profile strings
        strApplicationName = strApplication
        strKeyName = strKey

        ' Build the Profile file name
        strFileName = Application.StartupPath + "\" + strProfileName + ".ini"
        intStatus = WritePrivateProfileString(strApplicationName, strKeyName, _
          strValue, strFileName)

        ' Check the command Status
        If intStatus = 0 Then
            bolStatus = False
        Else
            bolStatus = True
        End If

        WritePreferenceString = bolStatus

    End Function
    Public Function WriteConfigurationString(ByVal strProfileName As String, _
                                             ByVal strApplication As String, _
                                             ByVal strKey As String, _
                                             ByVal strValue As String) As Boolean
        '------------------------------------------------------------------------------
        ' Description:
        '   Write a key content in an INI file.
        '
        ' Parameter(s):
        '   Profile file name
        '   Application name (the one in [])
        '   Key name
        '   Key value
        '
        ' Returned Value:
        '   Command Status
        '------------------------------------------------------------------------------

        Dim strApplicationName As String
        Dim strKeyName As String
        Dim intStatus As Integer
        Dim bolStatus As Boolean

        ' Set up parameters for reading profile strings
        strApplicationName = strApplication
        strKeyName = strKey

        intStatus = WritePrivateProfileString(strApplicationName, strKeyName, _
          strValue, strProfileName)

        ' Check the command Status
        If intStatus = 0 Then
            bolStatus = False
        Else
            bolStatus = True
        End If

        WriteConfigurationString = bolStatus

    End Function

End Module
