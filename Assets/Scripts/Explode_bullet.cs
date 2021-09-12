using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode_bullet : MonoBehaviour
{
    public int amount;
    private bool isHit;
    public float timer ;
    public LayerMask whatIsEnemies;

    private UnityEngine.Object ParRef;
    // Start is called before the first frame update
    void Start()
    {
        ParRef = Resources.Load("Explode_par");
        timer = 1.5f;
        isHit = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0) { timer -= 1 * Time.deltaTime; }
        if(timer <= 0  || (timer < .8f && isHit))
        {
            Collider2D[] enemiesToDmg = Physics2D.OverlapCircleAll(transform.position, 2, whatIsEnemies);
            if (enemiesToDmg.Length != 0)
            {
                if(enemiesToDmg.Length <= amount)
                {
                    for (int i = 0; i < enemiesToDmg.Length; i++)
                    {
                        enemiesToDmg[i].GetComponent<enemy>().health -= 2;

                    }
                }
                else
                {
                    for (int i = 0; i < amount; i++)
                    {
                        enemiesToDmg[i].GetComponent<enemy>().health -= 2;

                    }
                }

            }
            GameObject explosion = (GameObject)Instantiate(ParRef);
            explosion.transform.position = new Vector2(transform.position.x, transform.position.y);
            FindObjectOfType<SoundManager>().Play("explode");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            isHit = true;
        }
    }
}
