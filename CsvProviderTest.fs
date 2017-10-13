module CsvProviderTest

open System
open FSharp.Data

type DataProvider = CsvProvider<Sample="template.csv", Separators="^", Quote='\v'>

let readCsv filePath =

    let fileInput = System.IO.File.ReadAllText filePath
    let parsed = DataProvider.Parse fileInput
    printfn "parsed.column: %A" parsed.NumberOfColumns
    printfn "headers: %A" parsed.Headers

    parsed.Headers
    |> Option.map(String.concat " | " )
    |> Option.get
    |> printfn "%s"

    parsed.Rows
    |> Seq.iter (fun row ->
        printfn "%A | %A | %A" row.``Serial No.`` row.Name row.Value
    )
