using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

	private Transform target;
	private int wavepointIndex = 0;
	private Enemy enemy;
	private Vector3 offsetVector;

	void Start()
	{
		enemy = GetComponent<Enemy>();
		target = Waypoints.points[0];
		offsetVector = new Vector3(0f, enemy.healthBarY, enemy.healthBarZ); 
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
		enemy.healthBarCanvas.position = enemy.transform.position + offsetVector;

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
			transform.LookAt(target);
		}

		enemy.speed = enemy.startingSpeed;
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}

	void EndPath()
	{
		PlayerStats.Lives--;
		WaveSpawner.enemiesAlive--;
		Destroy(gameObject);
	}

	float RotateYValue(Vector3 dir)
    {
		if(dir.x > 0)
			return 90f;
		if(dir.x < 0)
			return -90f;
		if (dir.z > 0)
			return 90f;
		if (dir.z < 0)
			return -90f;
		else return 0;
    }
}