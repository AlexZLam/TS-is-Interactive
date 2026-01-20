/*******************************************************************
 * File name: s4_objectInfo
 * Author: Nathen Mattis
 * Email: 1119065@lwsd.org
 * Course: Video Game Programming I
 * Last edited: 1/16/2026
 *
 * Description: Stores extra information for interactable objects
 ********************************************************************/
using UnityEngine;

public class s4_objectInfo : MonoBehaviour
{
    [Header("Required")]
    public string prompt_1;
    public string prompt_2;
    public string prompt_3;

    public string aiResponse_1;
    public string aiResponse_2;
    public string aiResponse_3;

    public string playerCaption_1;
    public string playerCaption_2;
    public string playerCaption_3;

    public string objectName;

    [Header("Optional")]
    public string objectCaption_1;
    public string objectCaption_2;
    public string objectCaption_3;
    public bool hasCaptions;
}
