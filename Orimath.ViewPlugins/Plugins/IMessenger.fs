﻿namespace Orimath.Plugins
open System
open System.Windows.Input

type ViewPane =
    | Main = 0
    | Top = 1
    | Side = 2
    | Dialog = 3   


type IMessenger =
    abstract member AddViewModel : viewModel: obj -> unit
    abstract member RemoveViewModel : viewModelType: Type -> unit
    abstract member RemoveViewModel : viewModel: obj -> unit
    abstract member RegisterView : viewPane: ViewPane * viewModelType: Type * viewType: Type -> unit
    abstract member RegisterView : viewPane: ViewPane * viewModelType: Type * viewUri: string -> unit
    abstract member SetEffectParameterViewModel<'ViewModel> : mapping: ('ViewModel -> obj) -> unit
    abstract member OpenDialog : viewModel: obj -> unit
    abstract member CloseDialog : unit -> unit
    abstract member CloseDialogCommand : ICommand
    abstract member GetEffectCommand : effect: IEffect -> ICommand
    abstract member SaveSetting : name: string * model: 'T -> unit
    abstract member LoadSetting : name: string -> 'T option
