using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : GameUnit
{
    public override void OnInit()
    {
    }
    public override void OnDespawn()
    {
        TF.SetParent(SimplePool.Root);
        SimplePool.Despawn(this);
    }
}
