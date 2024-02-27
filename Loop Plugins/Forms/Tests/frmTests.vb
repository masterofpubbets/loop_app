Public Class frmTests
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim dbTest As New EAMS.DataBaseTools.SQLServerTools
        dbTest.DataBaseLocation = "."
        dbTest.DataBaseName = "TempReports"
        dbTest.Connect()

        Dim sql As String = "SELECT [LOOP_NAME]
      ,[RIE1]
      ,[RIE2]
      ,[MMS]
      ,[TMC]
      ,[TGS]
      ,[TREND MASTER ]
      ,[ALFALAVAL]
      ,[GOODWARD]
      ,[AIR COMPRESSOR]
      ,[DCS]
      ,[SIS]
      ,[PLAN START DAY]
      ,[PLAN FINISH DAY]
      ,DATEDIFF(D,[PLAN START DAY],[PLAN FINISH DAY]) AS Weeks
  FROM [TempReports].[dbo].[Loops]
  INNER JOIN LoopScope ON [Loops].LOOP_NAME = LoopScope.[Loop Name]
"

        Dim dt As DataTable = dbTest.ReturnDataTable(sql)
        GRD.DataSource = dt
    End Sub
End Class