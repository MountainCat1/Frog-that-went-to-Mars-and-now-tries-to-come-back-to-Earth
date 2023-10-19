using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ConstValues
{
    public const string GameSceneName = "SampleScene";
    public const float FramesPerSecond = 2f;
}

public static class Utilities
{
    public static bool IsInGameScene => SceneManager.GetActiveScene().name == ConstValues.GameSceneName;
}