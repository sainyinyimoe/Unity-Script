using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySplattedScript : MonoBehaviour
{
    [SerializeField] Sprite[] sprs;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprs[Random.Range(0, sprs.Length)];
        Destroy(gameObject, 2);      
    }


}
