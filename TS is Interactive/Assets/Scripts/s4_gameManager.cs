using UnityEngine;

public class s4_gameManager : MonoBehaviour
{
    [Header("Text Mesh Pro Variables")]
    public GameObject caption_display_obj;
    public GameObject options_display_obj;
    public GameObject hover_display_obj;
    /*public string defaultOptionOne;
    public string defaultOptionTwo;
    public string defaultOptionThree;*/

    // actual text change information
    private TMPro.TextMeshProUGUI caption_text;
    private TMPro.TextMeshProUGUI options_text;
    private TMPro.TextMeshProUGUI hover_text;

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            processInput(promptIsShown);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && promptIsShown)
        {
            processInput(promptIsShown);
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

    private void processInput(bool promptIsShown)
    {
        // Toggling prompts to give to AI
        if (!promptIsShown)
        {
            options_display_obj.SetActive(true);
        }

        // Selecting AI prompts
    }
}
