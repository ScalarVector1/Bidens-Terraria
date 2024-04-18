using BidenMod.Core.Systems.PlayableCharacterSystem;

namespace BidenMod.Content.Characters
{
	public class JoeBiden : PlayableCharacter
	{
		public override string Name => "Joe Biden";

		public override void Setup()
		{
			// Bidens appearance
			player.hair = 115;
			player.hairColor = new Color(239, 235, 229);
			player.skinColor = new Color(244, 176, 161);
			player.eyeColor = new Color(37, 101, 224);
			player.shirtColor = new Color(71, 68, 83);
			player.pantsColor = new Color(71, 68, 83);
			player.underShirtColor = Color.White;
			player.shoeColor = new Color(110, 72, 41);
			player.skinVariant = 3;

			player.name = "Joe Biden";

			player.GetModPlayer<BidenTracker>().isBidenUnlocked = true;
		}

		public override void PreUpdate()
		{
			player.statManaMax2 = 0;

			player.accRunSpeed += 0.8f;
			player.maxRunSpeed += 0.8f;

			if (player.jump > 6)
				player.jump = 6;
		}
	}
}