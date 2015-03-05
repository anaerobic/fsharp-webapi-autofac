namespace FSharpWeb1

open Owin
open Microsoft.Owin
open System
open System.Net.Http
open System.Web
open System.Web.Http
open System.Web.Http.Owin
open System.Web.Http.Dispatcher
open Autofac
open FSharpWeb1.Configuration

[<Sealed>]
type Startup() = 
    
    static member RegisterWebApi(config : HttpConfiguration) = 
        let container = new AutofacBuilder() |> (fun x -> x.Build())
        let activator = new AutofacCompositionRoot(container)
        config.Services.Replace(typedefof<IHttpControllerActivator>, activator)
        // Configure routing
        config.MapHttpAttributeRoutes()
        // Configure serialization
        config.Formatters.XmlFormatter.UseXmlSerializer <- true
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver <- Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver
                                                                                   ()
    
    // Additional Web API settings
    member __.Configuration(builder : IAppBuilder) = 
        let config = new HttpConfiguration()
        Startup.RegisterWebApi(config)
        builder.UseWebApi(config) |> ignore
