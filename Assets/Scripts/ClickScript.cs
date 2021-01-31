using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ClickScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject minigame;
    GameObject instantGame;
    public void OnPointerClick(PointerEventData eventData)
    {
        instantGame = Instantiate(minigame,transform.parent);
        instantGame.transform.position = new Vector3(0, 0, -5);
        Debug.Log("Clicked It");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
