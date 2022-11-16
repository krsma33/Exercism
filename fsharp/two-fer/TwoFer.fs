module TwoFer

let twoFer (input: string option): string =
    if  input = None then
        "One for you, one for me."
    else
        sprintf "One for %s, one for me." input.Value