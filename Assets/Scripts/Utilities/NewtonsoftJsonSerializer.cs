using Newtonsoft.Json;
using QFramework;
using UnityEngine;

namespace SlayTheSpireM
{
    public interface IJsonSerializer : IUtility
    {
        CardConfig[] ReadJsonToArray(string path);
    }

    public class NewtonsoftJsonSerializer : IJsonSerializer
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="path">配置文件路径，不需要后缀</param>
        public CardConfig[] ReadJsonToArray(string path)
        {
            string jsonText = Resources.Load<TextAsset>(path).text;
            CardConfig[] cardConfigs = JsonConvert.DeserializeObject<CardConfig[]>(jsonText);
            return cardConfigs;
        }
    }
}


