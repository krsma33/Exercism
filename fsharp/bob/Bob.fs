module Bob

open System

let response (input: string): string =
    match input with
    | x when String.IsNullOrWhiteSpace(x) -> "Fine. Be that way!"
    | x when x |> Seq.toArray
               |> Seq.filter(fun c -> Char.IsLetter c) 
               |> Seq.forall(fun c -> Char.IsUpper c) 
             && 
             x |> Seq.toArray 
               |> Seq.exists(fun c -> Char.IsLetter c) 
             && 
             x.Trim().EndsWith "?" -> "Calm down, I know what I'm doing!"
    | x when x.Trim().EndsWith "?" -> "Sure."   
    | x when x |> Seq.toArray
               |> Seq.filter(fun c -> Char.IsLetter c) 
               |> Seq.forall(fun c -> Char.IsUpper c) 
             && 
             x |> Seq.toArray 
               |> Seq.exists(fun c -> Char.IsLetter c) -> "Whoa, chill out!"
    | _ -> "Whatever."

