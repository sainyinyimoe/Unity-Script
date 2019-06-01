using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{


    // Speed is provided by player
    public float speed = 0;
    public float damage = 0;

    // Start is called before the first frame update
    public void SetAttributes(float _speed,float _damage)
    {
        speed = _speed;
        damage = _damage;
    }

    private void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector3.right *speed *Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyFollow>().healthPoint -= damage;
            Destroy(gameObject);
        }
    }
}
