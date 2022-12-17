Imports System.Data.SqlClient
Public Class Login
    Inherits System.Web.UI.Page

    Dim sqlConnection As New SqlConnection("Server = JOE; Database = firstProject; Integrated Security = true")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub signup_Click(sender As Object, e As EventArgs) Handles signup.Click
        sqlConnection.Open()
        Dim sqlCmd As New SqlCommand("SELECT * FROM userCredentials WHERE (userName = @userName or userEmail = @userEmail) and userPassword = @userPassword", sqlConnection)
        sqlCmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = username.Text
        sqlCmd.Parameters.Add("@userEmail", SqlDbType.VarChar).Value = email.Text
        sqlCmd.Parameters.Add("@userPassword", SqlDbType.VarChar).Value = password.Text
        Dim adapter As New SqlDataAdapter(sqlCmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        sqlConnection.Close()

        If table.Rows.Count > 0 Then
            status.Text = "<br />Welcome, " & username.Text
            status.Attributes.Remove("red")
            status.CssClass = "green"
            System.Threading.Thread.Sleep(1500)
            Response.Redirect("Dashboard.aspx")

        ElseIf username.Text <> String.Empty Then
            isAccountCreated()

        ElseIf email.Text <> String.Empty Then
            isAccountCreated()
        End If


    End Sub

    Private Sub isAccountCreated()
        sqlConnection.Open()
        Dim sqlCmd As New SqlCommand("SELECT * FROM userCredentials WHERE (userName = @userName or userEmail = @userEmail) and userPassword = @userPassword", sqlConnection)
        sqlCmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = username.Text
        sqlCmd.Parameters.Add("@userEmail", SqlDbType.VarChar).Value = username.Text
        sqlCmd.Parameters.Add("@userPassword", SqlDbType.VarChar).Value = password.Text
        Dim adapter As New SqlDataAdapter(sqlCmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        sqlConnection.Close()

        If table.Rows.Count > 0 Then
            status.Text = "<br />Welcome, " & username.Text
            status.Attributes.Remove("red")
            status.CssClass = "green"
            System.Threading.Thread.Sleep(1500)
            Response.Redirect("https://google.com")

        Else
            status.Text = "<br />Wrong Credentials"
            status.CssClass = "red"
        End If
    End Sub

    'Private Sub emailLogin()
    '    sqlConnection.Open()
    '    Dim command As New SqlCommand("SELECT * FROM userCredentials WHERE userEmail = @userEmail and userPassword = @userPassword", sqlConnection)
    '    command.Parameters.Add("@userEmail", SqlDbType.VarChar).Value = email.Text
    '    command.Parameters.Add("@userPassword", SqlDbType.VarChar).Value = password.Text
    '    Dim dbadapter As New SqlDataAdapter(command)
    '    Dim dbtable As New DataTable()
    '    dbadapter.Fill(dbtable)
    '    sqlConnection.Close()

    '    If dbtable.Rows.Count > 0 Then
    '        status.Text = "<br />Welcome, " & username.Text
    '        status.Attributes.Remove("red")
    '        status.CssClass = "green"
    '        System.Threading.Thread.Sleep(1500)
    '        Response.Redirect("https://google.com")

    '    Else
    '        status.Text = "<br />Wrong Credentials"
    '        status.CssClass = "red"
    '    End If
    'End Sub
End Class