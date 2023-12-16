using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponImages : MonoBehaviour
{
    public List<WeaponImagesStats> imagesStats;

    [System.Serializable]
    public class WeaponImagesStats
    {
        public Sprite weponImage;
    }
}
