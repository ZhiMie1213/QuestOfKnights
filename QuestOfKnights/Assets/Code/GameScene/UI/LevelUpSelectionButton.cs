using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpSelectionButton : MonoBehaviour
{
    public TMP_Text upgradeDescText, upgradeDescText1, upgradeDescText2, upgradeDescText3, nameLevelText;
    public Image weaponIcon;

    private Weapon assignedWeapon;

    public void UpdateButtonDisplay ( Weapon theWeapon )
    {
        if ( theWeapon.gameObject.activeSelf == true ) { 
            upgradeDescText.text = theWeapon.stats[ theWeapon.weaponLevel ].upgradeText;
            upgradeDescText1.text = theWeapon.stats[ theWeapon.weaponLevel ].upgradeText1;
            upgradeDescText2.text = theWeapon.stats[ theWeapon.weaponLevel ].upgradeText2;
            upgradeDescText3.text = theWeapon.stats[ theWeapon.weaponLevel ].upgradeText3;
            
            weaponIcon.sprite = theWeapon.stats[ theWeapon.weaponIcon ].icon;

            nameLevelText.text = theWeapon.name + " + " + theWeapon.weaponLevel;
        }else
        {
            upgradeDescText.text = "New";
            weaponIcon.sprite = theWeapon.stats[ theWeapon.weaponIcon ].icon;

            nameLevelText.text = theWeapon.name;
        }

        assignedWeapon = theWeapon;
    }

    public void SelectUpgrade ( )
    {
        if ( assignedWeapon != null )
        {
            if ( assignedWeapon.gameObject.activeSelf == true ) 
            { 
                assignedWeapon.LevelUp( );
            }
            else
            {
                PlayerController.instance.AddWeapon( assignedWeapon );
            }

            UIController.instance.levelUpPanel.SetActive( false );
            Time.timeScale = 1f;
        }
    }
}
