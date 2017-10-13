// Learn more about F# at http://fsharp.org

open System
open FSharp.Data


type DataProvider = CsvProvider<Sample="template.csv", Separators="^", Quote='\v'>

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let dataFile = "data.csv"
    let fileInput = System.IO.File.ReadAllText(dataFile)
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
    0 // return an integer exit code
