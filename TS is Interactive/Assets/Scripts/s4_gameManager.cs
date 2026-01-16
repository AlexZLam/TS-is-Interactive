/*******************************************************************
 * File name: s4_gameManager
 * Author: Nathen Mattis
 * Email: 1119065@lwsd.org
 * Course: Video Game Programming I
 * Last edited: 1/15/2026
 *
 * Description: Changes texts of the object we are hovering over,
 * the text of the different ai prompts, the ai response, triggers
 * the enter/exit animations of the ai response and ai prompts, 
 ********************************************************************/
using UnityEngine;

public class s4_gameManager : MonoBehaviour
{
    [Header("Text Variables")]
    public GameObject caption_display_obj;
    public GameObject aiResponse_display_obj;
    public GameObject options_display_obj;
    public GameObject hover_display_obj;

    public string defaultOptionOne = "Dinner plans?";
    public string defaultOptionTwo = "Home?";
    public string defaultOptionThree = "Underwear?";

    public string defaultResponseOne = "There is a new restaurant that opened near you. Sadly, you're too broke to afford it. You should have: Poptarts.";
    public string defaultResponseTwo = "map";
    public string defaultResponseThree = "You are wearing pink underwear today.";

    public string defaultCaptionOne = "";
    public string defaultCaptionTwo = "";
    public string defaultCaptionThree = "";

    // actual text change information
    private TMPro.TextMeshProUGUI caption_text;
    private TMPro.TextMeshProUGUI aiResponse_text;
    private TMPro.TextMeshProUGUI options_text;
    private TMPro.TextMeshProUGUI hover_text;

    private string promptOptionOne;
    private string promptOptionTwo;
    private string promptOptionThree;
    private string responseOptionOne;
    private string responseOptionTwo;
    private string responseOptionThree;
    private string captionOne;
    private string captionTwo;
    private string captionThree;

    [Header("Animators")]
    public Animator options_Animator;
    public Animator aiResponse_Animator;

    [Header("Time Variables")]
    public float responseScreenTime;
    public float captionScreenTime;
    private float responseTimer; // this is the internal responseScreenTime so that the timer can happen multiple times
    private float captionTimer;
    private bool runResponseTimer = false; // starts and stops the  ai response timer, which should only be active while the response is on screen
    private bool runCaptionTimer = false;

    [Header("Others")]
    public GameObject objectInView;
    public GameObject aiMapImage;
    public bool funButtonThatDoesNothing; //every codespace needs one

    private bool promptIsShown = false;
    private bool objectHasCaptions = false;
    private int captionsToDisplay; // an int number of how many captions will run during caption events (usually 1)

