using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pet : MonoBehaviour
{

    private GamCon _gamecon;

    private bool notded;

    public GameObject par;
    private UnityEngine.Object HitRef;
    public Text text;

    private SpriteRenderer _spriteRenderer;

    public GameObject red_par;
    public GameObject blue_par;
    public bool element; // true = red , false = blue

    public float health;
    // Start is called before the first frame update
    void Start()
    {
        _gamecon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GamCon>();
        notded = false;
        par = GameObject.Find("par");
        element = true;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        health = 11;
        HitRef = Resources.Load("Explode_par");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = health.ToString();
        if (Input.GetKeyDown(KeyCode.R) && health > 3)
        {

            element = !element;
            if (_gamecon.isStart)
            {
                health -= 1;
            }
        }

        if(element == true)
        {
            _spriteRenderer.color = Color.red;
            red_par.SetActive(true);
            blue_par.SetActive(false);
        }
        if(element == false)
        {
            _spriteRenderer.color = Color.white;
            red_par.SetActive(false);
            blue_par.SetActive(true);
        }


        if(health <= 0)
        {
            health = 0;
            this.GetComponentInChildren<Shoot>().enabled = false;
            par.SetActive(false);
            this.GetComponent<petMove>().enabled = false;
            this.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            if (!notded)
            {
                GameObject explosion = (GameObject)Instantiate(HitRef);
                explosion.transform.position = new Vector2(transform.position.x, transform.position.y);
                notded = true;
            }
          
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "item")
        {
            FindObjectOfType<SoundManager>().Play("Collect");

            Destroy(collision.gameObject);
            health += 1;
        }
    }


}
