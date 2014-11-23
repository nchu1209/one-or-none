Public Class CustomerPayBills
    Inherits System.Web.UI.Page

    Dim db As New ClassDBPayee
    Dim valid As New ClassValidate

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CustomerFirstName") Is Nothing Then
            Response.Redirect("CustomerLogin.aspx")
        End If

        db.GetCustomerPayees(Session("CustomerNumber"))

        ddlPayee.DataSource = db.PayeeDataset.Tables("tblPayees")
        ddlPayee.DataTextField = "PayeeName"
        ddlPayee.DataValueField = "PayeeID"
        ddlPayee.DataBind()

    End Sub

    Protected Sub txtPay_Click(sender As Object, e As EventArgs) Handles txtPay.Click
        'validate textbox field
        If valid.CheckDecimal(txtAmount.Text) = -1 Then
            lblMessage.Text = "Please enter a valid payment amount."
            Exit Sub
        End If

        'validate selected date (today or later)
        'if today, post immediately
        'if in future, schedule as pending payment
    End Sub
End Class