using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponImage : MonoBehaviour
{
    public List<WeaponImages> images;
    

    void Update()
    {
        
    }

    [System.Serializable]
    public class WeaponImages
    {
        public Sprite image;
    }
}
