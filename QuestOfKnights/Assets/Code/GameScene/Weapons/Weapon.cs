using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<WeaponStats> stats;
    public int weaponLevel;

    [HideInInspector] public bool statsUpdated;
    //����̃A�C�R��
    public Sprite icon;
    //����
    protected Vector2 forward;

    public void LevelUp( )
    {
        if ( weaponLevel < stats.Count - 1 )
        {
            weaponLevel++;

            statsUpdated = true;
        }
    }
}

[System.Serializable]
public class WeaponStats
{
    public float speed, damage, range, timeBetweenAttacks, amount, duration;
    public string upgradeText;
    public Sprite currentLevelImage;
}
