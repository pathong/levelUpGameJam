using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private SpriteRenderer rend;
    private Material WhiteMat;
    private Material DefaultMat;

    public GameObject item;
    public int health;
    private UnityEngine.Object ParRef;
    private UnityEngine.Object HitRef;
    public GamCon _gameCon;
    // Start is called before the first frame update
    void Start()
    {
        ParRef = Resources.Load("Explode_par");
        HitRef = Resources.Load("Hit_par");
        _gameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GamCon>();
        rend = this.GetComponent<SpriteRenderer>();

        DefaultMat = rend.material;
        WhiteMat = Resources.Load("FlashWhite", typeof(Material)) as Material;




    }

    // Update is called once per frame
    void Update()
    {
       
        if (health <= 0)
        {
            FindObjectOfType<SoundManager>().Play("explode");
            _gameCon.score += 100;
            int ran = Random.Range(1, 10);

            for (int i = 0; i < ran; i++)
            {
                float ran_x = Random.Range(transform.position.x - .5f, transform.position.x + .5f);
                float ran_y = Random.Range(transform.position.y - .5f, transform.position.y + .5f);
                Instantiate(item, new Vector2 (ran_x, ran_y), Quaternion.identity);
            }
            Destroy(gameObject);
            GameObject explosion = (GameObject)Instantiate(ParRef);
            explosion.transform.position = new Vector2(transform.position.x, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            if(health > 0)
            {
                FindObjectOfType<SoundManager>().Play("hit");

            }
            rend.material = WhiteMat;
            Invoke("Reset_mat", .1f);
        }
    }

    void Reset_mat()
    {
        rend.material = DefaultMat;
    }


}