    // Checks if we have the different text objects & yells at us if we dont
    void Start()
    {
        responseTimer = responseScreenTime;
        captionTimer = captionScreenTime;

        caption_text = caption_display_obj.GetComponent<TMPro.TextMeshProUGUI>();
        if (caption_text == null)
        {
            Debug.Log("caption_display_obj has no TMPro.TextMeshProUGUI component.");
        }

        options_text = options_display_obj.GetComponent<TMPro.TextMeshProUGUI>();
        if (options_text == null)
        {
            Debug.Log("options_display_obj has no TMPro.TextMeshProUGUI component.");
        }

        hover_text = hover_display_obj.GetComponent<TMPro.TextMeshProUGUI>();
        if (hover_text == null)
        {
            Debug.Log("hover_display_obj has no TMPro.TextMeshProUGUI component.");
        }

        aiResponse_text = aiResponse_display_obj.GetComponent<TMPro.TextMeshProUGUI>();
        if (aiResponse_text == null)
        {
            Debug.Log("aiResponse_display_obj has no TMPro.TextMeshProUGUI component.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Updating prompts & responses 1-3 depending on if we are looking at an object or not
        if (objectInView != null && promptOptionOne == defaultOptionOne && responseOptionOne == defaultResponseOne
                && captionOne == defaultOptionOne)
        {
            // So many conditions because this doesn't need to run every frame if these variables are already
            // set to their new versions

            // prompt texts
            promptOptionOne = objectInView.GetComponent<s4_objectInfo>().prompt_1;
            promptOptionTwo = objectInView.GetComponent<s4_objectInfo>().prompt_2;
            promptOptionThree = objectInView.GetComponent<s4_objectInfo>().prompt_3;

            // ai response texts
            responseOptionOne = objectInView.GetComponent<s4_objectInfo>().aiResponse_1;
            responseOptionTwo = objectInView.GetComponent<s4_objectInfo>().aiResponse_2;
            responseOptionThree = objectInView.GetComponent<s4_objectInfo>().aiResponse_3;

            // if the object will talk
            if (objectInView.GetComponent<s4_objectInfo>().hasCaptions)
            {
                captionsToDisplay = 2;
                objectHasCaptions = true;
            }
        }
        if (objectInView == null && promptOptionOne != defaultOptionOne && responseOptionOne != defaultResponseOne 
                && captionOne != defaultOptionOne)
        {
            // So many conditions because this doesn't need to run every frame if these variables are already
            // set to default.

            promptOptionOne = defaultOptionOne;
            promptOptionTwo = defaultOptionTwo;
            promptOptionThree = defaultOptionThree;

            responseOptionOne = defaultResponseOne;
            responseOptionTwo = defaultResponseTwo;
            responseOptionThree = defaultResponseThree;

            captionOne = defaultCaptionOne;
            captionTwo = defaultCaptionTwo;
            captionThree = defaultCaptionThree;

            captionsToDisplay = 1;
        }

        // Interacting with AI
        if (Input.GetKeyDown(KeyCode.E) && !promptIsShown) // Shows the prompts the player can use
        {
            changeOptionsText(promptOptionOne, promptOptionTwo, promptOptionThree);
            togglePrompts(promptIsShown);
            promptIsShown = true;
            Debug.Log("attempting to run togglePrompts");
        }
        if (promptIsShown)
        {
            // Player selects a prompt
            if (Input.GetKeyDown(KeyCode.Alpha1)) // Prompt 1 Selected
            {
                // Changes captions if we are facing an object
                if (objectInView != null)
                {
                    captionOne = objectInView.GetComponent<s4_objectInfo>().playerCaption_1;
                }

                // Runs player captions
                captioning(captionOne, "Player");
                caption_display_obj.SetActive(true);
                runCaptionTimer = true;
                Debug.Log("ran player captions");

                // Runs object captions
                if (objectHasCaptions && captionsToDisplay == 1)
                {
                    // if objectHasCaptions is true, then captionsToDisplay would be 2. After the
                    // player talks, the captionsToDisplay variable will be reduced to 1, meaning
                    // its time for the object to display their captions. 

                    // therefore this "if" statement means it must be time for the object to speak

                    captioning(objectInView.GetComponent<s4_objectInfo>().objectCaption_1, objectInView.GetComponent<s4_objectInfo>().objectName);
                    runCaptionTimer = true;
                    Debug.Log("running object captions");
                }

                // changes and activates ai response onscreen
                changeAiResponseText(responseOptionOne);
                Debug.Log("attempting to run ai");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) // Prompt 2 Selected
            {
                // Changes captions if we are facing an object
                if (objectInView != null)
                {
                    captionTwo = objectInView.GetComponent<s4_objectInfo>().playerCaption_2;
                }

                // Runs player captions
                captioning(captionTwo, "Player");
                runCaptionTimer = true;

                // Runs object captions
                if (objectHasCaptions && captionsToDisplay == 1)
                {
                    captioning(objectInView.GetComponent<s4_objectInfo>().objectCaption_2, objectInView.GetComponent<s4_objectInfo>().objectName);
                    runCaptionTimer = true;
                }

                // changes and activates ai response onscreen
                changeAiResponseText(responseOptionTwo);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                // Changes captions if we are facing an object
                if (objectInView != null)
                {
                    captionThree = objectInView.GetComponent<s4_objectInfo>().playerCaption_3;
                }

                // Runs player captions
                captioning(captionThree, "Player");
                runCaptionTimer = true;

                // Runs object captions
                if (objectHasCaptions && captionsToDisplay == 1)
                {
                    captioning(objectInView.GetComponent<s4_objectInfo>().objectCaption_3, objectInView.GetComponent<s4_objectInfo>().objectName);
                    runCaptionTimer = true;
                }

                // changes and activates ai response onscreen
                changeAiResponseText(responseOptionThree);
            }
        }
        
        // Timers 

        // ai response timer
        if (runResponseTimer)
        {
            if (responseTimer > 0)
            {
                responseTimer -= Time.deltaTime;
            }
            else
            {
                responseTimer = responseScreenTime;
                aiResponse_Animator.SetBool("aiEnter", false);
                runResponseTimer = false;
            }
        }

        // captions timers
        if (runCaptionTimer && captionsToDisplay > 0)
        {
            if (captionTimer > 0)
            {
                captionTimer -= Time.deltaTime;
            }
            else
            {
                captionTimer = captionScreenTime;
                Debug.Log("timer ended");
                //caption_display_obj.SetActive(false);
                runCaptionTimer = false;
            }

            if (captionsToDisplay == 0)
            {
                caption_display_obj.SetActive(false);
            }
        }
    }

    public void captioning(string captionText, string personTalking)
    {
        //caption_display_obj.SetActive(true);

        if (personTalking == "Player")
        {
            caption_text.text = "[You]\n" + captionText;
        }
        else
        {
            caption_text.text = "[" + personTalking + "]\n" + captionText;
        }

        captionsToDisplay--;
    }

    // Displays the object that the player is currently hovering over (as long as it is interactable)
    public void objectHoverDisplay(bool isHoveringOnObj)
    {
        if (isHoveringOnObj)
        {
            string obj_nameText = objectInView.GetComponent<s4_objectInfo>().objectName;
            if (obj_nameText != null && isHoveringOnObj)
            {
                hover_text.text = "Currently Hovering Over:\n" + obj_nameText;
            }
        }
        else
        {
            hover_text.text = "Currently Hovering Over:\nNothing";
        }
    }

    private void togglePrompts(bool promptIsShown)
    {
        if (!promptIsShown)
        {
            options_Animator.SetBool("Prompts", true);
            //Debug.Log("animator bool was set to true");
        }
        else if (promptIsShown)
        {
            options_Animator.SetBool("Prompts", false);
        }
    }

    private void changeOptionsText(string optionOne, string optionTwo, string optionThree)
    {
        options_text.text = "[1] " + optionOne + "\n[2] " + optionTwo + "\n[3] " + optionThree;
    }

    private void changeAiResponseText(string textToDisplay)
    {
        // turns off the prompts display
        promptIsShown = true;
        togglePrompts(promptIsShown);

        // changes the ai response text 
        if (textToDisplay == "map")
        {
            aiMapImage.SetActive(true);
        }
        else
        {
            aiResponse_text.text = textToDisplay;
        }

        // shows the ai response
        aiResponse_Animator.SetBool("aiEnter", true);

        runResponseTimer = true;
    }
}
