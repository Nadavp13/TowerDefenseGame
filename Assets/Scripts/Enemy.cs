using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

	public float startingSpeed = 10f;
	public static int EnemiesKilled = 0;
	[HideInInspector]
	public float speed;
	public float startHealth = 100;
	private float health;
	public int worth = 50;

	public GameObject deathEffect;

	public HealthBar healthBar;
	public Transform healthBarCanvas;
	public float healthBarY = 0;
	public float healthBarZ = 0;

	[Header("Unity Stuff")]
	public static float spawnOffset = -2f;
	private Vector3 offset = new Vector3(0, spawnOffset, 0);

	private bool isDead = false;
	

	void Start()
	{
		speed = startingSpeed;
		health = startHealth;
		healthBar.SetMaxHealth(health);
		//Offset
		transform.position += offset;
	}

	public void TakeDamage(float amount)
	{
		health -= amount;
		healthBar.SetHealth(health);
		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	public void Slow(float pct)
	{
		speed = startingSpeed * (1f - pct);
	}

	void Die()
	{
		isDead = true;
		PlayerStats.Money += worth;

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);

		WaveSpawner.enemiesAlive--;
		EnemiesKilled++;
		Destroy(gameObject);
	}

	public static int GetEnemiesKilled()
    {

		return EnemiesKilled;
    }
}