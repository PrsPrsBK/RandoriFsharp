// Learn more about F# at http://fsharp.org

open System

let reader (sth: string) =
    printfn "input is %s" sth
    sth

let evaler (sth: string) =
    sprintf "evaled: %s" sth

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
