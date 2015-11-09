Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Contensive.BaseClasses

Namespace Contensive.Addons.LineXSliders


    Public Class linexslider

        Inherits AddonBaseClass
        '
        '
        Public Overrides Function Execute(ByVal CP As CPBaseClass) As Object
            Dim returnHtml As String = ""
            '
            Try

                Dim layout As CPBlockBaseClass = CP.BlockNew
                Dim blockLayout As CPBlockBaseClass = CP.BlockNew
                Dim tmpHtml As String = ""
                Dim linexImage As String = ""
                Dim UseImage As Boolean = False
                Dim slideDescription As String = ""
                Dim cs As BaseClasses.CPCSBaseClass = CP.CSNew()


                Dim ImageCnt As Integer = 0
                Dim histCount As Integer = 0
                Dim exitLoop As Boolean = False

                Dim innerHtml As String = ""
                Dim cacheName As String = "SliderCache"

                '  
                returnHtml = CP.Cache.Read(cacheName)
                '                
                layout.OpenLayout("Linex Slider Layout")


                If cs.Open("Linex Slider", , "id Desc") Then
                    Do
                        If cs.GetBoolean("useImage") Then
                            linexImage = cs.GetText("sliderImage")
                            slideDescription = cs.GetText("sliderDescription")
                            '**
                            blockLayout.Load(layout.GetInner("#js-lxHomeSliderUL"))
                            '
                            blockLayout.SetInner("#js-lxSlide", " <div class=""sliderImg""> <img src=""" & CP.Site.FilePath & linexImage & """ alt="""" /> <div class=""sliderCaption"">" & slideDescription & "</div> </div>")
                            innerHtml &= blockLayout.GetHtml
                            '
                        End If
                        '
                        Call cs.GoNext()
                    Loop While cs.OK
                End If
                Call cs.Close()
                ' ***
                layout.SetInner("#js-lxHomeSliderUL", innerHtml)

                Call cs.Close()

                'do
                ' read a table
                ' end do

                'layout.SetInner(".newsFeedBox", tmpHtml)

                returnHtml = layout.GetHtml
                CP.Cache.Save(cacheName, returnHtml, "Linex Slider")
            Catch ex As Exception
                CP.Site.ErrorReport(ex, "error in multiFormAjaxSample.execute")
            End Try
            Return returnHtml
        End Function
    End Class
End Namespace



