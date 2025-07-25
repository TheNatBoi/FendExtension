using Microsoft.CommandPalette.Extensions.Toolkit;


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
