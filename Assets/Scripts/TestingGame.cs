using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingGame : MonoBehaviour
{
    GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.CreatePrimitive(PrimitiveType.Cube);
        background.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
        background.transform.parent = transform;
        
        background.transform.localScale = new Vector3(200, 200, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //put minigame here and then delete self and children when done
        
    }
}
