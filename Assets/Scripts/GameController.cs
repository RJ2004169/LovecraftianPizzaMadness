using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private static int cameraMove = 0, tendrilDirection = 1;
    private static bool sanityMechanic = false, tendrilMove = false;
    private static float initY, sanity = 99.99f;

    public GameObject stealingTendril;

    public Slider sanitySlider;

    public List<Sprite> sanityScreenSprites;

    public Transform sanityGO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(cameraMove!=0)
        {
            if (cameraMove == 1)
            {
                Camera.main.transform.position += new Vector3(0, 10f * Time.deltaTime, 0);
                if (Camera.main.transform.position.y - initY >= 10.1f)
                {
                    cameraMove = 0;
                    Camera.main.transform.SetPositionAndRotation(new Vector3(0, initY + 10.1f, -10), Quaternion.identity);
                }
            }
            else if(cameraMove == -1)
            {
                Camera.main.transform.position += new Vector3(0, -10f * Time.deltaTime, 0);
                if (initY - Camera.main.transform.position.y >= 10.1)
                {
                    Camera.main.transform.SetPositionAndRotation(new Vector3(0, initY - 10.1f, -10), Quaternion.identity);
                    cameraMove = 0;
                }
                    
            }
        }

        if(sanityMechanic)
        {
            sanity = Mathf.Max(0, sanity - 2 * Time.deltaTime);
            //sanityMeter.transform.localScale = new Vector3(1, sanity / 10, 1);
            sanitySlider.value = sanity;
        }

        if(sanity == 0)
        {
            Camera.main.transform.SetPositionAndRotation(new Vector3(0, -20.2f, -10), Quaternion.identity);
            
        }
        else
        {
            sanityGO.GetComponent<SpriteRenderer>().sprite = sanityScreenSprites[(10 - (int) sanity / 10) - 1];
        }

        if(tendrilMove)
        {
            stealingTendril.transform.position += new Vector3(tendrilDirection * Time.deltaTime, 0, 0);
        }
    }

    public static void CameraMoveUp()
    {
        cameraMove = 1;
            initY = Camera.main.transform.position.y;
    }

    public static void CameraMoveDown()
    {
        cameraMove = -1;
            initY = Camera.main.transform.position.y;
    }

    public static int getCameraMove()
    {
        return cameraMove;
    }
    public static void StartSanityMechanic()
    {
        sanityMechanic = true;
    }
    public static void AddSanity()
    {
        Debug.Log(sanity);
        sanity = Mathf.Min(100.0f, sanity + 5);
        Debug.Log("increase"+sanity);
    }
    public static void StopSanityMechanic()
    {
        sanityMechanic = false;
    }
}
