using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidenMod.Core.CampaignSystem
{
	internal class Question
	{
		string question;

		public Answer[] answers = new Answer[4];

		public Question(string question)
		{
			this.question = question;
		}
	}

	internal class Answer
	{
		public string answer;

		public Dictionary<string, float> scores = new();

		public Answer(string answer)
		{
			this.answer = answer;
			Reset();
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
