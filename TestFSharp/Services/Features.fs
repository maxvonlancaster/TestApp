module Features

// let defines an immutable value
let square x = x * x

// string concatenation
let hello = "Hello " + "World"

let negate x = x * -1

let print x = printfn "Result: %d" x

// pipe operator - used to chain functions and arguments together
let ``square then negate`` x = x |> square |> negate |> print

// composition operator -> to compose functions:
let composition' = square >> negate >> print


// rec together with let -> recursive function
let rec factorial x =
    if x < 1 then 1
    else x * factorial (x - 1)

// mutually recursive functions indicated by and keyword:
let rec even x =
    if x = 0 then true 
    else odd (x - 1)

and odd x = 
    if x = 1 then true 
    else even (x - 1)


// Pattern matching - match keyword **************************************************************
let rec fibbonachi n =
    match n with 
    | 0 -> 0
    | 1 -> 1
    | _ -> fibbonachi (n - 1) + fibbonachi (n - 2)
    
// use when to create filters or guards on patterns:
let sign x = 
    match x with
    | 0 -> 0
    | x when x < 0 -> -1
    | x -> 1


// Collections *********************************************************************************************
// lists use [] brackets and ; delimiter -> immutable!
let list1 = ["a"; "b"]
// :: is prepending and @ is concatenating
let list2 = "c" :: list1
let list3 = list1 @ list2
// recursion on list using :: operator
let rec sum list =
    match list with 
    | [] -> 0
    | x :: xs -> x + sum xs

// arrays -> fixed-size, zero-based, mutable, [|array|]
let array1 = [|"a", "b"|]
let first = array1.[0]

// sequence is a logical series of elements of the same type. Individual sequence elements are computed only as required, so a sequence can 
// provide better performance than a list in situations in which not all the elements are used. Can use yield and contain subsequences
let seq1 =
    seq {
        yield 1 // yield adds one element
        yield 2
        yield! [5..10] // yield! adds a whole subsequence
    }



// Higher-order functions on collections *********************************************************************************************
// the same list [1;3;5;7;9] or array [|1;3;5;7;9|] can be generated in various ways:
// using range operator ..
let xs = [1..2..9]
// using list or array comprehensions
let ys = [|for i in 0..4 -> 2*i + 1 |]
// using init function
let zs = List.init 5 (fun i -> 2 * i + 1)
// Lists and arrays have comprehensive sets of higher-order functions for manipulation
// fold starts from the left of the list (or array) and foldBack goes in the opposite direction
let xs' = Array.fold(fun str n -> 
    sprintf "%s,%i" str n ) "" [|0..9|]
// reduce doesn't require an initial accumulator
let last xs = List.reduce (fun acc x -> x) xs
// map transforms every element of the list (or array)
let ys' = Array.map (fun x -> x * x) [| 0..9 |]
// iterate through a list and produce side effects
let _ = List.iter (printfn "%i") [ 0..9 ] 
// All these operations are also available for sequences. The added benefits of sequences are laziness and uniform treatment of all collections implementing IEnumerable<'T>.
let zs' = 
    seq {
        for i in 0..9 do
        printfn "Adding %d" i
        yield i
    }



// Tuples and records ****************************************************************************************************************************
// tuple is a grouping of unnamed but ordered values, possibly of different types:
let x = (1, "Hello")
let y = ("a", "b", "c")
let (a', b') = x // deconstruction
// first and second elements of a tuple can be obtained using fst, snd, or pattern matching:
let c' = fst (1, 2)
let d' = snd (1, 2)

let print' tuple =
    match tuple with
    | (a, b) -> printfn "Pair %A %A" a b
// records represent simple aggregates of named values, optionally with members:
type Person = { Name : string; Age : int } // decalre a recodr type
let paul = { Name = "Paul"; Age = 28 }
let jim = { paul with Name = "Jim" }
// records can be augmented with properties and methods:
type Person with
    member x.Info = (x.Name, x.Age)
// records are essentially sealed classes with extra topping: default immutability, structural equality, and pattern matching support.
let isPaul person =
    match person with
    | { Name = "Paul" } -> true
    | _ -> false


// Discriminated unions ****************************************************************************************************************************
// Discriminated unions (DU) provide support for values that can be one of a number of named cases, each possibly with different values and types.
type Tree<'T> =
    | Node of Tree<'T> * 'T * Tree<'T>
    | Leaf

let rec depth = function
    | Node(l, _, r) -> 1 + max (depth l) (depth r)
    | Leaf -> 0

// F# Core has a few built-in discriminated unions for error handling, e.g., Option and Choice.
let optionPatternMatch input =
   match input with
    | Some i -> printfn "input is an int=%d" i
    | None -> printfn "input is missing"
// Single-case discriminated unions are often used to create type-safe abstractions with pattern matching support:
type OrderId = Order of string

let orderId = Order "12" // Create a DU value

let (Order id) = orderId // Use pattern matching to deconstruct single-case DU


// Exceptions ***************************************************************************************************************************************



// Classes and inheritance ****************************************************************************************************************************
// basic class with (1) local let binding, (2) properties, (3) methods and (4) static members:
type Vector(x : float, y : float) =
    let mag = sqrt(x*x + y*y) // (1)
    member this.X = x // (2)
    member this.Y = y
    member this.Mag = mag
    member this.Scale(s) = Vector(x*s, y*s) // (3)
    static member (+) (a: Vector, b : Vector) = Vector(a.X + b.X, a.Y + b.Y) // (4)

// inheritance and call of a base class
type Animal() = 
    member _.Rest() = ()

type Dog() = 
    inherit Animal()
    member _.Run() = base.Rest()

// upcasting with :>
let dog = Dog()
let animal = dog :> Animal

// dynamic downcasting :?> migth throw an InvalidCastException if the cast does not succed at runtime
let shouldBeADog = animal :?> Dog


// Interfaces and object expressions ****************************************************************************************************************************



// Active patterns *********************************************************************************************



// Compiler directives *********************************************************************************************




// Additional *********************************************************************************************
let playAround = 
    let v1 = Vector(1.0, 2.0)
    let v2 = Vector(5.0, 2.0)
    let v3 = v1 + v2
    printfn "Sum vector -> x: %f y: %f length: %f" v3.X v3.Y v3.Mag
    0