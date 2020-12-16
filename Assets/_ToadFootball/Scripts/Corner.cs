using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corner : MonoBehaviour
{
    public static bool isForward;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Ball")
        {
            if (isForward)
            {
                //collision.collider.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 500);
            }
            else
            {
                //collision.collider.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 500);
            }
        }
    }
}
