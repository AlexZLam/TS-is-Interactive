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
    private bool captionTimerEnded = false;

    [Header("Others")]
    public GameObject objectInView;
    public GameObject aiMapImage;
    public bool funButtonThatDoesNothing; //every codespace needs one

    private bool triggerAiResponse = false;
    private bool promptIsShown = false;
    private bool objectHasCaptions = false;
    private bool runningPrompt = false; // a bool to make sure no variables change while a prompt is being processed
    private int captionsToDisplay; // an int number of how many captions will run during caption events (usually 1)
    private int promptToRun = 0; 

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
        if (objectInView != null && !runningPrompt /*&& promptOptionOne == defaultOptionOne && responseOptionOne == defaultResponseOne
                && captionOne == defaultOptionOne*/)
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
                objectHasCaptions = true;
            }

            Debug.Log("prompts have changed");
        }
        if (objectInView == null && !runningPrompt && promptOptionOne != defaultOptionOne && responseOptionOne != defaultResponseOne 
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

            Debug.Log("prompts have been defaulted");
        }

        // Interacting with AI
        if (Input.GetKeyDown(KeyCode.E) && !promptIsShown && !runningPrompt) // Shows the prompts the player can use
        {
            // changes options texts
            changeOptionsText(promptOptionOne, promptOptionTwo, promptOptionThree);
            // toggles prompts on
            togglePrompts(promptIsShown);
            promptIsShown = true;
            runningPrompt = true;

            // changes caption texts
            if (objectInView != null)
            {
                captionOne = objectInView.GetComponent<s4_objectInfo>().playerCaption_1;
                captionTwo = objectInView.GetComponent<s4_objectInfo>().playerCaption_2;
                captionThree = objectInView.GetComponent<s4_objectInfo>().playerCaption_3;
            }
            else if (objectInView == null)
            {
                captionOne = defaultCaptionOne;
                captionTwo = defaultCaptionTwo;
                captionThree = defaultCaptionThree;
            }

            Debug.Log("attempting to run togglePrompts");
        }
        if (promptIsShown)
        {
            // Player selects a prompt

            if (objectInView != null)
                captionsToDisplay = 1;
            else if (objectInView == null)
                captionsToDisplay = 1;

            if (Input.GetKeyDown(KeyCode.Alpha1)) // Prompt 1 Selected
            {
                runningPrompt = true;

                // Changes captions if we are facing an object
                /*if (objectInView != null)
                {
                    captionOne = objectInView.GetComponent<s4_objectInfo>().playerCaption_1;
                }*/

                // Runs player captions
                captioning(captionOne, "Player");
                runCaptionTimer = true;
                captionTimerEnded = false;
                
                // Runs object captions (i gave up on this function)
                if (objectHasCaptions && captionsToDisplay == 1)
                {
                    // if objectHasCaptions is true, then captionsToDisplay would be 2. After the
                    // player talks, the captionsToDisplay variable will be reduced to 1, meaning
                    // its time for the object to display their captions. 

                    // therefore this "if" statement means it must be time for the object to speak

                    captioning(objectInView.GetComponent<s4_objectInfo>().objectCaption_1, objectInView.GetComponent<s4_objectInfo>().objectName);

                    runCaptionTimer = true;
                    //Debug.Log("running object captions");
                }

                // ai response variables
                promptToRun = 1; // tells the script which prompt we are trying to run

                triggerAiResponse = true; // tells the script its time to trigger the
                                          // function to run the ai response (which
                                          // should only happen after the captoins
                                          // have been disabled
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) // Prompt 2 Selected
            {
                runningPrompt = true;

                // Changes captions if we are facing an object
                /*if (objectInView != null)
                {
                    captionTwo = objectInView.GetComponent<s4_objectInfo>().playerCaption_2;
                }*/

                // Runs player captions
                captioning(captionTwo, "Player");
                runCaptionTimer = true;
                captionTimerEnded = false;

                // Runs object captions (i gave up on this function)
                if (objectHasCaptions && captionsToDisplay == 1)
                {
                    captioning(objectInView.GetComponent<s4_objectInfo>().objectCaption_2, objectInView.GetComponent<s4_objectInfo>().objectName);
                    runCaptionTimer = true;
                }

                // ai response variables
                promptToRun = 2; // tells the script which prompt we are trying to run

                triggerAiResponse = true; // tells the script its time to trigger the
                                          // function to run the ai response (which
                                          // should only happen after the captoins
                                          // have been disabled
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                runningPrompt = true;

                // Runs object captions (i gave up on this function)
                /*if (objectInView != null)
                {
                    captionThree = objectInView.GetComponent<s4_objectInfo>().playerCaption_3;
                }*/

                // Runs player captions
                captioning(captionThree, "Player");
                runCaptionTimer = true;
                captionTimerEnded = false;

                // Runs object captions
                if (objectHasCaptions && captionsToDisplay == 1)
                {
                    captioning(objectInView.GetComponent<s4_objectInfo>().objectCaption_3, objectInView.GetComponent<s4_objectInfo>().objectName);
                    runCaptionTimer = true;
                }

                // ai response variables
                promptToRun = 3; // tells the script which prompt we are trying to run

                triggerAiResponse = true; // tells the script its time to trigger the
                                          // function to run the ai response (which
                                          // should only happen after the captoins
                                          // have been disabled
            }
        }

        // changes and activates ai response onscreen
        if (triggerAiResponse && captionTimerEnded)
        {
            if (promptToRun == 1)
            {
                changeAiResponseText(responseOptionOne);
                promptToRun = 0;
            }
            else if (promptToRun == 2)
            {
                changeAiResponseText(responseOptionTwo);
                promptToRun = 0;
            }
            else if (promptToRun == 3)
            {
                changeAiResponseText(responseOptionThree);
                promptToRun = 0;
            }
            else
            {
                Debug.Log("Something went wrong.\npromptToRun: " + promptToRun);
            }
            triggerAiResponse = false;
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
                runningPrompt = false;
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
                // resets the timer
                captionTimer = captionScreenTime;

                // lets the ai response trigger know it can spawn now
                captionTimerEnded = true;

                //tells the script to stop running the caption timer
                runCaptionTimer = false;

                // a caption has now been displayed so this variable
                // should go down by one
                captionsToDisplay--;

                //turns off the captions
                if (captionsToDisplay == 0)
                {
                    caption_display_obj.SetActive(false);
                }

                Debug.Log("timer ended");
            }

        }
        else if (runCaptionTimer && captionsToDisplay <= 0)
        {
            Debug.Log("Something went wrong.\ncaptionsToDisplay: " + captionsToDisplay);
        }
    }

    public void captioning(string captionText, string personTalking)
    {
        if (personTalking == "Player")
        {
            caption_text.text = "[You]\n" + captionText;
        }
        else
        {
            caption_text.text = "[" + personTalking + "]\n" + captionText;
        }

        caption_display_obj.SetActive(true);
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
        togglePrompts(promptIsShown);
        promptIsShown = false;

        // changes the ai response text 
        if (textToDisplay == "map")
        {
            aiResponse_text.text = "";
            aiMapImage.SetActive(true);
        }
        else
        {
            aiMapImage.SetActive(false);
            aiResponse_text.text = textToDisplay;
        }

        // shows the ai response
        aiResponse_Animator.SetBool("aiEnter", true);

        runResponseTimer = true;
        triggerAiResponse = false;
    }
}
