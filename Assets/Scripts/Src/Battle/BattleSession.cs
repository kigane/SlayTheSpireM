using System;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace SlayTheSpireM
{
    public class BattleSession : BaseMonoController
    {
        public static BattleSession instance;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        BattleState state;
        // 全局状态
        public Deck deck;
        public RoleType role;
        public BindableProperty<int> playerHp = new(80);
        public BindableProperty<int> playerMaxHp = new(80);
        public BindableProperty<int> gold = new(99);
        public BindableProperty<int> floor = new(0);
        public int ascension = 0;
        public int[] potion = new[] { 0, 0, 0 };

        // 战斗状态
        public Player player;
        public List<Enemy> enemies;

        public void CacheStartingDeck()
        {
            Log.Info("Role", role, 16);
            Log.Info("Battle Session Init", 18);
            //TODO 设置初始卡组
            deck = new Deck(role);
        }

        public void SessionStart()
        {
            //TODO 初始化玩家状态，抽牌堆，手牌，能量等
            player = new Player();
            //TODO 根据当前楼层生成敌人
            enemies.Add(new Enemy());
        }

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
