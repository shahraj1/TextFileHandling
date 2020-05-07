Public Class frmTextFiles

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strSSN As String
        Dim strFirstName As String
        Dim strLastName As String


        'declare the object Empfile as an output file 
        Dim EmpFile As System.IO.StreamWriter

        Dim strFileName As String = "employees.txt"


         EmpFile = System.IO.File.AppendText(strFileName)


        
        'obtain data
        strSSN = Me.txtSSN.Text
        strFirstName = Me.txtFirstName.Text
        strLastName = Me.txtLastName.Text

        EmpFile.Write(strSSN)
        EmpFile.Write(",")
        EmpFile.Write(strFirstName)
        EmpFile.Write(",")
        EmpFile.WriteLine(strLastName)


        'once the record is written you must close the text file.

        EmpFile.Close()

        'clear textbox for next employee

        Me.txtSSN.Clear()
        Me.txtFirstName.Clear()
        Me.txtLastName.Clear()
        Me.txtSSN.Focus()

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        'declare the object Empfile as an input file 

        Dim EmpFile As System.IO.StreamReader
        Dim strFileName As String = "employees.txt"

        Dim strEmpRecord As String
        Dim intIndex
        Dim strEmpSSN As String
        Dim strEmpFirstName As String
        Dim strEmpLastName As String

        'the following will determine if file exist. 
        'If does, will open, if does not will put out a message box.
        If System.IO.File.Exists(strFileName) Then
            EmpFile = System.IO.File.OpenText(strFileName)
            'I am now going to populate the list box with the employee data
            Do Until EmpFile.Peek = -1
                'read the record from the employee file
                strEmpRecord = EmpFile.ReadLine()
                'break the record apart into fields based on the commas
                intIndex = strEmpRecord.IndexOf(",")
                strEmpSSN = strEmpRecord.Substring(0, intIndex)
                strEmpRecord = strEmpRecord.Remove(0, intIndex + 1)
                intIndex = strEmpRecord.IndexOf(",")
                strEmpFirstName = strEmpRecord.Substring(0, intIndex)
                strEmpLastName = strEmpRecord.Remove(0, intIndex + 1)


                'add to list box. Notice the vbTab that will help you format
                Me.lstEmployees.Items.Add("SSN: " & vbTab & vbTab & strEmpSSN)
                Me.lstEmployees.Items.Add("First Name: " & vbTab & strEmpFirstName)
                Me.lstEmployees.Items.Add("Last Name: " & vbTab & strEmpLastName)
                Me.lstEmployees.Items.Add("")
            Loop
            'make sure you close the file
            EmpFile.Close()
        Else
            MessageBox.Show("Employee File Does Not Exist")
        End If






    End Sub
End Class
