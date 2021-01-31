using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionHandler : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void playHammer()
    {
        Transform hammer = transform.GetChild(2);
        Animator animcon = hammer.GetComponent<Animator>();
        AnimationClip anim = animcon.runtimeAnimatorController.animationClips[0];
        
        StartCoroutine(WaitForAnim(anim,1));

    }

    IEnumerator WaitForAnim(AnimationClip animclip, float spd)
    {
        Transform hammer = transform.GetChild(2);
        hammer.gameObject.SetActive(true);
        float tempTime = animclip.length * (1 / spd);
        yield return new WaitForSeconds(tempTime);
        hammer.gameObject.SetActive(false);
        StaticChildren.DisableTransitions();
    }
}
