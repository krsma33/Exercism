module GradeSchool

type School = Map<int, string list>

let empty: School = Map.empty

let add (student: string) (grade: int) (school: School): School =
    match school.TryFind(grade) with
    | None -> school.Add(grade, [student])
    | Some a -> school.Change(grade, fun x -> Option.Some(student::x.Value))

let grade (number: int) (school: School): string list =
    match school.TryFind(number) with
    | None -> []
    | Some a -> school.[number]

let roster (school: School): string list =
    match school with
    | s when s.IsEmpty -> []
    | s -> s
        |> Map.toList
        |> List.map(fun (x,y) -> y |> List.sort)
        |> List.reduce(fun s d -> s @ d)
