﻿using System;
using System.Reflection;

namespace BidenMod
{
	internal class LocalizationRewriter : ModSystem
	{
		public override void PostSetupContent()
		{
#if DEBUG
			MethodInfo refreshInfo = typeof(LocalizationLoader).GetMethod("UpdateLocalizationFilesForMod", BindingFlags.NonPublic | BindingFlags.Static, new Type[] { typeof(Mod), typeof(string), typeof(GameCulture) });
			refreshInfo.Invoke(null, new object[] { Mod, null, Language.ActiveCulture });
#endif
		}
	}

	internal static class LocalizationRoundabout
	{
		public static void SetDefault(this LocalizedText text, string value)
		{
#if DEBUG
			PropertyInfo valueProp = typeof(LocalizedText).GetProperty("Value", BindingFlags.Public | BindingFlags.Instance);

			LanguageManager.Instance.GetOrRegister(text.Key, () => value);
			valueProp.SetValue(text, value);
#endif
		}

		public static LocalizedText DefaultText(string key, string english)
		{
			LocalizedText text = Language.GetOrRegister($"Mods.BidenMod.{key}", () => english);
			text.SetDefault(english);

			return text;
		}
	}
}