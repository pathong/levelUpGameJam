using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float ro;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        ro = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //ro += Time.deltaTime;
        //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, ro);
        timer -= 1 * Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }

    }
}
