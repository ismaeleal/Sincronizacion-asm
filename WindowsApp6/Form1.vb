Public Class Form1
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles ASM.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click


        Dim con As New OleDb.OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0; Data Source= D:\ismae\Documents\equipos1.1.mdb")

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


        'base de datos asm
        Try
            con.Open()
            MsgBox("Conexión Exitosa con la base de datos", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        'base de datos web

        Public conweb As New OleDb.OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0; Data Source= D:\ismae\Documents\equipos1.1.mdb")

        Try
            conweb.Open()
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



        'Ensayos recepcion

        cmd3.Connection = con
        cmd3.CommandType = CommandType.Text
        cmd3.CommandText = "SELECT LMS_Ensayos_Recepcion.Muestra_Recepcion, LMS_Ensayos_Recepcion.Ensayo, LMS_Ensayos_Recepcion.Grupo_Ensayos FROM LMS_Ensayos_Recepcion;"
        dr3 = cmd3.ExecuteReader()



        Dim Codigo As String = selecionada_equipos
        Dim Denominacion As String
        Dim Marca As String
        Dim Modelo As String
        Dim Estado As String
        Dim Especificacion As String
        Dim Serie As String
        Dim software As String
        Dim mantenimiento_calibracion As Boolean
        Dim mantenimiento As Boolean
        Dim ubicacion As String
        Dim caracteristicas As String
        Dim observaciones As String
        Dim fecha_alta As String
        Dim fecha_baja As String
        'Ensayos

        cmd4.Connection = con
        cmd4.CommandType = CommandType.Text
        cmd4.CommandText = "SELECT MES_Ensayos.Ensayo, MES_Ensayos.Nombre, MES_Ensayos.Metodo_Analitico, MES_Ensayos.Limite_Superior_Acreditacion, MES_Ensayos.Limite_Inferior_Acreditacion, MES_Ensayos.PNT FROM MES_Ensayos;"
        dr4 = cmd4.ExecuteReader()

        Dim Codigo As String = selecionada_equipos
        Dim Denominacion As String
        Dim Marca As String
        Dim Modelo As String
        Dim Estado As String
        Dim Especificacion As String
        Dim Serie As String
        Dim software As String
        Dim mantenimiento_calibracion As Boolean
        Dim mantenimiento As Boolean
        Dim ubicacion As String
        Dim caracteristicas As String
        Dim observaciones As String
        Dim fecha_alta As String
        Dim fecha_baja As String



        cmd5.Connection = con
        cmd5.CommandType = CommandType.Text
        cmd5.CommandText = "Select Case LMS_Determinacion.Muestra_Recepcion, LMS_Determinacion.Ensayo, LMS_Determinacion.Rdo_Bruto, LMS_Determinacion.Atributo_Rdo, LMS_Determinacion.Rdo_Final From LMS_Determinacion;"
        dr5 = cmd5.ExecuteReader()

        Dim Codigo As String = selecionada_equipos
        Dim Denominacion As String
        Dim Marca As String
        Dim Modelo As String
        Dim Estado As String
        Dim Especificacion As String
        Dim Serie As String
        Dim software As String
        Dim mantenimiento_calibracion As Boolean
        Dim mantenimiento As Boolean
        Dim ubicacion As String
        Dim caracteristicas As String
        Dim observaciones As String
        Dim fecha_alta As String
        Dim fecha_baja As String


    End Sub

   