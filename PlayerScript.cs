using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // Move
    Vector3 movement;
    [SerializeField] float speed = 5;

    // Bullet
    [SerializeField] float bulletSpeed = 10;
    [SerializeField] float bulletDamage = 30;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float timeBetweenEachShoot = 0.1f;
    float timer = 0;

    [SerializeField] float xBoundary = 8.5f;
    [SerializeField] float yBoundary = 4.5f;

    [SerializeField] float maxHealth = 100;
    float currentHealth;

    [SerializeField] Slider healthSlider;
    [SerializeField] float hurtCooldown = 0.2f;

    [SerializeField] Image hurtScreenFlash;
    [SerializeField] Color hurtScreenFlashColor;
    [SerializeField] float hurtScreenFlashTime;

    float hurtTimer = 0;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.value = currentHealth;
    }

    void Update()
    {
        Move();
        Rotate();
        Shoot();
        Hurt();
    }

    void Hurt()
    {
        if(hurtScreenFlash.color.a > 0)
        {
            hurtScreenFlash.color = Color.Lerp(hurtScreenFlash.color, Color.clear, hurtScreenFlashTime * Time.deltaTime); // LERp

        }
        hurtTimer += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(hurtTimer> hurtCooldown && collision.transform.CompareTag("Enemy"))
        {
            currentHealth -= collision.GetComponent<EnemyFollow>().damageToPlayer;
            hurtScreenFlash.color = hurtScreenFlashColor;
            hurtTimer = 0;
            healthSlider.value = currentHealth;
        }
    }

    // Move function
    void Move()
    {
        
        // Move
        float h = Input.GetAxisRaw ("Horizontal"); // Raw mean jump from 0 to 1 instantly
        float v = Input.GetAxisRaw ("Vertical"); // GetAxis only mean that it also consider form decimal point
        movement.Set(h, v, 0);
        movement= movement.normalized * speed * Time.deltaTime; // Normally x = 1 , y = 1 ,between x and y = root 2.Normalized neutralize it.
        transform.position += movement;

        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -xBoundary, xBoundary);
        pos.y = Mathf.Clamp(pos.y, -yBoundary, yBoundary);

        transform.position = pos;
    }

    // Rotate function
    void Rotate()
    {
        Vector3 mousepos = Input.mousePosition;
        // Screen point to world point
        Vector3 worldPos = Camera.main.ScreenToWorldPoint (mousepos);
      //  Debug.Log (worldPos);

        // Rotate with mouse
        worldPos.z = 0;
        transform.right = worldPos - transform.position;
    }

    // Shoot
    void Shoot()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && timer > timeBetweenEachShoot)
        {
            GameObject bulletGo = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // Bullet Shoot
            bulletGo.GetComponent<BulletScript>().SetAttributes(bulletSpeed,bulletDamage);
            timer = 0;
        }
    }

}
