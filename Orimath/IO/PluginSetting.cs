﻿using System;

namespace Orimath.IO
{
    public sealed class PluginSetting
    {
        public string[] PluginOrder { get; set; } = Array.Empty<string>();

        public string[] ViewPluginOrder { get; set; } = Array.Empty<string>();
    }
}