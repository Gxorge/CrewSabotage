using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using Reactor;

namespace CrewSabotage
{
    [BepInPlugin(Id)]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    public class CrewSabotage : BasePlugin
    {
        public const string Id = "me.gabriella.crewsabotage";

        public Harmony Harmony { get; } = new Harmony(Id);

        public ConfigEntry<string> Name { get; private set; }

        public static ManualLogSource log;

        public override void Load()
        {
            log = base.Log;
            Harmony.PatchAll();
            log.LogInfo("CrewSabotage is ready!");
        }
    }
}
