using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    private SpriteRenderer rend;
    private GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        rend = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        print(rend.color);
        rend.color = new Color(255-cam.transform.position.y*10, 255 - cam.transform.position.y * 10, 255 - cam.transform.position.y * 10);
    }
}
