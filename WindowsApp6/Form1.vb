Imports MySql.Data.MySqlClient
Public Class Form1
    Dim con As New OleDb.OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0; Data Source= D:\ismae\Documents\equipos1.1.mdb")
    Dim con_web As New OleDb.OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0; Data Source= D:\ismae\Documents\equipos1.1.mdb")
    Dim com_web As New MySqlConnection("datasource=localhost;port=3306;username=ismael;password=1234")

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

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

        Dim cmd1_web As New OleDb.OleDbCommand
        Dim dr1_web As OleDb.OleDbDataReader


        Dim cmd2_web As New OleDb.OleDbCommand
        Dim dr2_web As OleDb.OleDbDataReader


        Dim cmd3_web As New OleDb.OleDbCommand
        Dim dr3_web As OleDb.OleDbDataReader


        Dim cmd4_web As New OleDb.OleDbCommand
        Dim dr4_web As OleDb.OleDbDataReader

        Dim cmd5_web As New OleDb.OleDbCommand
        Dim dr5_web As OleDb.OleDbDataReader


        Try
            con.Open()
            MsgBox("Conexión Exitosa con la base de datos", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            con_web.Open()
            MsgBox("Conexión Exitosa con la base de datos 2", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        'base de datos web



        Try
            con_web.Open()
            MsgBox("Conexión Exitosa con la base de datos", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        'Clientes_datos 

        cmd1.Connection = con
        cmd1.CommandType = CommandType.Text
        cmd1.CommandText = "SELECT Ges_Clientes.Codigo, Ges_Clientes.Nombre, Ges_Clientes.Nombre_Comercial, Ges_Clientes.Nif, Ges_Clientes.Direccion, Ges_Clientes.Poblacion, Ges_Clientes.Pais, Ges_Clientes.Email, Ges_Clientes.Telefono_1, Ges_Clientes.Telefono_2 FROM Ges_Clientes;"
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
            Direccion = dr1(4).ToString
            poblacion = dr1(5).ToString
            pais = dr1(6).ToString
            email = dr1(7).ToString
            telefono_1 = dr1(8).ToString
            telefono_2 = dr1(9).ToString

            'insericion de datos
            cmd1_web.Connection = con_web
            cmd1_web.CommandType = CommandType.Text
            cmd1_web.CommandText = "insert into mantenimiento(id_equipo,operacion,fecha_mantenimiento,M_Preventivo,M_correctivo,calibracion,estado,observaciones) values ('" & Codigo_cliente & "','" & Nombre & "','" & Nombre_comercial & "'," & Nif & "," & Direccion & "," & poblacion & ",'" & pais & "',' " & email & " ,'" & telefono_1 & "',' " & telefono_2 & "')"
            dr1_web = cmd1_web.ExecuteReader()

        End While

        'Recepcion muestras

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
        Dim Cliente_facturacion As Boolean
        Dim revision As Boolean
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
            revision = dr2(9).ToString
            fecha_revision = dr2(10).ToString


            'insericion de datos
            cmd2_web.Connection = con_web
            cmd2_web.CommandType = CommandType.Text
            cmd2_web.CommandText = "insert into mantenimiento(id_equipo,operacion,fecha_mantenimiento,M_Preventivo,M_correctivo,calibracion,estado,observaciones) values ('" & Muestra_Recepcion & "','" & Lote & "','" & Fecha_Recepcion & "'," & Referencia & "," & cliente & "," & quien & ",'" & prioridad & "',' " & observaciones & " ," & Cliente_facturacion & ",'" & revision & "',' " & fecha_revision & "')"
            dr2_web = cmd3_web.ExecuteReader()

        End While

        'Ensayos recepcion

        cmd3.Connection = con
        cmd3.CommandType = CommandType.Text
        cmd3.CommandText = "SELECT LMS_Ensayos_Recepcion.Muestra_Recepcion, LMS_Ensayos_Recepcion.Ensayo, LMS_Ensayos_Recepcion.Grupo_Ensayos FROM LMS_Ensayos_Recepcion;"
        dr3 = cmd3.ExecuteReader()



        Dim Muestra_Recepcion_1 As String
        Dim Ensayo As String
        Dim Grupo_Ensayos As String

        While dr3.Read()


            Muestra_Recepcion_1 = dr3(0).ToString
            Ensayo = dr3(1).ToString
            Grupo_Ensayos = dr3(2).ToString

            'insericion de datos
            cmd3_web.Connection = con_web
            cmd3_web.CommandType = CommandType.Text
            cmd3_web.CommandText = "insert into mantenimiento(id_equipo,operacion,fecha_mantenimiento,M_Preventivo,M_correctivo,calibracion,estado,observaciones) values ('" & selecionada_equipos & "','" & operacion & "','" & fecha_de_mantenimiento & "'," & t_M_Preventivo & "," & t_M_correctivo & "," & t_calibracion & ",'" & Estado & "',' " & obserbaciones & " ')"
            dr3_web = cmd3_web.ExecuteReader()

        End While

        'Ensayos

        cmd4.Connection = con
        cmd4.CommandType = CommandType.Text
        cmd4.CommandText = "SELECT MES_Ensayos.Ensayo, MES_Ensayos.Nombre, MES_Ensayos.Metodo_Analitico, MES_Ensayos.Limite_Superior_Acreditacion, MES_Ensayos.Limite_Inferior_Acreditacion, MES_Ensayos.PNT FROM MES_Ensayos;"
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

            'insericion de datos
            cmd4_web.Connection = con_web
            cmd4_web.CommandType = CommandType.Text
            cmd4_web.CommandText = "insert into mantenimiento(id_equipo,operacion,fecha_mantenimiento,M_Preventivo,M_correctivo,calibracion,estado,observaciones) values ('" & selecionada_equipos & "','" & operacion & "','" & fecha_de_mantenimiento & "'," & t_M_Preventivo & "," & t_M_correctivo & "," & t_calibracion & ",'" & Estado & "',' " & obserbaciones & " ')"
            dr4_web = cmd4_web.ExecuteReader()

        End While


        cmd5.Connection = con
        cmd5.CommandType = CommandType.Text
        cmd5.CommandText = "Select Case LMS_Determinacion.Muestra_Recepcion, LMS_Determinacion.Ensayo, LMS_Determinacion.Rdo_Bruto, LMS_Determinacion.Atributo_Rdo, LMS_Determinacion.Rdo_Final From LMS_Determinacion;"
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
            Rdo_Final = dr5(3).ToString
            Atributo_Rdoo = dr5(4).ToString


            'insericion de datos
            cmd5_web.Connection = con_web
            cmd5_web.CommandType = CommandType.Text
            cmd5_web.CommandText = "insert into mantenimiento(id_equipo,operacion,fecha_mantenimiento,M_Preventivo,M_correctivo,calibracion,estado,observaciones) values ('" & selecionada_equipos & "','" & operacion & "','" & fecha_de_mantenimiento & "'," & t_M_Preventivo & "," & t_M_correctivo & "," & t_calibracion & ",'" & Estado & "',' " & obserbaciones & " ')"
            dr5_web = cmd5_web.ExecuteReader()

        End While

    End Sub

    Private Sub BindingSource2_CurrentChanged(sender As Object, e As EventArgs) Handles BindingSource2.CurrentChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            con_web.Open()
            MsgBox("Conexión Exitosa con la base de datos", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
