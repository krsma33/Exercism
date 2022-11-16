module QueenAttack

let chessBoard = Array2D.init 8 8 (fun x y -> (x+1,y+1))

let create (position: int * int) =
    match position with
        | x,y when x >= 0 && x < 8 && y >= 0 && y < 8 -> true
        | _ -> false

let substractPositions ((x1,y1): int*int) ((x2,y2): int*int) = 
    (x1-x2 |> abs,y1-y2 |> abs)

let canAttack (queen1: int * int) (queen2: int * int) =
    let diff = substractPositions queen1 queen2
    match diff with
        | (x,y) when x = 0 || y = 0 || x=y -> true
        | _ -> false