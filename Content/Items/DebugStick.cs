using BidenMod.Content.GUI;

namespace BidenMod.Content.Items
{
	public class DebugStick : ModItem
	{
		public override string Texture => "BidenMod/Assets/MagicPixel";

		public override void SetDefaults()
		{
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = 1;
		}

		public override bool? UseItem(Player player)
		{
			Main.NewText(player.hair);
			Main.NewText(player.hairColor);
			Main.NewText(player.skinColor);
			Main.NewText(player.eyeColor);
			Main.NewText(player.shirtColor);
			Main.NewText(player.shoeColor);
			Main.NewText(player.skinVariant);

			UnlockGui.Display();
			return true;
		}
	}
}