using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField]
    private int timer;    //生成する時間
    [SerializeField]
    private GameObject top; //生成場所参照
    [SerializeField]
    private GameObject center;//生成場所参照
    [SerializeField]
    private GameObject bottom;//生成場所参照

    private Vector3 pos;
    private bool isSummon;
    private int summon_count;
    private void Start()
    {
        isSummon = false;
        summon_count = 0;
    }
    void FixedUpdate()
    {
        if(!isSummon)
            StartCoroutine(Summon(timer));
    }

    public IEnumerator Summon(float cool_time)
    {
        isSummon = true;

        #region 時間が立てば立つほど早く生成するよ
        if (summon_count > 40)
        {
            yield return new WaitForSeconds(Random.Range(cool_time - 4, cool_time)); //クールタイム計測開始
        }
        else if (summon_count > 10)
        {
            yield return new WaitForSeconds(Random.Range(cool_time - 2, cool_time)); //クールタイム計測開始
        }
        else
        {
            yield return new WaitForSeconds(Random.Range(cool_time, cool_time)); //クールタイム計測開始
        }
        #endregion

        Unit_manager.Instantiate_unit(Unit_manager.unit_list[Random.Range(0, Unit_manager.unit_list.Count)], Summon_pos(), 2);  //生成するユニット、生成する場所、生成するプレイヤー

        summon_count++;
        isSummon = false;
    }

    public Vector3 Summon_pos()
    {
        float place = Random.Range(0,3);
        switch (place)
        {
            case 0:
                pos = top.gameObject.transform.position;
                break;
            case 1:
                pos = center.gameObject.transform.position;
                break;
            case 2:
                pos = bottom.gameObject.transform.position;
                break;
            default:
                Debug.Log("生成時にエラーが起こってるよ");
                break;
        }
        return pos;
    }
}
