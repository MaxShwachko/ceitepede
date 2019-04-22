using System;
using UnityEngine;
using UnityEngine.UI;

//This class handles visualisation of some data in UI (some kind of bindings). For now it's only players HP, could be complete with score, playing time, etc.
public class LevelUIManager : MonoBehaviour
{
    [SerializeField]
    private Text lifesCount;

    private MachineGunLifeController playerLifeController;

    void Start()
    {
        playerLifeController = FindObjectOfType<MachineGunLifeController>();

        if (playerLifeController == null)
            throw new Exception("Machine gun life controller component is missing");

        playerLifeController.OnDamageTaken += SetLivesCount;
        playerLifeController.OnHeal += SetLivesCount;
        SetLivesCount();
    }

    private void SetLivesCount()
    {
        lifesCount.text = playerLifeController.Health.ToString();
    }
}
