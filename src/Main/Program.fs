// Learn more about F# at http://fsharp.org

open System

let tokenize (sth: string) =
    sth.Replace("(", " ( ").Replace(")", " ) ").Split([|" ";|], StringSplitOptions.RemoveEmptyEntries)

let reader (sth: string) =
    printfn "input is %s" sth
    sth |> tokenize

let evaler (sth: string array) =
    sprintf "evaled: %A" sth

let printer (sth: string) =
    printfn "%s" sth

let rec looper () =
    stdout.Write("prompt$ ")
    let sth = stdin.ReadLine()
    match sth with
    | "q" -> ()
    |_ -> sth |> reader |> evaler |> printer |> looper

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    looper()
    0 // return an integer exit code
