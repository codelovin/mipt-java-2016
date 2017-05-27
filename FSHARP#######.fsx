open FSharp.Data
open System
open System.IO
open System.Net
open System.Text
open System.Collections.Specialized

let fpath = "./llab2/llab2.fs"

// Task 1
let readLines (path:string) = 
  File.ReadAllLines(path)
  |> Array.toList
  
// Testing task 1
let TASK1 = readLines fpath

// Task 3
let words (path:string) =
  let lines = File.ReadAllLines(path)
  lines
  |> Array.map (fun x -> x.Split([|' '; '.'; ','; ';'|]))
  |> Array.filter (fun x -> x.Length > 0)
  |> Array.concat
  |> Array.toList

// Testing task 3
let TASK3 = words fpath

// Task 2
// Считаем количество повторяющихся слов в данной строке
let getMaxWordFreq (line:string) =
  line.Split([|' '; '.'; ','; ';'|])
  |> Array.toList
  |> List.filter (fun x -> x.Length > 0)
  |> List.toSeq
  |> Seq.countBy id
  |> Seq.toList
  |> List.fold (fun sum (id, num) -> if num > 1 then sum + num else sum) 0

// Считаем строку с самым большим количеством повторяющихся слов
let countMaxLine (path:string) = 
  readLines path
  |> List.map (fun line -> (line, getMaxWordFreq line))
  |> List.fold (fun (line, max_) (new_line, new_max) -> if new_max > max_ then (new_line, new_max) else (line, max_)) ("", 0) 
  |> fst

// Тестируем
let TASK2 = countMaxLine fpath
