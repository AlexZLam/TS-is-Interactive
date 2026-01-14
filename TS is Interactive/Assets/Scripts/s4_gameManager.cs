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

    // actual text change information
    private TMPro.TextMeshProUGUI caption_text;
    private TMPro.TextMeshProUGUI options_text;
    private TMPro.TextMeshProUGUI hover_text;

    private string promptOptionOne;
    private string promptOptionTwo;
    private string promptOptionThree;

    [Header("Animators")]
    public Animator options_Animator;
    public Animator aiResponse_Animator;

    [Header("Others")]
    public GameObject objectInView;
    public bool funButtonThatDoesNothing; //every codespace needs one

    private bool promptIsShown = false;


    // Checks if we have the different text objects & yells at us if we dont
    void Start()
    {
        caption_text = caption_display_obj.GetComponent<TMPro.TextMeshProUGUI>();
        if (caption_text == null)
        {
            Debug.Log("caption_display_obj has no TMPro.TextMeshProUGUI component.");
        }

        options_text = options_display_obj.GetComponent<TMPro.TextMeshProUGUI>();
        if (options_text == null)
        {
            Debug.Log("caption_display_obj has no TMPro.TextMeshProUGUI component.");
        }

        hover_text = hover_display_obj.GetComponent<TMPro.TextMeshProUGUI>();
        if (hover_text == null)
        {
            Debug.Log("caption_display_obj has no TMPro.TextMeshProUGUI component.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Updating prompts 1-3 depending on if we are looking at an object or not
        if (objectInView != null)
        {
            promptOptionOne = objectInView.GetComponent<s4_objectInfo>().aiResponse_1;
            promptOptionTwo = objectInView.GetComponent<s4_objectInfo>().aiResponse_2;
            promptOptionThree = objectInView.GetComponent<s4_objectInfo>().aiResponse_3;
        }
        if (objectInView == null)
        {
            promptOptionOne = defaultOptionOne;
            promptOptionTwo = defaultOptionTwo;
            promptOptionThree = defaultOptionThree;
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
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectPrompt(1);
            }
        }
        
        //debugging
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            aiResponse_display_obj.SetActive(false);
        }
    }

    public void captioning()
    {
        //this changes the captions
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
            Debug.Log("animator bool was set to true");
        }
    }

    private void selectPrompt(int promptSelected)
    {
        // Selecting AI prompts
        aiResponse_display_obj.SetActive(true);

        options_Animator.SetBool("Prompts", false);
    }

    private void changeOptionsText(string optionOne, string optionTwo, string optionThree)
    {
        options_text.text = "[1] " + optionOne + "\n[2] " + optionTwo + "\n[3] " + optionThree;
    }
}
