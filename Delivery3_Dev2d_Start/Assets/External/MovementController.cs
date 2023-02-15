using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public void Flee()
    {
        transform.Translate(new Vector3(0, 3, 0));
    }

    public void Attack()
    {
        transform.Translate(new Vector3(-3, 0, 0));
    }
}
