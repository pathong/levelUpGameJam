using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petMove : MonoBehaviour
{
    public bool isClick;
    public GameObject player;
    public GameObject main;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(screenPosition), Time.fixedDeltaTime * 3f);
        
    }
    

}
