// Learn more about F# at http://fsharp.org

open System
open FSharp.Data


[<EntryPoint>]
let main argv =
    CsvProviderTest.readCsv "data.csv"
    ExcelProviderTest.readExcel "Excel.xlsx"
    0 // return an integer exit code
