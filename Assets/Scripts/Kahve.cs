using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kahve : MonoBehaviour
{
    enum KahveTurleri
    {
        CreamaCup,
        EmptyCup,
        FilledCup,
        WithPipette,
        LidCup
    }

    int Para = 8;
    Transform TransformNextCoffee;
    PlayerController pc;
    [SerializeField]
    int Sira;
    public float forwardForce = 20;
    GameObject Player;
    public Transform FinishPoint;
    bool Finish = false;
    KahveTurleri Tur;

    void Start()
    {
        Tur = KahveTurleri.EmptyCup;
        Player = GameObject.FindWithTag("Player");
        pc = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Finish)
        {
            ForwardForce();
        }
        else
        {
            GoFinish();
        }
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (transform.position.x - pc.transform.position.x > 0.1f || transform.position.x - pc.transform.position.x < -0.1f)
        {
            if (transform.position.x < pc.transform.position.x)
            {
                transform.position += new Vector3((100f / (Sira + 5)) * Time.deltaTime, 0, 0);
            }
            else if (transform.position.x > pc.transform.position.x)
            {
                transform.position -= new Vector3((100f / (Sira + 5)) * Time.deltaTime, 0, 0);
            }
        }
    }

    void ForwardForce()
    {
        transform.position += new Vector3(0, 0, forwardForce * Time.deltaTime);
    }

    public void SetTransformNextCoffee(Transform TransformNextCoffee)
    {
        this.TransformNextCoffee = TransformNextCoffee;
    }

    public void SetSira(int sira)
    {
        Sira = sira;
    }

    public int GetSira()
    {
        return Sira;
    }

    public int GetPara()
    {
        return Para;
    }

    void OndekileriDusur()
    {
        if (TransformNextCoffee != null)
        {
            TransformNextCoffee.position += new Vector3(0,0,Random.Range(4,9));
            TransformNextCoffee.tag = "Kahve";
            TransformNextCoffee.GetComponent<Kahve>().enabled = false;
            TransformNextCoffee.GetComponent<Kahve>().OndekileriDusur();
            pc.SetPara(-TransformNextCoffee.GetComponent<Kahve>().Para);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Engel")
        {

            pc.SetPara(-Para);
            foreach (var item in GameObject.FindGameObjectsWithTag("EldeKahve"))
            {
                if (item.GetComponent<Kahve>().Sira == Sira-1)
                {
                    pc.LastKahveLocations = item.transform;
                }
            }
            if (pc.KahveLenght != 0)
            {

            }
            else
            {
                pc.LastKahveLocations = pc.transform;
            }
            pc.KahveLenght = Sira;
            OndekileriDusur();
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        if (other.tag == "Finish")
        {
            FinishPoint =  pc.FinishPoint;
            Finish = true;
        }
        if (other.tag == "Kahve")
        {
            pc.KahveAl(other.gameObject);
        }
        if (other.tag == "FlowingCoffee")
        {
            transform.GetChild((int)Tur).gameObject.SetActive(false);
            Tur = KahveTurleri.FilledCup;
            transform.GetChild((int)Tur).gameObject.SetActive(true);
            Para += 8;
            pc.SetPara(8);
        }
        if (other.tag == "CremaCupGate")
        {
            transform.GetChild((int)Tur).gameObject.SetActive(false);
            Tur = KahveTurleri.CreamaCup;
            transform.GetChild((int)Tur).gameObject.SetActive(true);
            Para += 8;
            pc.SetPara(8);
        }
        if (other.tag == "LidMaker")
        {
            transform.GetChild((int)Tur).gameObject.SetActive(false);
            Tur = KahveTurleri.LidCup;
            transform.GetChild((int)Tur).gameObject.SetActive(true);
            Para += 8;
            pc.SetPara(8);
        }
        if (other.tag == "SellField")
        {
            GameObject.FindGameObjectWithTag("SellKahve").GetComponent<Animator>().SetBool("isSell",true);
            if (pc.KahveLenght != 1)
            {
                
            }
            else
            {
                pc.LastKahveLocations = pc.transform;
            }
            pc.KahveDuzenle(Sira);
            Destroy(this.gameObject);

            //pc.NewLastKahveLocations(Sira-1);
        }
        if (other.tag == "FinishPoint")
        {
            Destroy(this.gameObject);
        }
    }



    void GoFinish()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(FinishPoint.transform.position.x, FinishPoint.transform.position.y, FinishPoint.transform.position.z + 2.5f + Sira), 5f * Time.deltaTime);
    }
}
