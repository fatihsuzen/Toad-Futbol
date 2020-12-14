using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
	public GameObject GoalObject;
	public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GetComponent<AudioSource>().Play();
            other.gameObject.transform.position = new Vector3(-6.06f, 0.4999999f, -7.27f);

			int Rnd = Random.Range(0, 2);
			int RndX = Random.Range(-4, 4);
			if (Rnd % 2 == 0)
			{
				RndX *= -1;
			}

			int RndZ = Random.Range(-10, 10);

			if (RndX == 0)
			{
				RndX = Random.Range(-10, 10);

				if (RndX == 0)
				{
					RndX = Random.Range(-10, 10);
				}
			}
			other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(RndX, 0.4999999f, RndZ) * 150);
			GoalObject.SetActive(true);
			animator.Play(0);

		}
    }
}
