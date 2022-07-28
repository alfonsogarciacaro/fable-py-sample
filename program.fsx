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
    use file = builtins.``open``("data.txt", "r")
    let contents = file.read()
    let reversed = contents.Split(" ") |> Array.rev |> String.concat " "
    printfn $"Data:     {contents}"
    printfn $"Reversed: {reversed}"

    use out = builtins.``open``("reversed.txt", "w")
    out.write reversed |> ignore

    // Uncomment the following lines to see how to interact with a Python library
    // Please note this requires Pandas to be installed in your Python environment
    
    // let df = pandas.read_csv("numbers.csv")
    // builtins.print(df)
    // let columnA: int[] = df.loc("A")
    // columnA |> Array.map (fun i -> i + 4) |> Array.sum |> printfn "%i"

    0