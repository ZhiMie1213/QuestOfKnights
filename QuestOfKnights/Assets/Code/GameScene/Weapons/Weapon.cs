using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<WeaponStats> stats;
    public int weaponLevel;

    [HideInInspector] public bool statsUpdated;
    //•Ší‚ÌƒAƒCƒRƒ“
    public Sprite icon;
    //•ûŒü
    protected Vector2 forward;

    public void LevelUp( )
    {
        if ( weaponLevel < stats.Count - 1 )
        {
            weaponLevel++;

            statsUpdated = true;

            if( weaponLevel >= stats.Count - 1 )
            {
                PlayerController.instance.fullyLevelledWeapons.Add( this );
                PlayerController.instance.assignedWeapons.Remove( this );
            }
        }
    }
}

[System.Serializable]
public class WeaponStats
{
    public float speed, damage, range, timeBetweenAttacks, amount, duration;
    public string upgradeText, upgradeText1, upgradeText2, upgradeText3;

    public Sprite currentLevelImage;
}
