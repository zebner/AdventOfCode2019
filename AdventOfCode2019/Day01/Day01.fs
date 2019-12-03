module Day01

open AdventOfCode2019.Utilities

let getFuelRequirement mass = (mass / 3) - 2

let rec getFuelRequirementRec mass =
    if mass <= 0 then 0
    else mass + getFuelRequirementRec(getFuelRequirement mass)

let getSolution =
    let answerPart1 = parseEachLine asInt "Day01\Input.txt" 
                        |> Seq.sumBy getFuelRequirement
    printfn "Part 1 Solution: %i" answerPart1
    let answerPart2 = parseEachLine asInt "Day01\Input.txt" 
                        |> Seq.sumBy(fun line -> getFuelRequirementRec (getFuelRequirement line))
    printfn "Part 2 Solution: %i" answerPart2