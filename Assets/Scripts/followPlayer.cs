using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * 1f);

        }
    }
}
