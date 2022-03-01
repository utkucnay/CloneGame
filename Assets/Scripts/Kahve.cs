using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kahve : MonoBehaviour
{
    int Para = 8;
    public Rigidbody rb;
    PlayerController pc;
    int Sira;
    float Delay = 0.05f;
    public float forwardForce = 20;
    public float sidewaysForce;
    GameObject Player;
    public Transform FinishPoint;
    bool Finish = false;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        pc = Player.GetComponent<PlayerController>();
        Delay *= (Sira+1);
        InvokeRepeating("KahveReset", 0f, Delay * 2);
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
    }

    void ForwardForce()
    {
        transform.position += new Vector3(0, 0, forwardForce * Time.deltaTime);
    }

    public void SetSira(int sira)
    {
        Sira = sira;
    }

    public void Left(float sidewaysForce)
    {
        this.sidewaysForce = sidewaysForce;
        Invoke("LeftDelay", Delay);
    }

    public int GetPara()
    {
        return Para;
    }
    void LeftDelay()
    {
        transform.position += new Vector3(sidewaysForce * -1 * Time.deltaTime, 0, 0);
    }
    public void Right(float sidewaysForce)
    {
        this.sidewaysForce = sidewaysForce;
        Invoke("RightDelay", Delay);
    }
    void RightDelay()
    {
        transform.position += new Vector3(sidewaysForce * 1 * Time.deltaTime, 0, 0);
    }
    void KahveReset()
    {
        transform.position = Vector3.MoveTowards(transform.position,new Vector3 (Player.transform.position.x,Player.transform.position.y, transform.position.z),75f * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Para")
        {
            Para += 8;
            pc.SetPara(8);
        }
        if (other.tag == "Engel")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            pc.SetPara(-Para);
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
    }

    void GoFinish()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(FinishPoint.transform.position.x, FinishPoint.transform.position.y, FinishPoint.transform.position.z + 2.5f + Sira), 5f * Time.deltaTime);
    }
}
