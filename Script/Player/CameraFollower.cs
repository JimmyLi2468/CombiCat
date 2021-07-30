using UnityEngine;

public class CameraFollower : MonoBehaviour
{
	[SerializeField] Transform player;
	Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
		//transform.position = player.position + offset; follower the player
		// or following code that camera would stay in the middle
        Vector3 targetPos = player.position+offset;
		targetPos.x = 0;
		transform.position = targetPos;
    }
}
