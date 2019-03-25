using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform[] coinSpawnPoints;

    public int score = 0;

    private int lastSpawn = -1;

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Coin") == null)
        {
            if (lastSpawn >= 0)
                coinCollected();

            Instantiate(coinPrefab, coinSpawnPoints[pickSpawnPlace()]);
        }
    }

    public void coinCollected()
    {
        //GameObject coin = GameObject.FindGameObjectWithTag("Coin");
        //Object.Destroy(coin);
        score += 15;
        Debug.Log("Score: " + score);
    }

    public void bonus(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
    }

    int pickSpawnPlace()
    {
        int pick = Random.Range(0, coinSpawnPoints.Length - 1);
        pick = pick == lastSpawn ? (pick < coinSpawnPoints.Length - 1 ? (pick > 0 ? pick-- : pick++) : pick--) : pick;
        lastSpawn = pick;
        Debug.Log(pick + " picked");
        return pick;
    }

    public void reset()
    {
        score = 0;
    }
}
