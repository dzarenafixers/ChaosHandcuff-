using System;
using Exiled.API.Features;
using PlayerRoles;
using PlayerHandler =   ChaosHandcuff.Handlers.PlayerHandler;

public class ChaosHandcuffPlugin : Plugin<Config>
{
    public override string Name => "ChaosHandcuffPlugin";
    public override string Author => "dzarenafixers*moncef50g";
    public override Version RequiredExiledVersion => new Version(9, 5, 0);

    public PlayerHandler PlayerHandler { get; private set; }

    public override void OnEnabled()
    {
        base.OnEnabled();

        PlayerHandler = new PlayerHandler();
        Exiled.Events.Handlers.Player.Handcuffing += PlayerHandler.OnHandcuffing;
        Exiled.Events.Handlers.Player.Escaping += PlayerHandler.OnEscaping;
    }

    public override void OnDisabled()
    {
        base.OnDisabled();

        Exiled.Events.Handlers.Player.Handcuffing -= PlayerHandler.OnHandcuffing;
        Exiled.Events.Handlers.Player.Escaping -= PlayerHandler.OnEscaping;
        PlayerHandler = null;
    }
}