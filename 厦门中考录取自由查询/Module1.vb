Module Module1

    Sub Main()
        Console.WriteLine("厦门中考录取自由查询工具")
        Console.WriteLine("https://github.com/cyyself/xmzk")
        Console.WriteLine("https://cyyself.name/2015/08/xmzk/" & vbCrLf)
        Console.WriteLine("请输入报名号：（可打开中考志愿填报工具.exe中的SQ Lite文件查询）")
        Dim bmh As String = Console.ReadLine()
        Console.WriteLine("请输入准考证号前6位：（根据考试学校决定）")
        Dim zkz6 As String = Console.ReadLine()
        If zkz6.Length = 6 Then
        Else
            MsgBox("准考证号不合法")
            Console.Clear()
            Main()
            End
        End If
        Console.WriteLine("请输入该考生考试学校的考场数量：")
        Dim kc As String = Console.ReadLine()
        Console.WriteLine("请输入该考生考场的座位数量：")
        Dim zw As String = Console.ReadLine()
        Try
            Int(bmh)
            Int(zkz6)
            Int(kc)
            Int(zy)
        Catch ex As Exception
            MsgBox("存在不合法输入，请重新输入")
            Console.Clear()
            Main()
            End
        End Try
        For i = 1 To Int(kc)
            For i2 = 1 To Int(zw)
                Dim number As String
                Dim data As String
                Dim s As Boolean = False
                If i < 10 Then
                    number = "0" & i
                Else
                    number = i
                End If
                If i2 < 10 Then
                    number &= "0" & i2
                Else
                    number &= i2
                End If
                Try
                    data = http.HttpPost("http://www.xmzskszx.net/pub/lqcx.aspx", "ScriptManager1=ScriptManager1%7CBtn&__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=%2FwEPDwUKMTUxMTIyOTQ5N2RkLtRJMl87ErmEQn8ufkyZ%2F5eCfZ%2FFOoAVW44RZcgSE6o%3D&__VIEWSTATEGENERATOR=D6AFB629&__EVENTVALIDATION=%2FwEWBAKc7fjjAwLDgoO0AQLBgpu%2FAgKyoqqWD8MCaPYdf9%2BluHxgfGAxjMhvr7usgQvwPFx7eLx%2BApMS&TxtBMH=" & bmh & "&TxtZKZ=" & zkz6 & number & "&__ASYNCPOST=true&Btn=%20%20%E7%A1%AE%20%E5%AE%9A%20%20")
                Catch ex As Exception
                    Console.WriteLine("已查询准考证号：" & zkz6 & number & "失败")
                    s = True
                End Try
                If s Then
                Else
                    If data.Contains("无录取信息。") Then
                        Console.WriteLine("已查询准考证号：" & zkz6 & number & "无录取信息。")
                    Else

                        MsgBox("准考证号：" & zkz6 & number & vbCrLf & data)
                        End
                    End If
                End If
            Next
        Next
        Console.WriteLine("已遍历，无结果，请检查输入信息是否正确。")
        Console.ReadKey()
    End Sub

End Module
