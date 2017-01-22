using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private GameObject currentProjectile;
    public GameObject basicProjectile;

    public float moveSpeed;
    public float jumpHeight;
    public float gravity;
    public float shootDelay;

    public float pixelSize;

    public float[] shootAngles;
    private Quaternion rot;


    public int direction;

    public LayerMask solid;
    public LayerMask oneway;

    private float hsp;
    private float vsp;
    private float shootDelayCounter;
    
    private bool KeyLeft;
    private bool KeyRight;
    private bool KeyUp;
    private bool KeyDown;
    private bool KeyJump;
    private bool KeyAction;
    private bool KeyJumpOff;

    private bool onGround;
    private bool jumped;
    private bool moving;
    private bool onPlatform;
    private bool obsticleOnRight;
    private bool obsticleOnLeft;

    private Vector2 botLeft;
    private Vector2 botRight;
    private Vector2 topLeft;
    private Vector2 topRight;

    private Animator[] animators;



    void Start () {
        currentProjectile = basicProjectile;
        animators = GetComponentsInChildren<Animator>();
        shootDelayCounter = 0;
        rot = new Quaternion(0,0,0,0);

    }
	
	void Update () {
        CalculateBounds();
        onGround = 
            CheckCollision(botLeft, Vector2.down, pixelSize, solid) || 
            CheckCollision(botRight, Vector2.down, pixelSize, solid) ||
            CheckCollision(botLeft, Vector2.down, pixelSize, oneway) ||
            CheckCollision(botRight, Vector2.down, pixelSize, oneway);
        onPlatform = 
            CheckCollision(botLeft, Vector2.down, pixelSize, oneway) ||
            CheckCollision(botRight, Vector2.down, pixelSize, oneway);

        obsticleOnRight = CheckCollision(topRight, Vector2.right, pixelSize, solid) || CheckCollision(botRight, Vector2.right, pixelSize, solid);
        obsticleOnLeft = CheckCollision(topLeft, Vector2.left, pixelSize, solid) || CheckCollision(botLeft, Vector2.left, pixelSize, solid);

        GetInput();
        CalculateDirection();
        CalculateShootAngles();
        Animate();
        Move();
        Shoot();
	}

    void GetInput ()
    {
        KeyLeft = Input.GetKey(KeyCode.LeftArrow);
        KeyRight = Input.GetKey(KeyCode.RightArrow);
        KeyUp = Input.GetKey(KeyCode.UpArrow);
        KeyDown = Input.GetKey(KeyCode.DownArrow);
        KeyJump = Input.GetKeyDown(KeyCode.Z);
        KeyAction = Input.GetKey(KeyCode.X);
        KeyJumpOff = KeyDown && KeyJump;
    }

    void Move()
    {


        if (KeyLeft && !obsticleOnLeft)
        {
            hsp = -moveSpeed * Time.deltaTime;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (KeyRight && !obsticleOnRight)
        {
            hsp = moveSpeed * Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (KeyRight || KeyLeft) moving = true;
        if ((!KeyLeft && !KeyRight) || (KeyLeft && KeyRight))
        {
            moving = false;
            hsp = 0;
        }
        

        // спрыгиваем с платформы
        if (onPlatform && KeyJumpOff)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - pixelSize);
            onGround = false;
        }

        if (KeyJump && onGround)
        {
            jumped = true;
            vsp = jumpHeight;
            onGround = false;
        }

        if (!onGround) vsp -= gravity * Time.deltaTime;

        // проверяем пол под ногами
        if((vsp < 0) && (CheckCollision(botLeft, Vector2.down, Mathf.Abs(vsp), solid) || CheckCollision(botRight, Vector2.down, Mathf.Abs(vsp), solid)))
        {
            float dist1 = CheckCollisionDistance(botLeft, Vector2.down, Mathf.Abs(vsp), solid);
            float dist2 = CheckCollisionDistance(botRight, Vector2.down, Mathf.Abs(vsp), solid);
            if (dist1 <= dist2) vsp = -dist1;
            else vsp = -dist2;
            transform.position = new Vector2(transform.position.x, transform.position.y + vsp + pixelSize/2);
            vsp = 0;
        }
        // проверяем платформу под ногами
        if ((vsp < 0) && (CheckCollision(botLeft, Vector2.down, Mathf.Abs(vsp), oneway) || CheckCollision(botRight, Vector2.down, Mathf.Abs(vsp), oneway)))
        {
            float dist1 = CheckCollisionDistance(botLeft, Vector2.down, Mathf.Abs(vsp), oneway);
            float dist2 = CheckCollisionDistance(botRight, Vector2.down, Mathf.Abs(vsp), oneway);
            if (dist1 <= dist2) vsp = -dist1;
            else vsp = -dist2;
            transform.position = new Vector2(transform.position.x, transform.position.y + vsp + pixelSize / 2);
            vsp = 0;
        }

        

        // проверяем потолок
        if ((vsp > 0) && (CheckCollision(topLeft, Vector2.up, vsp, solid) || CheckCollision(topRight, Vector2.up, vsp, solid)))
        {
            float dist1 = CheckCollisionDistance(topLeft, Vector2.up, vsp, solid);
            float dist2 = CheckCollisionDistance(topRight, Vector2.up, vsp, solid);
            if (dist1 <= dist2) vsp = dist1;
            else vsp = dist2;
            transform.position = new Vector2(transform.position.x, transform.position.y + vsp + pixelSize / 2);
            vsp = 0;
        }

        // проверяем стену справа
        if ((hsp > 0) && (CheckCollision(topRight, Vector2.right, hsp, solid) || CheckCollision(botRight, Vector2.right, hsp, solid)))
        {
            float dist1 = CheckCollisionDistance(topRight, Vector2.right, hsp, solid);
            float dist2 = CheckCollisionDistance(botRight, Vector2.right, hsp, solid);
            if (dist1 <= dist2) hsp = dist1;
            else hsp = dist2;
            transform.position = new Vector2(transform.position.x + hsp, transform.position.y);
            hsp = 0;
        }

        // проверяем стену слева
        if ((hsp < 0) && (CheckCollision(topLeft, Vector2.left, Mathf.Abs(hsp), solid) || CheckCollision(botLeft, Vector2.left, Mathf.Abs(hsp), solid)))
        {
            float dist1 = CheckCollisionDistance(topLeft, Vector2.left, Mathf.Abs(hsp), solid);
            float dist2 = CheckCollisionDistance(botLeft, Vector2.left, Mathf.Abs(hsp), solid);
            if (dist1 <= dist2) hsp = -dist1;
            else hsp = -dist2;
            transform.position = new Vector2(transform.position.x + hsp, transform.position.y);
            hsp = 0;
        }


        if (vsp == 0) jumped = false;

        transform.position = new Vector2(transform.position.x + hsp, transform.position.y + vsp);
    }

    // Стрельба
    private void Shoot()
    {
        if(KeyAction && shootDelayCounter <= 0)
        {
            if((currentProjectile == basicProjectile) && FindObjectsOfType<Projectile>().Length < 4)
            {
                Instantiate(currentProjectile, transform.position, rot);
                shootDelayCounter = shootDelay;
            }
            
        }
        shootDelayCounter -= Time.deltaTime;
    }

    // Рассчитать направление
    void CalculateDirection()
    {
        if (KeyUp && !KeyRight && !KeyLeft && !KeyDown)
        {
            direction = 8;
        } else if (jumped && KeyDown && !KeyRight && !KeyLeft) direction = 2;
        else if(transform.localScale.x > 0)
        {
            if (KeyUp && KeyRight) direction = 9;
            else if (KeyDown && KeyRight) direction = 3;
            else if (KeyDown && !KeyRight) direction = 6;
            else direction = 6;
        }
        else if (transform.localScale.x < 0)
        {
            if (KeyUp && KeyLeft) direction = 7;
            else if (KeyDown && KeyLeft) direction = 1;
            else if (KeyDown && !KeyLeft) direction = 4;
            else direction = 4;
        }

    }

    // Рассчитать углы стрельбы
    void CalculateShootAngles()
    {
        if (direction == 8) rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, shootAngles[0]);
        if (direction == 9) rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -shootAngles[1]);
        if (direction == 6) rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -shootAngles[2]);
        if (direction == 3) rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -shootAngles[3]);
        if (direction == 2) rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, shootAngles[4]);
        if (direction == 7) rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, shootAngles[1]);
        if (direction == 4) rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, shootAngles[2]);
        if (direction == 1) rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, shootAngles[3]);
    }

    // Проверка столкновения
    private bool CheckCollision(Vector2 raycastOrigin,Vector2 direction, float distance, LayerMask layer)
    {
        return Physics2D.Raycast(raycastOrigin, direction, distance, layer);
    }

    // Проверка дистанции до столкновения
    private float CheckCollisionDistance(Vector2 raycastOrigin, Vector2 direction, float distance, LayerMask layer)
    {
        int i = 0;
        while(Physics2D.Raycast(raycastOrigin, direction, distance, layer))
        {
            i++;

            if (distance > pixelSize) distance -= pixelSize;
            else distance = pixelSize; /// может забаговаться

            if (i > 1000) return 0;
        }
        return distance;
    }

    // пересчитать углы
    private void CalculateBounds()
    {
        Bounds b = GetComponent<BoxCollider2D>().bounds;
        topLeft = new Vector2(b.min.x, b.max.y);
        botLeft = new Vector2(b.min.x, b.min.y);
        topRight = new Vector2(b.max.x, b.max.y);
        botRight = new Vector2(b.max.x, b.min.y);
    }

    // Анимация
    private void Animate()
    {
        for(int i=0; i<animators.Length; i++)
        {
            animators[i].SetBool("OnGround", onGround);
            animators[i].SetBool("Jumped", jumped);
            animators[i].SetBool("Moving", moving);
            animators[i].SetBool("Shooting", KeyAction);
            animators[i].SetFloat("VSP", vsp);
            animators[i].SetInteger("Direction", direction);
        }
    }

    // С
}
