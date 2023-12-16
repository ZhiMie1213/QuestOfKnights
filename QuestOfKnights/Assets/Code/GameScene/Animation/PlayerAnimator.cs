using UnityEngine;

namespace Code.GameScene.Animation
{
    public class PlayerAnimator : MonoBehaviour
    {
        Animator am;
        PlayerController pc;
        SpriteRenderer sr;
        private static readonly int Move = Animator.StringToHash("Move");

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
            if ( pc.lastHorizontalVector > 0 )
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
    }
}
