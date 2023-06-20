using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDialogueController : MonoBehaviour
{
    private GameObject managerGO;
    private Animator managerAnimator;
    [SerializeField] private GameObject managerDialogueGO;
    [SerializeField] private GameObject playerDialogueGO;
    [SerializeField] private TMPro.TextMeshProUGUI managerDialogueText;
    [SerializeField] private TMPro.TextMeshProUGUI playerDialogueText;

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
        "Tomorrow it’s all on you."

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

    private int dialogueCounter;
    private int managerDialogueCounter;
    private int playerDialogueCounter;

    private void Start()
    {
        managerGO = GameObject.Find("Papa Gorbu");
        managerAnimator = managerGO.GetComponent<Animator>();

        dialogueCounter = 0;
        managerDialogueCounter = 0;
        playerDialogueCounter = 0;


        managerDialogueGO.SetActive(false);
        playerDialogueGO.SetActive(false);
    }

    //DIALOGUE COUNTER FUNCTIONS
    public void ManagerCounterIncrement()
    {
        managerDialogueCounter++;
        dialogueCounter++;
    }
    public void PlayerCounterIncrement()
    {
        playerDialogueCounter++;
        dialogueCounter++;
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
                default:
                    break;
            }
        }
    }
}
