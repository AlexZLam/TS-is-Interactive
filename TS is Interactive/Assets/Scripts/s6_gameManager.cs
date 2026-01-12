using UnityEngine;

public class s6_GameManager : MonoBehaviour
{
    public GameObject text_display_obj;
    public bool level_done = false;
    public GameObject obj_in_view;
    private TMPro.TextMeshProUGUI text_display;

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
                if (obj_in_view != null)
                {
                    string obj_flavortext = obj_in_view.GetComponent<s2_clickable_object>().flavortext;
                    if (obj_flavortext != null)
                    {
                        displayText(obj_flavortext);
                    }
                    string obj_phase = obj_in_view.GetComponent<s2_clickable_object>().phase;
                    if (obj_phase != null)
                    {
                        if (obj_phase == "door")
                        {
                            obj_in_view.transform.Rotate(0, 50 * Time.deltaTime, 0);
                        }
                    }
                }
            }
        }
    }
    private void displayText(string text)
    {
        text_display.text = text;
    }
}


