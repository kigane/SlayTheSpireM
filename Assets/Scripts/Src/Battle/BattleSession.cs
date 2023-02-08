using System;
using System.Collections;
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
        public BindableProperty<int> gold = new(99);
        public BindableProperty<int> floor = new(0);
        public int ascension = 0;
        public int[] potion = new[] { 0, 0, 0 };

        // 战斗状态
        public Player player;
        public Enemy[] enemies;
        public Transform enemyUnitsTransform;

        public void CacheStartingDeck()
        {
            role = RoleType.Ironclad;
            // 设置初始卡组
            deck = new Deck(role);
            player = new Player();
            enemies = new Enemy[3];
        }

        public void SessionStart()
        {
            //TODO 初始化玩家状态，抽牌堆，手牌，能量等
            player.SetUp();
            //TODO 根据当前楼层生成敌人
            // 挂载敌方单位的容器
            enemyUnitsTransform = GameObject.FindGameObjectWithTag("EnemyUnits").transform;
            var original = Resources.Load<GameObject>("Prefabs/EnemyUnit");
            // 生成敌人数据
            Enemy enemy1 = new(5);
            Enemy enemy2 = new(5);
            Enemy enemy3 = new(5);
            enemies[0] = enemy1;
            enemies[1] = enemy2;
            enemies[2] = enemy3;
            // 逐个生成敌人GO，并挂载到容器对象下。生成顺序对应在数组中的位置
            Instantiate(original, enemyUnitsTransform);
            Instantiate(original, enemyUnitsTransform);
            Instantiate(original, enemyUnitsTransform);
            //TODO 在实例化后，获取Controller，再根据Controller中提供的Id生成敌人数据，将该数据注入Controller中
        }

        public void CleanAllEnemiesBlock()
        {
            foreach (var enemy in enemies)
            {
                if (enemy != null)
                    enemy.block.Value = 0;
            }
        }

        public void EnemiesDoIntent()
        {
            foreach (var enemy in enemies)
            {
                enemy.DoAction();
            }
        }

        public void ChangeState(BattleStateType type)
        {
            state = type switch
            {// switch expression。 用type和箭头前的表达式进行模式匹配，匹配上了则执行其箭头后的语句 
                BattleStateType.Init => new BattleInit(),
                BattleStateType.PlayerTurn => new BattlePlayerTurn(),
                BattleStateType.EnemyTurn => new BattleEnemyTurn(),
                BattleStateType.Win => new BattleWin(),
                BattleStateType.Lose => new BattleLose(),
                _ => null,
            };
            state?.Enter();
        }

        private void Update()
        {
            state?.OnUpdate();
        }

        public void StartPlayerTurn()
        {
            foreach (var enemy in enemies)
            {
                enemy.GenerateRandomIntention();
            }
            this.SendCommand<StartPlayerTurnCommand>();
        }

        public void EndPlayerTurn()
        {
            this.SendCommand<EndPlayerTurnCommand>();
            StartCoroutine(nameof(EndEnemyTurn));
        }

        public void EndEnemyTurn()
        {
            StartCoroutine(nameof(EndEnemyTurnAfterTwoSeconds));
        }

        private IEnumerator EndEnemyTurnAfterTwoSeconds()
        {
            Log.Debug("EndEnemyTurn", 16);
            yield return new WaitForSeconds(2);
            ChangeState(BattleStateType.PlayerTurn);
        }
    }
}
