module Day01

open AdventOfCode2019.Utilities

let getFuelRequirement mass = (mass / 3) - 2


let rec getFuelRequirementRec mass =
    if mass <= 0 then 0
    else mass + getFuelRequirementRec(getFuelRequirement mass)

    
//let asInt: string -> int = int
//let parseEachLineAsInt fileName = File.ReadLines(fileName) |> Seq.map asInt

let getSolution =
    let answerPart1 = parseEachLine asInt "Day01\Input.txt" 
                        |> Seq.sumBy getFuelRequirement
    printfn "%i" answerPart1
    let answerPart2 = parseEachLine asInt "Day01\Input.txt" 
                        |> Seq.sumBy(fun line -> getFuelRequirementRec (getFuelRequirement line))
    printfn "%i" answerPart2