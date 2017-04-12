using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class EnemySpawn : NetworkBehaviour 
{
	[SerializeField]
	private GameObject _enemyPrefab;

	[SerializeField]
	private int _enemyQuantity;

	public override void OnStartServer () 
	{
		base.OnStartServer ();

		for (int i = 0; i < _enemyQuantity; i++) 
		{
			Vector3 spawnPosition = new Vector3 (Random.Range (-9, 14), 0, Random.Range (-4, 20));
			Vector3 spawnRotation = new Vector3 (0, Random.Range (0f, 180f), 0);

			GameObject temp = Instantiate (_enemyPrefab, spawnPosition, Quaternion.Euler (spawnRotation)) as GameObject;
			NetworkServer.Spawn (temp);
		}
	}
}
