using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_bullet : MonoBehaviour
{
    public int amount;

    public float timer;
    public LayerMask whatIsEnemies;
    public bool isHit;
    private UnityEngine.Object ParRef;
    // Start is called before the first frame update
    void Start()
    {
        ParRef = Resources.Load("Hit_par");

        isHit = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) { timer -= 1 * Time.deltaTime; }
        if (timer <= 0 || isHit)
        {

            Collider2D[] enemiesToDmg = Physics2D.OverlapCircleAll(transform.position, 1, whatIsEnemies);
            print(enemiesToDmg.Length);
            if (enemiesToDmg.Length != 0)
            {

                enemiesToDmg[0].GetComponent<enemy>().health -= 1;


            }
            GameObject explosion = (GameObject)Instantiate(ParRef);
            explosion.transform.position = new Vector2(transform.position.x, transform.position.y);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            isHit = true;
        }
    }
}
