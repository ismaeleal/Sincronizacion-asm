﻿


Imports MySql.Data.MySqlClient
Public Class Form1
    Dim con As New OleDb.OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0; Data Source= C:\Users\ismae\Desktop\Database1.mdb")

    Dim con_web As New MySqlConnection("datasource=192.168.49.135;Database=asm;port=3306;username=ismael;password=1234")

    Dim contador As Integer = 0


    Private Sub sincronizacion()


        Dim cmd1 As New OleDb.OleDbCommand
        Dim dr1 As OleDb.OleDbDataReader


        Dim cmd2 As New OleDb.OleDbCommand
        Dim dr2 As OleDb.OleDbDataReader


        Dim cmd3 As New OleDb.OleDbCommand
        Dim dr3 As OleDb.OleDbDataReader


        Dim cmd4 As New OleDb.OleDbCommand
        Dim dr4 As OleDb.OleDbDataReader

        Dim cmd5 As New OleDb.OleDbCommand
        Dim dr5 As OleDb.OleDbDataReader

        Dim cmd1_web As New MySqlCommand
        Dim dr1_web As MySqlDataReader


        Dim cmd2_web As New MySqlCommand
        Dim dr2_web As MySqlDataReader


        Dim cmd3_web As New MySqlCommand
        Dim dr3_web As MySqlDataReader


        Dim cmd4_web As New MySqlCommand
        Dim dr4_web As MySqlDataReader

        Dim cmd5_web As MySqlCommand
        Dim dr5_web As MySqlDataReader


        Dim cmd1_web1 As New MySqlCommand
        Dim dr1_web1 As MySqlDataReader


        Dim cmd2_web1 As New MySqlCommand
        Dim dr2_web1 As MySqlDataReader


        Dim cmd3_web1 As New MySqlCommand
        Dim dr3_web1 As MySqlDataReader


        Dim cmd4_web1 As New MySqlCommand
        Dim dr4_web1 As MySqlDataReader

        Dim cmd5_web1 As MySqlCommand
        Dim dr5_web1 As MySqlDataReader

        Dim cmd0_web As MySqlCommand
        Dim dr0_web As MySqlDataReader
        Dim datos(5) As Integer


        cmd0_web = New MySqlCommand("SELECT dato FROM datos_sincronizacion")
        cmd0_web.Connection = con_web

        dr0_web = cmd0_web.ExecuteReader()

        Dim i As Integer = 0

        While dr0_web.Read()

            datos(i) = dr0_web(0).ToString
            i = i + 1
        End While
        dr0_web.Close()
        Dim Cliente_datos As Integer = datos(0)
        Dim Recepcion_muestras As String = datos(1)
        Dim Ensayos_recepcion As String = datos(2)
        Dim Ensayos As String = datos(3)
        Dim Determinacion As String = datos(4)

        'Clientes_datos ////////////////////////////////////////////////////////////////////////////////////

        cmd1.Connection = con
        cmd1.CommandType = CommandType.Text
        cmd1.CommandText = "SELECT Codigo, Nombre, Nombre_Comercial,Nif, Direccion, Poblacion, Pais, Email, Telefono_1, Telefono_2 FROM Ges_Clientes"
        dr1 = cmd1.ExecuteReader()

        Dim Codigo_cliente As String
        Dim Nombre As String
        Dim Nombre_comercial As String
        Dim Nif As String
        Dim Direccion As String
        Dim poblacion As String
        Dim pais As String
        Dim email As String
        Dim telefono_1 As String
        Dim telefono_2 As String

        While dr1.Read()
            Codigo_cliente = dr1(0).ToString
            Nombre = dr1(1).ToString
            Nombre_comercial = dr1(2).ToString
            Nif = dr1(3).ToString
            Direccion = Replace(dr1(4).ToString(), "'", ";")
            poblacion = dr1(5).ToString()
            dr1(5).ToString()
            pais = dr1(6).ToString
            email = dr1(7).ToString
            telefono_1 = dr1(8).ToString
            telefono_2 = dr1(9).ToString

            If Codigo_cliente < Cliente_datos Then
                'insericion de datos


                cmd1_web.Connection = con_web
                cmd1_web.CommandType = CommandType.Text
                cmd1_web.CommandText = "update into DatosUsuario(uuid,nombre,nombre_comercial,nif,direccion,poblacion,pais,email,telefono_1,telefono_2) values ('" & Codigo_cliente & "','" & Nombre & "','" & Nombre_comercial & "'," & Nif & "," & Direccion & "," & poblacion & ",'" & pais & "',' " & email & " ,'" & telefono_1 & "',' " & telefono_2 & "')"
                dr1_web = cmd1_web.ExecuteReader()
            Else

                'insericion de datos
                cmd1_web1 = New MySqlCommand("insert into datos_usuario(uuid,nombre,nonmbre_comercial,nif,direccion,poblacion,pais,email,telefono_1,telefono_2) values (" & Codigo_cliente & ",'" & Nombre & "','" & Nombre_comercial & "','" & Nif & "','" & Direccion & "','" & poblacion & "','" & pais & "',' " & email & " ','" & telefono_1 & "',' " & telefono_2 & "')")
                cmd1_web1.Connection = con_web


                dr1_web1 = cmd1_web1.ExecuteReader()
                dr1_web1.Close()
            End If
        End While
        Label13.Text = Codigo_cliente

        'Recepcion muestras//////////////////////////////////////////////////////////////////////////////////////////////////////
        cmd2.Connection = con
        cmd2.CommandType = CommandType.Text
        cmd2.CommandText = "SELECT LMS_Recepcion.Muestra_Recepcion, LMS_Recepcion.Lote, LMS_Recepcion.Fecha_Recepcion, LMS_Recepcion.Referencia, LMS_Recepcion.Cliente, LMS_Recepcion.Quien_Trae_Muestra, LMS_Recepcion.Prioridad, LMS_Recepcion.Observaciones, LMS_Recepcion.ClienteFacturacion, LMS_Recepcion.Revision, LMS_Recepcion.Fecha_Revision FROM LMS_Recepcion;"
        dr2 = cmd2.ExecuteReader()


        Dim Muestra_Recepcion As String
        Dim Lote As String
        Dim Fecha_Recepcion As String
        Dim Referencia As String
        Dim cliente As String
        Dim quien As String
        Dim prioridad As String
        Dim observaciones As String
        Dim Cliente_facturacion As String

        Dim revision As String

        Dim fecha_revision As String

        While dr2.Read()


            Muestra_Recepcion = dr2(0).ToString
            Lote = dr2(1).ToString
            Fecha_Recepcion = dr2(2).ToString
            Referencia = dr2(3).ToString
            cliente = dr2(4).ToString
            quien = dr2(5).ToString
            prioridad = dr2(6).ToString
            observaciones = dr2(7).ToString
            Cliente_facturacion = dr2(8).ToString
            If dr2(9).ToString = "00002" Then
                revision = "SI"
            Else
                revision = "NO"
            End If

            fecha_revision = dr2(10).ToString


            If False Then


            Else
                cmd2_web1 = New MySqlCommand("insert into recepcion_muestras(Muestras_recepcion,Lote,Fecha_recepcion,Referencia,Cliente,Quien_trae,Prioridad,Observaciones,Cliente_facturacion,Revision,Fecha_Revision) values (" & Muestra_Recepcion & ",'" & Lote & "','" & Fecha_Recepcion & "','" & Referencia & "','" & cliente & "','" & quien & "','" & prioridad & "',' " & observaciones & "' ,'" & Cliente_facturacion & "','" & revision & "',' " & fecha_revision & "')")
                cmd2_web1.Connection = con_web


                dr2_web1 = cmd2_web1.ExecuteReader()
                dr2_web1.Close()

            End If
            'insericion de datos

        End While
        Label14.Text = Muestra_Recepcion

        '//////////////////////////////////////////////////Ensayos recepcion ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        cmd3.Connection = con
        cmd3.CommandType = CommandType.Text
        cmd3.CommandText = "SELECT LMS_Ensayos_Recepcion.Muestra_Recepcion, LMS_Ensayos_Recepcion.Ensayo, LMS_Ensayos_Recepcion.Grupo_Ensayos FROM LMS_Ensayos_Recepcion "
        dr3 = cmd3.ExecuteReader()

        Dim Muestra_Recepcion_1 As String
        Dim Ensayo As String
        Dim Grupo_Ensayos As String

        While dr3.Read()
            Muestra_Recepcion_1 = dr3(0).ToString
            Ensayo = dr3(1).ToString
            Grupo_Ensayos = dr3(2).ToString

            If False Then

            Else


                cmd3_web1 = New MySqlCommand("insert into ensayos_recepcion(mustras_recepcion,ensayo,grupo_ensayos) values ('" & Muestra_Recepcion_1 & "','" & Ensayo & "','" & Grupo_Ensayos & "')")
                cmd3_web1.Connection = con_web


                dr3_web1 = cmd3_web1.ExecuteReader()
                dr3_web1.Close()

            End If
            'insericion de datos


        End While
        Label15.Text = Muestra_Recepcion_1
        '////////////////////////////////////////////////Ensayos//////////////////////////////////////////////////////////////////////////

        cmd4.Connection = con
        cmd4.CommandType = CommandType.Text
        cmd4.CommandText = "SELECT MES_Ensayos.Ensayo, MES_Ensayos.Nombre, MES_Ensayos.Metodo_Analitico, MES_Ensayos.Limite_Superior_Acreditacion, MES_Ensayos.Limite_Inferior_Acreditacion, MES_Ensayos.PNT FROM MES_Ensayos "
        dr4 = cmd4.ExecuteReader()

        Dim Ensayo_1 As String
        Dim Nombre_1 As String
        Dim Metodo_Analitico As String
        Dim Limite_Superior_Acreditacion As String
        Dim Limite_Inferior_Acreditacion As String
        Dim PNT As String

        While dr4.Read()


            Ensayo_1 = dr4(0).ToString
            Nombre_1 = dr4(1).ToString
            Metodo_Analitico = dr4(2).ToString
            Limite_Superior_Acreditacion = dr4(3).ToString
            Limite_Inferior_Acreditacion = dr4(4).ToString
            PNT = dr4(5).ToString




            If Ensayo_1 > Ensayos Then
                'insericion de datos


                cmd4_web = New MySqlCommand("insert into ensayo(ensayo,nombre,metodo_analitico,limite_superior,limite_inferior,pnt) values ('" & Ensayo_1 & "','" & Nombre_1 & "','" & Metodo_Analitico & "','" & Limite_Superior_Acreditacion & "','" & Limite_Inferior_Acreditacion & "','" & PNT & "')")
                cmd4_web.Connection = con_web


                dr4_web = cmd4_web.ExecuteReader()
                dr4_web.Close()
            End If

        End While
        Label16.Text = Ensayo_1
        Ensayos = Ensayo_1

        cmd5.Connection = con
        cmd5.CommandType = CommandType.Text
        cmd5.CommandText = "Select  LMS_Determinacion.Muestra_Recepcion, LMS_Determinacion.Ensayo, LMS_Determinacion.Rdo_Bruto, LMS_Determinacion.Atributo_Rdo, LMS_Determinacion.Rdo_Final From LMS_Determinacion;"
        dr5 = cmd5.ExecuteReader()

        Dim Muestra_Recepcion_2 As String
        Dim Ensayo_2 As String
        Dim Rdo_Bruto As String
        Dim Rdo_Final As String
        Dim Atributo_Rdoo As String

        While dr5.Read()

            Muestra_Recepcion_2 = dr5(0).ToString
            Ensayo_2 = dr5(1).ToString
            Rdo_Bruto = dr5(2).ToString
            Rdo_Final = dr5(4).ToString
            Atributo_Rdoo = dr5(3).ToString


            'insericion de datos
            If Determinacion < Muestra_Recepcion_2 Then

                cmd5_web = New MySqlCommand("update ensayos_recepcion SET resultado = '" & Rdo_Final & "' WHERE mustras_recepcion ='" & Muestra_Recepcion_2 & "' and ensayo ='" & Ensayo_2 & "' ")
                cmd5_web.Connection = con_web


                dr5_web = cmd5_web.ExecuteReader()
                dr5_web.Close()
            End If
        End While

        Label17.Text = Muestra_Recepcion_2
        Determinacion = Muestra_Recepcion_2

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        sincronizacion()


    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Try
            con.Open()
            MsgBox("Conexión Exitosa con la base de datos", MsgBoxStyle.Information)
            Label3.Text = "conectado"

        Catch ex As Exception
            MsgBox(ex.ToString)
            Label3.Text = "error"
        End Try

        Try
            con_web.Open()
            MsgBox("Conexión Exitosa con la base de datos 2", MsgBoxStyle.Information)
            Label4.Text = "conectado"

        Catch ex As Exception
            MsgBox(ex.ToString)
            Label4.Text = "error"
        End Try

        If Label3.Text = "conectado" And Label4.Text = "conectado" Then

            Timer1.Enabled = True
            Label1.Text = "CONECTADO"
            Button4.Enabled = True
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            con.Open()
            MsgBox("Conexión Exitosa con la base de datos", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.ToString)
            con.Close()
        End Try

        con.Close()
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            con_web.Open()
            MsgBox("Conexión Exitosa con la base de datos 2", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.ToString)
            con_web.Close()
        End Try
        con_web.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        contador = contador + 1
        Label18.Text = "'" & contador & "'"
        If contador = Convert.ToInt16(ComboBox1.Text) Then

            sincronizacion()
            contador = 0
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = False
        Label1.Text = "DESCONECTADO"
        ComboBox1.SelectedIndex = ComboBox1.FindString("60")
        Button4.Enabled = False
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class
