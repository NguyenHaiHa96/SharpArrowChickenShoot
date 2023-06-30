using JetSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIExtent : MonoBehaviour
{
    public GameObject GOImageCoinPrefab;
    public List<GameObject> GOCoins;
    public Transform TfCoin;
    public Transform TfSpawnPosition;
    public int CoinAmount;
    public float TimeMoveTween;

    private void Start()
    {
        UIManager.onLevelCompleteSet += MoveCoinToCoinContainer;
        for (int i = 0; i < CoinAmount; i++)
        {
            GameObject go = Instantiate(GOImageCoinPrefab);
            go.transform.SetParent(TfSpawnPosition);
            go.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            GOCoins.Add(go);
        }
    }

    public void MoveCoinToCoinContainer(int value)
    {
        for (int i = 0; i < GOCoins.Count; i++)
        { 
            GOCoins[i].transform.DOMove(new Vector2(Random.Range(20, -20), Random.Range(20, -20)), TimeMoveTween);
        }
    }
}
