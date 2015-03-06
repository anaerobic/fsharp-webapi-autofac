namespace FSharpWeb1.Configuration

open FSharpWeb1.Models
open System.Web.OData.Builder

type EdmBuilder() = 
    member this.Build() = 
        let ns = "api"
        let builder = new ODataConventionModelBuilder()
        builder.Namespace <- ns
        let lift = builder.EntitySet<Lift>("Lifts").EntityType
        lift.HasKey(fun x -> x.Id) |> ignore
        lift.Property(fun x -> x.Movement) |> ignore
        lift.Property(fun x -> x.Destroys) |> ignore
        for x in builder.EntitySets do
            x.EntityType.Namespace <- ns
        for x in builder.EnumTypes do
            x.Namespace <- ns
        for x in builder.StructuralTypes do
            x.Namespace <- ns
        builder.GetEdmModel()
