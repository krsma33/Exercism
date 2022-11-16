module OcrNumbers

let zero = 
    [ " _ ";
      "| |";
      "|_|";
      "   " ]

let one = 
    [ "   ";
      "  |";
      "  |";
      "   " ]

let two = 
    [ " _ ";
      " _|";
      "|_ ";
      "   " ]

let three = 
    [ " _ ";
      " _|";
      " _|";
      "   " ]

let four = 
    [ "   ";
      "|_|";
      "  |";
      "   " ]

let five = 
    [ " _ ";
      "|_ ";
      " _|";
      "   " ]

let six = 
    [ " _ ";
      "|_ ";
      "|_|";
      "   " ]

let seven = 
    [ " _ ";
      "  |";
      "  |";
      "   " ]

let eight = 
    [ " _ ";
      "|_|";
      "|_|";
      "   " ]

let nine = 
    [ " _ ";
      "|_|";
      " _|";
      "   " ]

let numbers = [ zero; one; two; three; four; five; six; seven; eight; nine; ]

let properCols = 3
let properRows = 4

let rec sliceString (text:string) sliceSize acc =
    match text with
    | s when s.Length < sliceSize -> acc |> List.rev
    | s -> let (h,t) = (s.[0 .. sliceSize-1],s.[sliceSize..])
           let acc' = h::acc
           sliceString t sliceSize acc'

let recombine (input:string list list) =
    input
    |> List.fold (fun x y -> (y |> List.indexed |> Map) |> Map.map (fun k v -> if (x |> Map.containsKey k) then v::x.[k] else [v]) ) Map.empty
    |> Map.toList
    |> List.map (fun (_,y) -> y |> List.rev)

let combineAndMapSingleRow (input:string list) =
    input
    |> List.map (fun x -> sliceString x properCols List.empty )
    |> recombine
    |> List.map (fun x -> let index = numbers |> List.tryFindIndex(fun y -> y = x)
                          match index with
                          | None -> "?"
                          | Some n -> n |> string)
    |> List.reduce (fun x y -> x + y)

let combineAndMap (input:string list) =
    input
    |> List.splitInto(input.Length / properRows)
    |> List.map (fun x -> x |> combineAndMapSingleRow)
    |> List.reduce(fun acc s -> acc + "," + s)

       
let convert (input:string list) =
    match input with
    | l when l.Length % properRows <> 0 -> None
    | l when l |> List.exists (fun s -> s.Length % properCols <> 0) -> None
    | l -> l |> combineAndMap |> Some
   



