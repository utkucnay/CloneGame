using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public PlayerController FollowPlayer;
    private Vector3 Distance;
    float handYBegginerPos;
    void Start()
    {
        Distance = transform.position - FollowPlayer.transform.position;
        handYBegginerPos = FollowPlayer.transform.position.y;
    }

    void Update()
    {
        if (FollowPlayer.transform.position.z >= FollowPlayer.FinishPoint.transform.position.z)
        {
            //transform.position = new Vector3(transform.position.x, FollowPlayer.transform.position.y , Distance.z + FollowPlayer.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, FollowPlayer.transform.position.y +2, Distance.z + FollowPlayer.transform.position.z), 5f * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), 20f * Time.deltaTime);
        }
        else if (FollowPlayer.GetFinish())
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(50,0,0), 10f * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, FollowPlayer.transform.position.y + Distance.y + 5, Distance.z + FollowPlayer.transform.position.z),5f * Time.deltaTime) ;
            //transform.position = new Vector3(transform.position.x, FollowPlayer.transform.position.y + Distance.y +5, Distance.z + FollowPlayer.transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, FollowPlayer.transform.position.y + Distance.y, Distance.z + FollowPlayer.transform.position.z);
        }
    }

}