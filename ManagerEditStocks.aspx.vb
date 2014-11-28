Public Class ManagerEditStocks
    Inherits System.Web.UI.Page


    'have a gridview with textboxes for the prices.
    'for the descriptive message we should do loops to see what was changed and store that in a string to be output on a panel that will become visible after a succesful transaction

    '=========== HELLO FROM NICOLE ====================

    'Hey Leah! Okay, so I set up the gridview. It's all on the aspx page -- essentially you turn the column into a TemplateField, 
    'then turn the "template" to anything you want--textbox, calendar, imagebutton, etc.
    'to reference the cell, you have to do something a bit weird. You can see CustomerPayBills for working code, but essentially you have to take
    'whatever's in the cell and create a virtual textbox, then call that:

    'Dim t As TextBox = DirectCast(gvMyPayees.Rows(i).Cells(4).FindControl("txtAmount"), TextBox)
    'and then you use t.Text to pull the values.
    'Kind of convoluted, but it works. 

    'Let me know if you have any questions! Hope this helps :)



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("EmployeeFirstName") Is Nothing Then
            Response.Redirect("EmployeeLogin.aspx")
        End If
    End Sub

End Class