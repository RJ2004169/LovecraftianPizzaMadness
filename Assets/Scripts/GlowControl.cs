using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowControl : MonoBehaviour
{
    public Sprite eyesGlow, pineappleGlow, dirtySockGlow, cheeseGlow, leechesGlow, doughGlow, tentaclesGlow, sporesGlow, sauceGlow, toiletGlow, upArrowGlow, downArrowGlow, counterButtonGlow;
    public Sprite eyes, pineapple, dirtySock, cheese, leeches, dough, tentacles, spores, sauce, toilet, upArrow, downArrow, counterButton;
    public GameObject subtitleButtonGO, eyesGO, pineappleGO, dirtySockGO, cheeseGO, leechesGO, doughGO, tentaclesGO, sporesGO, sauceGO, toiletGO, upArrow1GO, upArrow2GO, downArrow1GO, downArrow2GO, counterButtonGO;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CastRay();
    }

    void CastRay()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            switch (hit.collider.gameObject.name)
            {
                case "eyes":
                    resetGlow();
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = eyesGlow;
                    break;
                case "pineapple":
                    resetGlow();
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = pineappleGlow;
                    break;
                case "dirty_socks":
                    resetGlow();
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = dirtySockGlow;
                    break;
                case "cheese":
                    resetGlow();
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = cheeseGlow;
                    break;
                case "leeches":
                    resetGlow();
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = leechesGlow;
                    break;
                case "eldritch_dough":
                    resetGlow();
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = doughGlow;
                    break;
                case "tenticles":
                    resetGlow();
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = tentaclesGlow;
                    break;
                case "pizza_sauce":
                    resetGlow();
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = sauceGlow;
                    break;
                case "necrotic_spores":
                    resetGlow();
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = sporesGlow;
                    break;
                case "toilet_roll":
                    resetGlow();
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = toiletGlow;
                    break;
                case "up_arrow":
                    resetGlow();
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = upArrowGlow;
                    break;
                case "down_arrow":
                    resetGlow();
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = downArrowGlow;
                    break;
                case "counter_button":
                    resetGlow();
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = counterButtonGlow;
                    break;
                case "subtitleArrow":
                    resetGlow();
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = upArrowGlow;
                    break;
                default:
                    resetGlow();
                    break;
            }
        }
        else
            resetGlow();
    }


    void resetGlow()
    {
        eyesGO.GetComponent<SpriteRenderer>().sprite = eyes;
        pineappleGO.GetComponent<SpriteRenderer>().sprite = pineapple;
        dirtySockGO.GetComponent<SpriteRenderer>().sprite = dirtySock;
        cheeseGO.GetComponent<SpriteRenderer>().sprite = cheese;
        leechesGO.GetComponent<SpriteRenderer>().sprite = leeches;
        doughGO.GetComponent<SpriteRenderer>().sprite = dough;
        tentaclesGO.GetComponent<SpriteRenderer>().sprite = tentacles;
        sporesGO.GetComponent<SpriteRenderer>().sprite = spores;
        sauceGO.GetComponent<SpriteRenderer>().sprite = sauce;
        toiletGO.GetComponent<SpriteRenderer>().sprite = toilet;
        upArrow1GO.GetComponent<SpriteRenderer>().sprite = upArrow;
        upArrow2GO.GetComponent<SpriteRenderer>().sprite = upArrow;
        downArrow1GO.GetComponent<SpriteRenderer>().sprite = downArrow;
        downArrow2GO.GetComponent<SpriteRenderer>().sprite = downArrow;
        counterButtonGO.GetComponent<SpriteRenderer>().sprite = counterButton;
        subtitleButtonGO.GetComponent<SpriteRenderer>().sprite = upArrow;
    }

}
