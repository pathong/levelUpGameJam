using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shoot : MonoBehaviour
{
    public int bullet_count;
    public float Speed;
    public Transform fireBullet;
    public GameObject bullet_prefab; private float timer = 1f;
    public float cooldowntimer_bullet;
    private AudioSource audio_;
    void Update()
    {

        if (timer > 0)
        {
            timer -= Time.deltaTime * 1;
        }
        if (timer < 0)
        {
            timer = 0;
        }
        if (timer == 0)
        {

                Shoot_();
                timer = cooldowntimer_bullet;

        }
    }

    public void Shoot_()
    {
        GameObject bullet = Instantiate(bullet_prefab, fireBullet.position, fireBullet.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(fireBullet.right * Speed, ForceMode2D.Impulse);
    }
}
