using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KillPlayer", menuName = "Dialogue/EndNodes/KillPlayer", order = 0)]
public class EndNode_KillPlayer : EndNode
{

    public static Action<EndNode_KillPlayer> DoAnimation;
    public override void Finish(GameObject talker)
    {
        base.Finish(talker);
        DoAnimation?.Invoke(this);
    }

}
