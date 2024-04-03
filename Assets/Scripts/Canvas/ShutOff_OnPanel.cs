using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShutOff_OnPanel : MonoBehaviour
{
    public GameObject ActivePanel;
    public GameObject PanelToActivate;
  public void ActivatePanel()
    {
        ActivePanel.SetActive(false);
        PanelToActivate.SetActive(true);
    }

}
