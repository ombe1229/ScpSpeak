using Features = Exiled.API.Features;
using Log = Exiled.API.Features.Log;

namespace ScpSpeak
{
    public class ScpSpeak : Features.Plugin<Configs>
    {
        private EventHandlers EventHandlers { get; set; }

        private void LoadEvents()
        {
            
        }

        public override void OnEnabled()
        {
            if (!Config.IsEnabled) return;
            Log.Info("Plugin is enabled.");
            EventHandlers = new EventHandlers(this);
            LoadEvents();
        }

        public override void OnDisabled()
        {
            
        }
    }
}