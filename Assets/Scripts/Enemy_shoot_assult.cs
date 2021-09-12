using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shoot_assult : MonoBehaviour
{
    public int bullet_count;
    private float Speed = 5f;
    public Transform fireBullet;
    public GameObject bullet_prefab; private float timer = 2f;
    public float cooldowntimer_bullet = 1;
    private AudioSource audio_;

    public int amount =  5;
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
            StartCoroutine(Shoot_());

            timer = 5;

        }
    }

    IEnumerator Shoot_()
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(.1f);
            GameObject bullet = Instantiate(bullet_prefab, fireBullet.position, fireBullet.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(fireBullet.right * Speed, ForceMode2D.Impulse);
        }
    }


}
