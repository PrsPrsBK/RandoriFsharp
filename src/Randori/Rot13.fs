namespace Randori

[<AutoOpen>]
module Rot13 =

  open System

  let rotAlphByte (b: byte): byte =
    if 0x40uy < b && b <= 0x5Auy then
      if 13uy + b < 0x5Buy then
        13uy + b
      else
        0x40uy + 13uy + b - 0x5Auy
    else if 0x60uy < b && b <= 0x7Auy then
      if 13uy + b < 0x7Buy then
        13uy + b
      else
        0x60uy + 13uy + b - 0x7Auy
    else
      b

  let (|Lower|Upper|Other|) (x: int) =
    if 0x41 <= x && x <= 0x5A then
      Lower x
    else if 0x61 <= x && x <= 0x7A then
      Upper x
    else
      Other // maybe 'Other x' is better. ActivePattern is wildly flexible.

  let rot13 (first: int) (last: int) (x: int) : int =
    [ first..last ].[(13 + (x - first)) % 26]

  // Rott13 $ abcテスト
  // printfn "%c %x %x" c (byte c) (int c)
  // a 61 61
  // b 62 62
  // c 63 63
  // テ c6 30c6
  // ス b9 30b9
  // ト c8 30c8
  // => nopA1E
  let convertCharAsByte (c: char) : char =
    // match box c with
    // | :? byte -> byte c |> rotAzByte |> char // :? not work
    // | _ -> c
    byte c |> rotAlphByte |> char

  let convertChar (c: char) : char =
    match int c with
    | Lower x -> (rot13 0x41 0x5A x) |> char
    | Upper x -> (rot13 0x61 0x7A x) |> char
    | Other -> c

  let convertSeq (sth: seq<char>) : seq<char> =
    Seq.map convertChar sth
  
  let printer (sth: seq<char>) =
    sth |> String.Concat |> printfn "%s"
  
  let rec looper () =
    stdout.Write("Rott13 $ ")
    let sth = stdin.ReadLine()
    match sth with
    | "q" -> ()
    | _ -> sth |> convertSeq |> printer |> looper
