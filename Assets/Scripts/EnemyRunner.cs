using UnityEngine;
using System.Collections;

public class EnemyRunner : MonoBehaviour {

    private bool onGround;
    public Transform groundSensor;

    private bool cliffAhead;
    public Transform cliffSensor;

    public LayerMask ground;

    private Rigidbody2D myBody;

    public float moveSpeed;
    public float jumpHeight;

    private bool reacted;

    // Use this for initialization
    void Start () {
        myBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        onGround = Physics2D.OverlapCircle(groundSensor.position, 0.1f, ground);
        cliffAhead = !Physics2D.OverlapCircle(cliffSensor.position, 0.1f, ground);

        if(onGround && cliffAhead && !reacted)
        {
            Debug.Log("react");
            ReactToCliff(Random.Range(0,3));
        }
        if (onGround && !cliffAhead && reacted)
        {
            reacted = false;
        }

        myBody.velocity = new Vector2(moveSpeed * transform.localScale.x, myBody.velocity.y);
    }

    void ReactToCliff(float r)
    {
        if(r == 0)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);            
        }
        if (r == 1)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight/3);            
        }
        if (r > 1)
        {
            myBody.velocity = new Vector2(0, myBody.velocity.y);
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
        reacted = true;
    }
}
