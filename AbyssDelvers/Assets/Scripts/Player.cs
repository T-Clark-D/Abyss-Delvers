using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float speed = 7;
    public Vector2 velocity;
    public SpriteRenderer SR;
    public ProjectileBehaviour ProjBeh;
    //public Vector2 RPJ;
    public Sprite RightFire;
    public Sprite RightDownFire;
    public Sprite RightUpFire;
    public Sprite LeftFire;
    public Sprite LeftDownFire;
    public Sprite LeftUpFire;
    public Sprite UpFire;
    public Sprite DownFire;
    public Sprite Idle;
    public Sprite IdleOne;
    public Sprite IdleTwo;
    public bool isIdle;
    public float FrameDelay;
    public float NextFrameTime;
    public int counter;
    // Use this for initialization

    void Start () {
        SR = GetComponent<SpriteRenderer>();
        //transform.Translate(new Vector3(transform.position.x, transform.position.y, -transform.position.y));
        ProjBeh = FindObjectOfType<ProjectileBehaviour>();
        //RPJ = ProjBeh.rawProjInput;
        FrameDelay = 0.9f;
        counter = 0;
        NextFrameTime = 0;
        isIdle = true;


    }
	
	// Update is called once per frame
	void Update () {
        

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 direction = input.normalized;
        velocity = direction * speed;
        
        transform.Translate(velocity * Time.deltaTime);
        //transform.Translate(new Vector3(transform.position.x, transform.position.y, 100f+transform.position.y));
        if (isIdle)
        {
            if (NextFrameTime < Time.time)
            {
                counter++;
                counter = counter % 2;
                switch (counter)
                {
                    case 0:
                        SR.sprite = IdleOne;
                        break;
                    case 1:
                        SR.sprite = IdleTwo;
                        break;
                   
                }
                NextFrameTime += FrameDelay;
            }
        }
    }

    void LateUpdate()
    {
        SR.sortingOrder = (int) (500 - (Camera.main.WorldToScreenPoint(SR.bounds.min).y+200)) ;
    }
    public void UpdateSprite(Vector2 RPJ)
    {
        print("bro");
        print(RPJ);

        if (RPJ.x == 1 && RPJ.y == 0) { SR.sprite = RightFire; isIdle = false; }
        else if (RPJ.x == 1 && RPJ.y == 1) { SR.sprite = RightUpFire; isIdle = false; }
        else if (RPJ.x == 0 && RPJ.y == 1) { SR.sprite = UpFire; isIdle = false; }
        else if (RPJ.x == -1 && RPJ.y == 1) { SR.sprite = LeftUpFire; isIdle = false; }
        else if (RPJ.x == -1 && RPJ.y == 0) { SR.sprite = LeftFire; isIdle = false; }
        else if (RPJ.x == -1 && RPJ.y == -1) { SR.sprite = LeftDownFire; isIdle = false; }
        else if (RPJ.x == 0 && RPJ.y == -1) { SR.sprite = DownFire; isIdle = false; }
        else if (RPJ.x == 1 && RPJ.y == -1) { SR.sprite = RightDownFire; isIdle = false; }
        else {
            SR.sprite = Idle;
            isIdle = true;
        }
    }
}
