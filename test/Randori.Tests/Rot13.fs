module Tests

open Expecto
open System

[<Tests>]
let tests =
  testList "Rot13" [
    testCase "Oneway-Convert" <| fun _ ->
      Expect.equal
        ("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
        |> Randori.Rot13.convertSeq |> String.Concat)
        "nopqrstuvwxyzabcdefghijklmNOPQRSTUVWXYZABCDEFGHIJKLM"
        "Oneway Done."

    testCase "Round trip" <| fun _ ->
      Expect.equal
        ("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
        |> Randori.Rot13.convertSeq |> String.Concat
        |> Randori.Rot13.convertSeq |> String.Concat)
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
        "Round trip Done."

    testCase "Non-Alphabet" <| fun _ ->
      Expect.equal
        ("テスト表abcdefgÁÉÍÓÚÝÀÈÌÒÙÂÊÎÔÛÄËÏÖÜŸáéíóúýàèìòùâêîôûäëïöüÿÇŞÃÕÑĄĘĮŲÆŒØĲẞÞǷçşãõñąęįųæœøĳßþƿ"
        |> Randori.Rot13.convertSeq |> String.Concat)
        "テスト表nopqrstÁÉÍÓÚÝÀÈÌÒÙÂÊÎÔÛÄËÏÖÜŸáéíóúýàèìòùâêîôûäëïöüÿÇŞÃÕÑĄĘĮŲÆŒØĲẞÞǷçşãõñąęįųæœøĳßþƿ"
        "Non-Alphabet Done."
  ]
