using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnMon : MonoBehaviour
{
    private float max_distance;

    private UnityEngine.Object ParRef;
    public Text wave_text;
    private bool pass;
    public GameObject[] mons;
    public int wave;
    private float timer;
    private float ran_x, ran_y;

    private void Start()
    {
        ParRef = Resources.Load("Spawn_par");
        wave = 0;
        timer = 3;
        max_distance = 17;
    }

    private void Update()
    {
        wave_text.text = "wave " + wave.ToString();
        if(GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            pass = true;
        }
        if (pass)
        {
            if (timer > 0) { timer -= 1*Time.deltaTime; }
            if(timer <= 0)
            {
                wave++;
                Spawn(wave);
                pass = false;
                timer = 3;
                max_distance += 3;
            }
        }

    }


    public void Spawn(int number)
    {
        for (int i = 0; i < number + 3; i++)
        {
            int ran_idex = Random.Range(0, mons.Length);
            while (true)
            {
                float ran_x = Random.Range(GameObject.FindGameObjectWithTag("Player").transform.position.x - max_distance, GameObject.FindGameObjectWithTag("Player").transform.position.x + max_distance);
                float ran_y = Random.Range(GameObject.FindGameObjectWithTag("Player").transform.position.y - max_distance, GameObject.FindGameObjectWithTag("Player").transform.position.y + max_distance);
                if(Vector2.Distance(new Vector2( ran_x, ran_y), new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y)) > 7){
                    Instantiate(mons[ran_idex], new Vector2(ran_x, ran_y), Quaternion.identity);
                    GameObject explosion = (GameObject)Instantiate(ParRef);
                    explosion.transform.position = new Vector2(ran_x, ran_y);
                    break;
                }    
            }


        }
    }
}
