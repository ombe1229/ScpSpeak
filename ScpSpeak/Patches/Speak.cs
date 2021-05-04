﻿using System.Collections.Generic;
using Assets._Scripts.Dissonance;
using HarmonyLib;
using System.Linq;

namespace ScpSpeak.Patches
{
    [HarmonyPatch(typeof(DissonanceUserSetup), nameof(DissonanceUserSetup.CallCmdAltIsActive))]
    public class ScpSpeak
    {
        public static void Prefix(DissonanceUserSetup __instance, bool value)
        {
            CharacterClassManager ccm = __instance.gameObject.GetComponent<CharacterClassManager>();
            if (IsScp(ccm.CurClass)) __instance.MimicAs939 = value;
        }

        private static bool IsScp(RoleType role)
        {
            List<RoleType> scpList = new List<RoleType>
            {
                RoleType.Scp049, RoleType.Scp079, RoleType.Scp096, RoleType.Scp106, RoleType.Scp173, RoleType.Scp0492,
                RoleType.Scp93953, RoleType.Scp93989
            };
            return scpList.Contains(role);
        }
    }
}