using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class playerController : NetworkBehaviour 
{
	[SerializeField]
	private Renderer _renderer;

	[SerializeField]
	private Rigidbody _bullet;

	[SerializeField]
	private Transform _bulletSpawn;

	public override void OnStartLocalPlayer () 
	{
		if (_renderer && _renderer.material)
			_renderer.material.color = Color.blue;
		base.OnStartLocalPlayer ();
	}
	
	void Update () 
	{
		if (!isLocalPlayer)
			return;

		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis ("Vertical") * Time.deltaTime * 3.0f;
	
		transform.Rotate (0, x, 0);
		transform.Translate (0, 0, z);

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			CmdFire ();
		}
	}

	[Command]
	private void CmdFire ()
	{
		var bullet = Instantiate (_bullet, _bulletSpawn.position, _bulletSpawn.rotation) as Rigidbody;

		if (!bullet)
		{
			Debug.Log ("notset");
			return;
		}

		bullet.velocity = bullet.transform.forward * 6;
		NetworkServer.Spawn (bullet.gameObject);

		Destroy (bullet.gameObject, 2.0f);
	}
}
