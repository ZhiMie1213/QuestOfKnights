using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickup : MonoBehaviour
{
    public int expValue;

    private bool movingToPlayer;
    public float moveSpeed;

    public float timeBerweenChecks = .2f;
    private float checkCounter;

    private PlayerController player;

    void Start( )
    {
        player = PlayerHealthController.instance.GetComponent<PlayerController>( );
    }

    void Update( )
    {
        //プレイヤーが経験玉の採取範囲に着いたら吸収のように受け取る
        if ( movingToPlayer == true )
        {
            transform.position = Vector3.MoveTowards( transform.position, 
                PlayerHealthController.instance.transform.position, moveSpeed * Time.deltaTime );
        }
        else
        {
            checkCounter -= Time.deltaTime;
            if ( checkCounter <= 0 )
            {
                checkCounter = timeBerweenChecks;
                //プレイヤーが採取範囲より小さい場合
                if ( Vector3.Distance( transform.position, player.transform.position ) < player.pickUpRange )
                {
                    movingToPlayer = true;
                    moveSpeed += player.moveSpeed;
                }
            }
        }
    }
    
    //プレイヤーに当てれば経験玉は消える
    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.tag == "Player" )
        {
            ExperienceLevelController.instance.GetExp( expValue );

            Destroy( gameObject );
        }
    }
}
