// What is F#
// https://docs.microsoft.com/en-us/dotnet/fsharp/what-is-fsharp

open System

let names = [ "Peter"; "Julia"; "Xi" ]

let getGreeting name = $"Hello, {name}"

names
|> List.map getGreeting
|> List.iter (fun greeting -> printfn $"{greeting}! Enjoy your F#")

// Tour of F#
// https://docs.microsoft.com/en-us/dotnet/fsharp/tour

module BasicFunctions =
    let sampleFunction1 x = x * x + 3
    let result1 = sampleFunction1 4573
    printfn $"The result of squaring the integer 4573 and adding 3 is %d{result1}"

    let sampleFunction2 (x: int) = 2 * x * x - x / 5 + 3
    let result2 = sampleFunction2 (7 + 4)
    printfn $"The result of applying the 2nd sample function to (7 + 4) is %d{result2}"

    let sampleFunction3 x =
        if x < 100.0 then
            2.0 * x * x - x / 5.0 + 3.0
        else
            2.0 * x * x + x / 5.0 - 37.0

    let result3 = sampleFunction3 (6.5 + 4.5)
    printfn $"The result of applying the 3rd sample function to (6.5 + 4.5) is %f{result3}"

module Tuples =
    let sampleStructTuple = struct (1, 2)

    let convertFromStructTuple (struct (a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct (a, b)

module PipelinesAndComposition =
    let square x = x * x
    let addOne x = x + 1
    let isOdd x = x % 2 <> 0
    let numbers = [ 1; 2; 3; 4; 5 ]

    let squareOddValuesAndAddOne values =
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map (square >> addOne)

    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

module Lists =
    let daysList =
        [ for month in 1 .. 12 do
              for day in 1 .. DateTime.DaysInMonth(2017, month) do
                  yield DateTime(2017, month, day) ]

module RecursiveFunctions =
    let rec factorial n =
        if n = 0 then
            1
        else
            n * factorial (n - 1)

    let rec sumList xs =
        match xs with
        | [] -> 0
        | y :: ys -> y + sumList ys

    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | [] -> accumulator
        | y :: ys -> sumListTailRecHelper (accumulator + y) ys

    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [ 1 .. 10 ]
    printfn $"The sum 1-10 is %d{sumListTailRecursive oneThroughTen}"
