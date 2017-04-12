using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class healthController : NetworkBehaviour 
{
	public int CurrentHealth
	{
		get
		{ 
			return currentHealth;
		}	
	}

	[SyncVar(hook = "OnChangeHealth")]
	private int currentHealth = 200;

	[SerializeField]
	private RectTransform _healthBar;

	[SerializeField]
	private bool _destroyOnDeath;

	void OnChangeHealth (int health) 
	{
		_healthBar.sizeDelta = new Vector2 (health, _healthBar.sizeDelta.y);
	}

	public void TakeDamage (int amount)
	{
		if (!isServer)
			return;
		currentHealth -= amount;

		if (currentHealth <= 0) 
		{
			currentHealth = 0;
			Debug.Log ("dead");
		
			if (_destroyOnDeath)
				Destroy (gameObject);
			else
				RpcRespawn ();
		}
	}

	[ClientRpc]
	void RpcRespawn()
	{
		currentHealth = 200;
		if (isLocalPlayer) 
		{
			transform.position = NetworkManager.singleton.GetStartPosition ().position;
		}
	}
}
