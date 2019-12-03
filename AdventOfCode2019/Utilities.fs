namespace AdventOfCode2019

open System
open System.IO

module Utilities =

    let parseEachLine f = File.ReadLines >> Seq.map f

    let asString : string -> string = id
    let asInt : string -> int = int
