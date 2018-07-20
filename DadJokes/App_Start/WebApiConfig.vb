Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)

        ' change output to plain text from XML!
        config.Formatters.XmlFormatter.SupportedMediaTypes.Clear()
        config.Formatters.XmlFormatter.SupportedMediaTypes.Add(New Net.Http.Headers.MediaTypeHeaderValue("text/plain"))

        ' Web API routes
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )

    End Sub
End Module
