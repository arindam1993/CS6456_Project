using UnityEngine;
using System.Collections;

public class HealthManagerScript : MonoBehaviour {

	public float startHealth;
	public Transform healthBar;
	
	public Transform upgradeBar;
	public float upgradeProgress;
	public float upgradeDecay;
	public GameObject upgradedObject;

	private float currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = startHealth;
		//upgradeBar.transform.localScale = new Vector3(upgradeProgress/100, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.name == "wall")
		{
			upgradeProgress-=upgradeDecay;
			upgradeProgress = Mathf.Clamp(upgradeProgress, 0, 100);
			upgradeBar.transform.localScale = new Vector3(upgradeProgress/100, 1, 1);
		}

	}

	public void heal(float healAmount){
		Debug.Log (gameObject.name + " healed by " + healAmount + "HP" + currentHealth/startHealth);
		if(currentHealth<startHealth)
		{
			currentHealth += healAmount;
			currentHealth=Mathf.Clamp(currentHealth,0,startHealth);
			
			healthBar.transform.localScale = new Vector3(currentHealth/startHealth, 1, 1);
		}else if(currentHealth == startHealth){
			if(gameObject.name == "wall")
			{
				upgradeProgress+=healAmount;
				upgradeBar.transform.localScale = new Vector3(upgradeProgress/100, 1, 1);
				if(upgradeProgress > 100){
					upgradedObject.SetActive(true);
					gameObject.SetActive(false);
				}
			}
		}
	}

	public void damage(float dmgAmount){
		currentHealth -= dmgAmount;
		currentHealth=Mathf.Clamp(currentHealth,0,startHealth);
		Debug.Log (gameObject.name + " takes " + dmgAmount + "damage" + currentHealth/startHealth);
		healthBar.transform.localScale = new Vector3(currentHealth/startHealth, 1, 1);
		if (currentHealth <= 0) {
			Destroy(gameObject, 0.1f);

			if(gameObject.name == "teapot"){
				endGame();
			}
			else{

				}
		}

	}

	private void endGame(){
		float threshold = 2.5f;
		GameObject.Find("infoText").GetComponent<TextMesh>().text = "You lose. Play again?";
	}
}
