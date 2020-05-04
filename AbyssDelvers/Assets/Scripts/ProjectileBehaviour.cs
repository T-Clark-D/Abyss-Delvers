using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed = 10;
    public float boltDelay = 0.1f;
    public float timeOfLastFiredBolt;
    public GameObject ProjectilePrefab;
    public GameObject PlayerObject;
    float nextSpawnTime;
    float HFire;
    float VFire;
    float angle;
    GameObject newBlock;
    Player FoundPLayer;
    Vector2 PlayerVelocity;
    public Vector2 rawProjInput;
    public Vector2 previousInput = Vector2.zero;
    public Vector2 projectileOffset;
    public event System.Action UpdateSprite;


    // Use this for initialization
    void Start()
    {
        FoundPLayer = FindObjectOfType<Player>();
        nextSpawnTime = Time.time + boltDelay;


    }

    // Update is called once per frame
    void Update()
    {
            HFire = Input.GetAxisRaw("FireProjectileHorizontal");
            VFire = Input.GetAxisRaw("FireProjectileVertical");
            rawProjInput = new Vector2(HFire, VFire);
        if (Time.time > nextSpawnTime)
        {
            //if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            //{
            PlayerVelocity = FoundPLayer.velocity / 2;
            //print(PlayerVelocity.ToString());

            

            if (HFire != 0 || VFire != 0)
            {


                Vector2 ProjVelocity = rawProjInput.normalized * Speed;
                Vector2 vectorDirection = ProjVelocity + PlayerVelocity;
                Vector2 vectorDirectionNormalized = vectorDirection.normalized;

                angle = Vector2.Angle(new Vector2(1, 0), vectorDirectionNormalized);
                if (vectorDirectionNormalized.y < 0) { angle = -angle; }

                print(angle);
                if (rawProjInput.x != previousInput.x || rawProjInput.y != previousInput.y)
                {
                    FindObjectOfType<Player>().UpdateSprite(rawProjInput);
                }
                print(angle);
                if (angle < 90 && angle > -90) { projectileOffset = new Vector2(0.5f, 0); }

                else if (angle > 90 || angle < -90) { projectileOffset = new Vector2(-0.5f, 0); }

                else if (angle == 90) { projectileOffset = new Vector2(0, 0.5f); }

                else if (angle == -90) { projectileOffset = new Vector2(0, -0.5f); }
                if (rawProjInput.x == 1 && rawProjInput.y == 0) { projectileOffset = new Vector2(0.5f, 0); }
                else if (rawProjInput.x == 1 && rawProjInput.y == 1) { projectileOffset = new Vector2(0.5f, 0.5f).normalized / 2; }
                else if (rawProjInput.x == 0 && rawProjInput.y == 1) { projectileOffset = new Vector2(0, 0.5f); }
                else if (rawProjInput.x == -1 && rawProjInput.y == 1) { projectileOffset = new Vector2(-0.5f, 0.5f).normalized / 2; }
                else if (rawProjInput.x == -1 && rawProjInput.y == 0) { projectileOffset = new Vector2(-0.5f, 0); }
                else if (rawProjInput.x == -1 && rawProjInput.y == -1) { projectileOffset = new Vector2(-0.5f, -0.5f).normalized / 2; }
                else if (rawProjInput.x == 0 && rawProjInput.y == -1) { projectileOffset = new Vector2(0, -0.5f); }
                else if (rawProjInput.x == 1 && rawProjInput.y == -1) { projectileOffset = new Vector2(0.5f, -0.5f).normalized / 2; }







                newBlock = (GameObject)Instantiate(ProjectilePrefab, (Vector2)PlayerObject.transform.position + projectileOffset, Quaternion.Euler(new Vector3(0, 0, 1) * angle));
                nextSpawnTime = Time.time + boltDelay;
                previousInput = rawProjInput;

            }
            else if (rawProjInput.x != previousInput.x || rawProjInput.y != previousInput.y)
            {
                FindObjectOfType<Player>().UpdateSprite(rawProjInput);
                previousInput = rawProjInput;
            }

        }else
        if (rawProjInput.x != previousInput.x || rawProjInput.y != previousInput.y)
        {
            FindObjectOfType<Player>().UpdateSprite(rawProjInput);
            previousInput = rawProjInput;
        }

    }


}
//}
