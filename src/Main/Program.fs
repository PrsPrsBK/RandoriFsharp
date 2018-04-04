// Learn more about F# at http://fsharp.org

open System

let rec promptLoop () =
    stdout.Write("prompt$ ")
    let sth = stdin.ReadLine()
    printfn "input is %s" sth
    match sth with
    | "q" -> ()
    |_ -> promptLoop()

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    promptLoop()
    0 // return an integer exit code
