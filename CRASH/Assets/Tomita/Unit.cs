using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    
    public EnemyType type;
    public int attack;
    public int EnemyHP;//�G�l�~�[�̗̑�
    public int defaultEnemyHP;
    public Slider Slider;

    private void Start()
    {
        Slider.value = 1;
        EnemyHP = defaultEnemyHP;
    }
}
public enum EnemyType
{
    Skeleton,

}
