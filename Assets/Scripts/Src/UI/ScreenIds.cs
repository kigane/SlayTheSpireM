using QFramework;

namespace SlayTheSpireM
{
    public sealed class ScreenIds
    {
        // Prefabs/UI/Screens/xxx
        // 变量名会作为注册的Id，值必须对应相应的Prefab
        public const string GameStartWindow = "GameStartWindow";
        public const string BackgroundPanel = "BackgroundPanel";
        public const string ModeSelectWindow = "ModeSelectWindow";
        public const string CharacterSelectWindow = "CharacterSelectWindow";
    }

    public sealed class GameScreenIds
    {
        // Prefabs/UI/Screens/xxx
        // 变量名会作为注册的Id，值必须对应相应的Prefab
        public const string InitRewardWindow = "InitRewardWindow";
        public const string GameBackgroundPanel = "GameBackground";
        public const string StatusPanel = "StatusPanel";
        public const string BattleWindow = "BattleWindow";
        public const string BattleWinWindow = "BattleWinWindow";
        public const string GameOverWindow = "GameOverWindow";
    }
}
