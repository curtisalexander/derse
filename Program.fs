module Derse.Main

open System
open Argu
open Derse.Arguments
open Derse.Dir

[<EntryPoint>]
let main argv =
    let errorHandler = ProcessExiter(colorizer = function ErrorCode.HelpText -> None | _ -> Some ConsoleColor.Red)
    let parser = ArgumentParser.Create<DerseArguments>(programName = "derse", errorHandler = errorHandler)

    try
        let args = parser.Parse argv

        match args.GetAllResults() with
        | [Directory d] -> printfn "The directory to produce a summary: %s" d
        | _ -> ()
        0
    with
    | :? ArguParseException as ex ->
        printfn "%s" ex.Message
        1
    | ex ->
        printfn "Internal Error:"
        printfn "%s" ex.Message
        2
