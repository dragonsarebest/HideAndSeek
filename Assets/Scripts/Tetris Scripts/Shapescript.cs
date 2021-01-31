using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapescript : MonoBehaviour
{
    public Vector3 rotationPoint;
    float timer;
    public bool active;
    public float fallTime = 1f;
    Vector3 spawn;
    SpawnerScript spawner;
  
    void Start()
    {
        spawner = transform.parent.GetComponent<SpawnerScript>();
        spawn = transform.position;
        timer = Time.time;

        if (!isValid())
        {
            spawner.EndGame();
            Destroy(gameObject);
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Application.Quit();

        }

        if (active)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position += new Vector3(1, 0);
                if (!isValid())
                {
                    transform.position -= new Vector3(1, 0);
                }

            }
            else if (Input.GetKeyDown(KeyCode.A) )
            {

                transform.position += new Vector3(-1, 0);
                if (!isValid())
                {
                    transform.position += new Vector3(1, 0);
                }
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                //transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);

                //if (!isValid())
                //{
                //    transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
                //}
            }
            if (Time.time - timer > (Input.GetKey(KeyCode.S) ? fallTime/8 : fallTime))
            {
                timer = Time.time;
                transform.position += new Vector3(0, -1);
                if (!isValid())
                {
                    transform.position += new Vector3(0, 1);
                    setNotActive();
                    if (transform.position == spawn)
                    {
                        spawner.EndGame();
                    }
                }
            }
        }

    }

    void setNotActive()
    {
        foreach (Transform children in transform)
        {
            
            SpawnerScript.board[(int)(children.position.y - spawn.y) + 10, (int)(children.position.x - spawn.x) + 5] = children;

        }
        active = false;
        
    }
    bool isValid()
    {
        foreach(Transform children in transform)
        {
            if(children.transform.position.x > spawn.x + 5 || children.transform.position.x < spawn.x - 5 || children.transform.position.y < spawn.y - 10)
            {
                return false;
            }
            try
            {
                if (SpawnerScript.board[(int)(children.position.y - spawn.y) + 10, (int)(children.position.x - spawn.x) + 5] != null)
                {
                    
                    return false;
                }
            }
            catch
            {
                Debug.Log(children.position.y - spawn.y + 10);
                Debug.Log((children.position.x - spawn.x) + 5);
            }
        }
        return true;
    }

}
