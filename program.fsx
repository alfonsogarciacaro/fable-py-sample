#r "nuget:Fable.Python"

open Fable.Python.Builtins

[<EntryPoint>]
let main argv =
    let name = Array.tryHead argv |> Option.defaultValue "Guest"
    printfn $"Hello {name}!"

    // Open file with builtin `open`
    use file = builtins.``open``(StringPath "data.txt")
    file.read() |> printfn "File contents: %s"

    0