using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnMouseHover : MonoBehaviour
{
    private void OnMouseOver()
    {
        GetComponent<Animator>().SetBool("Highlight", true);

    }

    private void OnMouseExit()
    {
        GetComponent<Animator>().SetBool("Highlight", false);
    }


}
