using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform TF;
    void Start()
    {
        TF = transform;
        TF.position = LevelManager.Instance.playCtrl.position;
    }

    // Update is called once per frame
    void Update()
    {
        TF.position = LevelManager.Instance.playCtrl.position;
    }
}
