

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Contensive.BaseClasses

Namespace Contensive.Addons.LineXSliders

    Public Class LinexSearchClass

        Inherits AddonBaseClass
        '
        '
        Public Overrides Function Execute(ByVal CP As CPBaseClass) As Object
            Dim returnHtml As String = ""
            '
            Try



                Dim activeSection As Boolean = False
                Dim cs As BaseClasses.CPCSBaseClass = CP.CSNew()


                Dim ImageCnt As Integer = 0
                Dim histCount As Integer = 0
                Dim exitLoop As Boolean = False

                Dim innerHtml As String = ""
                'Dim cacheName As String = "SliderCache"
                Dim linexCustomeSearch = CP.Utils.ExecuteAddon("Text Search 2")

                Dim inputFeild = ("<input type=""Text"" name=""TextSearchWordList"" size=""15"" value="""">")
                Dim searchButton = ("<input type=""SUBMIT"" name=""BUTTON"" value=""Search"" onclick="""" id="""">")

                '  
                linexCustomeSearch = linexCustomeSearch.Replace("<input type=""Text"" name=""TextSearchWordList"" size=""15"" value="">", "<input type=""Text"" id=""js-lxSearchInput"" name=""TextSearchWordList"" size=""15"" value="""">")
                linexCustomeSearch = linexCustomeSearch.Replace("<input type=""SUBMIT"" name=""BUTTON"" value=""Search"" onclick="" id="">", "<input type=""SUBMIT"" class=""searchBtn"" name=""BUTTON"" value=""Search"" onclick="""" id="""">")
                '       
                '' ***
                returnHtml = linexCustomeSearch

            Catch ex As Exception
                CP.Site.ErrorReport(ex, "error in multiFormAjaxSample.execute")
            End Try
            Return returnHtml
        End Function
    End Class
End Namespace





