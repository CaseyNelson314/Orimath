﻿namespace Orimath.Basics.ViewModels
open System
open System.Collections.ObjectModel
open System.Windows.Media
open Mvvm
open Orimath.Plugins

type LayerViewModel(layer: ILayerModel, pointConverter: IViewPointConverter, dispatcher: IDispatcher) =
    inherit NotifyPropertyChanged()
    let points = new AttachedObservableCollection<_, _>(dispatcher, layer.Points, layer.PointChanged, (fun p -> PointViewModel(p, pointConverter)), ignore)
    let lines = new AttachedObservableCollection<_, _>(dispatcher, layer.Lines, layer.LineChanged, (fun l -> LineViewModel(l, pointConverter)), ignore)

    member __.Source = layer
    member val Edges = layer.Edges |> Seq.map(fun e -> EdgeViewModel(e, pointConverter))
    member val Vertexes =
        layer.Edges
        |> Seq.map(fun e -> 
            let p = pointConverter.ModelToView(e.Line.Point1)
            Windows.Point(p.X, p.Y))
        |> PointCollection
    member __.Points = points :> ObservableCollection<_>
    member __.Lines = lines :> ObservableCollection<_>

    member __.Dispose() = points.Dispose(); lines.Dispose()

    interface IDisposable with
        member this.Dispose() = this.Dispose()

    interface IDisplayTargetViewModel with
        member __.GetTarget() = DisplayTarget.Layer(layer)