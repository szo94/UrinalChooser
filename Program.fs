open System
open UrinalLogic

Console.WriteLine("Enter a row of urinals as 1s and 0s with 1s indicating 'Occupied' and 0s indicating 'Unoccupied': ")
let row =
    Console.ReadLine()
    |> Seq.map (fun c -> if c = '0' then 0 else 1)
    |> List.ofSeq

// print row
for urinal in row do
    match urinal with
    | 0 -> printf "[ ]"
    | _ -> printf "[x]"
printfn ""

try
    // get best urinal
    let bestUrinal = chooseUrinal row // throws exception if no unoccupied urinals

    // print arrow indicating best urinal
    for urinal in [ 0 .. row.Length-1 ] do
        match urinal with
        | _ when urinal = bestUrinal -> printf " ^ "
        | _ -> printf "   "
    printfn ""
with
    | _ as e -> printfn "Error: %s" e.Message