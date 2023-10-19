using UnityEngine.SceneManagement;

public class ConstValues
{
    public const string GameSceneName = "SampleScene";
}

public static class Utilities
{
    public static bool IsInGameScene => SceneManager.GetActiveScene().name == ConstValues.GameSceneName;
}