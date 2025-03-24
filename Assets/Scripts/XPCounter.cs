using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class XPCounter : MonoBehaviour
{
    public int xp = 0;
    public TextMeshProUGUI xpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xpText.text = xp.ToString();
        
    }
}
