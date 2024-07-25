using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement)
    {
        
    }
}
