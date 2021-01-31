using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisHandler : MonoBehaviour
{
    public GameObject boardPrefab;
    GameObject background;
    GameObject gameboard;
    SpawnerScript spawnerScript;
    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.CreatePrimitive(PrimitiveType.Cube);
        background.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        background.transform.parent = transform;
        background.transform.localScale = new Vector3(200, 200, 1);
        gameboard = Instantiate(boardPrefab, transform);
        gameboard.transform.localPosition = new Vector3(0, -6, -10);
        spawnerScript = gameboard.GetComponentInChildren<SpawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnerScript.end)
        {
            float score = spawnerScript.GetScore();
            StaticChildren.currentStudent.joy -= Mathf.RoundToInt((20 * (score/100)));
            GameManager.minigamesComplete++;
            Destroy(transform.gameObject);

        }
    }
}
