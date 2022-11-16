module Clock

type Minutes = Minutes of int

type Hours = Hours of int

type Clock = {
    Hours:Hours
    Minutes:Minutes
}

let private clockCreate (hours,minutes) =
    { Hours = Hours <| hours; Minutes = Minutes <| minutes }

let private deconstructClock { Hours = h; Minutes = m} =
    let deconstructHoursMinutes (Hours h') (Minutes m') =
        (h',m')
    deconstructHoursMinutes h m

let private normalizeHoursAndMinutes (h,m) =
    let m' = m % 60
    let h' = h + m / 60
    (h' % 24, m')

let rec private calculateAbsoluteHoursAndMinutes =
    function
    | (h,m) when h < 0 && m < 0 -> (24 + h - 1, 60 + m ) |> calculateAbsoluteHoursAndMinutes
    | (h,m) when h >= 0 && m < 0 -> (h - 1, 60 + m) |> calculateAbsoluteHoursAndMinutes
    | (h,m) when h < 0 && m >= 0 -> (24 + h, m) |> calculateAbsoluteHoursAndMinutes
    | (h,m) -> (h,m)

let private addMinutes m' (h,m) =
    (h,m+m')

let private calculateClock (h,m) =
    (h,m)
    |> normalizeHoursAndMinutes
    |> calculateAbsoluteHoursAndMinutes
    |> clockCreate

let create hours minutes =
    (hours, minutes)
    |> calculateClock

let add minutes clock =
    clock
    |> deconstructClock
    |> addMinutes minutes
    |> calculateClock

let subtract minutes clock =
    clock
    |> add -minutes

let display clock = 
    clock
    |> deconstructClock
    |> fun (h,m) -> sprintf "%02d:%02d" h m