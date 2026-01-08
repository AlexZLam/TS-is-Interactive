using Unity.VisualScripting;
using UnityEngine;

public class s2_GameManager : MonoBehaviour
{
    
    public GameObject text_display_obj;
    private string steps_list = "wait 5 seconds\nman, watching tv is so boring. wish i had something else to do." +
        "\nreadyup from desk\nwait 2 seconds\ndoorbell\nwait 0.3 seconds\ni should check that.\nreadyup from door\nlooks like i got a package. could it be...." +
        "\nreadyup from package\nmy new meta rayban glasses with private in-lens display and wrist control??!?!?\nthis is sure to keep me entertained." +
        "\ntv time!\nreadyup from couch\ncant wait to try these on!\nreadyup from glasses\nso many apps...\nreadyup from apps\nreels!!!\nwait 1 second" +
        "\nreadyup from reels\nnow this is the life. \nwait 1 second    \nthe meta rayban glasses with private in lens display and wrist control are " +
        "perfect for keeping all critical thought from my brain! \n wait 5 seconds \n end level";
    private bool ready_for_next_step = true;
    public KeyCode skip_button;
    private float timer_counter;
    private bool timer_active;
    private string[] steps;
    private int current_step_index;
    private string current_step;
    private TMPro.TextMeshProUGUI text_display;
    public bool level_done = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text_display = text_display_obj.GetComponent<TMPro.TextMeshProUGUI>();
        if (text_display == null)
        {
            Debug.Log("text_display_obj has no TMPro.TextMeshProUGUI component.");
        }
        steps_list = "[first step ignored]\n" + steps_list;
        steps = steps_list.Split('\n');
        current_step_index = 0;
        current_step = steps[current_step_index];
    }

    // Update is called once per frame
    void Update()
    {
        if(level_done == false)
        {

        
            //decrement timer if its active
            if(timer_active)
            {
                timer_counter -= Time.deltaTime;
                //if timer done, readyup
                if (timer_counter <= 0)
                {
                    timer_active = false;
                    readyUp();
                }
            }
            //start next step if readyup-ed
            if (ready_for_next_step)
            {
                //move to next step
                current_step_index += 1;
                current_step = steps[current_step_index];
                Debug.Log("current_step: " + current_step);
                if(current_step.StartsWith("end level"))
                {

                }
                //wait
                if(current_step.StartsWith("wait"))
                {
                    string waitstring = current_step.Substring(5);
                    waitstring = waitstring.Substring(0, waitstring.IndexOf(" "));
                    Debug.Log("waitstring: " + waitstring);
                    float seconds = 0;
                    if(float.TryParse(waitstring, out seconds) == false)
                    {
                        Debug.Log("wait time formatted wrong. timer defaulting to 1 second");
                        seconds = 1;
                    }
                    startTimer(seconds);
                }
                else if(current_step.StartsWith("readyup"))
                {
                    Debug.Log("waiting for " + current_step);
                }
                else
                {
                    displayText(current_step);
                    startTimer(1.5f);
                }
                ready_for_next_step = false;

            }
            //if left mouse button clicked
            if (Input.GetMouseButtonDown(0))
            {

            }
            //skip button
            if(Input.GetKeyDown(skip_button))
            {
                readyUp();
            }
        }
    }

    private void displayText(string text)
    {
        text_display.text = text;
    }

    private void startTimer(float seconds)
    {
        timer_counter = seconds;
        timer_active = true;
    }

    public void readyUp()
    {
        ready_for_next_step = true;
    }

    /*
     * sitting on couch, looking at roblox tv
wait 5 seconds
man, watching tv is so boring. wish i had something else to do.
readyup from desk interact: 
    (on desk: book, paintbrush, knitting, plant) all give responses 
    readyUp after 3 clicked
wait 2 seconds
doorbell
wait 0.3 seconds
i should check that.
readyup from door
    readyup when clicked
looks like i got a package. could it be....
readyup from package
    readyup when clicked
my new meta rayban glasses with private in-lens display and wrist control??!?!?
this is sure to keep me entertained.
tv time!
readyup from couch: 
    readyup on collision
cant wait to try these on!
readyup from glasses
    click to equip
    readyup once equipped
so many apps...
readyup from apps
    response for each app
    readyup when insta clicked
reels!!!
wait 1 second
readyup from reels
    spam click for reels (shake hand wildly)
    readyup once done
now this is the life. 
wait 1 second    
the meta rayban glasses with private in lens display and wrist control are perfect for keeping all critical thought from my brain!
wait 5 seconds
    stretch: freeze character pos

click to advance?
     */
}
