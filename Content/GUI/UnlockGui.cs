using BidenMod.Content.Characters;
using BidenMod.Core.Loaders.UILoading;
using ReLogic.Graphics;
using System.Collections.Generic;
using Terraria.UI;
using Terraria.UI.Chat;

namespace BidenMod.Content.GUI
{
	public class UnlockGui : SmartUIState
	{
		public const int MAX_STATE = 1;

		public static bool visible;
		public static int fade = 0;
		public static int state = 0;

		string imagePath = "BidenMod/Assets/GUI/Biden1";
		string message = "You've unlocked 46th US President Joe Biden as a playable character! Press 'K' to switch between Joe and your main character. Joe has is own equipment, life, and inventory seperate from you.";

		UnlockButton button;

		public override bool Visible => visible;

		public override int InsertionIndex(List<GameInterfaceLayer> layers)
		{
			return layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
		}

		public override void OnInitialize()
		{
			button = new(this);
			button.Left.Set(-40, 0.5f);
			button.Top.Set(100, 0.5f);
			button.OnLeftClick += (a, b) => Advance();
			Append(button);
		}

		public static void Display()
		{
			visible = true;
			state = 0;
			fade = 0;

			// debug
			UILoader.GetUIState<UnlockGui>().RemoveAllChildren();
			UILoader.GetUIState<UnlockGui>().OnInitialize();
		}

		public static void Advance()
		{
			state++;

			if (state >= MAX_STATE)
				Main.LocalPlayer.GetModPlayer<BidenTracker>().isBidenUnlocked = true;
		}

		public override void SafeUpdate(GameTime gameTime)
		{
			if ( state < MAX_STATE && fade < 60)
				fade++;
			else if (state >= MAX_STATE)
				fade--;

			if (state >= MAX_STATE && fade <= 0)
				visible = false;

			Recalculate();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			var tex = ModContent.Request<Texture2D>("BidenMod/Assets/MagicPixel").Value;
			var opacity = fade / 60f;

			spriteBatch.Draw(tex, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Black * (opacity * 0.6f));

			Color boxColor = new Color(49, 84, 141) * 0.9f;

			int yOff = -220;

			var image = ModContent.Request<Texture2D>(imagePath).Value;
			yOff += image.Height + 10;

			DynamicSpriteFont font = Terraria.GameContent.FontAssets.MouseText.Value;
			string wrapped = Helpers.GUIHelper.WrapString(message, 360, font, 1);
			yOff += (int)ChatManager.GetStringSize(font, wrapped, Vector2.One).Y;

			Rectangle center = new Rectangle(Main.screenWidth / 2 - 200, Main.screenHeight / 2 - 220, 400, 220 + yOff);
			Rectangle titlebar = new Rectangle(Main.screenWidth / 2 - 200, Main.screenHeight / 2 - 300, 400, 60);

			Helpers.GUIHelper.DrawBox(spriteBatch, center, new Color(30, 60, 100) * 0.8f * opacity);

			Helpers.GUIHelper.DrawBox(spriteBatch, titlebar, boxColor * opacity);
			Utils.DrawBorderStringBig(spriteBatch, "BIDEN UNLOCKED", titlebar.Center.ToVector2(), Color.White * opacity, 0.8f, 0.5f, 0.3f);

			spriteBatch.End();
			spriteBatch.Begin(default, BlendState.NonPremultiplied, default, default, default, default, Main.UIScaleMatrix);

			spriteBatch.Draw(image, center.TopLeft(), Color.White * opacity);

			spriteBatch.End();
			spriteBatch.Begin(default, default, default, default, default, default, Main.UIScaleMatrix);

			Utils.DrawBorderString(spriteBatch, wrapped, center.TopLeft() + new Vector2(10, image.Height + 10), Color.White * opacity, 0.9f);

			button.Top.Set(yOff + 10, 0.5f);
			Recalculate();

			base.Draw(spriteBatch);
		}
	}

	public class UnlockButton : SmartUIElement
	{
		UnlockGui parent;

		public UnlockButton(UnlockGui parent)
		{
			Width.Set(80, 0);
			Height.Set(30, 0);
			this.parent = parent;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			Color boxColor = new Color(49, 84, 141) * 0.9f;
			var opacity = UnlockGui.fade / 60f;

			Helpers.GUIHelper.DrawBox(spriteBatch, GetDimensions().ToRectangle(), boxColor * opacity);
			Utils.DrawBorderString(spriteBatch, "Next", GetDimensions().Center(), Color.White * opacity, 1, 0.5f, 0.4f);
		}
	}
}