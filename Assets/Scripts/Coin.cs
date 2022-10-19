using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
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
