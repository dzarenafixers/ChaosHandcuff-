using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace  ChaosHandcuff .Handlers  
{
    public class PlayerHandler
    {
        public void OnHandcuffing(HandcuffingEventArgs ev)
        {
            // Check if the player doing the handcuffing is a Chaos Insurgent and the target is a Facility Guard
            if (ev.Player.Role == RoleTypeId.ChaosConscript && ev.Target.Role == RoleTypeId.FacilityGuard)
            {
                ev.IsAllowed = true;
                ev.Target.Handcuff ();
                ev.Player.ShowHint("You have handcuffed the Facility Guard!");
            }
        }

        public void OnEscaping(EscapingEventArgs ev)
        {
            // Check if the escaping player is a Facility Guard and is cuffed
            if (ev.Player.Role == RoleTypeId.FacilityGuard && ev.Player.IsCuffed)
            {
                ev.IsAllowed = false;
                ev.Player.Role.Set(RoleTypeId.ChaosConscript);
                ev.Player.ShowHint("You have escaped as a Chaos Insurgent!");
            }
        }
    }
}