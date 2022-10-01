#r "nuget:Fable.Core, 4.0.0-theta-004"

open System
open Fable.Core

Py.NEW_CELL

printfn "This is a cell"

let result =
    "FooBar"
    |> Seq.rev
    |> Seq.toArray
    |> String

// Result at the end of cell is displayed
result

Py.NEW_CELL

printfn "Import matplotlib"

Py.python """
import matplotlib.pyplot as plt
"""

Py.NEW_CELL

printfn "Generate data in F#"

let x = [| 0. .. 0.20 .. 20 |]
let y = x |> Array.map Math.Sin

Py.NEW_CELL

printfn "Plotting..."

Py.python """
plt.plot(x, y)
plt.show()
"""