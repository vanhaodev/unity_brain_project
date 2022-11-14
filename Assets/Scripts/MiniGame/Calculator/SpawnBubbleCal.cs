using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBubbleCal : MonoBehaviour
{
    [SerializeField] GameObject bubbleCal;

    private void Start()
    {
        for(int i = 0; i < 20; i++)
        {
            Instantiate(bubbleCal, new Vector3(Random.Range(-20, 21), Random.Range(-8, 9), 0), Quaternion.identity, this.transform);
        }
    }
}
