using UnityEngine;

public class s2_GameManager : MonoBehaviour
{

    public TextMesh text_display;
    private bool ready_for_next_step = false;

    private float timer_counter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if left mouse button clicked
        if(Input.GetMouseButtonDown(0))
        {

        }
    }

    private void displayText(string text)
    {
        text_display.text = text;
    }

    private void startTimer(float seconds)
    {

    }

    public void readyUp()
    {
        ready_for_next_step = true;
    }

    /*
     * sitting on couch, looking at roblox tv
wait 5 seconds
man, watching tv is so boring. wish i had something else to do.
desk interact: 
    (on desk: book, paintbrush, knitting, plant) all give responses 
    readyUp after 3 clicked
wait 2 seconds
doorbell
wait .3 seconds
i should check that.
door
    readyup when clicked
looks like i got a package. could it be....
package
    readyup when clicked
my new meta rayban glasses with private in-lens display and wrist control??!?!?
this is sure to keep me entertained.
tv time!
couch: 
    readyup on collision
cant wait to try these on!
glasses
    click to equip
    readyup once equipped
so many apps...
apps
    response for each app
    readyup when insta clicked
reels!!!
wait 1 second
spam click for reels (shake hand wildly)
    readyup once done
now this is the life. 
wait 1 second    
the meta rayban glasses with private in lens display and wrist control are perfect for keeping all critical thought from my brain!



click to advance?
     */
}
