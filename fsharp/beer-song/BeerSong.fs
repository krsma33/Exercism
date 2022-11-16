module BeerSong

let getDefaultVerse bottleNum =
    [ sprintf "%i bottles of beer on the wall, %i bottles of beer." bottleNum bottleNum;
      sprintf "Take one down and pass it around, %i bottles of beer on the wall." <| bottleNum - 1 ]

let getTwoBottleVerse =
    [ "2 bottles of beer on the wall, 2 bottles of beer.";
      "Take one down and pass it around, 1 bottle of beer on the wall."; ]

let getOneBottleVerse =
    [ "1 bottle of beer on the wall, 1 bottle of beer.";
      "Take it down and pass it around, no more bottles of beer on the wall."; ]

let getNoBottlesVerse =
    [ "No more bottles of beer on the wall, no more bottles of beer.";
      "Go to the store and buy some more, 99 bottles of beer on the wall." ]

let recite (startBottles: int) (takeDown: int) =
    [startBottles .. -1 .. (startBottles - takeDown + 1)]
    |> List.map (fun x ->
                    match x with
                    | _ when x = 2 -> getTwoBottleVerse
                    | _ when x = 1 -> getOneBottleVerse
                    | _ when x < 1 -> getNoBottlesVerse
                    | x -> getDefaultVerse x)
    |> List.reduce (fun x y -> List.append x (List.append [""] y))

