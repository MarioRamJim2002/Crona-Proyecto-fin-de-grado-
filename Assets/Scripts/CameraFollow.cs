using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float FollowSpeed = 10f;
    public Transform target;
    public GameObject nieve;
    void Start(){
        
    }

    void Update()
    {
        
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
        nieve.transform.position = new Vector3(transform.position.x,transform.position.y+10,transform.position.z);

    }
}
