using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickup : MonoBehaviour
{
    public int expValue;

    void Start( )
    {
        
    }

    void Update( )
    {
        
    }
    
    //
    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.tag == "Player" )
        {
            ExperienceLevelController.instance.GetExp(expValue);

            Destroy(gameObject);
        }
    }
}
