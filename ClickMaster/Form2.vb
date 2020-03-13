Public Class Form2
    Dim p As Point
    Dim pn As Point
    Dim ps As Boolean = False
    Private Declare Function GetCursorPos Lib "user32" (ByRef lpPoint As Point) As Long
    Public Declare Auto Function RegisterHotKey Lib "user32.dll" Alias "RegisterHotKey" (ByVal hwnd As IntPtr, ByVal id As Integer, ByVal fsModifiers As Integer, ByVal vk As Integer) As Boolean
    Public Declare Auto Function UnRegisterHotKey Lib "user32.dll" Alias "UnregisterHotKey" (ByVal hwnd As IntPtr, ByVal id As Integer) As Boolean
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RegisterHotKey(Handle, 0, 0, Keys.Enter)
        If Form1.selected = True Then
            Label2.Text = "已选择：" + Form1.selectpoint.ToString
        End If
    End Sub
    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = 786 Then
            ps = True
            pn = p
            Label2.Text = "已选择：" + pn.ToString
        End If
        MyBase.WndProc(m)
    End Sub
    Private Sub Form2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        UnRegisterHotKey(Handle, 0)
        Form1.Show()
        If ps = True Then
            Form1.selected = True
            Form1.selectpoint = pn
            Form1.Label5.Text = Form1.selectpoint.ToString
            Form1.Button2.Enabled = True
            Form1.Button2.Text = "开始连点"
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GetCursorPos(p)
        TextBox1.Text = p.ToString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class