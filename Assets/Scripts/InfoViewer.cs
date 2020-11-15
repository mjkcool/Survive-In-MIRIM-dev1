using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoViewer : MonoBehaviour
{
    public GameObject logo;
    public GameObject infoBox;

    public void showInfo()
    {
        infoBox.SetActive(true);
        logo.SetActive(false);
    }

    public void hideInfo()
    {
        infoBox.SetActive(false);
        logo.SetActive(true);
    }
}
