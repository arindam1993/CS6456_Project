using UnityEngine;
using System.Collections;

public class HealthManagerScript : MonoBehaviour {

	public float startHealth;
	public Transform healthBar;

	private float currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = startHealth;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void heal(float healAmount){
		currentHealth += healAmount;
	}

	public void damage(float dmgAmount){
		currentHealth -= dmgAmount;
		Debug.Log (gameObject.name + " takes " + dmgAmount + "damage" + currentHealth/startHealth);
		healthBar.transform.localScale -= new Vector3(dmgAmount/startHealth, 0, 0);
	}
}
