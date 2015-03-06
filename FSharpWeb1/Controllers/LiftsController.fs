namespace FSharpWeb1.Controllers

open System.Linq
open System.Net
open System.Net.Http
open System.Web.OData
open FSharpWeb1.Models

/// Retrieves values.
type LiftsController() = 
    inherit ODataController()
    
    let values = 
        [| { Id = 1
             Movement = "Squat"
             Destroys = "Legs" }
           { Id = 2
             Movement = "Deadlift"
             Destroys = "Legs" }
           { Id = 3
             Movement = "Bench"
             Destroys = "Chest" }
           { Id = 4
             Movement = "Clean & Jerk"
             Destroys = "Traps" }
           { Id = 5
             Movement = "Snatch"
             Destroys = "Upper Back" } |]
    
    /// Gets all values.
    member x.Get() = values.AsQueryable()
    
    /// Gets a single value at the specified index.
    member x.Get(request : HttpRequestMessage, key : int) = 
        [values.SingleOrDefault (fun x -> x.Id = key)].AsQueryable()
