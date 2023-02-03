using UnityEngine;

namespace SlayTheSpireM
{
    public class BattleStateManager : MonoBehaviour
    {
        public static BattleStateManager instance;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        BattleState state;

        public void ChangeState(BattleStateType type)
        {
            state = type switch
            {// switch expression。 用type和箭头前的表达式进行模式匹配，匹配上了则执行其箭头后的语句 
                BattleStateType.INIT => new BattleInit(),
                BattleStateType.PLAYER => new BattlePlayerTurn(),
                BattleStateType.ENEMY => new BattleEnemyTurn(),
                BattleStateType.WIN => new BattleWin(),
                BattleStateType.LOSE => new BattleLose(),
                _ => null,
            };
            state?.Enter();
        }

        private void Update()
        {
            state?.OnUpdate();
        }
    }
}
