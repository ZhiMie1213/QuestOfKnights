using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator am;
    PlayerController pc;
    SpriteRenderer sr;
    
    void Start( )
    {
        am = GetComponent<Animator>( );
        pc = GetComponent<PlayerController>( );
        sr = GetComponent<SpriteRenderer>( );
    }

    void Update( )
    {
        //プレイヤーアニメーション
        if ( pc.moveInput.x != 0 || pc.moveInput.y != 0 )
        {
            am.SetBool( "Move", true );
            SpriteDirectionChecker( );
        }
        else
        {
            am.SetBool( "Move", false );
        }
    }

    void SpriteDirectionChecker ( )
    {
        if ( pc.moveInput.x < 0 )
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
    }
}
