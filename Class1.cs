using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using Logger = Rocket.Core.Logging.Logger;


namespace EgnBlockWheel
{
    public class Class1 :  RocketPlugin<Config>
    {
        public Class1 Instance;
        protected override void Load()
        {
            base.Load();
            Instance = this;
            Logger.Log("-=Plugin By: Margarita#8172", ConsoleColor.Yellow);

            VehicleManager.onDamageTireRequested += DestroyWheel;
        }

        private void DestroyWheel(CSteamID instigatorSteamID, InteractableVehicle vehicle, int tireIndex, ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            UnturnedPlayer player = UnturnedPlayer.FromCSteamID(instigatorSteamID);

            if (damageOrigin == EDamageOrigin.Useable_Gun & Configuration.Instance.Armas_Pueden_Destruir_Ruedas || damageOrigin == EDamageOrigin.Useable_Melee & Configuration.Instance.Melee_Pueden_Destruir_Ruedas)
            {
                if (player.HasPermission(Configuration.Instance.Permiso))
                {
                    shouldAllow = true;
                }
                else
                {
                    shouldAllow = false;
                    return;
                }
            }
            else
            {
                shouldAllow = false;
                return;
            }

        }

        protected override void Unload()
        {
            Instance.UnloadPlugin();

        }
    }
}
