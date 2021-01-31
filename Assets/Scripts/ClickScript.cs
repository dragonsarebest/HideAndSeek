using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ClickScript : MonoBehaviour, IPointerClickHandler
{
    public enum animoption
    {
        Hammer, 
        Paper_Grab, 
        Walking
    };
    public GameObject minigame;
    GameObject instantGame;
    public animoption anim;
    public void OnPointerClick(PointerEventData eventData)
    {
        instantGame = Instantiate(minigame,transform.parent);
        instantGame.transform.position = new Vector3(0, 0, -5);
        TransitionHandler transhand = StaticChildren.CallTransition();
        switch(anim)
        {

            case animoption.Hammer:
            {
                transhand.playHammer();
                break;
            }
            case animoption.Paper_Grab:
            {

                break;
            }
        }

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
