using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorDisable : MonoBehaviour
{
    public PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.eulerAngles.z == 270f)
        {
            GetComponent<Animator>().enabled = false;
            pc.FinishAnimationLock = true;
        }
    }
}
