using System;
using HarmonyLib;
using Features = Exiled.API.Features;
using Log = Exiled.API.Features.Log;

namespace ScpSpeak
{
    public class ScpSpeak : Features.Plugin<Configs>
    {
        public Harmony Harmony { get; private set;  }

        public override void OnEnabled()
        {
            if (!Config.IsEnabled) return;
            Log.Info("Plugin is enabled.");
            try
            {
                Harmony = new Harmony($"com.ombe1229.ScpSpeak.{DateTime.Now.Ticks}");
                Harmony.PatchAll();
            }
            catch (Exception e)
            {
                Log.Error($"Patching failed: {e.ToString()}");
            }
        }

        public override void OnDisabled()
        {
            Harmony.UnpatchAll();
        }
    }
}