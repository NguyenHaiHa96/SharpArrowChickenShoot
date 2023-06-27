using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShop : MonoBehaviour
{
    private float speed = 5 ;
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, speed);
    }
}
