using UnityEngine;

public class billBoard : MonoBehaviour 
{
	void Update () 
	{
		transform.forward = Camera.main.transform.forward;
	}
}
