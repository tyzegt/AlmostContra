using UnityEngine;
using System.Collections;

public class PlayerDeathEffect : MonoBehaviour {

	public float impulseX;
    public float impulseY;

    void Start()
    {
        Rigidbody2D myRigidbody = GetComponent<Rigidbody2D>();
        transform.localScale = FindObjectOfType<PlayerController>().transform.localScale;

        if(transform.localScale.x > 0)
        {
            myRigidbody.AddRelativeForce(Vector2.left * (impulseX + PlayerController.rapidsPicked * PlayerController.projectileSpeedKoeff), ForceMode2D.Impulse);
        } else
        {
            myRigidbody.AddRelativeForce(Vector2.right * (impulseX + PlayerController.rapidsPicked * PlayerController.projectileSpeedKoeff), ForceMode2D.Impulse);
        }
        myRigidbody.AddRelativeForce(Vector2.up * (impulseY + PlayerController.rapidsPicked * PlayerController.projectileSpeedKoeff), ForceMode2D.Impulse);
    }


}
