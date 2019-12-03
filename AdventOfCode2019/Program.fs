// Learn more about F# at http://fsharp.org
open System

[<EntryPoint>]
printfn "Which day would you like to run?"
let dayToRun = Console.ReadLine()

match dayToRun with
            | "1" -> Day01.getSolution
            | "2" -> Day02.getSolution
            | _ -> printfn "Could not find day"
0 // return an integer exit code
