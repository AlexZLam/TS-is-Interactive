using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public bool level_done = false;
    public GameObject obj_in_view;
    private TMPro.TextMeshProUGUI text_display;
    public GameObject text_display_obj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text_display = text_display_obj.GetComponent<TMPro.TextMeshProUGUI>();
        if (text_display == null)
        {
            Debug.Log("text_display_obj has no TMPro.TextMeshProUGUI component.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (level_done == false)
        {


            //if left mouse button clicked
            if (Input.GetMouseButtonDown(0))
            {
                string obj_flavortext = obj_in_view.GetComponent<s2_clickable_object>().flavortext;
                if (obj_flavortext != null)
                {
                    displayText(obj_flavortext);
                }
                string obj_phase = obj_in_view.GetComponent<s2_clickable_object>().phase;
                if (obj_phase != null)
                {

                }
            }
        }
    }
    private void displayText(string text)
    {
        text_display.text = text;
    }
}


