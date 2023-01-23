using QFramework;
using System.Collections.Generic;

namespace SlayTheSpireM
{
    public interface IPlayerModel : IModel
    {
        RoleType Role { get; set; }
        BindableProperty<int> Hp { get; }
        BindableProperty<int> MaxHp { get; }
        BindableProperty<int> Gold { get; }
        BindableProperty<int> Ascension { get; }
        BindableProperty<int> Floor { get; }
        List<Card> Deck { get; }
        List<string> Relics { get; }
    }

    public class PlayerModel : AbstractModel, IPlayerModel
    {
        public RoleType Role { get; set; }
        public BindableProperty<int> Hp { get; } = new BindableProperty<int>(70);
        public BindableProperty<int> MaxHp { get; } = new BindableProperty<int>(70);
        public BindableProperty<int> Gold { get; } = new BindableProperty<int>(99);
        public BindableProperty<int> Ascension { get; } = new BindableProperty<int>(0);
        public BindableProperty<int> Floor { get; } = new BindableProperty<int>(0);
        public List<Card> Deck { get; } = new();
        //TODO 遗物
        public List<string> Relics { get; } = new();
        //TODO 药水

        protected override void OnInit() { }


    }
}
