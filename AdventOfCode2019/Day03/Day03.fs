module Day03

open AdventOfCode2019.Utilities

type Point = {X: int; Y: int}

let getAllPointsFromInstruction (instruction: string) (startingPoint: Point) =
    let mutable allPointsFromIntruction = [startingPoint]
    let direction = instruction.Substring(0, 1)
    let distance = instruction.Substring(1, instruction.Length - 1) |> int
    for spot = 0 to distance - 1 do
        let lastPointInList = allPointsFromIntruction |> List.head
        let pointToAdd = 
            if direction = "R" then { X = lastPointInList.X + 1; Y = lastPointInList.Y } 
            else if direction = "L" then { X = lastPointInList.X - 1; Y = lastPointInList.Y } 
            else if direction = "U" then { X = lastPointInList.X; Y = lastPointInList.Y + 1 } 
            else { X = lastPointInList.X; Y = lastPointInList.Y - 1 } 
        allPointsFromIntruction <- pointToAdd :: allPointsFromIntruction
    allPointsFromIntruction  

let getAllPointsForWire (allInstructions : seq<string>) =
    let mutable allPoints = [{X = 0; Y = 0}]
    for index = 0 to (allInstructions |> Seq.length) - 1 do
        let startingPoint = allPoints |> List.head
        let instruction = allInstructions |> Seq.item(index)
        let points = getAllPointsFromInstruction instruction startingPoint
        for i = points.Length - 1 downto 0 do
            allPoints <- points.[i] :: allPoints
    allPoints
   

let getSolution =
    let lines = parseEachLine listOfStrings "Day03\Input.txt"
    let firstWire = lines |> Seq.item(0)
    let secondWire = lines |> Seq.item(1)
    let allPoints1 = getAllPointsForWire firstWire |> Set.ofList
    let allPoints2 = getAllPointsForWire secondWire |> Set.ofList
    let intersections = Set.intersect allPoints1 allPoints2 |> Seq.filter(fun point -> point.X <> 0 || point.Y <> 0)
    let closest = intersections |> Seq.minBy(fun point -> abs point.X + abs point.Y)
    printfn "Part 1 Solution: %i" <| abs closest.X + abs closest.Y
    
