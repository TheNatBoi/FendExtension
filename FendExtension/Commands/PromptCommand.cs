using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using Microsoft.UI.Windowing;


namespace FendExtension.Commands
{
    internal sealed partial class PromptCommand : InvokableCommand
    {
        public PromptCommand(string result)
        {
            Name = result;
            Icon = new IconInfo("Assets\\StoreLogo.png");
        }
    }
}
