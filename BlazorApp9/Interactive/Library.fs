namespace Blazor.Interactive

open Microsoft.DotNet.Interactive.FSharp
open Microsoft.DotNet.Interactive
open Microsoft.DotNet.Interactive.Commands
open Microsoft.DotNet.Interactive.Events

open System.Linq
open System

open FsToolkit.ErrorHandling

module Test =

    let run (counter: int) = 

        task {
            let kernel = new FSharpKernel()

            let! _ = kernel.SubmitCodeAsync($"let x = 6 * {counter}")

            let! requestValue = 
                RequestValue("x", "text/plain", "fsharp")
                |> kernel.SendAsync

            Console.WriteLine($"Requested value for x")

            let events = requestValue.Events.ToList().Select( fun x -> x.GetType().Name)
            let eventsRaw = String.Join(" ", events.ToArray())

            Console.WriteLine($"all events: {eventsRaw}")

            return
                requestValue.Events.FirstOrDefault(fun x -> x.GetType() = typeof<ValueProduced>) 
                |> Option.ofNull
                |> Option.map (fun evt -> 
                    let valueProduced = evt :?> ValueProduced

                    Console.WriteLine($"got value: {valueProduced.FormattedValue.Value }")

                    valueProduced.FormattedValue.Value 
                )
                |> Option.defaultWith ( fun () ->
    
                    Console.WriteLine($"did not get a Value Produced event, checking for a failure event")
      
                    requestValue.Events.FirstOrDefault(fun x -> x.GetType() = typeof<CommandFailed>)
                    |> Option.ofNull
                    |> Option.map ( fun evt ->
                        let failed = evt :?> CommandFailed

                        Console.WriteLine failed.Message

                        failed.Message    
                    )   
                    |> Option.defaultWith ( fun () -> failwith "App error: not predicted/supported test flow, either ValueProduced or CommandFailed is expected") 
               )
             
        }