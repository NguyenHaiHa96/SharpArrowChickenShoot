using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetSystems;
using Cinemachine;
using Dreamteck.Splines;

public class LevelManager : Singleton<LevelManager>
{
    public delegate void OnLevelInstantiated();
    public static OnLevelInstantiated onLevelInstantiated;

    [Header(" Settings ")]
    [SerializeField] private GameObject[] levelsPrefabs;
    public Transform playCtrl;
    private GameObject currentLevel;
    int level;
    public int countRemainderBallon;
    private void Awake()
    {
        level = PlayerPrefs.GetInt("LEVEL");

        UIManager.onNextLevelButtonPressed += SpawnNextLevel;
    }

    private void OnDestroy()
    {
        UIManager.onNextLevelButtonPressed -= SpawnNextLevel;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnLevel();
        countRemainderBallon = currentLevel.GetComponent<Level>().bossContainer.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnLevel()
    {
        int correctedLevelIndex = level % levelsPrefabs.Length;

        transform.Clear();
        currentLevel = Instantiate(levelsPrefabs[correctedLevelIndex], transform);

        onLevelInstantiated?.Invoke();

        LeanTween.delayedCall(Time.deltaTime, ShowSpline);
    }

    private void SpawnNextLevel()
    {
        level++;
        PlayerPrefs.SetInt("LEVEL", level);

        SpawnLevel();

       AdManager.instance.ShowInterstitialAd();
    }

    private void ShowSpline()
    {
        SplineMesh splineMesh = FindObjectOfType<SplineMesh>();
        splineMesh.RebuildImmediate();
    }
}
