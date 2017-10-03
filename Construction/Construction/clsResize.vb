Public Class clsResize
    Private Shared l_sin_OrigFactorX As Single, _
                       l_sin_OrigFactorY As Single
    Private Shared l_sin_FontFactor As Single


    Public Shared Function Get_Column_Size(ByVal i_OrigSize As Integer) As String
        Try
            Dim Screens() As System.Windows.Forms.Screen = _
                    System.Windows.Forms.Screen.AllScreens

            Dim l_sin_OrigFactorX As Single
            Dim i_Xpixels As Integer
            Dim i_DesignX As Integer = 1152

            i_Xpixels = Screens(0).Bounds.Width ' Set up the screen values
            l_sin_OrigFactorX = (i_Xpixels / i_DesignX) ' Determine scaling factors

            Get_Column_Size = (i_OrigSize * l_sin_OrigFactorX).ToString

        Catch e As Exception
            Get_Column_Size = 0
            'Call clsPublic.Error_Handler(Reflection.MethodInfo.GetCurrentMethod.Name, e.ToString)
        End Try

    End Function

    Public Shared Sub Change_Resolution(ByVal def_MyForm As Form, ByVal b_ResizeForm As Boolean)
        Try
            Dim Screens() As System.Windows.Forms.Screen = _
                    System.Windows.Forms.Screen.AllScreens

            If Not (Screens(0).Bounds.Height = 766) And Not (Screens(0).Bounds.Width = 1152) Then
                Dim i_Xpixels As Integer, _
                    i_Ypixels As Integer 'For Screen Resolution

                Dim i_DesignX As Integer = 1152, _
                    i_DesignY As Integer = 766

                ' Set up the screen values
                i_Ypixels = Screens(0).Bounds.Height
                i_Xpixels = Screens(0).Bounds.Width

                ' Determine scaling factors

                l_sin_OrigFactorX = (i_Xpixels / i_DesignX) + 0.001 'Added for better ratio
                l_sin_OrigFactorY = (i_Ypixels / i_DesignY) + 0.05 'Added to make the screen fill out better
                l_sin_FontFactor = ((l_sin_OrigFactorX + (i_Ypixels / i_DesignY)) / 2) * 1.1
                If b_ResizeForm = True Then
                    def_MyForm.Width = def_MyForm.Width * (i_Xpixels / i_DesignX)
                    def_MyForm.Height = def_MyForm.Height * (i_Ypixels / i_DesignY)
                    def_MyForm.Left = (Screens(0).Bounds.Width - def_MyForm.Width) / 2
                    def_MyForm.Top = (Screens(0).Bounds.Height - def_MyForm.Height) / 2
                End If

                Call Resize_For_Resolution(def_MyForm)
            End If

        Catch e As Exception
            'Call clsPublic.Error_Handler(Reflection.MethodInfo.GetCurrentMethod.Name, e.ToString)
        End Try
    End Sub

    Public Shared Sub Resize_Encapsulations(ByVal cc_Controls As Control)
        Try

            Dim i_Encaps As Integer

            With cc_Controls
                For i_Encaps = 0 To cc_Controls.Controls.Count - 1
                    If TypeOf .Controls(i_Encaps) Is ComboBox Then ' cannot change Height
                        .Controls(i_Encaps).Left = .Controls(i_Encaps).Left * l_sin_OrigFactorX
                        .Controls(i_Encaps).Top = .Controls(i_Encaps).Top * l_sin_OrigFactorY
                        .Controls(i_Encaps).Width = .Controls(i_Encaps).Width * l_sin_OrigFactorX

                    ElseIf TypeOf .Controls(i_Encaps) Is Panel Then
                        .Controls(i_Encaps).Left = .Controls(i_Encaps).Left * l_sin_OrigFactorX
                        .Controls(i_Encaps).Top = .Controls(i_Encaps).Top * l_sin_OrigFactorY
                        .Controls(i_Encaps).Width = .Controls(i_Encaps).Width * l_sin_OrigFactorX
                        .Controls(i_Encaps).Height = .Controls(i_Encaps).Height * l_sin_OrigFactorY

                        Call Resize_Encapsulations(.Controls(i_Encaps))

                        'ElseIf TypeOf .Controls(i_Encaps) Is Infragistics.Win.UltraWinTabControl.UltraTabPageControl Then
                        '    .Controls(i_Encaps).Left = .Controls(i_Encaps).Left * l_sin_OrigFactorX
                        '    .Controls(i_Encaps).Top = .Controls(i_Encaps).Top * l_sin_OrigFactorY
                        '    .Controls(i_Encaps).Width = .Controls(i_Encaps).Width * l_sin_OrigFactorX
                        '    .Controls(i_Encaps).Height = .Controls(i_Encaps).Height * l_sin_OrigFactorY

                        '    Call Resize_Encapsulations(.Controls(i_Encaps))

                    ElseIf TypeOf .Controls(i_Encaps) Is GroupBox Then
                        .Controls(i_Encaps).Left = .Controls(i_Encaps).Left * l_sin_OrigFactorX
                        .Controls(i_Encaps).Top = .Controls(i_Encaps).Top * l_sin_OrigFactorY
                        .Controls(i_Encaps).Width = .Controls(i_Encaps).Width * l_sin_OrigFactorX
                        .Controls(i_Encaps).Height = .Controls(i_Encaps).Height * l_sin_OrigFactorY

                        Call Resize_Encapsulations(.Controls(i_Encaps))


                    Else
                        .Controls(i_Encaps).Left = .Controls(i_Encaps).Left * l_sin_OrigFactorX
                        .Controls(i_Encaps).Top = .Controls(i_Encaps).Top * l_sin_OrigFactorY
                        .Controls(i_Encaps).Width = .Controls(i_Encaps).Width * l_sin_OrigFactorX
                        .Controls(i_Encaps).Height = .Controls(i_Encaps).Height * l_sin_OrigFactorY
                    End If

                    .Controls(i_Encaps).Font = New Font(.Controls(i_Encaps).Font.Name, .Controls(i_Encaps).Font.Size * l_sin_FontFactor)
                Next i_Encaps
            End With

        Catch e As Exception
            'Call clsPublic.Error_Handler(Reflection.MethodInfo.GetCurrentMethod.Name, e.ToString)
        End Try
    End Sub

    Public Shared Sub Resize_For_Resolution(ByVal def_MyForm As Form)
        Try

            Dim i_i As Integer ',i_Grouboxes As Integer
            Dim sin_SFFont As Single

            sin_SFFont = (l_sin_OrigFactorX + l_sin_OrigFactorY) / 2 ' average scale

            ' Size the Controls for the new resolution
            'On Error Resume Next ' for read-only or nonexistent properties

            With def_MyForm
                For i_i = 0 To .Controls.Count - 1
                    If TypeOf .Controls(i_i) Is ComboBox Then ' cannot change Height
                        .Controls(i_i).Left = .Controls(i_i).Left * l_sin_OrigFactorX
                        .Controls(i_i).Top = .Controls(i_i).Top * l_sin_OrigFactorY
                        .Controls(i_i).Width = .Controls(i_i).Width * l_sin_OrigFactorX

                    ElseIf TypeOf .Controls(i_i) Is Panel Then
                        .Controls(i_i).Left = .Controls(i_i).Left * l_sin_OrigFactorX
                        .Controls(i_i).Top = .Controls(i_i).Top * l_sin_OrigFactorY
                        .Controls(i_i).Width = .Controls(i_i).Width * l_sin_OrigFactorX
                        .Controls(i_i).Height = .Controls(i_i).Height * l_sin_OrigFactorY

                        Call Resize_Encapsulations(.Controls(i_i))
                        'ElseIf TypeOf .Controls(i_i) Is Infragistics.Win.UltraWinTabControl.UltraTabControl Then
                        '    .Controls(i_i).Left = .Controls(i_i).Left * l_sin_OrigFactorX
                        '    .Controls(i_i).Top = .Controls(i_i).Top * l_sin_OrigFactorY
                        '    .Controls(i_i).Width = .Controls(i_i).Width * l_sin_OrigFactorX
                        '    .Controls(i_i).Height = .Controls(i_i).Height * l_sin_OrigFactorY

                        '    Call Resize_Encapsulations(.Controls(i_i))

                    ElseIf TypeOf .Controls(i_i) Is GroupBox Then
                        .Controls(i_i).Left = .Controls(i_i).Left * l_sin_OrigFactorX
                        .Controls(i_i).Top = .Controls(i_i).Top * l_sin_OrigFactorY
                        .Controls(i_i).Width = .Controls(i_i).Width * l_sin_OrigFactorX
                        .Controls(i_i).Height = .Controls(i_i).Height * l_sin_OrigFactorY

                        Call Resize_Encapsulations(.Controls(i_i))

                    ElseIf TypeOf .Controls(i_i) Is ListView Then
                        .Controls(i_i).Left = .Controls(i_i).Left * l_sin_OrigFactorX
                        .Controls(i_i).Top = .Controls(i_i).Top * l_sin_OrigFactorY
                        .Controls(i_i).Width = .Controls(i_i).Width * l_sin_OrigFactorX
                        .Controls(i_i).Height = .Controls(i_i).Height * l_sin_OrigFactorY

                        Call resizeListViewwidth(.Controls(i_i))


                    Else
                        .Controls(i_i).Left = .Controls(i_i).Left * l_sin_OrigFactorX
                        .Controls(i_i).Top = .Controls(i_i).Top * l_sin_OrigFactorY
                        .Controls(i_i).Width = .Controls(i_i).Width * l_sin_OrigFactorX
                        .Controls(i_i).Height = .Controls(i_i).Height * l_sin_OrigFactorY
                    End If

                    .Controls(i_i).Font = New Font(.Controls(i_i).Font.Name, .Controls(i_i).Font.Size * l_sin_FontFactor)
                Next i_i
            End With

        Catch e As Exception
            'Call clsPublic.Error_Handler(Reflection.MethodInfo.GetCurrentMethod.Name, e.ToString)
        End Try
    End Sub

    Public Shared Sub resizeListViewwidth(ByVal PatiView As System.Windows.Forms.ListView)
        Try
            Dim Screens() As System.Windows.Forms.Screen = _
                    System.Windows.Forms.Screen.AllScreens

            If Not (Screens(0).Bounds.Height = 766) And Not (Screens(0).Bounds.Width = 1152) Then
                Dim i_Xpixels As Integer, _
                    i_Ypixels As Integer 'For Screen Resolution

                Dim i_DesignX As Integer = 1152, _
                    i_DesignY As Integer = 766

                ' Set up the screen values
                i_Ypixels = Screens(0).Bounds.Height
                i_Xpixels = Screens(0).Bounds.Width

                ' Determine scaling factors

                l_sin_OrigFactorX = (i_Xpixels / i_DesignX) + 0.001 'Added for better ratio
                For col = 0 To PatiView.Columns.Count Step 1
                    PatiView.Columns.Item(col).Width = PatiView.Columns.Item(col).Width * l_sin_OrigFactorX
                Next
            End If
        Catch e As Exception
            'Call clsPublic.Error_Handler(Reflection.MethodInfo.GetCurrentMethod.Name, e.ToString)
        End Try

    End Sub


End Class
