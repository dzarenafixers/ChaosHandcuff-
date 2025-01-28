using Exiled.API.Interfaces;
using System.ComponentModel;

public class Config : IConfig
{
    [Description("Determines if the plugin is enabled or not.")]
    public bool IsEnabled { get; set; } = true;

    public bool Debug { get; set; }
}