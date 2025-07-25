// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace FendExtension;

public partial class FendExtensionCommandsProvider : CommandProvider
{
    private readonly ICommandItem[] _commands;

    public FendExtensionCommandsProvider()
    {
        DisplayName = "Fend";
        Icon = IconHelpers.FromRelativePath("https://raw.githubusercontent.com/printfn/fend/main/icon/icon.svg");
        _commands = [
            new CommandItem(new FendExtensionPage()) { Title = DisplayName },
            new CommandItem(new ListPage()) { Title = "Settings" }
        ];
    }

    public override ICommandItem[] TopLevelCommands()
    {
        return _commands;
    }

}
