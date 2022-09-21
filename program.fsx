#r "nuget:Fable.Core, 4.0.0-theta-002"

open System
open Fable.Core

Py.NEW_CELL

printfn "This is a cell"

Py.NEW_CELL

printfn "This is another cell"

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