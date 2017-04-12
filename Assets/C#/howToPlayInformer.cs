using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class howToPlayInformer : MonoBehaviour {

	[SerializeField]
	private GameObject _startInfo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) || Input.GetKeyUp(KeyCode.I))
		{
			_startInfo.SetActive (false);
		}

		if (Input.GetKeyDown(KeyCode.I))
		{
			_startInfo.SetActive (true);
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit ();		
		}
	}
}
