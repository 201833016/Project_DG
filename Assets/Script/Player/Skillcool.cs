using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Skillcool : MonoBehaviour
{    
    public Image abilityImage1; // 스킬 이미지
    public float cooldown1 = 5f;
    bool isCooldown = false;

    void Start() 
    {
        abilityImage1.fillAmount = 1;
    }

    void Update() 
    {
        Ability1();
    }

    void Ability1()
    {
        if(Input.GetKey(KeyCode.L) && isCooldown == false )
        {
            // 스킬 발동
            isCooldown = true;
            abilityImage1.fillAmount = 1;
        }

        if(isCooldown)
        {
            // 쿨타임 돌 떼
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if(abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 1;
                isCooldown = false;
            }
        }
    }
}
