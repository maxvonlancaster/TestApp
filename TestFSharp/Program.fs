// Learn more about F# at http://fsharp.org

open System
open Features


// cylinder value calculation
let cylinderValue radius length = 
    let pi = 3.14159
    length * pi * radius * radius

// matrix determinant calculation
let matrxCalc =
    let matrix = [[1;0;0];[0;1;0];[2;0;1]]
    let result = matrix.[0].[0]*matrix.[1].[1]*matrix.[2].[2] + matrix.[0].[1]*matrix.[1].[2]*matrix.[2].[0] + matrix.[1].[0]*matrix.[2].[1]*matrix.[0].[2] - matrix.[2].[0]*matrix.[1].[1]*matrix.[0].[2] - matrix.[1].[0]*matrix.[0].[1]*matrix.[2].[2] - matrix.[0].[0]*matrix.[2].[1]*matrix.[1].[2]
    printfn "Element 2,0: %i" matrix.[2].[0]
    result

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let vol = cylinderValue 2.0 1.0
    printfn "vol: %f" vol
    printfn "matrix determinant: %i" matrxCalc
    let s = square 5 
    printfn "Suqare %i" s
    ``square then negate`` 5
    composition' 3
    let f = fibbonachi 6
    printfn "fib: %i" f
    let list = [1;2;3]
    let sm = sum list
    printfn "Sum of list: %i" sm
    let v = Vector(1.0, 2.0)
    let v2 = v.Scale(5.0)
    printfn "Vector x: %f" v2.X
    let i = playAround
    0 // return an integer exit code

