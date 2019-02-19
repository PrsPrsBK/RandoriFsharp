module Tests

open Expecto
open System

[<Tests>]
let tests =
  testList "Rot13" [
    testCase "Test Case 1" <| fun _ ->
      Expect.equal
        ("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
        |> Randori.Rot13.convertSeq |> String.Concat)
        "nopqrstuvwxyzabcdefghijklmNOPQRSTUVWXYZABCDEFGHIJKLM"
        "Oneway Done."
  ]
