using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Keeper : MonoBehaviour
{
    public GameObject Ball;
    public GameObject KeeperWall;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            //Ball.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward * 15));
            Ball.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 15);
            //Ball.GetComponent<Rigidbody>().AddForce(new Vector3(transform.position.x, transform.position.y,5) * -500);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        
    }
    public void RightKepper()
    {
        KeeperWall.transform.DORotate(new Vector3(0, 120, 0), 0.3f);
        //KeeperWall.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(new Vector3(0,120, 0)));
    }
}
