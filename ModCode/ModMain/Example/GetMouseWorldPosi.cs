using System;
using HarmonyLib;
using UnityEngine;

namespace KrunchyToMAuto
{
	// Token: 0x02000007 RID: 7
	[HarmonyPatch(typeof(GameEffectTool), "GetMouseWorldPosi")]
	public class GetMouseWorldPosi
	{
		// Token: 0x06000061 RID: 97 RVA: 0x000061E0 File Offset: 0x000043E0
		public static void Postfix(ref Vector2 __result)
		{
			if (SceneType.battle != null && SceneType.battle.battleMap != null && ModMain.IsEnableAutoSkills() && !SceneType.battle.battleMap.isPassRoom)
			{
				UnitCtrlBase nearUnit = AITool.GetNearEnemyUnit(SceneType.battle.battleMap.playerUnitCtrl);
				if (nearUnit != null)
				{
					__result = nearUnit.posiCenter.position;
				}
			}
		}
	}
}
