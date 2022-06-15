using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MouseInput))]

public class PlayerAnimator : MonoBehaviour
{
    public AnimationClip RunAnimation;
    public AnimationClip IdleAnimation;

    public void Running()
    {
        GetComponent<Animation>().Play(RunAnimation.name);
    }

    public void Idle()
    {
        GetComponent<Animation>().Play(IdleAnimation.name);
    }
}
