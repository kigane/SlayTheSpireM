using UnityEngine;
using QFramework;

namespace SlayTheSpireM
{
    public class SlayTheSpireGame : Architecture<SlayTheSpireGame>
    {
        protected override void Init()
        {
            // 工具层
            RegisterUtility<IJsonSerializer>(new NewtonsoftJsonSerializer());

            // 系统层
            // RegisterSystem<IPlayerSystem>(new PlayerSystem());

            // 模型层
            RegisterModel<IPlayerModel>(new PlayerModel());
            RegisterModel(new CardDataBase());
            RegisterModel(new CardConfigModel("Configs/cards"));
        }
    }
}
