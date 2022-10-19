using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] int CountSpike = 5;
    [SerializeField] GameObject prefabSpike;
    [SerializeField] int CountCoin = 5;
    [SerializeField] GameObject prefabCoin;
    private void Awake()
    {
        PlayerBehavior.countCoinAtStart = CountCoin;
        SpawnInRandomPos(prefabSpike, CountSpike);
        SpawnInRandomPos(prefabCoin, CountCoin);
    }
    void SpawnInRandomPos(GameObject prefab, float quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            var gameObject = Instantiate(prefab, this.transform);
            float randPosX = 0;
            while (randPosX < 1 && randPosX > -1)
            {
                randPosX = Random.Range(Borders.minPos.x, Borders.maxPos.x);
            }
            float randPosY = 0;
            while (randPosY < 1 && randPosY > -1)
            {
                randPosY = Random.Range(Borders.minPos.y, Borders.maxPos.y);
            }
            gameObject.transform.position = new Vector2(randPosX, randPosY);
        }
    }
}
