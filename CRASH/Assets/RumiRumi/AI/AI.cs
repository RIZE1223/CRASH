using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField]
    private int timer;    //�������鎞��
    [SerializeField]
    private GameObject top; //�����ꏊ�Q��
    [SerializeField]
    private GameObject center;//�����ꏊ�Q��
    [SerializeField]
    private GameObject bottom;//�����ꏊ�Q��

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

        #region ���Ԃ����ĂΗ��قǑ������������
        if (summon_count > 40)
        {
            yield return new WaitForSeconds(Random.Range(cool_time - 4, cool_time)); //�N�[���^�C���v���J�n
        }
        else if (summon_count > 10)
        {
            yield return new WaitForSeconds(Random.Range(cool_time - 2, cool_time)); //�N�[���^�C���v���J�n
        }
        else
        {
            yield return new WaitForSeconds(Random.Range(cool_time, cool_time)); //�N�[���^�C���v���J�n
        }
        #endregion

        Unit_manager.Instantiate_unit(Unit_manager.unit_list[Random.Range(0, Unit_manager.unit_list.Count)], Summon_pos(), 2);  //�������郆�j�b�g�A��������ꏊ�A��������v���C���[

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
                Debug.Log("�������ɃG���[���N�����Ă��");
                break;
        }
        return pos;
    }
}
