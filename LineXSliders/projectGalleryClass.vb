Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Contensive.BaseClasses

Namespace Contensive.Addons.LineXSliders


    Public Class projectGalleryClass
        Inherits AddonBaseClass
        '
        Public Class rowClass
            Public thumb As String
            Public image As String
            Public title As String
        End Class

        '
        Public Overrides Function Execute(ByVal CP As CPBaseClass) As Object
            Dim returnHtml As String = ""
            '
            Try
                Dim cs As BaseClasses.CPCSBaseClass = CP.CSNew()
                Dim imageList As New List(Of rowClass)
                Dim jsonSerializer As New System.Web.Script.Serialization.JavaScriptSerializer
                Dim cacheName As String = "GalleryCache"

                '  
                returnHtml = CP.Cache.Read(cacheName)
                If String.IsNullOrEmpty(returnHtml) Then
                    If Not cs.Open("Project Gallery Images", , "id Desc") Then
                        Dim row As New rowClass
                        row.thumb = ""
                        row.image = "2015LinexGalleryImages/dummy.jpg"
                        row.title = "No Images Found"
                        imageList.Add(row)
                    Else
                        Do
                            Dim row As New rowClass
                            row.thumb = CP.Site.FilePath & cs.GetText("thumbFilename")
                            row.image = CP.Site.FilePath & cs.GetText("imageFilename")
                            row.title = cs.GetText("name")
                            imageList.Add(row)
                            Call cs.GoNext()
                        Loop While cs.OK
                    End If
                    Call cs.Close()
                    returnHtml = jsonSerializer.Serialize(imageList)
                    CP.Cache.Save(cacheName, returnHtml, "Project Gallery Images")
                End If
                '
               
            Catch ex As Exception
                CP.Site.ErrorReport(ex, "error in multiFormAjaxSample.execute")
            End Try
            Return returnHtml
        End Function
    End Class
End Namespace



