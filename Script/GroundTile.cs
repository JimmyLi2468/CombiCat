using UnityEngine;
using SkillzSDK;


public class GroundTile : MonoBehaviour
{

	GroundSpawner groundSpawner;
	[SerializeField] GameObject coinPrefab;
	[SerializeField] GameObject obstaclePrefab;
	[SerializeField] GameObject tallObstaclePrefab;
	[SerializeField] float tallObstacleChance = 0.4f;
	
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
		//SpawnObstacle();
		//SpawnCoins();
    }

	private void OnTriggerExit(Collider other){
		groundSpawner.SpawnTile(true);
		Destroy(gameObject,1);
	}
	
	
	public void SpawnObstacle(){
		
		//choose which to spawn
		GameObject obstacleToSpawn = obstaclePrefab;
		float random = SkillzCrossPlatform.Random.Range(0f,1f);
		if(random<tallObstacleChance){
			obstacleToSpawn = tallObstaclePrefab;
		}
		
		//choose a random point to spawn the obstacle
		int obstacleSpawnIndex = SkillzCrossPlatform.Random.Range(2,5);
		Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
		//spawn the obstacle at the position
		Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform); //spawn(object to spawn, position to spawn, no rotation, to set to it's parent so when destroyed the object will be destroyed as well)
		
	}
	
	
	public void SpawnCoins (){
		int coinsToSpawn = 3;
		for (int i = 0; i<coinsToSpawn; i++){
			GameObject temp = Instantiate(coinPrefab,transform);
			temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
		}
	}
	
	Vector3 GetRandomPointInCollider(Collider collider){
		float randomx = SkillzCrossPlatform.Random.Range(0f,1f);
		int xpos = 0;
		if(randomx<0.33f){
			xpos = -3;
		}
		else if(randomx < 0.66f){
			xpos = 0;
		}
		else{
			xpos = 3;
		}
		Vector3 point = new Vector3(
			xpos,
			SkillzCrossPlatform.Random.Range((int)collider.bounds.min.y,(int)collider.bounds.max.y),
			SkillzCrossPlatform.Random.Range((int)collider.bounds.min.z,(int)collider.bounds.max.z)
			);
		if (point != collider.ClosestPoint(point)){
			point = GetRandomPointInCollider(collider);
		}
		
		point.y = 1;
		return point;
	}
}
