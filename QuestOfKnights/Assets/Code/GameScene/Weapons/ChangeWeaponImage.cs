using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeaponImage : MonoBehaviour
{
    public Weapon weapon;
    public Sprite nextSprite;
    private Image weaponImage;

    public int weaponImages;
    
    void Start()
    {
        weaponImage = GetComponent<Image>( );
    }

    void Update()
    {
        if ( weapon.weaponLevel < weapon.stats.Count - 1 )
        {
            weaponImages++;
        }
    }
}
