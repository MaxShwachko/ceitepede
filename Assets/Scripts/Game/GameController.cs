using System;
using UnityEngine;

//GameController manages all the level process. It defines conditions of victory and defeat,
//depending on chosen game mode. It also sets all the variable properties depended on level difficulty,
//and runs all the spawn processes.
public class GameController : MonoBehaviour
{
    private MushroomSpawner mushroomSpawner;
    private CentipedeSpawner centipedeSpawner;
    private EnemiesSpawner enemiesSpawner;
    private LevelLoader levelLoader;
    private MachineGunLifeController playerLifeController;
    private GameMode mode;
    private GameLevelDifficulty difficulty;

    void Start()
    {
        mushroomSpawner = FindObjectOfType<MushroomSpawner>();

        if (mushroomSpawner == null)
            throw new Exception("Mushroom spawner component is missing");

        centipedeSpawner = FindObjectOfType<CentipedeSpawner>();

        if (centipedeSpawner == null)
            throw new Exception("Centipede spawner component is missing");

        enemiesSpawner = FindObjectOfType<EnemiesSpawner>();

        if (enemiesSpawner == null)
            throw new Exception("Enemies spawner component is missing");

        levelLoader = FindObjectOfType<LevelLoader>();

        if (levelLoader == null)
            throw new Exception("Level loader component is missing");

        var levelSettings = FindObjectOfType<LevelSettings>();

        if (levelSettings == null)
            throw new Exception("Level settings component is missing");

        playerLifeController = FindObjectOfType<MachineGunLifeController>();

        if (playerLifeController == null)
            throw new Exception("Machine gun life controller component is missing");

        StartGame(levelSettings.GameMode, levelSettings.Difficulty);
    }

    public void StartGame(GameMode gameMode, GameLevelDifficulty levelDifficulty)
    {
        difficulty = levelDifficulty;
        mode = gameMode;

        SetGameConditions();
        SetLevelSettings();
        StartGame();
    }

    private void StartGame()
    {
        mushroomSpawner.SpawnMultipleInRandomPositions(difficulty.MushroomsCount);
        centipedeSpawner.Spawn(difficulty.CentipedePartsCount);
    }

    private void SetGameConditions()
    {
        SetDefeatConditions();
        SetVictoryConditions();
    }

    private void SetVictoryConditions()
    {
        switch (mode)
        {
            case GameMode.Level:
                centipedeSpawner.OnAllPartsDestroyed += () => levelLoader.EndLevel(true);
                break;
            case GameMode.Endless:
                //Endless mode can't be finished with victory
                break;
            default:
                throw new Exception(string.Format("Condition for game mode {0} are not set", mode));
        }
    }

    private void SetDefeatConditions()
    {
        playerLifeController.OnDeath += () => levelLoader.EndLevel(false);
    }

    private void SetLevelSettings()
    {
        mushroomSpawner.BonusDropChance = difficulty.BonusDropChance;
        centipedeSpawner.CentipedeSpeed = difficulty.CentipedeSpeed;
        enemiesSpawner.SpawnCooldown = difficulty.EnemySpawnCooldown;

        centipedeSpawner.OnSpawn += (newPart) =>
        {
            var centipedePart = newPart.GetComponent<CentipedePart>();
            if (centipedePart != null)
                switch (mode)
                {
                    case GameMode.Level:
                        centipedePart.OnGoalReached += () =>
                        {
                            levelLoader.EndLevel(false);
                        };
                        break;
                    case GameMode.Endless:
                        centipedePart.OnGoalReached += () =>
                        {
                            playerLifeController.GetDamage(1);
                        };
                        break;
                    default:
                        break;
                }
        };

        if (mode == GameMode.Endless)
        {
            centipedeSpawner.OnAllPartsDestroyed += () =>
            {
                centipedeSpawner.Spawn(centipedeSpawner.LastSpawnPartsCount);

                centipedeSpawner.CentipedeSpeed *= 2;
                centipedeSpawner.Spawn(1);
                centipedeSpawner.CentipedeSpeed /= 2;
            };
        }
    }
}
