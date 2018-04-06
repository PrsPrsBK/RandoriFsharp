// Learn more about F# at http://fsharp.org

open System

let tryParseWith f = f >> function
    | true, v -> Some v
    | false, _ -> None

let parseAtom = tryParseWith Int32.TryParse

let (|Int|_|) = parseAtom

let whichAtom (x: string) =
    match x with
    | Int x -> "int."
    | _ -> "symbol."

let tokenize (sth: string) =
    sth.Replace("(", " ( ").Replace(")", " ) ").Split([|" ";|], StringSplitOptions.RemoveEmptyEntries)

let reader (sth: string) =
    printfn "input is %s" sth
    sth |> tokenize

let evaler (sth: string array) =
    for token in sth do
        printfn "  token %s is %s" token (whichAtom token)
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
