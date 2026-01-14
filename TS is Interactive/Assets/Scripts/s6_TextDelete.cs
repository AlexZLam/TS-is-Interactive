using UnityEngine;

public class s6_TextDelete : MonoBehaviour
{
    private float timer = 0;
    //public GameObject me;

    // Update is called once per frame
    void Update()
    {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                Destroy(this);
            }
    }
}
