using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public BoxCollider2D cameraBounds;

    public bool isFollowing;

    public GameObject LeftBorder;

    private Transform player;

    private Vector2 min;
    private Vector2 max;



    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>().transform;
	}
	
	// Update is called once per frame
	void Update () {
        min = cameraBounds.bounds.min;
        max = cameraBounds.bounds.max;

        var x = transform.position.x;

        if (isFollowing)
        {
            if (player.position.x > x)
            {
                x = player.position.x;
            }
        }
        var cameraHaflWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);
        x = Mathf.Clamp(x, min.x + cameraHaflWidth, max.x - cameraHaflWidth);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
        LeftBorder.transform.position = new Vector2(x - cameraHaflWidth, transform.position.y);
    }
}
