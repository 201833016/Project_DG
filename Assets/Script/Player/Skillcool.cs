using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Skillcool : MonoBehaviour
{    
    public Image abilityImage1; // 스킬 이미지
    public float cooldown1 = 5f;    // 스킬 쿨타임 시간
    bool isCooldown = false;    // 스킬 사용 여부

    void Start() 
    {
        abilityImage1.fillAmount = 1;   // 스킬 시간 범위. 0 ~ 1
    }

    void Update() 
    {
        Ability1(); // 스킬1 실행
    }

    void Ability1()
    {
        if(Input.GetKey(KeyCode.L) && isCooldown == false ) // L키 + 스킬 쿨타임 여유
        {
            // 스킬 발동
            isCooldown = true;
            abilityImage1.fillAmount = 1;
        }

        if(isCooldown)
        {
            // 쿨타임 돌 떼
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime; // 시간에 따라 감소 이미지 표현

            if(abilityImage1.fillAmount <= 0)   // 스킬 쿨타임 다 돌면
            {
                abilityImage1.fillAmount = 1; 
                isCooldown = false;
            }
        }
    }
}
