using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    private GameObject player;
    public float moveSpeed;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -180, transform.rotation.z), 1000 * Time.deltaTime);
        }
        if (player.transform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, transform.rotation.z), 1000 * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, player.transform.position) > distance)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * moveSpeed);

        }
    }
}
