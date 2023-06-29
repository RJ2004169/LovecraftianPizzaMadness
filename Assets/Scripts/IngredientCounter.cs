using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCounter : MonoBehaviour
{
    private void OnMouseDown()
    {
        TutorialDialogueController.ManagerCounterIncrement();
    }
}
