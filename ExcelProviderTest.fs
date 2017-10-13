module ExcelProviderTest

open System
open FSharp.ExcelProvider

type DataExcel = ExcelFile<FileName = "Excel.xlsx", SheetName = "Sheet 1", Range = "B2:AX999999">


let readExcel filePath =
    let parsed = new DataExcel(filePath)
    parsed.Data
    |> Seq.take 3
    |> Seq.iter (fun row ->
        let date = row.``Date of Credit`` |> DateTime.FromOADate
        printfn "date: %A" date
    )
    ()