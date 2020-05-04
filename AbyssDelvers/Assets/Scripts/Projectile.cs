using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
   
    public float Speed;
    public ProjectileBehaviour ProjBeh;
    CircleCollider2D cc;
    public SpriteRenderer SR;
    public Sprite projectileF0;
    public Sprite projectileF1;
    public Sprite projectileF2;
    public float FrameDelay;
    public float NextFrameTime;
    int counter;
    // Use this for initialization
    void Start () {
        CircleCollider2D cc = GetComponent<CircleCollider2D>();
        cc.radius = 0.4f;
        cc.offset = new Vector2(0.5f, 0);
        SR = GetComponent<SpriteRenderer>();
        counter = 1;
        FrameDelay = 0.1f;
        NextFrameTime = Time.time;
        ProjBeh = FindObjectOfType<ProjectileBehaviour>();
        Speed = ProjBeh.Speed;
        print(Speed);
    }
	
	// Update is called once per frame
	void Update () {
        
        transform.Translate(new Vector2(1,0) * Speed * Time.deltaTime, Space.Self);
        if (NextFrameTime < Time.time) { 
        counter++;
        counter = counter % 3;
        switch (counter)
        {
            case 0:
                SR.sprite = projectileF0;
                break;
            case 1:
                SR.sprite = projectileF1;
                break;
            default:
                SR.sprite = projectileF2;
                break;
        }
            NextFrameTime += FrameDelay;
    }}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if(collision.tag != "Player")
        Destroy(gameObject);
    }
    void LateUpdate()
    {
        SR.sortingOrder = (int)(500 - (Camera.main.WorldToScreenPoint(SR.bounds.min).y + 200));
    }
}
