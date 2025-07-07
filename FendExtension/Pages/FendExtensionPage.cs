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
    private List<ListItem> _items = [];
    private readonly List<ListItem> history = [];
    private ListItem _item;
    private string query;

    public FendExtensionPage()
    {
        Icon = new IconInfo("https://raw.githubusercontent.com/printfn/fend/main/icon/icon.svg");
        Title = "Fend";
        Name = "Open";
        query = SearchText; 
    }

    public override IListItem[] GetItems()
    {
        if (string.IsNullOrEmpty(SearchText))
        {
            if (_items == null)
            {
                return [];
            }
            return _items.ToArray();
        }
        else if (string.IsNullOrEmpty(InvokeFend()))
        {
            if (_items == null)
            {
                return [];
            }
            return _items.ToArray();
        }
        else
        {
            return [
            new ListItem(new CopyTextCommand(InvokeFend()) { Result = CommandResult.ShowToast("Copied to clipboard") })
            {
                Title = InvokeFend(),
                Subtitle = "Copy result to clipboard",
                Icon = new IconInfo("https://raw.githubusercontent.com/printfn/fend/main/icon/icon.svg")
            }
            ];
        }
    }

    public string InvokeFend()
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "fend.exe",
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
