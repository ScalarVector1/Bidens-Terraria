using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidenMod.Core.CampaignSystem
{
	internal class Voter : GlobalNPC
	{
		public Dictionary<string, float> beliefs = new();

		public override bool InstancePerEntity => true;

		public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
		{
			return entity.townNPC;
		}

		public void Reset()
		{
			beliefs.Clear();
			beliefs.Add("ServicesVsTaxes", 0);
			beliefs.Add("FreedomVsSafety", 0);
			beliefs.Add("WealthVsGrowth", 0);
			beliefs.Add("IndividualVsIdeal", 0);
			beliefs.Add("DeontologyVsUtilitarianism", 0);
			beliefs.Add("GeneralAppeal", 0);
		}
	}
}
