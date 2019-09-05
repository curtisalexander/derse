open System
open Argu

type CLIArguments =
    | [<Mandatory>]Name of name:string
with
    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | Name _ -> "Name of user"

[<EntryPoint>]
let main argv =
    let parser = ArgumentParser.Create<CLIArguments>(programName = "ipstack")

    try
        let args = parser.Parse argv

        match args.GetAllResults() with
        | [Name n] -> printfn "My name is %s" n
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
