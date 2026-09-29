using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIFloat : MonoBehaviour
{
    public PlayerController player;
    private Image img;


    void Start()
    {
        img = GetComponent<Image>();
    }
    void Update()
    {
        img.fillAmount = player.GetPowerProportion();
    }
}
