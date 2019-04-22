using UnityEngine;
using UnityEngine.SceneManagement;

//Switches between game scenes upon request
public class LevelLoader : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void EndLevel(bool win)
    {
        if (win)
            SceneManager.LoadScene("LevelComplete");
        else
            SceneManager.LoadScene("Lose");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
