using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggerControl : MonoBehaviour
{
    private Camera camera;
    private Transform tempObj;
    private int orderNumber = 0, cookType = 0, dialogueIndex = 0, mistake, totalScore = 0, starCount = 0;
    private List<Transform> pizzaToppings = new List<Transform>();
    private bool tutorialMode = true, timerCountdown = false, isDragging = false;
    private float timeRemaining;

    private struct pizzaEvaluator
    {
        public int cheese, tendrils, pineapple, sauce, sock, eyes, leeches, mushrooms, toiletRoll, dough, cookType;
    }
    pizzaEvaluator currentPizza = new pizzaEvaluator();
    pizzaEvaluator customerPizza1 = new pizzaEvaluator();
    pizzaEvaluator customerPizza2_1 = new pizzaEvaluator();
    pizzaEvaluator customerPizza2_2 = new pizzaEvaluator();
    pizzaEvaluator customerPizza2_3 = new pizzaEvaluator();
    pizzaEvaluator customerPizza4 = new pizzaEvaluator();
    pizzaEvaluator customerPizza5_1 = new pizzaEvaluator();
    pizzaEvaluator customerPizza5_2 = new pizzaEvaluator();
    pizzaEvaluator customerPizza5_3 = new pizzaEvaluator();
    
    //private static bool audioPlay = false, audioPlay2 = false;

    private string[] tutorialDialogue =
    {
        "Papa Gorbu: Ah, you’re finally awake…",
        "Greg: Huh? Where am I?",
        "Papa Gorbu: Welcome to Papa Gorbu’s Pizzeria,",
        "Papa Gorbu: The best and only pizzeria in the eldritch realm!",
        "Papa Gorbu: I’m Papa Gorbu, manager of this…horrifying establishment.",
        "Papa Gorbu: What’s your name?",
        "Greg: Um…I’m Greg.",
        "Greg: W-what do you want with me?",
        "Papa Gorbu: Well, that’s simple, Greg.",
        "Papa Gorbu: You make pizza, right?",
        "Greg: Uh, well…I want to.",
        "Papa Gorbu: Perfect! You work for me now!",
        "Papa Gorbu: I need a human to serve pizza to my customers!",
        "Papa Gorbu: Right…now I know you worked at a pizzeria back in your human world,",
        "Papa Gorbu: But this is a different world you live in now.",
        "Papa Gorbu: So you gotta learn the rules, and you gotta learn them well.",
        "Papa Gorbu: I’d hate to have to find another human so quickly…",
        "Greg: Another human?",
        "Papa Gorbu: Yeah well, last human employee I had got eaten.",
        "Papa Gorbu: He didn’t put enough leeches on one pizza…",
        "Papa Gorbu: And the customer was rather hungry, so…yeah.",
        "Greg: Ohh…that’s…",
        "Papa Gorbu: And that’s why I’m teaching you now,",
        "Papa Gorbu: So you don’t end up in that situation!",
        "Greg: Uhh….thanks, I guess?",
        "Papa Gorbu: Anyway, let’s get to it.",
        "Papa Gorbu: You’ve got today to get this right.",
        "Papa Gorbu: Tomorrow it’s all on you."

    };

    private string[] tutorialDialogue2 =
    {
        "Papa Gorbu: Alright, today’s the day, kid!",
        "Papa Gorbu: Time to show me what you’ve learned!",
        "Papa Gorbu: Customers will be coming soon, so get your head into the game,",
        "Papa Gorbu: And try not to go insane!"
    };

    public GameObject subtitleArrow;
    public Texture2D handFree, handGrab;
    public RectTransform subtitle, timer;
    public Transform cheese, tendrils, pineapple, sauce, sock, eyes, leeches, mushrooms, toiletRoll, dough, sanityMeter, scorecard;
    public Transform customer1, customer2, customer3, customer4, customer5, customer6, manager, littleChef, pizzaHanding;
    public Sprite cheeseBaked, tendrilsBaked, pineappleBaked, sauceBaked, sockBaked, eyesBaked, leechesBaked, mushroomsBaked, toiletRollBaked, doughBaked;
    public Sprite cheeseBurnt, tendrilsBurnt, pineappleBurnt, sauceBurnt, sockBurnt, eyesBurnt, leechesBurnt, mushroomsBurnt, toiletRollBurnt, doughBurnt;

    public AudioSource screenSwap1, screenSwap2, ingredientAudio, cookingAudio, orderAudio;
    public AudioSource lockerScreenAudio, backgroundMusic, cursedBurp;
    public List<AudioSource> stressToyAudio;

    void Awake()
    {
        camera = Camera.main;

        //Hiding customers, orders other game objects
        customer1.gameObject.SetActive(false);
        customer2.gameObject.SetActive(false);
        customer3.gameObject.SetActive(false);
        customer4.gameObject.SetActive(false);
        customer5.gameObject.SetActive(false);
        customer6.gameObject.SetActive(false);
        manager.GetChild(0).gameObject.SetActive(false);
        manager.GetChild(1).gameObject.SetActive(false);
        manager.GetChild(2).gameObject.SetActive(false);
        sanityMeter.gameObject.SetActive(false);
        subtitle.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
        scorecard.gameObject.SetActive(false);

        //Set pizza evaluators
        customerPizza1.mushrooms = 5;
        customerPizza1.cookType = 1;

        customerPizza2_1.leeches = 5;
        customerPizza2_1.cookType = 2;
        customerPizza2_2.sock = 2;
        customerPizza2_2.eyes = 5;
        customerPizza2_2.cookType = 1;
        customerPizza2_3.toiletRoll = 7;
        customerPizza2_3.tendrils = 7;
        customerPizza2_3.cookType = 1;

        customerPizza4.leeches = 2;
        customerPizza4.tendrils = 2;
        customerPizza4.cookType = 1;

        customerPizza5_1.leeches = 5;
        customerPizza5_1.cookType = 2;
        customerPizza5_2.sock = 2;
        customerPizza5_2.eyes = 5;
        customerPizza5_2.cookType = 1;
        customerPizza5_3.toiletRoll = 7;
        customerPizza5_3.tendrils = 7;
        customerPizza5_3.cookType= 1;
    }

    void Update()
    {


        if (Input.GetMouseButtonDown(0) && GameController.getCameraMove()==0)
        {
            CastRay();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                //if mouse button is lifted, and isDragging is true, then play ingredient dropping audio and add ingreedient to list of Pizza toppings
                isDragging = false;
                pizzaToppings.Add(tempObj);
                ingredientAudio.Play();
                tempObj = null;
            }
        }
        if (isDragging)
        {
            if (tempObj)
            {
                //if isDragging is true, then move the tempObj, which is the ingredient chosen, along with the mousePosition
                tempObj.transform.position = camera.ScreenToWorldPoint(Input.mousePosition);
                tempObj.transform.position += new Vector3(0, 0, 10);
            }
        }
        if(timerCountdown)
        {
            //if timer is running, then calculate the remaining time
            timeRemaining -= Time.deltaTime;
            timer.gameObject.GetComponent<Text>().text = (timeRemaining.ToString("0.0")+"s remaining");
            if (timeRemaining <= 0.0f)
            {
                //if time is up, then reduce score and move to the next order
                totalScore -= 5;
                timerCountdown = false;
                orderNumber++;
                updateOrder();
            }
        }
    }

    
    private void ClearPizza()
    {
        //Clear the current workspace by destroying the gameobjects of the ingredients in the pizza
        foreach(Transform t in pizzaToppings)
        {
            Destroy(t.gameObject);
        }
    }

    private void resetTimer()
    {
        //reset the countdown timer
        timeRemaining = 45;
    }

    private void evaluatePizza(pizzaEvaluator pizzaCheck)
    {
        mistake = 0;
        foreach (Transform t in pizzaToppings)
        {
            // count the individual toppings on the pizza
            switch (t.name)
            {
                case "cheese(Clone)":
                    currentPizza.cheese += 1;
                    break;
                case "tendrils(Clone)":
                    currentPizza.tendrils += 1;
                    break;
                case "pineapple(Clone)":
                    currentPizza.pineapple += 1;
                    break;
                case "sauce(Clone)":
                    currentPizza.sauce += 1;
                    break;
                case "sock(Clone)":
                    currentPizza.sock += 1;
                    break;
                case "sliced_eyes(Clone)":
                    currentPizza.eyes += 1;    
                    break;
                case "leeches(Clone)":
                    currentPizza.leeches += 1;
                    break;
                case "mushrooms(Clone)":
                    currentPizza.mushrooms += 1;
                    break;
                case "toilet paper(Clone)":
                    currentPizza.toiletRoll += 1;
                    break;
            }
        }

        currentPizza.cookType = cookType;

        mistake += Mathf.Abs(currentPizza.cheese - pizzaCheck.cheese);
        mistake += Mathf.Abs(currentPizza.tendrils - pizzaCheck.tendrils);
        mistake += Mathf.Abs(currentPizza.pineapple - pizzaCheck.pineapple);
        mistake += Mathf.Abs(currentPizza.sauce - pizzaCheck.sauce);
        mistake += Mathf.Abs(currentPizza.sock - pizzaCheck.sock);
        mistake += Mathf.Abs(currentPizza.eyes - pizzaCheck.eyes);
        mistake += Mathf.Abs(currentPizza.leeches - pizzaCheck.leeches);
        mistake += Mathf.Abs(currentPizza.mushrooms - pizzaCheck.mushrooms);
        mistake += Mathf.Abs(currentPizza.toiletRoll - pizzaCheck.toiletRoll);
        mistake += Mathf.Abs(currentPizza.cookType - pizzaCheck.cookType);
        
        totalScore += 20 - mistake;
    }

    private void startTimer()
    {
        timerCountdown = true;
    }

    private void stopTimer()
    {
        timerCountdown = false;
    }



    private void updateOrder()
    {
        if (orderNumber == 3)
        {
            //Start sanity mechanic after tutorial ends
            GameController.StartSanityMechanic();
        }
        switch (orderNumber)
        {
            case 1:
                //clear pizza
                ClearPizza();

                //play animations for pizza handing and customer eating
                pizzaHanding.GetComponent<Animator>().Play("pizzaHandingAnim");
                manager.GetComponent<Animator>().Play("managerAnim");

                
                manager.GetChild(0).gameObject.SetActive(false);
                manager.GetChild(1).gameObject.SetActive(true);
                pizzaToppings.Clear();
                cursedBurp.Play();
                orderAudio.Play();
                break;
            case 2:
                ClearPizza();

                pizzaHanding.GetComponent<Animator>().SetBool("play", false);
                pizzaHanding.GetComponent<Animator>().Play("pizzaHandingAnim");
                manager.GetComponent<Animator>().SetBool("play", false);
                manager.GetComponent<Animator>().Play("managerAnim");

                manager.GetChild(1).gameObject.SetActive(false);
                manager.GetChild(2).gameObject.SetActive(true);
                pizzaToppings.Clear();
                cursedBurp.Play();
                orderAudio.Play();
                break;
            case 3:
                
                ClearPizza();
                if(tutorialMode)
                {

                    pizzaHanding.GetComponent<Animator>().SetBool("play", false);
                    pizzaHanding.GetComponent<Animator>().Play("pizzaHandingAnim");
                    manager.GetComponent<Animator>().SetBool("play", false);
                    manager.GetComponent<Animator>().Play("managerAnim");
                }

                timer.gameObject.SetActive(true);
                resetTimer();
                startTimer();
                manager.gameObject.SetActive(false);
                pizzaToppings.Clear();
                customer1.gameObject.SetActive(true);
                cursedBurp.Play();
                orderAudio.Play();
                
                break;
            case 4:
                stopTimer();
                evaluatePizza(customerPizza1);
                
                ClearPizza();

                pizzaHanding.GetComponent<Animator>().SetBool("play", false);
                pizzaHanding.GetComponent<Animator>().Play("pizzaHandingAnim");
                customer1.GetComponent<Animator>().SetBool("play", false);
                customer1.GetComponent<Animator>().Play("shapeshifterAnim");

                

                resetTimer();
                startTimer();
                pizzaToppings.Clear();
                customer1.gameObject.SetActive(false);
                customer2.gameObject.SetActive(true);
                customer2.GetChild(2).gameObject.SetActive(false);
                customer2.GetChild(3).gameObject.SetActive(false);
                cursedBurp.Play();
                orderAudio.Play();
                break;
            case 5:
                stopTimer();
                evaluatePizza(customerPizza2_1);
                
                ClearPizza();
                
                pizzaHanding.GetComponent<Animator>().SetBool("play", false);
                pizzaHanding.GetComponent<Animator>().Play("pizzaHandingAnim");
                customer2.GetComponent<Animator>().SetBool("play", false);
                customer2.GetComponent<Animator>().Play("kingButterfrogAnim");
                
                resetTimer();
                startTimer();
                pizzaToppings.Clear();
                customer2.GetChild(0).gameObject.SetActive(false);
                customer2.GetChild(1).gameObject.SetActive(false);
                customer2.GetChild(2).gameObject.SetActive(true);
                cursedBurp.Play();
                orderAudio.Play();
                break;
            case 6:
                stopTimer();
                evaluatePizza(customerPizza2_2);
                
                ClearPizza();
                
                pizzaHanding.GetComponent<Animator>().SetBool("play", false);
                pizzaHanding.GetComponent<Animator>().Play("pizzaHandingAnim");
                customer2.GetComponent<Animator>().SetBool("play", false);
                customer2.GetComponent<Animator>().Play("kingButterfrogAnim");
                
                resetTimer();
                startTimer();
                pizzaToppings.Clear();
                customer2.GetChild(2).gameObject.SetActive(false);
                customer2.GetChild(3).gameObject.SetActive(true);
                cursedBurp.Play();
                orderAudio.Play();
                break;
            case 7:
                stopTimer(); 
                evaluatePizza(customerPizza2_3);
                
                ClearPizza();
                
                pizzaHanding.GetComponent<Animator>().SetBool("play", false);
                pizzaHanding.GetComponent<Animator>().Play("pizzaHandingAnim");
                customer2.GetComponent<Animator>().SetBool("play", false);
                customer2.GetComponent<Animator>().Play("kingButterfrogAnim");
                
                resetTimer();
                startTimer();
                pizzaToppings.Clear();
                customer2.gameObject.SetActive(false);
                customer3.gameObject.SetActive(true);
                cursedBurp.Play();
                orderAudio.Play();
                break;
            case 8:
                
                
                stopTimer();
                ClearPizza();
                
                pizzaHanding.GetComponent<Animator>().SetBool("play", false);
                pizzaHanding.GetComponent<Animator>().Play("pizzaHandingAnim");
                customer3.GetComponent<Animator>().SetBool("play", false);
                customer3.GetComponent<Animator>().Play("squidBoneAnim");
                
                resetTimer();
                startTimer();
                pizzaToppings.Clear();
                customer3.gameObject.SetActive(false);
                customer4.gameObject.SetActive(true);
                cursedBurp.Play();
                orderAudio.Play();
                break;
            case 9:
                stopTimer();
                evaluatePizza(customerPizza4);
                
                ClearPizza();
                
                pizzaHanding.GetComponent<Animator>().SetBool("play", false);
                pizzaHanding.GetComponent<Animator>().Play("pizzaHandingAnim");
                customer4.GetComponent<Animator>().SetBool("play", false);
                customer4.GetComponent<Animator>().Play("eelBrothersAnim");
                
                resetTimer();
                startTimer();
                pizzaToppings.Clear();
                customer4.gameObject.SetActive(false);
                customer5.gameObject.SetActive(true);
                cursedBurp.Play();
                orderAudio.Play();
                break;
            case 10:
                stopTimer();
                evaluatePizza(customerPizza5_1);

                ClearPizza();
                resetTimer();
                startTimer();
                pizzaToppings.Clear();
                pizzaHanding.GetComponent<Animator>().SetBool("play", false);
                pizzaHanding.GetComponent<Animator>().Play("pizzaHandingAnim");
                customer5.GetComponent<Animator>().SetBool("play", false);
                customer5.GetComponent<Animator>().Play("hoboAnim");

                cursedBurp.Play();
                orderAudio.Play();
                break;
            case 11:
                stopTimer();
                evaluatePizza(customerPizza5_2);

                ClearPizza();
                resetTimer();
                startTimer();
                pizzaToppings.Clear();
                pizzaHanding.GetComponent<Animator>().SetBool("play", false);
                pizzaHanding.GetComponent<Animator>().Play("pizzaHandingAnim");
                customer5.GetComponent<Animator>().SetBool("play", false);
                customer5.GetComponent<Animator>().Play("hoboAnim");

                cursedBurp.Play();
                orderAudio.Play();
                break;
            case 12:
                stopTimer();
                evaluatePizza(customerPizza5_3);
                
                ClearPizza();

                pizzaHanding.GetComponent<Animator>().SetBool("play", false);
                pizzaHanding.GetComponent<Animator>().Play("pizzaHandingAnim");
                customer5.GetComponent<Animator>().SetBool("play", false);
                customer5.GetComponent<Animator>().Play("hoboAnim");

                resetTimer();
                startTimer();
                pizzaToppings.Clear();
                customer5.gameObject.SetActive(false);
                customer6.gameObject.SetActive(true);

                cursedBurp.Play();
                orderAudio.Play();
                break;
            case 13:
                stopTimer();
                
                pizzaHanding.GetComponent<Animator>().SetBool("play", false);
                pizzaHanding.GetComponent<Animator>().Play("pizzaHandingAnim");
                customer6.GetComponent<Animator>().SetBool("play", false);
                customer6.GetComponent<Animator>().Play("tapewormAnim");
                cursedBurp.Play();

                Debug.Log(totalScore);

                break;
            default:
                stopGame();
                break;
        }
    }

    void cookPizza()
    {
        if (cookType == 1)
        {
            foreach (Transform t in pizzaToppings)
            {
                switch (t.name)
                {
                    case "cheese(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = cheeseBaked;
                        break;
                    case "tendrils(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = tendrilsBaked;
                        break;
                    case "pineapple(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = pineappleBaked;
                        break;
                    case "sauce(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = sauceBaked;
                        break;
                    case "sock(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = sockBaked;
                        break;
                    case "sliced_eyes(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = eyesBaked;
                        break;
                    case "leeches(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = leechesBaked;
                        break;
                    case "mushrooms(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = mushroomsBaked;
                        break;
                    case "toilet paper(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = toiletRollBaked;
                        break;
                    case "pizza dough layed out(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = doughBaked;
                        break;
                }
            }
        }
        else if(cookType == 2)
        {
            foreach (Transform t in pizzaToppings)
            {
                switch (t.name)
                {
                    case "cheese(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = cheeseBurnt;
                        break;
                    case "tendrils(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = tendrilsBurnt;
                        break;
                    case "pineapple(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = pineappleBurnt;
                        break;
                    case "sauce(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = sauceBurnt;
                        break;
                    case "sock(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = sockBurnt;
                        break;
                    case "sliced_eyes(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = eyesBurnt;
                        break;
                    case "leeches(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = leechesBurnt;
                        break;
                    case "mushrooms(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = mushroomsBurnt;
                        break;
                    case "toilet paper(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = toiletRollBurnt;
                        break;
                    case "pizza dough layed out(Clone)":
                        t.GetComponent<SpriteRenderer>().sprite = doughBurnt;
                        break;
                }
            }
        }
    }

    void CastRay()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if(hit)
        { 
            switch (hit.collider.gameObject.name)
            {
                case "cheese":
                    tempObj = Instantiate(cheese, camera.ScreenToWorldPoint(Input.mousePosition), cheese.rotation);
                    isDragging = true;
                    break;
                case "tenticles":
                    tempObj = Instantiate(tendrils, camera.ScreenToWorldPoint(Input.mousePosition), tendrils.rotation);
                    isDragging = true;
                    break;
                case "pineapple":
                    tempObj = Instantiate(pineapple, camera.ScreenToWorldPoint(Input.mousePosition), pineapple.rotation);
                    isDragging = true;
                    break;
                case "pizza_sauce":
                    tempObj = Instantiate(sauce, camera.ScreenToWorldPoint(Input.mousePosition), sauce.rotation);
                    isDragging = true;
                    break;
                case "dirty_socks":
                    tempObj = Instantiate(sock, camera.ScreenToWorldPoint(Input.mousePosition), sock.rotation);
                    isDragging = true;
                    break;
                case "eyes":
                    tempObj = Instantiate(eyes, camera.ScreenToWorldPoint(Input.mousePosition), eyes.rotation);
                    isDragging = true;
                    break;
                case "leeches":
                    tempObj = Instantiate(leeches, camera.ScreenToWorldPoint(Input.mousePosition), leeches.rotation);
                    isDragging = true;
                    break;
                case "necrotic_spores":
                    tempObj = Instantiate(mushrooms, camera.ScreenToWorldPoint(Input.mousePosition), mushrooms.rotation);
                    isDragging = true;
                    break;
                case "toilet_roll":
                    tempObj = Instantiate(toiletRoll, camera.ScreenToWorldPoint(Input.mousePosition), toiletRoll.rotation);
                    isDragging = true;
                    break;
                case "eldritch_dough":
                    tempObj = Instantiate(dough, new Vector3(0, -10.1f, 10), dough.rotation);
                    pizzaToppings.Add(tempObj);
                    tempObj.GetComponent<SpriteRenderer>().sortingLayerName = "Pizza Dough";
                    break;
                case "little_chef":
                    if(cookType<2)
                    {
                        cookType++;
                        cookingAudio.Play();
                        littleChef.GetComponent<Animator>().SetBool("play", false);
                        littleChef.GetComponent<Animator>().Play("littleChefAnim");
                        //littleChef.GetComponent<Animator>().SetBool("play", false);
                        //littleChef.GetComponent<Animator>().SetBool("idle", true);
                        cookPizza();
                    }
                    break;
                case "counter_button":
                    orderNumber++;
                    cookType = 0;
                    updateOrder();
                    break;
                case "down_arrow":
                    GameController.CameraMoveDown();
                    screenSwap1.Play();
                    break;
                case "up_arrow":
                    GameController.CameraMoveUp();
                    screenSwap2.Play();
                    break;
                case "stress_ball_anim":
                    hit.collider.gameObject.GetComponent<Animator>().SetTrigger("playAnim");
                    GameController.AddSanity();
                    int num = Random.Range(0, 9);
                    stressToyAudio[num].Play();
                    break;
                case "startButton":
                    camera.transform.position += new Vector3(20.3f, 0, 0);
                    startGame();
                    break;
                case "subtitleArrow":
                    nextDialogue();
                    break;
                default:
                    break;
            }
        }
        
        if (tempObj)
        {
            //pizzaToppings.Add(tempObj);
            tempObj.GetComponent<SpriteRenderer>().sortingLayerName = "Ingredient-Panel";

        }


        //Cursor.SetCursor(handGrab, Vector2.zero, CursorMode.ForceSoftware);
    }

    //public static bool getAudioPlay()
    //{
    //    return audioPlay;
    //}
    public void startGame()
    {
        scorecard.gameObject.SetActive(false);
        totalScore = 0;
        starCount = 0;
        backgroundMusic.Play();
        if(tutorialMode)
        {
            subtitle.gameObject.SetActive(true);
            subtitle.gameObject.GetComponent<Text>().text = tutorialDialogue[dialogueIndex];
        }
        else
        {
            customer1.gameObject.SetActive(false);
            customer2.gameObject.SetActive(false);
            customer3.gameObject.SetActive(false);
            customer4.gameObject.SetActive(false);
            customer5.gameObject.SetActive(false);
            customer6.gameObject.SetActive(false);
            manager.GetChild(0).gameObject.SetActive(false);
            manager.GetChild(1).gameObject.SetActive(false);
            manager.GetChild(2).gameObject.SetActive(false);
            timer.gameObject.SetActive(false);

            subtitle.gameObject.SetActive(false);
            sanityMeter.gameObject.SetActive(true);


            subtitleArrow.SetActive(false);

            orderNumber = 3;
            updateOrder();
            //orderAudio.Play();
            //manager.GetChild(0).gameObject.SetActive(true);
        }
    }

    void stopGame()
    {
        backgroundMusic.Stop();
        starCount = totalScore / 60;
        tutorialMode = false;

        scorecard.gameObject.SetActive(true);
        scorecard.GetChild(0).gameObject.SetActive(false);
        scorecard.GetChild(1).gameObject.SetActive(false);
        scorecard.GetChild(2).gameObject.SetActive(false);
        scorecard.GetChild(3).gameObject.SetActive(false);
        scorecard.GetChild(4).gameObject.SetActive(false);
        for(int i = 0; i < starCount; i++)
        {
            scorecard.GetChild(i).gameObject.SetActive(true);
        }
    }
    void nextDialogue()
    {
        if (dialogueIndex + 1 < tutorialDialogue.Length)
        {
            subtitle.gameObject.GetComponent<Text>().text = tutorialDialogue[++dialogueIndex];
        }
        else
        {
            subtitle.gameObject.SetActive(false);
            sanityMeter.gameObject.SetActive(true);
            
            
            subtitleArrow.SetActive(false);
            orderAudio.Play();
            manager.GetChild(0).gameObject.SetActive(true);
        }
    }
}
