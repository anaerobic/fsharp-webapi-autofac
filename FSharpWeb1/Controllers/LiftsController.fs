namespace FSharpWeb1.Controllers

open System.Net
open System.Net.Http
open System.Web.Http
open FSharpWeb1.Models

/// Retrieves values.
[<RoutePrefix("api")>]
type LiftsController() = 
    inherit ApiController()
    
    let values = 
        [| { Movement = "Squat"
             Destroys = "Legs" }
           { Movement = "Deadlift"
             Destroys = "Legs" }
           { Movement = "Bench"
             Destroys = "Chest" }
           { Movement = "Clean & Jerk"
             Destroys = "Traps" }
           { Movement = "Snatch"
             Destroys = "Upper Back" } |]
    
    /// Gets all values.
    [<Route("lifts")>]
    member x.Get() = values
    
    /// Gets a single value at the specified index.
    [<Route("lifts/{id}")>]
    member x.Get(request : HttpRequestMessage, id : int) = 
        if id >= 0 && values.Length > id then request.CreateResponse(values.[id])
        else request.CreateResponse(HttpStatusCode.NotFound)
