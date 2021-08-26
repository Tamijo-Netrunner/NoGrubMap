using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using Modding;


namespace NoGrubMap
{
    /// <summary>
    /// Disables Collector's Map. Can be disabled from mod menu.
    /// </summary>
    public class NoGrubMap : Mod, ITogglableMod
    {

        public override string GetVersion() => "1.0";

        // Hook to GetPlayerBoolHook
        public override void Initialize() {
            Log("Disabling Collector's Map");
            ModHooks.Instance.GetPlayerBoolHook += PlayerBoolGet;
        }

        // Unhook from GetPlayerBoolHook
        public void Unload() {
            Log("Allowing Collector's Map");
            ModHooks.Instance.GetPlayerBoolHook -= PlayerBoolGet;
        }

        // Overrides Collector's Map bool gets.
        public bool PlayerBoolGet(string target) {

            switch (target) {
                // Prevent game from reading Collector's Map
                case "hasPinGrub":
                    return false;
                
                // Allow other bools through
                default:
                    return PlayerData.instance.GetBoolInternal(target);
            }            
        }
    }
}
