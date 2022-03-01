using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParaUI : MonoBehaviour
{
    public PlayerController characterController;
    Text ParaText;
    // Start is called before the first frame update
    void Start()
    {
        ParaText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ParaText.text ="Para: " +characterController.GetToplamPara();
    }
}
