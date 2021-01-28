using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrewSabotage
{
    public static class HudPatch
    {
        public static IUsable currentTarget;
        public static UseButtonManager instance;

        public static bool isImpostor() { return PlayerControl.LocalPlayer.Data.IsImpostor; }
    }

    [HarmonyPatch(typeof(UseButtonManager), nameof(UseButtonManager.DoClick))]
    public static class DoClickPatch
    {
        public static void Postfix(UseButtonManager __instance)
        {
            if (HudPatch.currentTarget != null)
            {
                PlayerControl.LocalPlayer.UseClosest();
            }
            else
            {
                MapBehaviour.Instance.ShowInfectedMap();
            }
        }
    }

    [HarmonyPatch(typeof(UseButtonManager), nameof(UseButtonManager.SetTarget))]
    public static class SetTargetPatch
    {
        public static void Postfix(UseButtonManager __instance, [HarmonyArgument(0)] IUsable target)
        {
            HudPatch.currentTarget = target;

            if (target == null)
            {
                if (!HudPatch.isImpostor()) // i dont wanna mess with it if they're already an impostor
                {
                    __instance.UseButton.sprite = __instance.SabotageImage;
                    __instance.UseButton.color = UseButtonManager.EnabledColor;
                } 
            }
        }
    }
}
