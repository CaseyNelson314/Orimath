﻿using System;
using System.Collections.Generic;
using Orimath.FoldingInstruction.View.ViewModels;
using Orimath.Plugins;

namespace Orimath.FoldingInstruction.View
{
    [OrimathPlugin("折り図ビュー", "メインビューの上に折り図を表示します。対応しているツールの操作時に折り図風の図が表示されます。")]
    public class FoldingInstructionPlugin : IViewPlugin
    {
        public void Execute(ViewPluginArgs args)
        {
            args.Messenger.AddViewModel(new FoldingInstructionViewModel(args.Workspace, args.Dispatcher, args.PointConverter));
        }
    }
}
