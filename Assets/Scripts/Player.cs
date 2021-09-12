using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public bool isded;

    private SpriteRenderer rend;
    private Material WhiteMat;
    private Material DefaultMat;

    private UnityEngine.Object ParRef;
    public GamCon _gameCon;
    private Pet _pet;
    private UnityEngine.Object HitRef;

    private void Start()
    {
        rend = this.GetComponent<SpriteRenderer>();
        DefaultMat = rend.material;
        WhiteMat = Resources.Load("FlashWhite", typeof(Material)) as Material;

        isded = false;
        ParRef = Resources.Load("Explode_par");
        _gameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GamCon>();
        _pet = GameObject.FindGameObjectWithTag("Pet").GetComponent<Pet>();
        HitRef = Resources.Load("Hit_par");
    }

    private void Update()
    {
        if(_pet.health <= 0)
        {

            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<PlayerMove>().enabled = false;
            if (!isded)
            {
                FindObjectOfType<SoundManager>().Play("enemy_explode");
                GameObject explosion = (GameObject)Instantiate(ParRef);
                explosion.transform.position = new Vector2(transform.position.x, transform.position.y);
                isded = true;
            }
           
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            FindObjectOfType<SoundManager>().Play("hit");
            FindObjectOfType<SoundManager>().Play("Player_hit");
            rend.material = WhiteMat;
            Invoke("Reset_mat", .1f);

            GameObject explosion = (GameObject)Instantiate(HitRef);
            explosion.transform.position = new Vector2(transform.position.x, transform.position.y);
            ShakeIt();
            _pet.health -= 3;
            _gameCon.score -= 10;
        }
    }



    public void ShakeIt()
    {
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", .01f);
    }

    void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * .2f * 2 - .1f;
        float cameraShakingOffsetY = Random.value * .2f * 2 - .1f;
        Vector3 cameraIntermadiatePosition = Camera.main.transform.position;
        cameraIntermadiatePosition.x += cameraShakingOffsetX;
        cameraIntermadiatePosition.y += cameraShakingOffsetY;
        Camera.main.transform.position = cameraIntermadiatePosition;
    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        Camera.main.transform.position = Camera.main.transform.position;
    }


    void Reset_mat()
    {
        rend.material = DefaultMat;
    }

}
