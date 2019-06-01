using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    GameObject player;
    [SerializeField] float speed = 5;
    bool isGrowing = true;

    [SerializeField] float growthSecond = 5;

    public float healthPoint = 100;

    [SerializeField] AudioClip explosionFX;

    public float damageToPlayer = 10;
    [SerializeField] GameObject splattedPrefab;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        transform.localScale = Vector3.zero;

        GetComponent<CircleCollider2D>().enabled = false;
    }

    void Update()
    {
        if(healthPoint <= 0 )
        {
            Die();
        }

        Vector3 dir = player.transform.position - transform.position;
        transform.right = dir;

        if (isGrowing)
        {
            transform.localScale += Vector3.one * Time.deltaTime/growthSecond;

            if (transform.localScale.x > 1)
            {
                isGrowing = false;
                GetComponent<CircleCollider2D>().enabled = true;

            }
        }
        else
        {           
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
      
    }

    private void Die()
    {
        AudioSource.PlayClipAtPoint(explosionFX, transform.position);
        Instantiate(splattedPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
