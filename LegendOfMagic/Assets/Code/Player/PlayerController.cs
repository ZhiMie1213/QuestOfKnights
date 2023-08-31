using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0.01f;
    
    void Start( )
    {
        
    }

    void Update( )
    {
        //プレイヤーの操作
        Vector3 moveInput = new Vector3( 0f, 0f, 0f );
        moveInput.x = Input.GetAxisRaw( "Horizontal" );
        moveInput.y = Input.GetAxisRaw( "Vertical" );
        moveInput.Normalize( );

        //プレイヤーの速度
        transform.position += moveInput * moveSpeed * Time.deltaTime;
    }
}