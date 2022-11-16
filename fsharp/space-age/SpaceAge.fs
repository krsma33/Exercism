module SpaceAge

type Planet =
    | Earth
    | Mercury 
    | Venus
    | Mars
    | Jupiter
    | Saturn
    | Uranus
    | Neptune

let age (planet: Planet) (seconds: int64): float =
    
    let earthYears = float seconds / 31557600.0
    let calculate factor = earthYears / factor

    match planet with
    | Earth -> calculate 1.0
    | Mercury -> calculate 0.2408467
    | Venus -> calculate 0.61519726
    | Mars -> calculate 1.8808158
    | Jupiter -> calculate 11.862615
    | Saturn -> calculate 29.447498
    | Uranus -> calculate 84.016846
    | Neptune -> calculate 164.79132