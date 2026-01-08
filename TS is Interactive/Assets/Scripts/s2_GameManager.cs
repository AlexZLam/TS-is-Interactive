using UnityEngine;

public class s2_GameManager : MonoBehaviour
{

    public TextMesh text_display;
    public string steps_list;
    public keyCode skip_button;
    private bool ready_for_next_step = false;

    private float timer_counter;
    private bool timer_active;
    private string[] steps;
    private int current_step_index;
    private string current_step;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        steps_list = "[first step ignored]\n" + steps_list;
        steps = steps_list.Split('\n');
        current_step_index = 0;
        current_step = steps[current_step_index];
    }

    // Update is called once per frame
    void Update()
    {
        //decrement timer if its active
        if(timer_active)
        {
            timer_counter -= Time.deltaTime;
        }
        //if timer done, readyup
        if(timer_counter <= 0)
        {
            timer_active = false;
            readyUp();
        }
        //start next step if readyup-ed
        if (ready_for_next_step)
        {
            //move to next step
            current_step_index += 1;
            current_step = steps[current_step_index];
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
            }
            ready_for_next_step = false;

        }
        //if left mouse button clicked
        if (Input.GetMouseButtonDown(0))
        {

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

    stretch: freeze character pos

click to advance?
     */
}
