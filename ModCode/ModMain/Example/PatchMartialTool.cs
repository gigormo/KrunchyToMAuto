using System;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;

namespace KrunchyToMAuto
{
    // Token: 0x02000008 RID: 8
    [HarmonyPatch(typeof(MartialTool), "IsMouseDownSkill")]
    public class PatchMartialTool
    {
        public static void Postfix(ref bool __result, SkillBase skillBase)
        {
            if (!ModMain.IsEnableAutoSkills() || SceneType.battle.battleMap.isPassRoom)
            {
                return;
            }

            List<SkillAttack>.Enumerator enumerator = SceneType.battle.battleMap.playerUnitCtrl.skills.GetEnumerator();
            while (enumerator.MoveNext())
            {
                SkillAttack current = enumerator.Current;
                if (skillBase.data.mainSkillID == current.data.mainSkillID)
                {
                    __result = true;
                    break;
                }
            }
        }
    }
}
