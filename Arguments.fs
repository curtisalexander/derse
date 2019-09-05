namespace Derse.Arguments

open Argu

type DerseArguments =
| [<Mandatory>]Directory of directory:string
with
    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | Directory _ -> "Directory to create summary"
