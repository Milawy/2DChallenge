using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    #region Variables
    
    [Header("Player Animator")]
    public Animator playerAnimator;

    [Header("Values checker")]
    public bool isJumping = false;

    #endregion

    void Update()
    {
        isJumping = !(PlayerMovement.isGrounded);

        playerAnimator.SetFloat("zVelocity", Input.GetAxis("Vertical"));
        playerAnimator.SetBool("jumping", isJumping);
    }
}
