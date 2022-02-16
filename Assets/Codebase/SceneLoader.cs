using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadFirstGameScene()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadNextScene()
    {
        if (IsLastGameScene())
        {
            LoadFirstGameScene();
        }
        else
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public static bool IsLastGameScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        return SceneManager.sceneCountInBuildSettings <= nextSceneIndex;
    }
}