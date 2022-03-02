using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellKahveChanger : MonoBehaviour
{
    public enum KahveTurleri
    {
        CreamaCup,
        EmptyCup,
        FilledCup,
        WithPipette,
        LidCup
    }
     KahveTurleri Tur;
    // Start is called before the first frame update
    void Start()
    {
        Tur = KahveTurleri.EmptyCup;
    }

    public void TurChanger(int tur)
    {
        transform.GetChild((int)Tur).gameObject.SetActive(false);
        Tur = (KahveTurleri)tur;
        transform.GetChild((int)Tur).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
