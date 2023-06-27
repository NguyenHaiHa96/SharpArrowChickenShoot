using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetSystems;

public class PlayerDetection : MonoBehaviour
{
    [Header(" Components ")]
    [SerializeField] private ArrowPlacer arrowPlacer;

    [Header(" Settings ")]
    [SerializeField] private LayerMask doorsLayer;
    [SerializeField] private LayerMask enemiesLayer;
    [SerializeField] private LayerMask balloonsLayer;
    private bool canDetectDoors;
    int countBalloons;
    // Start is called before the first frame update
    void Start()
    {
        countBalloons = 0;
        canDetectDoors = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canDetectDoors)
            DetectDoors();

        DetectEnemies();
        DetectBalloons();
    }

    private void DetectDoors()
    {
        Collider[] detectedDoors = Physics.OverlapSphere(transform.position, arrowPlacer.GetPlayerColliderRadius(), doorsLayer);
        if (detectedDoors.Length <= 0) return;

        Transform closestDoorTransform = Utils.GetClosestTransformInArray(transform, Utils.ColliderToTransformArray(detectedDoors));
        Door closestDoor = closestDoorTransform.GetComponent<Door>();

        DoorTouchedCallback(closestDoor);
    }

    private void DetectEnemies()
    {
        Collider[] detectedEnemies = Physics.OverlapSphere(transform.position, arrowPlacer.GetPlayerColliderRadius(), enemiesLayer);
        if (detectedEnemies.Length <= 0) return;
        arrowPlacer.EnemiesTouchedCallback(detectedEnemies);
    }

    private void DetectBalloons()
    {
        
        Collider[] detectedBalloons = Physics.OverlapSphere(transform.position, arrowPlacer.GetPlayerColliderRadius(), balloonsLayer);
        if (detectedBalloons.Length <= 0) return;
        countBalloons++;
        //if(arrowPlacer.arrowsParent.childCount <= Mathf.Pow(2,countBalloons)) {
        //    arrowPlacer.SetGameover();
        //    for(int i =0; i < arrowPlacer.arrowsParent.childCount; i ++)
        //    {
        //        Destroy(arrowPlacer.arrowsParent.GetChild(i).gameObject);
        //    }
        //    return;
        //}
        arrowPlacer.BalloonTouchedCallback(detectedBalloons,countBalloons);
    }

    private void DoorTouchedCallback(Door door)
    {
        canDetectDoors = false;
        LeanTween.delayedCall(0.5f, () => canDetectDoors = true);

        arrowPlacer.DoorTouchedCallback(door);
    }
}
