using UnityEngine;
using UnityEngine.Networking;

public class enemy : NetworkBehaviour 
{
	healthController _targetHealth;

	void SearchPlayer ()
	{
		Debug.Log ("search player");
		var temp = FindObjectsOfType<playerController>();

		if (temp == null || temp.Length == 0)
			return;
		
		var randItem = temp [Random.Range (0, temp.Length)];

		if (randItem == null)	return;
		_targetHealth = randItem.gameObject.GetComponent<healthController> ();
	}
	
	void Update () 
	{
		if (_targetHealth == null)
		{
			SearchPlayer ();
			return;
		}

		if (Vector3.Distance (transform.position, _targetHealth.transform.position) < 1)
		{
			Debug.Log("attack!");
			_targetHealth.TakeDamage(5);
			if(_targetHealth.CurrentHealth == 0) _targetHealth = null;
			return;
		}

		transform.position = Vector3.MoveTowards(transform.position, _targetHealth.transform.position, 
			Time.deltaTime);
		transform.LookAt (_targetHealth.transform);
	}
}