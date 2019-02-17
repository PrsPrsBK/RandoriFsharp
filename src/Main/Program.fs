﻿// Learn more about F# at http://fsharp.org

open Randori

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#! %s" (Randori.Say.hello("from Lib"))
    
    if argv.Length = 0
    then
        Randori.LispRepl.looper()
    else
        match argv.[0] with
        | "repl" -> LispRepl.looper()
        | _ -> ()
    0 // return an integer exit code
