using System;

//Set of different variable properties that defines level difficulty. 
[Serializable]
public class GameLevelDifficulty
{
    public string Name;
    public int MushroomsCount;
    public float CentipedeSpeed;
    public int CentipedePartsCount;
    public float BonusDropChance;
    public float EnemySpawnCooldown;
}
