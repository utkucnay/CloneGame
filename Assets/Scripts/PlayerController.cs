using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Transform LastKahveLocations;

    int ToplamPara = 8;

    public float forwardForce = 20f;
    public float sidewaysForce = 200f;

    bool finish = false;
    public Transform FinishPoint;

    public int KahveLenght = 1;

    private Vector2 initialPosition;
    private Touch touch;

    void Update()
    {
        if (!finish)
        {
            ForwardForce();
            //MobileDeviceInput();
            PCInput();
        }
        else
        {
            Finish();
        }
    }

    public void SetPara(int Para) {
        ToplamPara += Para;
    }

    public int GetToplamPara()
    {
        return ToplamPara;
    }

    public void NewLastKahveLocations(int index)
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("EldeKahve"))
        {
            if (item.GetComponent<Kahve>().GetSira() == index)
            {
                LastKahveLocations = item.transform;
            }
        }
    }

    private void Finish()
    {
        transform.position = Vector3.MoveTowards(transform.position,FinishPoint.transform.position,5f*Time.deltaTime);
    }

    void ForwardForce()
    {
        transform.position += new Vector3(0, 0, forwardForce * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Kahve")
        {
            KahveAl(other.gameObject.GetComponent<Kahve>());
        }
        if (other.gameObject.tag == "Finish")
        {
            finish = true;
        }
    }

    public void KahveAl(GameObject Kahve)
    {
        KahveAl(Kahve.GetComponent<Kahve>());
    }

    public void KahveAl(Kahve kahve)
    {
        kahve.gameObject.transform.position = new Vector3(LastKahveLocations.transform.position.x, transform.position.y, transform.position.z + KahveLenght);
        if (KahveLenght == 0)
        {

        }
        else
        {
            LastKahveLocations.gameObject.GetComponent<Kahve>().SetTransformNextCoffee(kahve.transform);
            
        }
        LastKahveLocations = kahve.transform;
        kahve.enabled = true;
        kahve.SetSira(KahveLenght);
        KahveLenght++;
        kahve.gameObject.tag = "EldeKahve";
        ToplamPara += kahve.GetPara();
    }

    void MobileDeviceInput()
    {
        
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                initialPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                var direction = touch.position - initialPosition;
                var signedDirection = Mathf.Sign(direction.x);
                transform.position += new Vector3(sidewaysForce * signedDirection * Time.deltaTime, 0, 0);
            }
        }
    }
    void PCInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(sidewaysForce * -1 * Time.deltaTime, 0, 0);
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(sidewaysForce * 1 * Time.deltaTime, 0, 0);
        }
    }

    public void KahveDuzenle(int index)
    {
        KahveLenght--;
        foreach (var item in GameObject.FindGameObjectsWithTag("EldeKahve"))
        {
            if(item.GetComponent<Kahve>().GetSira() > index)
            {
                Destroy(item);
                KahveLenght--;
            }
            if (item.GetComponent<Kahve>().GetSira() == index - 1)
            {
                LastKahveLocations = item.transform;
            }
        }
        

    }
}
