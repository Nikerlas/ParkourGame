using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    Animator anim;
    int horizontal;
    int vertical;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement, bool isSprinting)
    {
        float snappedHorizontal;
        float snappedVertical;

        #region HorizontalMovement
        if(horizontalMovement > 0 && horizontalMovement < 0.55f) 
        {
            snappedHorizontal = 0.5f;
        }
        else if(horizontalMovement > 0.55f) 
        {
            snappedHorizontal = 1;
        }
        else if(horizontalMovement < 0 && horizontalMovement > -0.55f) 
        {
            snappedHorizontal = -0.5f;
        }
        else if(horizontalMovement < -0.55f) 
        {
            snappedHorizontal = -1;
        }
        else 
        {
            snappedHorizontal = 0;
        }
        #endregion

        #region VerticalMovement
        if(verticalMovement > 0 && verticalMovement < 0.55f) 
        {
            snappedVertical = 0.5f;
        } 
        else if(verticalMovement > 0.55f) 
        {
            snappedVertical = 1;
        }
        else if(verticalMovement < 0 && verticalMovement > -0.55f) 
        {
            snappedVertical = -0.5f;
        }
        else if(verticalMovement < -0.55f) 
        {
            snappedVertical = -1;
        }
        else 
        {
            snappedVertical = 0;
        }
        #endregion

        if(isSprinting)
        {
            snappedHorizontal = horizontalMovement;
            snappedVertical = 2;
        }

        anim.SetFloat("Horizontal", snappedHorizontal, 0.1f, Time.deltaTime);
        anim.SetFloat("Vertical", snappedVertical, 0.1f, Time.deltaTime);   
    }
}
