using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidenMod.Core.CampaignSystem
{
	internal class Voter : GlobalNPC
	{
		public Dictionary<string, float> scores = new();

		public override bool InstancePerEntity => true;

		public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
		{
			return entity.townNPC;
		}

		public void Reset()
		{
			scores.Clear();
			scores.Add("ServicesVsTaxes", 0);
			scores.Add("FreedomVsSafety", 0);
			scores.Add("WealthVsGrowth", 0);
			scores.Add("IndividualVsIdeal", 0);
			scores.Add("DeontologyVsUtilitarianism", 0);
			scores.Add("GeneralAppeal", 0);
		}
	}
}
