using System;
using Newtonsoft.Json;

namespace KrunchyToMAuto
{
	// Token: 0x0200000A RID: 10
	internal class SettingData
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00006F28 File Offset: 0x00005128
		// (set) Token: 0x06000071 RID: 113 RVA: 0x00006F30 File Offset: 0x00005130
		public bool AutoStart { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00006F39 File Offset: 0x00005139
		// (set) Token: 0x06000073 RID: 115 RVA: 0x00006F41 File Offset: 0x00005141
		public bool AutoMove { get; set; } = true;

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00006F4A File Offset: 0x0000514A
		// (set) Token: 0x06000075 RID: 117 RVA: 0x00006F52 File Offset: 0x00005152
		public bool AutoLeft { get; set; } = true;

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00006F5B File Offset: 0x0000515B
		// (set) Token: 0x06000077 RID: 119 RVA: 0x00006F63 File Offset: 0x00005163
		public bool AutoRight { get; set; } = true;

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00006F6C File Offset: 0x0000516C
		// (set) Token: 0x06000079 RID: 121 RVA: 0x00006F74 File Offset: 0x00005174
		public bool AutoStep { get; set; } = true;

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00006F7D File Offset: 0x0000517D
		// (set) Token: 0x0600007B RID: 123 RVA: 0x00006F85 File Offset: 0x00005185
		public bool AutoUltimate { get; set; } = true;

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00006F8E File Offset: 0x0000518E
		// (set) Token: 0x0600007D RID: 125 RVA: 0x00006F96 File Offset: 0x00005196
		public bool AutoRule { get; set; } = true;

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00006F9F File Offset: 0x0000519F
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00006FA7 File Offset: 0x000051A7
		public bool AutoImmortalSkill { get; set; } = true;

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00006FB0 File Offset: 0x000051B0
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00006FB8 File Offset: 0x000051B8
		public bool AutoHealthBackProp { get; set; } = true;

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00006FC1 File Offset: 0x000051C1
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00006FC9 File Offset: 0x000051C9
		public int HealthLowerRate { get; set; } = 50;

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00006FD2 File Offset: 0x000051D2
		// (set) Token: 0x06000085 RID: 133 RVA: 0x00006FDA File Offset: 0x000051DA
		public bool AutoBattleProp { get; set; } = true;

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00006FE3 File Offset: 0x000051E3
		// (set) Token: 0x06000087 RID: 135 RVA: 0x00006FEB File Offset: 0x000051EB
		public bool AutoPiscesPendant { get; set; } = true;

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00006FF4 File Offset: 0x000051F4
		// (set) Token: 0x06000089 RID: 137 RVA: 0x00006FFC File Offset: 0x000051FC
		public bool AutoGodEyeSkill { get; set; } = true;

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600008A RID: 138 RVA: 0x00007005 File Offset: 0x00005205
		// (set) Token: 0x0600008B RID: 139 RVA: 0x0000700D File Offset: 0x0000520D
		public bool AutoDevilDemonSkill { get; set; } = true;

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600008C RID: 140 RVA: 0x00007016 File Offset: 0x00005216
		// (set) Token: 0x0600008D RID: 141 RVA: 0x0000701E File Offset: 0x0000521E
		public bool AutoDevilDemonAbsorb { get; set; } = true;

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00007027 File Offset: 0x00005227
		// (set) Token: 0x0600008F RID: 143 RVA: 0x0000702F File Offset: 0x0000522F
		public int DemonAbsorbAtRate { get; set; } = 70;

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00007038 File Offset: 0x00005238
		// (set) Token: 0x06000091 RID: 145 RVA: 0x00007040 File Offset: 0x00005240
		public float TimeScale { get; set; } = 1f;

		// Token: 0x06000092 RID: 146 RVA: 0x00007049 File Offset: 0x00005249
		internal void SaveData()
		{
			g.data.obj.SetString("MOD_PFAutoBattle", "SettingData", JsonConvert.SerializeObject(this));
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000706C File Offset: 0x0000526C
		internal static SettingData GetSaveData()
		{
			SettingData settingData = null;
			if (g.data.obj.ContainsKey("MOD_PFAutoBattle", "SettingData"))
			{
				settingData = JsonConvert.DeserializeObject<SettingData>(g.data.obj.GetString("MOD_PFAutoBattle", "SettingData"));
			}
			if (settingData == null)
			{
				settingData = new SettingData();
			}
			return settingData;
		}
	}
}
