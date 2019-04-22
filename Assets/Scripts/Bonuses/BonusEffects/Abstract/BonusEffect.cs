using UnityEngine;

//BonusEffect can be added to any game object by instance of Bonus class inheritors. 
public abstract class BonusEffect : MonoBehaviour
{
    public float Value { get; set; }

    protected abstract void Affect();

    private void Start()
    {
        Affect();
    }
}