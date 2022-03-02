using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParaUI : MonoBehaviour
{
    public PlayerController characterController;
    TextMeshProUGUI ParaText;
    // Start is called before the first frame update
    void Start()
    {
        ParaText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ParaText.text = characterController.GetToplamPara() + " $";
    }
}
