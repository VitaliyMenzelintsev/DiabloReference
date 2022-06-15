using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class PlayerAnimator : MonoBehaviour
{
    public AnimationClip RunAnimation;
    public AnimationClip IdleAnimation;

    public void Running()
    {
        GetComponent<Animation>().CrossFade(RunAnimation.name);
    }

    public void Idle()
    {
        GetComponent<Animation>().CrossFade(IdleAnimation.name);
    }
}
