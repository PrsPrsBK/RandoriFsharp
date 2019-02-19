module Tests

open Expecto
open System

[<Tests>]
let tests =
  testList "Rot13" [
    testCase "Oneway-Convert" <| fun _ ->
      // need Fully Qualified Name like a `Randori.Rot13.foo`
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
        ("テスト表abcdefg0123456789ÁÉÍÓÚÝÀÈÌÒÙÂÊÎÔÛÄËÏÖÜŸáéíóúýàèìòùâêîôûäëïöüÿÇŞÃÕÑĄĘĮŲÆŒØĲẞÞǷçşãõñąęįųæœøĳßþƿ"
        |> Randori.Rot13.convertSeq |> String.Concat)
        "テスト表nopqrst0123456789ÁÉÍÓÚÝÀÈÌÒÙÂÊÎÔÛÄËÏÖÜŸáéíóúýàèìòùâêîôûäëïöüÿÇŞÃÕÑĄĘĮŲÆŒØĲẞÞǷçşãõñąęįųæœøĳßþƿ"
        "Non-Alphabet Done."
  ]
