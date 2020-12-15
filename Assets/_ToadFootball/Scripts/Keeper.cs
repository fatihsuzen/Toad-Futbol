using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Keeper : MonoBehaviour
{
    public GameObject Ball;
    public GameObject KeeperWall;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            
            //Ball.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward * 15));
            Ball.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 15);
            //Ball.GetComponent<Rigidbody>().AddForce(new Vector3(transform.position.x, transform.position.y,5) * -500);
        }
    }
}
