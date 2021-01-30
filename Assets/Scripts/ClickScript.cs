using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ClickScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject minigame;
    public void OnPointerClick(PointerEventData eventData)
    {
        Instantiate(minigame,transform.parent);
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
