using UnityEngine;
using System.Collections;

public class bulletController : MonoBehaviour
{
	void OnCollisionEnter(Collision col) 
	{
		var health = col.gameObject.GetComponent<healthController> ();
		if (health)
			health.TakeDamage (50);
		Destroy (gameObject);
	}
}
