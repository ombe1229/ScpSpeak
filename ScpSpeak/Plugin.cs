using System;
using HarmonyLib;
using Features = Exiled.API.Features;
using Log = Exiled.API.Features.Log;
using Exiled.API.Enums;

namespace ScpSpeak
{
    public class ScpSpeak : Features.Plugin<Configs>
    {
        public Harmony Harmony { get; private set;  }
        
        public override string Name { get; } = "ScpSpeak";
        public override string Prefix { get; } = "ScpSpeak";
        public override string Author { get; } = "ombe1229";
        public override PluginPriority Priority { get; } = PluginPriority.Default;
        
        public override void OnEnabled()
        {
            if (!Config.IsEnabled) return;
            base.OnEnabled();
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
            base.OnDisabled();
            Harmony.UnpatchAll();
        }
    }
}