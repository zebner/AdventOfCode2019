namespace AdventOfCode2019

open System.IO
open System

module Utilities =

    let parseSingleLine f fileName = 
        use fs = new FileStream(fileName, FileMode.Open)
        use reader = new StreamReader(fs)
        f (reader.ReadLine())


    let parseEachLine f fileName = 
        let lines = File.ReadLines(fileName)
        lines |> Seq.map f


    let asInt : string -> int = int
    let listOfInts (str: string) = str.Split(',', StringSplitOptions.None) |> Seq.map asInt
    let listOfStrings (str: string) = str.Split(',', StringSplitOptions.None)
