module Allergies

open System

type Allergen =
    | Eggs
    | Peanuts
    | Shellfish
    | Strawberries
    | Tomatoes
    | Chocolate
    | Pollen
    | Cats

let allergenMap =
    [ 0, Eggs
      1, Peanuts
      2, Shellfish
      3, Strawberries
      4, Tomatoes
      5, Chocolate
      6, Pollen
      7, Cats ]
      |> Map

let log2 =
    function
    | 0. -> failwith("InvalidInput")
    | n -> Math.Log(n,2.)
    
let rec decode codedAllergies numList =
    match codedAllergies with
    | n when n > 0 -> 
                    let number = n |> float |> log2 |> int
                    let nextList = number::numList
                    let nextNum = n - (Math.Pow(2.,number |> float) |> int)
                    decode nextNum nextList
    | _ -> numList 

let decodeAndMap codedAllergies =
    let powers = decode codedAllergies List.empty
    match powers with
    | [] -> Map.empty
    | p -> p 
        |> List.filter ( fun i -> allergenMap.ContainsKey i )
        |> List.map ( fun i -> (i,allergenMap.[i]))
        |> Map.ofList

let allergicTo codedAllergies allergen =
    codedAllergies
    |> decodeAndMap
    |> Map.filter (fun k v -> v = allergen)
    |> Map.isEmpty = false

let list codedAllergies =
    codedAllergies
    |> decodeAndMap
    |> Map.toList
    |> List.map ( fun (x,y) -> y )