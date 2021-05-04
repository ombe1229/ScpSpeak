using Assets._Scripts.Dissonance;
using HarmonyLib;

namespace ScpSpeak.Patches
{
    [HarmonyPatch(typeof(DissonanceUserSetup), nameof(DissonanceUserSetup.CallCmdAltIsActive))]
    public class Speak
    {
        public static bool Prefix(DissonanceUserSetup __player, bool value)
        {
            CharacterClassManager classManager = __player.gameObject
        }
    }
}