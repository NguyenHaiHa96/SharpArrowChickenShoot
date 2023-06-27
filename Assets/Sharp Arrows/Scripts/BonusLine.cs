using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLine : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] private Transform balloonsParent;
    [SerializeField] private float zSpacing;
    [SerializeField] private GameObject balloonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        PlaceBonusLines();
    }

    // Update is called once per frame

    private void PlaceBonusLines()
    {
        // Get the z spacing of the bonus lines
        Vector3 startPosition = transform.position; // + Vector3.forward * (transform.position.z + zSpacing / 2);
        int bonusLinesCount = Mathf.Min( LevelManager.instance.Level,8);
        // Spawn the bonus lines
        for (int i = 0; i < bonusLinesCount ; i++)
        {
            // Define the bonus line position
            Vector3 targetPosition = startPosition + Vector3.forward * zSpacing * i;
            // Define the target color
            Color targetColor = Color.HSVToRGB((float)i / bonusLinesCount, 0.8f, 0.9f);
            // Set the target amount
            float targetAmount = Mathf.Pow(2,i+1);
            Balloon balloon = Instantiate(balloonPrefab, targetPosition, Quaternion.identity, balloonsParent).GetComponent<Balloon>();
            if (i == bonusLinesCount - 1) balloon.transform.localScale = Vector3.one * 3;
            balloon.Configure(targetAmount);
        }
    }
}
