// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using FendExtension.Commands;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace FendExtension;

internal sealed partial class FendExtensionPage : DynamicListPage
{
    private readonly Lock _resultsLock = new();
    //private readonly SettingsManager _settingsManager;
    private readonly List<ListItem> _items = [new ListItem(new AnonymousCommand(null) { Result = CommandResult.KeepOpen() }) { Title = "Keep the palette open" }];
    private readonly List<ListItem> history = [];
    private ListItem _item;
    private string query;

    public FendExtensionPage()
    {
        Icon = new IconInfo(string.Empty);
        Title = "Fend";
        Name = "Open UP";
        query = SearchText; 
    }

    public override IListItem[] GetItems()
    {
        return [new ListItem(new PromptCommand(InvokeFend()) { })];
    }

    public string InvokeFend()
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "C:\\Program Files\\fend\\bin\\fend.exe",
            Arguments = SearchText,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };
        Process p = new Process();
        p.StartInfo = psi;
        p.Start();
        string output = p.StandardOutput.ReadToEnd().TrimEnd();
        p.WaitForExit();
        return output;
    }

    public override void UpdateSearchText(string _, string newSearch) => RaiseItemsChanged();
}
