module RobotSimulator

type Direction = North | East | South | West
type Position = int * int
type Robot = { direction: Direction; position: Position }

let changeDirectionRight robot =
    match robot.direction with
    | North -> East
    | East -> South
    | South -> West
    | West -> North

let changeDirectionLeft robot =
    match robot.direction with
    | North -> West
    | West -> South
    | South -> East
    | East -> North

let robotMove robot =
    let (x,y) = robot.position
    match robot.direction with
    | North -> (x,y+1)
    | West -> (x-1,y)
    | South -> (x,y-1)
    | East -> (x+1,y)

let parseInstruction instruction robot =
    match instruction with
    | 'R' -> { robot with direction = robot |> changeDirectionRight}
    | 'L' -> { robot with direction = robot |> changeDirectionLeft}
    | 'A' -> { robot with position = robot |> robotMove}
    | _ -> failwith "Unknown command"

let rec executeInstructions instructions robot =
    match instructions with
    | [] -> robot
    | (h::t) -> 
        robot 
        |> parseInstruction h
        |> executeInstructions t

let create direction position =
    { direction = direction; position = position}

let move instructions robot =
    let i = instructions |> Seq.toList
    robot
    |> executeInstructions i

