using BidenMod.Content.Characters;
using BidenMod.Core.Loaders.UILoading;
using ReLogic.Graphics;
using System.Collections.Generic;
using Terraria.UI;
using Terraria.UI.Chat;
using System.Linq;
using Terraria.GameContent;
using BidenMod.Core.Systems.PlayableCharacterSystem;

namespace BidenMod.Content.GUI
{
	internal class StartCampaignButton : SmartUIState
	{
		CampaignButton button;

		public override bool Visible => true;

		public override int InsertionIndex(List<GameInterfaceLayer> layers)
		{
			return layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
		}

		public override void OnInitialize()
		{
			button = new();
			Append(button);
		}

		public override void SafeUpdate(GameTime gameTime)
		{
			if (Main.LocalPlayer.GetModPlayer<PlayableCharacterPlayer>().playingAs is JoeBiden && Main.PylonSystem.Pylons.Any(n => Vector2.Distance(n.PositionInTiles.ToVector2() * 16, Main.LocalPlayer.Center) < 500))
			{
				var pylon = Main.PylonSystem.Pylons.FirstOrDefault(n => Vector2.Distance(n.PositionInTiles.ToVector2() * 16, Main.LocalPlayer.Center) < 500);

				Vector2 pos = pylon.PositionInTiles.ToVector2() * 16 - Main.screenPosition;
				button.Left.Set(pos.X - 50 + 24, 0);
				button.Top.Set(pos.Y - 64 - 50, 0);
				Recalculate();
			}
		}
	}

	internal class CampaignButton : SmartUIElement
	{
		public CampaignButton()
		{
			Width.Set(100, 0);
			Height.Set(100, 0);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			Helpers.GUIHelper.DrawBox(spriteBatch, GetDimensions().ToRectangle());
		}

		public override void SafeClick(UIMouseEvent evt)
		{
			Main.NewText("Its joe time!");
		}
	}
}
