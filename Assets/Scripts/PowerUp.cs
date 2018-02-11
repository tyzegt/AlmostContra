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
