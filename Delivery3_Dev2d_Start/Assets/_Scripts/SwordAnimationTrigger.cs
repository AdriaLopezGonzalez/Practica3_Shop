using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnimationTrigger : MonoBehaviour
{

    private Animator _swordAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _swordAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EndNode_KillPlayer.DoAnimation += DoAnimation;
    }

    private void OnDisable()
    {
        EndNode_KillPlayer.DoAnimation -= DoAnimation;
    }

    private void DoAnimation(EndNode_KillPlayer endNode)
    {
        _swordAnimator.SetTrigger("Attack");
    }
}
