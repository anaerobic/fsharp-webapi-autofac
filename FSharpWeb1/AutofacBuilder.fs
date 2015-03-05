namespace FSharpWeb1.Configuration

open System.Reflection
open Autofac
open FSharpWeb1.Controllers

type AutofacBuilder() = 
    member this.Build() = 
        let builder = new Autofac.ContainerBuilder()
        let bind = builder.RegisterAssemblyTypes(Assembly.GetAssembly(typedefof<LiftsController>))
        builder.Build()
