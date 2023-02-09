using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using QFramework;
using TMPro;
using UnityEngine.EventSystems;

namespace SlayTheSpireM
{
    public class BaseUnitController : BaseMonoController
    {
        public List<Buff> Buffs = new();

        [SerializeField] Slider healthBarSlider;
        [SerializeField] Transform buffsTransform;

        protected void SetHealthSlider(float val)
        {
            healthBarSlider.value = val;
        }

        /// <summary>
        /// 为单位加buff
        /// 如果是新buff，则添加新图标
        /// 如果是已有的buff，则更新其值
        /// </summary>
        /// <param name="buff"></param>
        public void AddBuff(Buff buff)
        {
            for (int i = 0; i < Buffs.Count; i++)
            {
                if (Buffs[i].Name == buff.Name)
                {
                    Buffs[i] += buff;
                    Buffs[i].Text.text = Buffs[i].Value.ToString();
                    return;
                }
            }

            GameObject buffPrototype = Resources.Load<GameObject>("Prefabs/Buff"); // 原型
            GameObject buffInstance = Instantiate(buffPrototype, buffsTransform); // 实例
            buff.instance = buffInstance;
            buffInstance.name = buff.Name;
            buffInstance.GetComponent<Image>().sprite = buff.Icon;
            buff.Text = buffInstance.GetComponentInChildren<TextMeshProUGUI>();
            buff.Text.text = buff.Value.ToString();
            Buffs.Add(buff);
        }
    }
}
