Imports System.Windows.Forms.Design
Imports System.ComponentModel

Public Class TBwPH
    Inherits TextBox
    Dim placeholder As String = "Placeholder"
    Dim PHforecolor As Color = Color.DimGray
    Dim phtbcolor As Color = Color.Black
    Dim defaultcolor As Color = PHforecolor
    Dim PassProtect As Boolean = False
    Dim selectAllClick As Boolean = False

    Public Sub New()
        Me.Text = PlaceHolderText
        Me.ForeColor = PHforecolor
        Me.BorderStyle = BorderStyle.FixedSingle
        If Me.Text = placeholder Then
            Me.ForeColor = PlaceHolderForeColor
        Else
            Me.ForeColor = phtbcolor
        End If
    End Sub

    Public Sub PHtextbox_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        'if tb displays placeholder, if tb is clicked then erase contents of tb
        If Me.Text = placeholder Then
            If e.Button = MouseButtons.Left Then
                Me.Text = Nothing
            Else

            End If
        Else
            'if tb does not have placeholder and is clicked, select all IF me.selectall = true
            If selectAllClick = True Then
                Me.SelectAll()
            End If
        End If
    End Sub

    Public Sub PHtextbox_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
        If Me.Text = placeholder Then
            Me.ForeColor = PlaceHolderForeColor
        Else
            Me.ForeColor = phtbcolor
        End If

        If PassProtect = True Then
            If Me.Text = placeholder Then
                Me.UseSystemPasswordChar = False
            ElseIf Me.Text = Nothing Then

            Else
                Me.UseSystemPasswordChar = True
            End If
        Else
            Me.UseSystemPasswordChar = False
        End If
    End Sub

    Public Sub PHtextbox_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        If Me.Text = Nothing Then
            Me.Text = placeholder
        End If
    End Sub

    Private Sub PHtextbox_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        If Me.Text = placeholder Then
            Me.Text = Nothing
        End If
    End Sub

    <Category("TextBox with Placeholder")>
    <DisplayName("Placeholder Text")>
    <Description("What the placeholder text will say.")>
    Public Property PlaceHolderText() As String
        Get
            Return placeholder
        End Get
        Set(value As String)
            placeholder = value
            Me.Text = placeholder
        End Set
    End Property

    <Category("TextBox with Placeholder")>
    <DisplayName("Placeholder Forecolor")>
    <Description("The color of the placeholder text.")>
    Public Property PlaceHolderForeColor() As Color
        Get
            Return PHforecolor
        End Get
        Set(value As Color)
            PHforecolor = value
            Me.ForeColor = value
        End Set
    End Property

    <Category("TextBox with Placeholder")>
    <DisplayName("TextBox Color")>
    <Description("The color of the text that will be entered into the textbox by the user.")>
    Public Property TextColor() As Color
        Get
            Return phtbcolor
        End Get
        Set(value As Color)
            phtbcolor = value
        End Set
    End Property

    <Category("TextBox with Placeholder")>
    <DisplayName("Password Protected")>
    <Description("When set to true, this will hide the text when being typed, much like password-protected textboxes on websites.")>
    Public Property PasswordProtected() As Boolean
        Get
            Return PassProtect
        End Get
        Set(value As Boolean)
            PassProtect = value
        End Set
    End Property

    <Category("TextBox with Placeholder")>
    <DisplayName("Select All On Click")>
    <Description("When set to true, all of the text will be selected when the textbox is clicked. This will not happen for the placeholder text.")>
    Public Property selectAllonClick() As Boolean
        Get
            Return selectAllClick
        End Get
        Set(value As Boolean)
            selectAllClick = value
        End Set
    End Property

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.ResumeLayout(False)

    End Sub
End Class