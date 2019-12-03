module Day02

open AdventOfCode2019.Utilities

let insertNounAndVerb list noun verb =
    list |> Seq.mapi(fun i x -> if i = 1 then noun else if i = 2 then verb else x)

let rec restoreGravity (list: seq<int>) address = 
    let currentValue = list |> Seq.item(address)
    match currentValue with
        | 1 | 2 as opcode -> 
            let param1 = list |> Seq.item (address+1)
            let param2 = list |> Seq.item (address+2)
            let param3 = list |> Seq.item (address+3)
            let firstValue = list |> Seq.item param1
            let secondValue = list |> Seq.item param2
            let newValue = if opcode = 1 then firstValue + secondValue else firstValue * secondValue
            let newSeq = list |> Seq.mapi(fun i x -> if i = param3 then newValue else x); 
            restoreGravity newSeq (address+4)
        | 99 -> list
        | _ -> failwith "not a 1, 2 or 99" 


let getSolution =
    let answerPart1 = parseSingleLine listOfInts "Day02\Input.txt"

    let replacedSeq = insertNounAndVerb answerPart1 12 2
    let sol = restoreGravity replacedSeq 0 |> Seq.item 0
    printfn "Part 1 Solution: %i" sol

    for noun = 0 to 99 do
        for verb = 0 to 99 do
            let newSeq = insertNounAndVerb answerPart1 noun verb
            let output = restoreGravity newSeq 0 |> Seq.item 0
            if output = 19690720 then
                let sol2 = 100 * noun + verb
                printfn "Part 2 Solution: %i" sol2 
        