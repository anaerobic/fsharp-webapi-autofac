namespace FSharpWeb1.Configuration

open System.Reflection
open System.Web.OData
open Autofac

type AutofacBuilder() = 
    member this.Build() = 
        let builder = new Autofac.ContainerBuilder()
        builder.RegisterAssemblyTypes(Assembly.GetAssembly(typedefof<AutofacBuilder>)) |> ignore
        builder.RegisterType<MetadataController>().AsSelf() |> ignore
        builder.Build()
