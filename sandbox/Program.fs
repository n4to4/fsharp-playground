// What is F#

open System

let names = [ "Peter"; "Julia"; "Xi" ]

let getGreeting name = $"Hello, {name}"

names
|> List.map getGreeting
|> List.iter (fun greeting -> printfn $"{greeting}! Enjoy your F#")
