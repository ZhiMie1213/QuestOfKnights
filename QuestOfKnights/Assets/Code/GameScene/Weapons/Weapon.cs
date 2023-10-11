using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<WeaponStats> stats;
    public int weaponLevel;

    [HideInInspector] public bool statsUpdated;
    //武器のアイコン
    public Sprite icon;
    //方向
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
