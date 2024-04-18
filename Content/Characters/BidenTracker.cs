using BidenMod.Core.Systems.PlayableCharacterSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.IO;

namespace BidenMod.Content.Characters
{
	internal class BidenTracker : ModPlayer
	{
		public bool isBidenUnlocked = false;

		public static ModKeybind swapButton;
		public int swapCooldown;

		public override void Load()
		{
			swapButton = KeybindLoader.RegisterKeybind(Mod, "Swap character", Microsoft.Xna.Framework.Input.Keys.K);
		}

		public override void PostUpdate()
		{
			if (isBidenUnlocked && swapButton.JustReleased && swapCooldown <= 0)
			{
				if (Player.GetModPlayer<PlayableCharacterPlayer>().isMainCharacter)
					Player.GetModPlayer<PlayableCharacterPlayer>().Swap<JoeBiden>();
				else
					Player.GetModPlayer<PlayableCharacterPlayer>().SwapToMain();

				swapCooldown = 3600;
			}

			if (swapCooldown > 0)
				swapCooldown--;
		}

		public override void SaveData(TagCompound tag)
		{
			tag.Add("isBidenUnlocked", isBidenUnlocked);
		}

		public override void LoadData(TagCompound tag)
		{
			isBidenUnlocked = tag.GetBool("isBidenUnlocked");
		}
	}
}
