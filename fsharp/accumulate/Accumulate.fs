module Accumulate

let accumulate (func: 'a -> 'b) (input: 'a list): 'b list =
    let rec accu (acc:'b list) (l:'a list) =
        match l with 
            | [] -> List.rev acc                       
            | x::xs -> accu (func x::acc) xs
    accu (List<'b>.Empty) input