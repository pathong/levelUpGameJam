using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    private Pet _pet;
    private float Speed;
    public Transform fireBullet;
    public GameObject red_bullet_prefab;
    public GameObject blue_bullet_prefab;
    public float timer ;
    public float cooldowntimer_bullet = 1;
    private GameObject bullet;

    void Start()
    {
        _pet = GetComponentInParent<Pet>();    
    }

    void Update()
    {
        if(_pet.element == true)
        {
            bullet = red_bullet_prefab;
            Speed = 14f;

        }
        if(_pet.element == false)
        {
            bullet = blue_bullet_prefab;
            Speed = 6f;

        }



        if(timer > 0)
        {
            timer -= 1* Time.deltaTime;
        }
        if(Input.GetMouseButtonDown(0) && timer <= 0 && _pet.health > 0 && Time.timeScale != 0)
        {

            Shoot_(bullet);
            FindObjectOfType<SoundManager>().Play("shoot");

            _pet.health -= 1;

            if (_pet.element == true)
            {
                timer = .3f;


            }
            if (_pet.element == false)
            {
                timer = 1.5f;

            }
        }
        
    }

    public void Shoot_(GameObject bullet)
    {
        GameObject _bullet = Instantiate(bullet, fireBullet.position, fireBullet.rotation );
        Rigidbody2D rb = _bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(fireBullet.right * Speed, ForceMode2D.Impulse);
    }
}
