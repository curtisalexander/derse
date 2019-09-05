module Derse.Dir

open System.IO

let summarizeFiles (dir, fileSeq) =
    let fileSize (_, size) = size
    let fileSizeFloat(_, size) = float size
    let fileExt ((file:string), _) = Path.GetExtension file

    let totalSize = fileSeq |> Seq.sumBy fileSize
    let avgSize = fileSeq |> Seq.averageBy fileSizeFloat
    let fileCnt = fileSeq |> Seq.length
    let exs = fileSeq |> Seq.map fileExt |> Seq.distinct |> List.ofSeq

    dir, totalSize, avgSize, fileCnt, exs

type FileSummary =
    {
        Directory : string
        TotalFileSize : int
        AverageFileSize : float
        FileCount : int
        FileExtensions : string list
    }

let toFileSummary (dir, totalSize, avgSize, fileCnt, exts) =
    {
        Directory = dir
        TotalFileSize = totalSize
        AverageFileSize = avgSize
        FileCount = fileCnt
        FileExtensions = exts
    }

let summarizeDir (startingDirectory:string) =
    Directory.EnumerateDirectories startingDirectory
    |> Seq.collect (Directory.EnumerateFiles)
    |> Seq.map (fun f -> f, (FileInfo f).Length |> int)
    |> Seq.groupBy (fun (f, _) -> Path.GetDirectoryName f)
    |> Seq.map summarizeFiles
    |> Seq.sortByDescending (fun (_, totalSize, _, _, _) -> totalSize)
    |> Seq.map toFileSummary


let summarizeDirPrint (startingDirectory:string) =
    summarizeDir startingDirectory
    |> Seq.iter (printfn "%A\n")
