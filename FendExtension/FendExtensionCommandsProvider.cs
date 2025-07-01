// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using Windows.Web.Http.Filters;

namespace FendExtension;

public partial class FendExtensionCommandsProvider : CommandProvider
{
    private readonly ICommandItem[] _commands;

    public FendExtensionCommandsProvider()
    {
        DisplayName = "Fend";
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png");
        _commands = [
            new CommandItem(new FendExtensionPage()) { Title = DisplayName },
            //new CommandItem(
            //    title: "Fend Settings",
            //    action: )
        ];
    }

    public override ICommandItem[] TopLevelCommands()
    {
        return _commands;
    }

}
