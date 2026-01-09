using UnityEngine;

public class s2_clickable_object : MonoBehaviour
{
    public string flavortext = "";
    public string phase = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*plan:
    - if the obj im looking at is this one, then put up its flavortext.
    phases:
    readyup from table interact: 
        (on desk: book, paintbrush, knitting, plant) all give responses 
        readyUp after 3 clicked
    readyup from door
        readyup when clicked
    readyup from package
        readyup when clicked
                                readyup from couch: 
                                    readyup on collision
    readyup from glasses
        click to equip
        readyup once equipped
    readyup from apps
        response for each app
        readyup when insta clicked
    readyup from reels
        spam click for reels (shake hand wildly)
        readyup once done
    /*
     * sitting on couch, looking at roblox tv
wait 5 seconds
man, watching tv is so boring. wish i had something else to do.

wait 2 seconds
doorbell
wait 0.3 seconds
i should check that.

looks like i got a package. could it be....

my new meta rayban glasses with private in-lens display and wrist control??!?!?
this is sure to keep me entertained.
tv time!

cant wait to try these on!

so many apps...

reels!!!
wait 1 second

now this is the life. 
wait 1 second    
    */
}
