using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDialogueController : MonoBehaviour
{
    private GameObject managerGO;
    private Animator managerAnimator;
    private Color fadeScreenColor;
    private Image fadeScreenImage;
    
    [SerializeField] private GameObject managerDialogueGO;
    [SerializeField] private GameObject playerDialogueGO;
    [SerializeField] private TMPro.TextMeshProUGUI managerDialogueText;
    [SerializeField] private TMPro.TextMeshProUGUI playerDialogueText;
    [SerializeField] private GameObject managerNextButton;

    [SerializeField] private GameObject FadeScreenImage;
    [SerializeField] private GameObject BackgroundImage;
    [SerializeField] private List<GameObject> IngredientsList;


    private string[] managerDialogue =
    {
        "Ah, you’re finally awake…",
        "Welcome to Papa Gorbu’s Pizzeria,",
        "The best and only pizzeria in the eldritch realm!",
        "I’m Papa Gorbu, manager of this…horrifying establishment.",
        "What’s your name?",
        "Well, that’s simple, Greg.",
        "You make pizza, right?",
        "Perfect! You work for me now!",
        "I need a human to serve pizza to my customers!",
        "Right…now I know you worked at a pizzeria back in your human world,",
        "But this is a different world you live in now.",
        "So you gotta learn the rules, and you gotta learn them well.",
        "I’d hate to have to find another human so quickly…",
        "Yeah well, last human employee I had got eaten.",
        "He didn’t put enough leeches on one pizza…",
        "And the customer was rather hungry, so…yeah.",
        "And that’s why I’m teaching you now,",
        "So you don’t end up in that situation!",
        "Anyway, let’s get to it. I'll introduce you to the ingredients",
        "You’ve got today to get this right.",
        "Tomorrow it’s all on you.",
        "You'll see our toppings are Cheese,",
        "You'll see our toppings are Cheese, Dirty Socks,",
        "You'll see our toppings are Cheese, Dirty Socks, Pineapple Slices,",
        "You'll see our toppings are Cheese, Dirty Socks, Pineapple Slices, Fresh Eyeballs,",
        "Toilet Rolls, pretty straightforward so far eh?",
        "Toilet Rolls, pretty straightforward so far eh? Now we've got Necrotic Spores, ",
        "Toilet Rolls, pretty straightforward so far eh? Now we've got Necrotic Spores, Pizza Sauce,",
        "Assorted Tentacles,",
        "Assorted Tentacles, our very own Eldritch Pizza Dough,",
        "Assorted Tentacles, our very own Eldritch Pizza Dough and Live Leeches,",
        "Chef Josh here is the one who cooks our pizzas, pay attention to how well the each pizza must be cooked.",
    };

    private string[] playerDialogue =
    {
        "Huh? Where am I?",
        "Um…I’m Greg.",
        "W-what do you want with me?",
        "Uh, well…I want to.",
        "Another human?",
        "Ohh…that’s…",
        "Uhh….thanks, I guess?"

    };

    private static int dialogueCounter;
    private static int managerDialogueCounter;
    private static int playerDialogueCounter;

    private void Start()
    {
        managerGO = GameObject.Find("Papa Gorbu");
        managerAnimator = managerGO.GetComponent<Animator>();

        dialogueCounter = 0;
        managerDialogueCounter = 0;
        playerDialogueCounter = 0;


        managerDialogueGO.SetActive(false);
        playerDialogueGO.SetActive(false);

        FadeScreenImage.SetActive(false);
        fadeScreenImage = FadeScreenImage.GetComponent<Image>();
        fadeScreenColor = FadeScreenImage.GetComponent<Image>().color;
    }

    //DIALOGUE COUNTER FUNCTIONS
    public static void ManagerCounterIncrement()
    {
        managerDialogueCounter++;
        dialogueCounter++;
    }
    public static void PlayerCounterIncrement()
    {
        playerDialogueCounter++;
        dialogueCounter++;
    }

    private void FadeScreenToBlack()
    {
        if(fadeScreenColor.a < 1)
        {
            fadeScreenColor = new Color(fadeScreenColor.r, fadeScreenColor.g, fadeScreenColor.b, fadeScreenColor.a + Time.deltaTime);
            fadeScreenImage.color = fadeScreenColor;
        }
        else
        {
        dialogueCounter++;
        BackgroundImage.GetComponent<Animator>().SetInteger("BackgroundCounter", 1);

        }
        return;
    }

    private void FadeScreenToClear()
    {
        if (fadeScreenColor.a > 0)
        {
            fadeScreenColor = new Color(fadeScreenColor.r, fadeScreenColor.g, fadeScreenColor.b, fadeScreenColor.a - Time.deltaTime);
            fadeScreenImage.color = fadeScreenColor;
            return;
        }
        dialogueCounter++;
        FadeScreenImage.SetActive(false);
        return;
    }

    private void Update()
    {

        if (managerAnimator.GetCurrentAnimatorStateInfo(0).length > 0.5 && managerAnimator.GetCurrentAnimatorStateInfo(0).IsName("ManagerSpawnAnimation"))
        {
            switch (dialogueCounter)
            {
                case 0:
                    managerDialogueGO.SetActive(true);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 1:
                    managerDialogueGO.SetActive(false);
                    playerDialogueGO.SetActive(true);
                    playerDialogueText.text = playerDialogue[playerDialogueCounter];
                    break;
                case 2:
                    playerDialogueGO.SetActive(false);
                    managerDialogueGO.SetActive(true);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 3:
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 4:
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 5:
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 6:
                    managerDialogueGO.SetActive(false);
                    playerDialogueGO.SetActive(true);
                    playerDialogueText.text = playerDialogue[playerDialogueCounter];
                    break;
                case 7:
                    playerDialogueText.text = playerDialogue[playerDialogueCounter];
                    break;
                case 8:
                    playerDialogueGO.SetActive(false);
                    managerDialogueGO.SetActive(true);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 9:
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 10:
                    managerDialogueGO.SetActive(false);
                    playerDialogueGO.SetActive(true);
                    playerDialogueText.text = playerDialogue[playerDialogueCounter];
                    break;
                case 11:
                    playerDialogueGO.SetActive(false);
                    managerDialogueGO.SetActive(true);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 12:
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 13:
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 14:
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 15:
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 16:
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 17:
                    managerDialogueGO.SetActive(false);
                    playerDialogueGO.SetActive(true);
                    playerDialogueText.text = playerDialogue[playerDialogueCounter];
                    break;
                case 18:
                    playerDialogueGO.SetActive(false);
                    managerDialogueGO.SetActive(true);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 19:
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 20:
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 21:
                    managerDialogueGO.SetActive(false);
                    playerDialogueGO.SetActive(true);
                    playerDialogueText.text = playerDialogue[playerDialogueCounter];
                    break;
                case 22:
                    playerDialogueGO.SetActive(false);
                    managerDialogueGO.SetActive(true);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 23:
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 24:
                    managerDialogueGO.SetActive(false);
                    playerDialogueGO.SetActive(true);
                    playerDialogueText.text = playerDialogue[playerDialogueCounter];
                    break;

                case 25:
                    playerDialogueGO.SetActive(false);
                    managerDialogueGO.SetActive(true);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 26:
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 27:
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 28:
                    managerDialogueGO.SetActive(false);
                    managerGO.SetActive(false);
                    FadeScreenImage.SetActive(true);
                    FadeScreenToBlack();
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch(dialogueCounter)
            {
                case 28:
                FadeScreenToBlack();
                    break;
                case 29:
                    FadeScreenToClear();
                    break;
                case 30:
                    IngredientsList[0].SetActive(true);
                    managerDialogueGO.SetActive(true);
                    
                    managerNextButton.SetActive(false);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 31:
                    IngredientsList[1].SetActive(true);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 32:
                    IngredientsList[2].SetActive(true);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 33:
                    IngredientsList[3].SetActive(true);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 34:
                    IngredientsList[4].SetActive(true);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 35:
                    IngredientsList[5].SetActive(true);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 36:
                    IngredientsList[6].SetActive(true);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 37:
                    IngredientsList[7].SetActive(true);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 38:
                    IngredientsList[8].SetActive(true);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 39:
                    IngredientsList[9].SetActive(true);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;
                case 40:
                    IngredientsList[10].SetActive(true);
                    managerDialogueText.text = managerDialogue[managerDialogueCounter];
                    break;

            default:
                    break;
        }
        }
    }
}
