namespace FSharpWeb1.Configuration

open System.Net.Http
open System.Web.Http.Dispatcher
open System.Web.Http
open System
open Autofac
open System.Web.Http.Controllers
open FSharpWeb1.Controllers

type AutofacCompositionRoot(container : Autofac.IContainer) = 
    interface IHttpControllerActivator with
        member this.Create(request, descriptor, ctype) = 
            let scope = container.BeginLifetimeScope(fun builder -> builder.RegisterInstance request)
            request.RegisterForDispose scope
            scope.Resolve ctype :?> IHttpController
