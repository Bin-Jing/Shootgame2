using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CannonHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public GameObject DeadExplosion;
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public AudioClip deathClip;

	AudioSource audioSource;

	bool isDead;
	bool damaged = false;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			audioSource.PlayOneShot (deathClip);
			StartCoroutine (KillPlayer());
		}
		if(damaged){
			damageImage.color = flashColour;
		}
		else{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}
	public void applyDamage(int damage){
		damaged = true;
		currentHealth -= damage;
		healthSlider.value = currentHealth;
	}
	IEnumerator KillPlayer(){
		Instantiate (DeadExplosion, this.transform.position, this.transform.rotation);

		yield return new WaitForSeconds(2.0f);

		Application.LoadLevel(2);
		Destroy (this.gameObject,2);
	}
}
