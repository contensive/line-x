Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Contensive.BaseClasses

Namespace Contensive.Addons.LineXSliders

    Public Class LinexMenu

        Inherits AddonBaseClass
        '
        '
        Public Overrides Function Execute(ByVal CP As CPBaseClass) As Object
            Dim returnHtml As String = ""
            '
            Try

                Dim sectionName As String = ""
                Dim activeSection As Boolean = False
                Dim cs As BaseClasses.CPCSBaseClass = CP.CSNew()


                Dim ImageCnt As Integer = 0
                Dim histCount As Integer = 0
                Dim exitLoop As Boolean = False

                Dim innerHtml As String = ""
                Dim cacheName As String = "SliderCache"
                Dim linexCustomeMenu = CP.Utils.ExecuteAddon("Menu")
                '  

                '
                If cs.Open("Site Sections", , "id Desc", , "Name") Then
                    Do
                        sectionName = cs.GetText("Name")
                        linexCustomeMenu = linexCustomeMenu.Replace(">" & sectionName & "<", "><span class=""hov"">" & sectionName & "</span><")
                        Call cs.GoNext()
                    Loop While cs.OK
                End If
                Call cs.Close()
                '' ***
                returnHtml = linexCustomeMenu

            Catch ex As Exception
                CP.Site.ErrorReport(ex, "error in multiFormAjaxSample.execute")
            End Try
            Return returnHtml
        End Function
    End Class
End Namespace




