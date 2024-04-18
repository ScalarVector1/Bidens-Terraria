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
			UnlockGui.Display();
			return true;
		}
	}
}