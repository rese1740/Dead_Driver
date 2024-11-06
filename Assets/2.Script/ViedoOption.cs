using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViedoOption : MonoBehaviour
{

    public Dropdown resolutiondropdown;
    List<Resolution>resolutions = new List<Resolution>(); 
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       resolutions.AddRange( Screen.resolutions);
        foreach (Resolution item in resolutions )
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + "x" + item.height + "y" + item.refreshRateRatio  + "hz";
            resolutiondropdown.options.Add(option);
        }
        resolutiondropdown.RefreshShownValue();

        
    }
}
