using System;
using System.Linq;
using UnityEngine;

//LevelSetting class is used in main menu to set level properties. Has it's own difficulties list,
//which can be changed from the Unity inspector. It implements some kind of Singleton pattern(antipattern)
//because it's a need to DontDestroyOnLoad() it when scenes are swiched, and there conld'n exist more than one LevelSettings at the same time.
public class LevelSettings : MonoBehaviour
{
    private static LevelSettings singletonInstance;

    public GameLevelDifficulty[] AllDifficulties;
    public GameMode GameMode;
    public GameLevelDifficulty Difficulty;

    private void Start()
    {   
        DontDestroyOnLoad(gameObject);

        if (singletonInstance != null)
            Destroy(singletonInstance.gameObject);

        singletonInstance = this;
    }

    public void SetGameMode(int mode)
    {
        GameMode = (GameMode)mode;
    }

    public void SetDifficulty(string name)
    {
        var difficulty = AllDifficulties.FirstOrDefault(d => d.Name == name);
        Difficulty = difficulty ?? throw new ArgumentException("Difficulty name parameter must be one of the Difficulties array elements");
    }
}
