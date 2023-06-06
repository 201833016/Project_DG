using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public Sprite loopSprite;   // 드랍 아이템 이미지
    public string lootName;     // 드랍 아이템 이름
    public int dropChance;  // 드랍 확률 1% ~ 100%

    public Loot(string lootName, int dropChance)    // 이름, 드랍률 초기화
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
    }
}
