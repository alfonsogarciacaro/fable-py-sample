#r "nuget:Fable.Python"

open Fable.Core
open Fable.Core.PyInterop
open Fable.Python.Builtins

module Pandas =
    type DataFrame =
        [<Emit("$0[$1]")>]
        abstract loc: label: obj -> 'T

    type IPandas =
        abstract read_csv: string -> DataFrame

    [<ImportAll("pandas")>]
    let pandas: IPandas = nativeOnly

open Pandas

[<EntryPoint>]
let main argv =
    let name = Array.tryHead argv |> Option.defaultValue "Guest"
    printfn $"Hello {name}!"

    // Open file with builtin `open`
    use file = builtins.``open``(StringPath "data.txt")
    file.read() |> printfn "File contents: %s"

    // Open file with Pandas. We don't have bindings yet
    // but you can use dynamic programming
    let df = pandas.read_csv("numbers.csv")
    builtins.print(df)
    let columnA: int[] = df.loc("A")
    columnA |> Array.map (fun i -> i + 4) |> Array.sum |> printfn "%i"

    // pandas?plotting?andrews_curves(df, "B")

    0