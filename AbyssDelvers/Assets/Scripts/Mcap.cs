using UnityEngine;
using System.Collections;

public class Mcap : MonoBehaviour {
    public Sprite D1;
    public Sprite D2;
    public Sprite D3;
    public Sprite D4;
    public Sprite D5;

    public  Sprite WCLeft;
    public  Sprite WCRight;
    public Color32 CapColor;

    SpriteRenderer SR;
    // Use this for initialization
    void Start () {
        SR = GetComponent<SpriteRenderer>();
        //CapColor = Random.ColorHSV();
        int rand = Random.Range(0, 6);
        switch (rand)
        {
            case 1:
                CapColor = new Color32(255, (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
                break;
            case 2:
                CapColor = new Color32((byte)Random.Range(0, 255),255 , (byte)Random.Range(0, 255), 255);
                break;
            case 3:
                CapColor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255),255 , 255);
                break;
            case 4:
                CapColor = new Color32(0, (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
                break;
            case 5:
                CapColor = new Color32((byte)Random.Range(0, 255), 0, (byte)Random.Range(0, 255), 255);
                break;
            case 6:
                CapColor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 0, 255);
                break;
        }
        SR.color = CapColor;
    }
	
	// Update is called once per frame
	void Update () {
     
       // transform.Translate(Vector2.zero);
	}
    public void RenderRight()
    {
        SR.sprite = WCRight;
    }
   public void  RenderLeft()
    {
        SR.sprite = WCLeft;
    }
    public void RenderD1()
    {
        SR.sprite = D1;
    }
    public void RenderD2()
    {
        SR.sprite = D2;
    }
    public void RenderD3()
    {
        SR.sprite = D3;
    }
    public void RenderD4()
    {
        SR.sprite = D4;
    }
    public void RenderD5()
    {
        SR.sprite = D5;
    }
}
