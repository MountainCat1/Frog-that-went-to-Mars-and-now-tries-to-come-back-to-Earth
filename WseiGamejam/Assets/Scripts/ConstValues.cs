using UnityEngine.SceneManagement;

public class ConstValues
{
    public const string GameSceneName = "GameScene";
    public const float FramesPerSecond = 2f;
    public const string SummaryScene = "ScoreSummary";
}

public static class Utilities
{
    public static bool IsInGameScene => SceneManager.GetActiveScene().name == ConstValues.GameSceneName;
}