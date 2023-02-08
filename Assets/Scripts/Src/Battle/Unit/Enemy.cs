using QFramework;

namespace SlayTheSpireM
{
    public class Enemy : BattleUnit
    {
        public Enemy(int id)
        {
            this.id = id;
        }

        public string intention; // 意图

        public void GenerateRandomIntention()
        {
            
        }

        public void DoAction()
        {
            //TODO 执行意图
        }
    }
}
