using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    public Animator AttackAnimator;
    public void Attack()
    {
        AttackAnimator.SetTrigger("Attack");
    }
}
