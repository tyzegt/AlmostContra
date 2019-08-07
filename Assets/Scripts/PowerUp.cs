using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    /*
     * 0 - R
     * 1 - M
     * 2 - F
     * 3 - S
     * 4 - L
     */
    public int type;
    public float height = 6;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * height, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 2, ForceMode2D.Impulse);
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && type != 0)
        {
            other.GetComponent<PlayerController>().ChangeWeapon(type);
            Destroy(gameObject);
        }

        if (other.tag == "Player" && type == 0)
        {
            if (PlayerController.rapidsPicked < 2) PlayerController.rapidsPicked++;
            Destroy(gameObject);
        }
    }
}
