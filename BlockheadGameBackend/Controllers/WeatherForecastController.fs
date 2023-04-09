﻿namespace BlockheadGameBackend.Controllers

open System
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open BlockheadGameBackend

[<ApiController>]
[<Route("[controller]")>]
type WeatherForecastController(logger: ILogger<WeatherForecastController>) =
    inherit ControllerBase()

    let summaries =
        [| "Freezing"
           "Bracing"
           "Chilly"
           "Cool"
           "Mild"
           "Warm"
           "Balmy"
           "Hot"
           "Sweltering"
           "Scorching" |]

    [<HttpGet>]
    member _.Get() =
        let rng = Random()

        [| for index in 0..4 ->
               { Date = DateTime.Now.AddDays(float index)
                 TemperatureC = rng.Next(-20, 55)
                 Summary = summaries.[rng.Next(summaries.Length)] } |]

    [<HttpGet("/field")>]
    member _.Field() = Field.createField (Seq.toList "АНОНС")

    [<HttpGet("/words")>]
    member _.Words() =
        Dictionary.wordsOfLength 5 Dictionary.readDictionary