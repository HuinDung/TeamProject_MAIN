using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSequence : MonoBehaviour
{
    public Animator backgroundAnimator;
    public Animator logoAnimator;

    void Start()
    {
        // Background �ִϸ��̼� ����
        backgroundAnimator.Play("BackgroundColor");
    }

    // Background �ִϸ��̼ǿ��� ȣ���� �̺�Ʈ �Լ�
    public void OnBackgroundAnimationEnd()
    {
        // Background �ִϸ��̼��� ���� �� Logo �ִϸ��̼� ����
        logoAnimator.Play("LogoFadeIn");
    }
}
