using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

	public int startHealth;
	private int currentHealth;
	public int shellDamage;

	public Slider healthSlider;                                 // Reference to the UI's health bar.
	public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
	public AudioClip deathClip;                                 // The audio clip to play when the player dies.
	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
	public Canvas gameOverCanvas;

	private bool damaged = false;
	
	// Use this for initialization
	void Start () {
		currentHealth = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(damaged)
		{
			damageImage.color = flashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}
	
	void OnCollisionEnter(Collision col) {
		hit (col);
	}
	
	public void hit(Collision col) {
		if (col.gameObject.name.Contains("Shell")) {
			damaged = true;
			currentHealth -= shellDamage;
			displayPlayerHealth(startHealth, currentHealth);
			if (currentHealth <= 0) {
				GetComponent<Animator>().SetBool("IsDead", true);
				GameStatus.getInstance().stopTanks();
				GetComponent<Control>().disabled = true;
				gameOverCanvas.GetComponent<CanvasGroup>().alpha = 1f;
				gameOverCanvas.GetComponent<CanvasGroup>().interactable = true;
				gameOverCanvas.GetComponent<RecordHighScore>().recordAndDisplayScore(GameStatus.getInstance().getScore());
			}
		}
	}

	public void displayPlayerHealth(int total, int current) {
		int percent = (total / 100) * current;
		healthSlider.value = percent;
	}
}
