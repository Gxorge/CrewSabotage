using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrewSabotage
{
    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    public static class PingPatch
    {
        public static void Postfix(PingTracker __instance)
        {
            __instance.text.Text = "Developer:\n- [CA4972FF]Gabriella#6859";
        }
    }
}
