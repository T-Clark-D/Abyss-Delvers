using UnityEngine;
using System.Collections;

public class TreeFrogManager : MonoBehaviour {

    // Use this for initialization

    /*
    
    public GameObject target;
    public Vector3 direction;
    float eulerAngle;
    public RaycastHit2D hitInfo;
    */
    public Sprite DeadTreeFrog;
    public bool isalive;
    public bool hastarget;
    public float health;
    public SpriteRenderer SR;
    public Color32 DMGColor;
    public Color32 DEFAULTColor;
    public float DelayToNextDmgDisplay;
    private float TimeToNextDmgDisplay;



    void Start () {
        health = 50;
        hastarget = false;
        SR = GetComponent<SpriteRenderer>();
        DEFAULTColor = new Color32(255, 255, 255, 255);
        DMGColor = new Color32(255,127,127,255);
        DelayToNextDmgDisplay = 0.1f;
        isalive = true;


    }
	
	// Update is called once per frame
	void Update () {
        //transform.position.Set(transform.position.x, transform.position.y, -transform.position.y);
        if (Time.time > TimeToNextDmgDisplay&& isalive)
        {
            SR.material.color = DEFAULTColor;
        }
    }
    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        print(triggerCollider.tag);
        if (triggerCollider.tag == "Projectile")
        {
            health-=10;
            DisplayDamageTick();
            SR.material.color = DMGColor;
            if (health <= 0)
            {
                SR.sprite = DeadTreeFrog;
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
