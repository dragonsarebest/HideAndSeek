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
        
        StartCoroutine(WaitForAnim(anim,2));

    }
    public void playPaper()
    {
        Transform paper = transform.GetChild(1);
        Animator animcon = paper.GetComponent<Animator>();
        AnimationClip anim = animcon.runtimeAnimatorController.animationClips[0];

        StartCoroutine(WaitForAnim(anim, 1));
    }
    public void playWalking()
    {
        Transform walk = transform.GetChild(3);
        Animator animcon = walk.GetComponent<Animator>();
        AnimationClip anim = animcon.runtimeAnimatorController.animationClips[0];

        StartCoroutine(WaitForAnim(anim, 3));
    }
    IEnumerator WaitForAnim(AnimationClip animclip, int child)
    {
        Transform anim = transform.GetChild(child);
        anim.gameObject.SetActive(true);
        float tempTime = animclip.length;
        yield return new WaitForSeconds(tempTime);
        anim.gameObject.SetActive(false);
        StaticChildren.DisableTransitions();
    }
}
