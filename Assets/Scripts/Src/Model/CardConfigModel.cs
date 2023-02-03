using System.Collections.Generic;
using QFramework;

namespace SlayTheSpireM
{
    public class CardConfigModel : AbstractModel, IModel
    {
        protected string ConfigPath { get; set; }
        protected CardConfig[] cardConfigs;

        public CardConfigModel(string path)
        {
            ConfigPath = path;
        }

        protected override void OnInit()
        {
            cardConfigs = this.GetUtility<IJsonSerializer>().ReadJsonToArray(ConfigPath);
            Log.Debug(cardConfigs);
        }

        public List<CardConfig> GetCardsByRole(RoleType role)
        {
            List<CardConfig> ret = new();
            for (int i = 0; i < cardConfigs.Length; i++)
            {
                if (cardConfigs[i].RoleType == (int)role)
                {
                    ret.Add(cardConfigs[i]);
                }
            }
            return ret;
        }
    }
}
