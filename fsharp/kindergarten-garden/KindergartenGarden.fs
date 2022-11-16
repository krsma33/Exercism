module KindergartenGarden

open System.Text

type Plant =
    | Radishes
    | Clover
    | Grass
    | Violets

let getPlantFromAcronym =
    function
    | 'R' -> Radishes
    | 'C' -> Clover
    | 'G' -> Grass
    | 'V' -> Violets
    | _ -> failwith "Not Implemented"

let getIndicesForStudent =
    function
    | "Alice" -> (0,1)
    | "Bob" -> (2,3)
    | "Charlie" -> (4,5)
    | "David" -> (6,7)
    | "Eve" -> (8,9)
    | "Fred" -> (10,11)
    | "Ginny" -> (12,13)
    | "Harriet" -> (14,15)
    | "Ileana" -> (16,17)
    | "Joseph" -> (18,19)
    | "Kincaid" -> (20,21)
    | "Larry" -> (22,23)
    | _ -> failwith "Not Implemented"

let getBothRows (input:string) =
    let rows = input.Split('\n')
    (rows.[0] |> Seq.toList, rows.[1] |> Seq.toList)

let getPlants (row1:char list,row2:char list) (i1,i2) =
    [ row1.[i1]; 
      row1.[i2];
      row2.[i1];
      row2.[i2] ]
    |> List.map getPlantFromAcronym

let plants diagram student =
    diagram
    |> getBothRows
    |> getPlants <| getIndicesForStudent student

