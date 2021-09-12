using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    GameObject Child;
    private SpriteRenderer _rend;
    private float timer ;
    // Start is called before the first frame update
    void Start()
    {


        _rend = GetComponent<SpriteRenderer>();
        GameObject Child = this.gameObject.transform.GetChild(0).gameObject;
        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector2.Distance(transform.position, GameObject.FindWithTag("Pet").transform.position);


        if (dis <= 10)
        {

            //transform.position =  new Vector2(transform.position, GameObject.FindWithTag("Pet").transform.position, Time.deltaTime);
            float speed = 10 - dis;
            speed = speed * Time.deltaTime * .5f;
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindWithTag("Pet").transform.position, speed);

        }

        if(timer > 0) { timer -= Time.deltaTime; }
        //if(timer <= 3)
        //{
        //    while (true)
        //    {
        //        _rend.enabled = false;
        //        Child.SetActive(false);
        //        Invoke("ResetMat", .5f);
        //    }

        //}
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    //public void ResetMat()
    //{
    //    _rend.enabled = true;
    //    Child.SetActive(true);
    //}
}
