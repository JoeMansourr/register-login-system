Imports System.Data.SqlClient

Public Class Register
    Inherits System.Web.UI.Page

    Dim sqlConnection As New SqlConnection("Server = JOE; Database = firstProject; Integrated Security = true")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub signup_Click(sender As Object, e As EventArgs) Handles signup.Click
        sqlConnection.Open()
        Dim sqlCommand As New SqlCommand("SELECT * FROM userCredentials where userName = @userName and userEmail = @userEmail and userPassword = @userPassword", sqlConnection)
        sqlCommand.Parameters.Add("@userName", SqlDbType.VarChar).Value = username.Text
        sqlCommand.Parameters.Add("@userEmail", SqlDbType.VarChar).Value = email.Text
        sqlCommand.Parameters.Add("@userPassword", SqlDbType.VarChar).Value = password.Text
        Dim adapter As New SqlDataAdapter(sqlCommand)
        Dim table As New DataTable()
        adapter.Fill(table)
        sqlConnection.Close()

        If (table.Rows.Count > 0) Then
            status.Text = "<br />User Already Exists!"
            status.CssClass = "red"

        ElseIf email.Text <> String.Empty Then
            checkEmail()

        Else
            sqlConnection.Open()
            Dim sqlCmd As New SqlCommand("INSERT INTO userCredentials VALUES(@userName, @userEmail, @userPassword)", sqlConnection)
            sqlCmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = username.Text
            sqlCmd.Parameters.Add("@userEmail", SqlDbType.VarChar).Value = email.Text
            sqlCmd.Parameters.Add("@userPassword", SqlDbType.VarChar).Value = password.Text
            sqlCmd.ExecuteNonQuery()
            sqlConnection.Close()
            status.Text = "<br />User Created Proceed to Login"
            status.Attributes.Remove("red")
            status.CssClass = "green"
        End If
    End Sub

    Private Sub checkEmail()
        sqlConnection.Open()
        Dim cmd As New SqlCommand("SELECT userEmail from userCredentials where userEmail = @userEmail", sqlConnection)
        cmd.Parameters.Add("@userEmail", SqlDbType.VarChar).Value = email.Text
        Dim ad As New SqlDataAdapter(cmd)
        Dim tbl As New DataTable()
        ad.Fill(tbl)
        sqlConnection.Close()
        If tbl.Rows.Count > 0 Then
            status.Text = "<br />User Already Exists"
            status.CssClass = "red"

        ElseIf (password.Text.Length < 6) Then
            status.Text = "<br />Password must contain at least 6 Characters"
            status.CssClass = "red"

        Else
            sqlConnection.Open()
            Dim sqlCmd As New SqlCommand("INSERT INTO userCredentials VALUES(@userName, @userEmail, @userPassword)", sqlConnection)
            sqlCmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = username.Text
            sqlCmd.Parameters.Add("@userEmail", SqlDbType.VarChar).Value = email.Text
            sqlCmd.Parameters.Add("@userPassword", SqlDbType.VarChar).Value = password.Text
            sqlCmd.ExecuteNonQuery()
            sqlConnection.Close()
            status.Text = "<br />User Created Proceed to Login"
            status.Attributes.Remove("red")
            status.CssClass = "green"
        End If
    End Sub

End Class