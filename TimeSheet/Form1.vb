Public Class Form1
    Dim TotalHoursPerWeek As Byte = 45
    Dim ShiftStart As String = "09:00"
    Dim ShiftEnd As String = "18:00"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists("C:\Users\Public\Documents\Data.txt") Then
            Dim values() As String = IO.File.ReadAllText("C:\Users\Public\Documents\Data.txt").Split("|"c)
            TextBox1.Text = values(0)
            TextBox2.Text = values(1)
            TextBox3.Text = values(2)
            TextBox4.Text = values(3)
            TextBox5.Text = values(4)
            TextBox6.Text = values(5)
            TextBox7.Text = values(6)
            TextBox8.Text = values(7)
            TextBox9.Text = values(8)
            TextBox10.Text = values(9)
        End If
    End Sub

    Private Sub TotalHoursPerWeekToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalHoursPerWeekToolStripMenuItem.Click
        Form2.TextBox1.Text = TotalHoursPerWeek
        Form2.ShowDialog()
    End Sub

    Private Sub ShiftTimingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShiftTimingsToolStripMenuItem.Click
        Form3.TextBox1.Text = ShiftStart
        Form3.TextBox2.Text = ShiftEnd
        Form3.ShowDialog()
    End Sub
    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim HoursTill, LeaveByHours, LeaveByMinutes As Byte
        Dim HoursTill_Mon, HoursTill_Tue, HoursTill_Wed, HoursTill_Thu, HoursTill_Fri As Byte
        Dim MinutesTill_Mon, MinutesTill_Tue, MinutesTill_Wed, MinutesTill_Thu, MinutesTill_Fri As Byte
        Dim MinutesTill, HoursLeft, MinutesLeft As Integer


        If TextBox1.Text = String.Empty Or
           TextBox2.Text = String.Empty Or
           TextBox3.Text = String.Empty Or
           TextBox4.Text = String.Empty Or
           TextBox5.Text = String.Empty Or
           TextBox6.Text = String.Empty Or
           TextBox7.Text = String.Empty Or
           TextBox8.Text = String.Empty Or
           TextBox9.Text = String.Empty Or
           TextBox10.Text = String.Empty Then
            MsgBox("Invalid data entry!")
        ElseIf (((Val(TextBox6.Text.Split(":")(0)) - Val(TextBox1.Text.Split(":")(0))) < 0) And TextBox6.Text <> "00:00") Or
           (((Val(TextBox7.Text.Split(":")(0)) - Val(TextBox2.Text.Split(":")(0))) < 0) And TextBox7.Text <> "00:00") Or
           (((Val(TextBox8.Text.Split(":")(0)) - Val(TextBox3.Text.Split(":")(0))) < 0) And TextBox8.Text <> "00:00") Or
           (((Val(TextBox9.Text.Split(":")(0)) - Val(TextBox4.Text.Split(":")(0))) < 0) And TextBox9.Text <> "00:00") Or
           (((Val(TextBox10.Text.Split(":")(0)) - Val(TextBox5.Text.Split(":")(0))) < 0) And TextBox10.Text <> "00:00") Then
            MsgBox("OUT Time should be later than IN Time.")
        Else
            'HoursTill = (Val(TextBox6.Text.Split(":")(0)) - Val(TextBox1.Text.Split(":")(0))) _
            '            + (Val(TextBox7.Text.Split(":")(0)) - Val(TextBox2.Text.Split(":")(0))) _
            '            + (Val(TextBox8.Text.Split(":")(0)) - Val(TextBox3.Text.Split(":")(0))) _
            '            + (Val(TextBox9.Text.Split(":")(0)) - Val(TextBox4.Text.Split(":")(0))) _
            '            + (Val(TextBox10.Text.Split(":")(0)) - Val(TextBox5.Text.Split(":")(0)))

            If TextBox6.Text = "00:00" Then
                HoursTill_Mon = 0
            Else
                HoursTill_Mon = (Val(TextBox6.Text.Split(":")(0)) - Val(TextBox1.Text.Split(":")(0)))
            End If

            If TextBox7.Text = "00:00" Then
                HoursTill_Tue = 0
            Else
                HoursTill_Tue = (Val(TextBox7.Text.Split(":")(0)) - Val(TextBox2.Text.Split(":")(0)))
            End If

            If TextBox8.Text = "00:00" Then
                HoursTill_Wed = 0
            Else
                HoursTill_Wed = (Val(TextBox8.Text.Split(":")(0)) - Val(TextBox3.Text.Split(":")(0)))
            End If

            If TextBox9.Text = "00:00" Then
                HoursTill_Thu = 0
            Else
                HoursTill_Thu = (Val(TextBox9.Text.Split(":")(0)) - Val(TextBox4.Text.Split(":")(0)))
            End If

            If TextBox10.Text = "00:00" Then
                HoursTill_Fri = 0
            Else
                HoursTill_Fri = (Val(TextBox10.Text.Split(":")(0)) - Val(TextBox5.Text.Split(":")(0)))
            End If

            HoursTill = HoursTill_Mon + HoursTill_Tue + HoursTill_Wed + HoursTill_Thu + HoursTill_Fri

            If TextBox6.Text = "00:00" Then
                MinutesTill_Mon = 0
            ElseIf (Val(TextBox6.Text.Split(":")(1)) - Val(TextBox1.Text.Split(":")(1))) < 0 Then
                MinutesTill_Mon = 60 + (Val(TextBox6.Text.Split(":")(1)) - Val(TextBox1.Text.Split(":")(1)))
                HoursTill -= 1
            Else
                MinutesTill_Mon = (Val(TextBox6.Text.Split(":")(1)) - Val(TextBox1.Text.Split(":")(1)))
            End If

            If TextBox7.Text = "00:00" Then
                MinutesTill_Tue = 0
            ElseIf (Val(TextBox7.Text.Split(":")(1)) - Val(TextBox2.Text.Split(":")(1))) < 0 Then
                MinutesTill_Tue = 60 + (Val(TextBox7.Text.Split(":")(1)) - Val(TextBox2.Text.Split(":")(1)))
                HoursTill -= 1
            Else
                MinutesTill_Tue = (Val(TextBox7.Text.Split(":")(1)) - Val(TextBox2.Text.Split(":")(1)))
            End If

            If TextBox8.Text = "00:00" Then
                MinutesTill_Wed = 0
            ElseIf (Val(TextBox8.Text.Split(":")(1)) - Val(TextBox3.Text.Split(":")(1))) < 0 Then
                MinutesTill_Wed = 60 + (Val(TextBox8.Text.Split(":")(1)) - Val(TextBox3.Text.Split(":")(1)))
                HoursTill -= 1
            Else
                MinutesTill_Wed = (Val(TextBox8.Text.Split(":")(1)) - Val(TextBox3.Text.Split(":")(1)))
            End If

            If TextBox9.Text = "00:00" Then
                MinutesTill_Thu = 0
            ElseIf (Val(TextBox9.Text.Split(":")(1)) - Val(TextBox4.Text.Split(":")(1))) < 0 Then
                MinutesTill_Thu = 60 + (Val(TextBox9.Text.Split(":")(1)) - Val(TextBox4.Text.Split(":")(1)))
                HoursTill -= 1
            Else
                MinutesTill_Thu = (Val(TextBox9.Text.Split(":")(1)) - Val(TextBox4.Text.Split(":")(1)))
            End If

            If TextBox10.Text = "00:00" Then
                MinutesTill_Fri = 0
            ElseIf (Val(TextBox10.Text.Split(":")(1)) - Val(TextBox5.Text.Split(":")(1))) < 0 Then
                MinutesTill_Fri = 60 + (Val(TextBox10.Text.Split(":")(1)) - Val(TextBox5.Text.Split(":")(1)))
                HoursTill -= 1
            Else
                MinutesTill_Fri = (Val(TextBox10.Text.Split(":")(1)) - Val(TextBox5.Text.Split(":")(1)))
            End If

            MinutesTill = MinutesTill_Mon + MinutesTill_Tue + MinutesTill_Wed + MinutesTill_Thu + MinutesTill_Fri
            HoursTill = HoursTill + (MinutesTill \ 60)
            MinutesTill = MinutesTill Mod 60
            Label11.Text = String.Format("{0:00}:{1:00}", HoursTill, MinutesTill)
            If TotalHoursPerWeek > HoursTill Then
                HoursLeft = TotalHoursPerWeek - HoursTill
                If MinutesTill <> 0 Then
                    MinutesLeft = 60 - MinutesTill
                    HoursLeft -= 1
                End If
                Label12.Text = String.Format("{0:00}:{1:00}", HoursLeft, MinutesLeft)
                Label12.ForeColor = Color.Crimson

                If TextBox6.Text = "00:00" Then
                    If TextBox1.Text = "00:00" Then
                        TextBox1.Text = ShiftStart
                        TextBox1.BackColor = Color.Yellow
                    End If
                    TextBox2.Text = ShiftStart
                    TextBox2.BackColor = Color.Yellow
                    TextBox3.Text = ShiftStart
                    TextBox3.BackColor = Color.Yellow
                    TextBox4.Text = ShiftStart
                    TextBox4.BackColor = Color.Yellow
                    TextBox5.Text = ShiftStart
                    TextBox5.BackColor = Color.Yellow
                    TextBox7.Text = ShiftEnd
                    TextBox7.BackColor = Color.Yellow
                    TextBox8.Text = ShiftEnd
                    TextBox8.BackColor = Color.Yellow
                    TextBox9.Text = ShiftEnd
                    TextBox9.BackColor = Color.Yellow
                    TextBox10.Text = ShiftEnd
                    TextBox10.BackColor = Color.Yellow

                    LeaveByMinutes = Val(TextBox1.Text.Split(":")(1))
                    LeaveByHours = Val(TextBox1.Text.Split(":")(0)) + 9
                    TextBox6.Text = String.Format("{0:00}:{1:00}", LeaveByHours, LeaveByMinutes)
                    TextBox6.BackColor = Color.Yellow
                    Label13.Text = String.Format("{0:00}:{1:00}", LeaveByHours, LeaveByMinutes)
                ElseIf TextBox7.Text = "00:00" Then
                    If TextBox2.Text = "00:00" Then
                        TextBox2.Text = ShiftStart
                        TextBox2.BackColor = Color.Yellow
                    End If
                    TextBox3.Text = ShiftStart
                    TextBox3.BackColor = Color.Yellow
                    TextBox4.Text = ShiftStart
                    TextBox4.BackColor = Color.Yellow
                    TextBox5.Text = ShiftStart
                    TextBox5.BackColor = Color.Yellow
                    TextBox8.Text = String.Format("{0:00}:{1:00}", (Val(TextBox3.Text.Split(":")(0)) + (HoursLeft \ 4) _
                        + ((Val(TextBox3.Text.Split(":")(1)) + (MinutesLeft \ 4)) \ 60)), ((Val(TextBox3.Text.Split(":")(1)) + (MinutesLeft \ 4)) Mod 60))
                    TextBox8.BackColor = Color.Yellow
                    TextBox9.Text = String.Format("{0:00}:{1:00}", (Val(TextBox4.Text.Split(":")(0)) + (HoursLeft \ 4) _
                        + ((Val(TextBox4.Text.Split(":")(1)) + (MinutesLeft \ 4)) \ 60)), ((Val(TextBox4.Text.Split(":")(1)) + (MinutesLeft \ 4)) Mod 60))
                    TextBox9.BackColor = Color.Yellow
                    TextBox10.Text = String.Format("{0:00}:{1:00}", (Val(TextBox5.Text.Split(":")(0)) + (HoursLeft \ 4) _
                        + ((Val(TextBox5.Text.Split(":")(1)) + (MinutesLeft \ 4)) \ 60)), ((Val(TextBox5.Text.Split(":")(1)) + (MinutesLeft \ 4)) Mod 60))
                    TextBox10.BackColor = Color.Yellow

                    LeaveByMinutes = (Val(TextBox2.Text.Split(":")(1)) + (MinutesLeft \ 4) + (MinutesLeft Mod 4)) Mod 60
                    LeaveByHours = Val(TextBox2.Text.Split(":")(0)) + (HoursLeft \ 4) + (HoursLeft Mod 4) _
                        + ((Val(TextBox2.Text.Split(":")(1)) + (MinutesLeft \ 4) + (MinutesLeft Mod 4)) \ 60)
                    TextBox7.Text = String.Format("{0:00}:{1:00}", LeaveByHours, LeaveByMinutes)
                    TextBox7.BackColor = Color.Yellow
                    Label13.Text = String.Format("{0:00}:{1:00}", LeaveByHours, LeaveByMinutes)
                ElseIf TextBox8.Text = "00:00" Then
                    If TextBox3.Text = "00:00" Then
                        TextBox3.Text = ShiftStart
                        TextBox3.BackColor = Color.Yellow
                    End If
                    TextBox4.Text = ShiftStart
                    TextBox4.BackColor = Color.Yellow
                    TextBox5.Text = ShiftStart
                    TextBox5.BackColor = Color.Yellow
                    TextBox9.Text = String.Format("{0:00}:{1:00}", (Val(TextBox4.Text.Split(":")(0)) + (HoursLeft \ 3) _
                        + ((Val(TextBox4.Text.Split(":")(1)) + (MinutesLeft \ 3)) \ 60)), ((Val(TextBox4.Text.Split(":")(1)) + (MinutesLeft \ 3)) Mod 60))
                    TextBox9.BackColor = Color.Yellow
                    TextBox10.Text = String.Format("{0:00}:{1:00}", (Val(TextBox5.Text.Split(":")(0)) + (HoursLeft \ 3) _
                        + ((Val(TextBox5.Text.Split(":")(1)) + (MinutesLeft \ 3)) \ 60)), ((Val(TextBox5.Text.Split(":")(1)) + (MinutesLeft \ 3)) Mod 60))
                    TextBox10.BackColor = Color.Yellow

                    LeaveByMinutes = (Val(TextBox3.Text.Split(":")(1)) + (MinutesLeft \ 3) + (MinutesLeft Mod 3)) Mod 60
                    LeaveByHours = Val(TextBox3.Text.Split(":")(0)) + (HoursLeft \ 3) + (HoursLeft Mod 3) _
                        + ((Val(TextBox3.Text.Split(":")(1)) + (MinutesLeft \ 3) + (MinutesLeft Mod 3)) \ 60)
                    TextBox8.Text = String.Format("{0:00}:{1:00}", LeaveByHours, LeaveByMinutes)
                    TextBox8.BackColor = Color.Yellow
                    Label13.Text = String.Format("{0:00}:{1:00}", LeaveByHours, LeaveByMinutes)
                ElseIf TextBox9.Text = "00:00" Then
                    If TextBox4.Text = "00:00" Then
                        TextBox4.Text = ShiftStart
                        TextBox4.BackColor = Color.Yellow
                    End If
                    TextBox5.Text = ShiftStart
                    TextBox5.BackColor = Color.Yellow
                    TextBox10.Text = String.Format("{0:00}:{1:00}", (Val(TextBox5.Text.Split(":")(0)) + (HoursLeft \ 2) _
                        + ((Val(TextBox5.Text.Split(":")(1)) + (MinutesLeft \ 2)) \ 60)), ((Val(TextBox5.Text.Split(":")(1)) + (MinutesLeft \ 2)) Mod 60))
                    TextBox10.BackColor = Color.Yellow

                    LeaveByMinutes = (Val(TextBox4.Text.Split(":")(1)) + (MinutesLeft \ 2) + (MinutesLeft Mod 2)) Mod 60
                    LeaveByHours = Val(TextBox4.Text.Split(":")(0)) + (HoursLeft \ 2) + (HoursLeft Mod 2) _
                        + ((Val(TextBox4.Text.Split(":")(1)) + (MinutesLeft \ 2) + (MinutesLeft Mod 2)) \ 60)
                    TextBox9.Text = String.Format("{0:00}:{1:00}", LeaveByHours, LeaveByMinutes)
                    TextBox9.BackColor = Color.Yellow
                    Label13.Text = String.Format("{0:00}:{1:00}", LeaveByHours, LeaveByMinutes)
                ElseIf TextBox10.Text = "00:00" Then
                    If TextBox5.Text = "00:00" Then
                        TextBox5.Text = ShiftStart
                        TextBox5.BackColor = Color.Yellow
                    End If
                    LeaveByMinutes = (Val(TextBox5.Text.Split(":")(1)) + MinutesLeft) Mod 60
                    LeaveByHours = Val(TextBox5.Text.Split(":")(0)) + HoursLeft + ((Val(TextBox5.Text.Split(":")(1)) + MinutesLeft) \ 60)
                    TextBox10.Text = String.Format("{0:00}:{1:00}", LeaveByHours, LeaveByMinutes)
                    TextBox10.BackColor = Color.Yellow
                    Label13.Text = String.Format("{0:00}:{1:00}", LeaveByHours, LeaveByMinutes)
                End If
            Else
                HoursLeft = HoursTill - TotalHoursPerWeek
                MinutesLeft = MinutesTill
                Label12.Text = String.Format("+{0:00}:{1:00}", HoursLeft, MinutesLeft)
                Label12.ForeColor = Color.Green
                Label13.Text = "Now"
            End If
        End If


        'Dim TotalHoursPerWeek, HoursTill, HoursLeft, LeaveBy As Date

        'TotalHoursPerWeek = TotalHoursPerWeek.Add(TimeSpan.FromHours(45))
        'HoursTill = (TextBox6.Text - TextBox1.Text) + (TextBox7.Text - TextBox2.Text) + (TextBox8.Text - TextBox3.Text) + (TextBox9.Text - TextBox4.Text) + (TextBox10.Text - TextBox5.Text)
        'Label11.Text = HoursTill.ToString("hh:mm")
        'HoursLeft = TotalHoursPerWeek - HoursTill
        'Label12.Text = HoursLeft.ToString("hh:mm")
        'LeaveBy = TextBox5.Text + HoursLeft
        'Label13.Text = LeaveBy.ToString("hh:mm tt")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        IO.File.WriteAllText("C:\Users\Public\Documents\Data.txt", String.Join("|", New String() _
                 {TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text, TextBox9.Text, TextBox10.Text}))
        MsgBox("Saved successfully..!")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = "00:00"
        TextBox1.BackColor = Color.White
        TextBox2.Text = "00:00"
        TextBox2.BackColor = Color.White
        TextBox3.Text = "00:00"
        TextBox3.BackColor = Color.White
        TextBox4.Text = "00:00"
        TextBox4.BackColor = Color.White
        TextBox5.Text = "00:00"
        TextBox5.BackColor = Color.White
        TextBox6.Text = "00:00"
        TextBox6.BackColor = Color.White
        TextBox7.Text = "00:00"
        TextBox7.BackColor = Color.White
        TextBox8.Text = "00:00"
        TextBox8.BackColor = Color.White
        TextBox9.Text = "00:00"
        TextBox9.BackColor = Color.White
        TextBox10.Text = "00:00"
        TextBox10.BackColor = Color.White
        Label11.Text = "00:00"
        Label12.Text = "45:00"
        Label12.ForeColor = Color.Crimson
        Label13.Text = "18:00"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If IO.File.Exists("C:\Users\Public\Documents\Data.txt") Then
            Dim values() As String = IO.File.ReadAllText("C:\Users\Public\Documents\Data.txt").Split("|"c)
            TextBox1.Text = values(0)
            TextBox1.BackColor = Color.White
            TextBox2.Text = values(1)
            TextBox2.BackColor = Color.White
            TextBox3.Text = values(2)
            TextBox3.BackColor = Color.White
            TextBox4.Text = values(3)
            TextBox4.BackColor = Color.White
            TextBox5.Text = values(4)
            TextBox5.BackColor = Color.White
            TextBox6.Text = values(5)
            TextBox6.BackColor = Color.White
            TextBox7.Text = values(6)
            TextBox7.BackColor = Color.White
            TextBox8.Text = values(7)
            TextBox8.BackColor = Color.White
            TextBox9.Text = values(8)
            TextBox9.BackColor = Color.White
            TextBox10.Text = values(9)
            TextBox10.BackColor = Color.White
        Else
            MsgBox("Backup file not found..!")
        End If
    End Sub
End Class
