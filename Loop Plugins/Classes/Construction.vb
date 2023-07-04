Public Class Construction


    Public Enum ItemsTypes
        LIGHTING = 1
        TRAYS = 2
        CABLES = 3
        EQUIPMENT = 4
        INSTRUMENTS = 5
        ACTIVITIES = 6
        CABLESFULL = 7
    End Enum
    Public Overloads Function GetItems(ByVal itemType As ItemsTypes) As DataTable
        Try
            Select Case itemType
                Case ItemsTypes.LIGHTING
                    Return (DB.ReturnDataTable("EXEC CONSTRUCTION.GetLighting"))
                Case ItemsTypes.TRAYS
                    Return (DB.ReturnDataTable("EXEC CONSTRUCTION.GetTrays"))
                Case ItemsTypes.CABLES
                    Return (DB.ReturnDataTable("EXEC CONSTRUCTION.GetCables"))
                Case ItemsTypes.EQUIPMENT
                    Return (DB.ReturnDataTable("EXEC CONSTRUCTION.GetEquipment"))
                Case ItemsTypes.INSTRUMENTS
                    Return (DB.ReturnDataTable("EXEC CONSTRUCTION.GetInstruments"))
                Case ItemsTypes.ACTIVITIES
                    Return (DB.ReturnDataTable("EXEC PLANNING.GetActivities"))
                Case ItemsTypes.CABLESFULL
                    Return (DB.ReturnDataTable("EXEC CONSTRUCTION.GetCablesFull"))
            End Select

        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function


End Class
