module Day01

open System.IO


let getFuel mass = (mass / 3) - 2


let rec getFuel2 mass =
    if mass <= 0 then 0
    else mass + getFuel2(getFuel mass)

    
let asInt: string -> int = int
let parseEachLineAsInt fileName = File.ReadLines(fileName) |> Seq.map asInt

let getSolution = 
    let answerPart1 = parseEachLineAsInt "Day01\Input.txt" |> Seq.sumBy getFuel
    printfn "%i" answerPart1
    let answerPart2 = parseEachLineAsInt "Day01\Input.txt" |> Seq.sumBy(fun line -> getFuel2 (getFuel line))
    printfn "%i" answerPart2