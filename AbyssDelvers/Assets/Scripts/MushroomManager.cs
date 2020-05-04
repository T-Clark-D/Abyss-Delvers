using UnityEngine;
using System.Collections;

public class MushroomManager : MonoBehaviour
{

    public Player FoundPLayer;


    public Sprite DeadMush1;
    public Sprite DeadMush2;
    public Sprite DeadMush3;
    public Sprite DeadMush4;
    public Sprite DeadMush5;
    public Sprite DeadMush6;
  
 
    public Sprite IdleRightOne;
    public Sprite IdleRightTwo;
    public Sprite IdleleftOne;
    public Sprite IdleleftTwo;

    public Sprite AgroRight;
    public Sprite AgroLeft;




    public bool isalive;
    public bool hastarget;
    public float health;
    public SpriteRenderer SR;
  

    public Color32 DMGColor;
    public Color32 CapColor;
    public Color32 DEFAULTColor;
    public float DelayToNextDmgDisplay;
    private float TimeToNextDmgDisplay;
    private bool DeathAnimationDone;
    int Deathcounter;
    int idleCounter;
    public float NextFrameTime;
    public float FrameDelay;
    public bool isAgro;
    private float distance;
    public float Speed;
    Vector2 unitdirection;
    bool isleft = true;
    GameObject Cap;
    Mcap CapScript;
    //public GameObject Mushroom;
    // Use this for initialization
    void Start()
    {
        isAgro = false;
        isalive = true;
        health = 10;
        FoundPLayer = FindObjectOfType<Player>();
        hastarget = false;
        SR = GetComponent<SpriteRenderer>();
        Cap = transform.GetChild(0).gameObject;
        CapScript = Cap.GetComponent<Mcap>();
        //float derp =  Random.Range(0.001f, 0.01f);
       
        //transform.localScale += new Vector3(derp, derp, 0);


        DEFAULTColor = new Color32(255, 255, 255, 255);
        DMGColor = new Color32(255, 127, 127, 255);
       

        DelayToNextDmgDisplay = 0.1f;
        DeathAnimationDone = false;
        Deathcounter = 0;
        idleCounter = 0;
        NextFrameTime = Time.time;
        FrameDelay = 0.5f;
        Speed = 3;
    }

    // Update is called once per frame
    void Update()
    {

        if (isalive)
        {

            if (Time.time > TimeToNextDmgDisplay)
            {
                SR.material.color = DEFAULTColor;
            }
            if (!isAgro)
            {
                distance = Vector2.Distance(FoundPLayer.transform.position, transform.position);
                if (distance < 50)
                {
                    isAgro = true;
                    //transform.Translate();
                }
            }
            if (isAgro)
            {
                //print("bruh");

                unitdirection = (FoundPLayer.transform.position - transform.position).normalized;
                transform.Translate(unitdirection * Speed * Time.deltaTime);
                if (transform.position.x > FoundPLayer.transform.position.x && !isleft) { SR.sprite = AgroLeft; isleft = true; CapScript.RenderLeft(); }
                else if(transform.position.x < FoundPLayer.transform.position.x && isleft ){ SR.sprite = AgroRight; isleft = false; CapScript.RenderRight(); }
            }
            else
            {
                idleCounter++;
                idleCounter = idleCounter % 2;
                switch (idleCounter)
                {
                    case 0:
                        if (transform.position.x > FoundPLayer.transform.position.x) { SR.sprite = IdleleftOne; }
                        else { SR.sprite = IdleRightTwo; }

                        break;
                    case 1:
                        if (transform.position.x > FoundPLayer.transform.position.x) { SR.sprite = IdleleftTwo; }
                        else { SR.sprite = IdleRightTwo; }

                        break;
                }
                NextFrameTime += FrameDelay;
            }
        }
        else if (!DeathAnimationDone)
        {
            if (NextFrameTime < Time.time)
            {
                Deathcounter++;
                Deathcounter = Deathcounter % 6;
                switch (Deathcounter)
                {
                    case 0:
                        SR.sprite = DeadMush1;
                       
                        break;
                    case 1:
                        SR.sprite = DeadMush2;
                        CapScript.RenderD1();
                        break;
                    case 2:
                        SR.sprite = DeadMush3;
                        CapScript.RenderD2();
                        break;
                    case 3:
                        SR.sprite = DeadMush4;
                        CapScript.RenderD3();
                        break;
                    case 4:
                        SR.sprite = DeadMush5;
                        CapScript.RenderD4();
                        break;
                    case 5:
                        SR.sprite = DeadMush6;
                        CapScript.RenderD5();
                        DeathAnimationDone = true;
                        break;
                }
                NextFrameTime += FrameDelay;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        print(triggerCollider.tag);
        if (triggerCollider.tag == "Projectile")
        {
            health -= 10;
            DisplayDamageTick();
            SR.material.color = DMGColor;
            if (health <= 0)
            {
                isalive = false;
                SR.material.color = DEFAULTColor;

            }
            print(health);
        }
    }
    public void DisplayDamageTick()
    {
        SR.material.color = DMGColor;
        TimeToNextDmgDisplay = Time.time + DelayToNextDmgDisplay;
    }
    void LateUpdate()
    {
        SR.sortingOrder = (int)(500 - (Camera.main.WorldToScreenPoint(SR.bounds.min).y + 200));
    }

}
