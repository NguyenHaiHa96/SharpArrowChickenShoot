using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Balloon : GameUnit
{
    [Header(" Components ")]
    [SerializeField] private Renderer renderer;
    [SerializeField] private Collider collider;
    [SerializeField] private TextMeshPro multiplierText;
    [SerializeField] private GameEvent popEvent;

    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
    }
    public override void OnInit()
    {

    }
    public void Configure(float multiplier)
    {
        multiplierText.text = "-" + multiplier.ToString();
    }

    public void Pop()
    {
        popEvent.RaiseEvent(new EnemyTouchedEvent(transform.position));
        Destroy(gameObject);
        renderer.enabled = false;
        multiplierText.enabled = false;
        collider.enabled = false;
    }
}
