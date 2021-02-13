Imports System.Management
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        NotifyIcon1.BalloonTipTitle = "ComputInfos"
        NotifyIcon1.BalloonTipText = "Les informations viennent d'être chargées."
        NotifyIcon1.ShowBalloonTip(5000)

        Dim n As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_Processor")

        For Each pn As ManagementObject In n.Get()
            TextBox2.Text = pn("Name")
            TextBox3.Text = pn("NumberOfCores")
            Exit For
        Next

        Dim m As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_VideoController")

        For Each ob As ManagementObject In m.Get()
            TextBox1.Text = ob("Name")
            Exit For
        Next


        Dim Giga As Long = 1024 * 1024 * 1024
        Dim TotaleRam As Long = My.Computer.Info.TotalPhysicalMemory
        Dim TotaleRamEnGiga As Double = TotaleRam / Giga
        TextBox4.Text = TotaleRamEnGiga.ToString(".00")

        Dim RamLibre As Long = My.Computer.Info.AvailablePhysicalMemory
        Dim RamLibreEnGiga As Double = RamLibre / Giga
        TextBox5.Text = RamLibreEnGiga.ToString(".00")

        Dim RamUtilisée As Long = TotaleRam - RamLibre
        Dim RamUtiliséeEnGiga As Double = RamUtilisée / Giga
        TextBox6.Text = RamUtiliséeEnGiga.ToString(".00")


        TextBox7.Text = Environment.UserName
        TextBox8.Text = Environment.MachineName


    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim conf As DialogResult = MessageBox.Show("Voulez-vous vraiment quitter le logiciel ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If conf = DialogResult.Yes Then
            NotifyIcon1.BalloonTipTitle = "ComputInfos"
            NotifyIcon1.BalloonTipText = "Application fermée."
            NotifyIcon1.ShowBalloonTip(5000)
        End If

        If conf = DialogResult.No Then
            e.Cancel = True

        End If

    End Sub

    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon1.DoubleClick

        Me.Hide()

        NotifyIcon1.BalloonTipTitle = "ComputInfos"
        NotifyIcon1.BalloonTipText = "Application réduite."
        NotifyIcon1.ShowBalloonTip(5000)

    End Sub

    Private Sub NotifyIcon1_Click(sender As Object, e As EventArgs) Handles NotifyIcon1.Click
        Me.Show()

        NotifyIcon1.BalloonTipTitle = "ComputInfos"
        NotifyIcon1.BalloonTipText = "Application de nouveau visible."
        NotifyIcon1.ShowBalloonTip(5000)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Process.Start("https://software.antow.cf/")

    End Sub
End Class
