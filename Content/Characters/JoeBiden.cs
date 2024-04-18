using BidenMod.Core.Systems.PlayableCharacterSystem;

namespace BidenMod.Content.Characters
{
	public class JoeBiden : PlayableCharacter
	{
		public override string Name => "Joe Biden";

		public override void PreUpdate()
		{
			player.statManaMax2 = 0;
		}
	}
}