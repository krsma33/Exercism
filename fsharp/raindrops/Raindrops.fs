module Raindrops

let factors =
    [ (3, "Pling")
      (5, "Plang")
      (7, "Plong") ]


let convert (number: int): string =
    let result =
        List.fold (fun acc (num, str) -> if number % num = 0 then acc + str else acc) "" factors

    if result = "" then number.ToString() else result

let result = convert 2679