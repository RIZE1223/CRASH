using UnityEngine;

[CreateAssetMenu(fileName = "New_Unit_Data", menuName = "Create_Unit_Data")]
public class Unit_data : ScriptableObject
{
    public enum Unit_class    //ユニットのクラス
    {
        castle,
        short_range_unit,
        long_range_unit,
        machine_unit
    }
    [SerializeField, Header("ユニット名")]
    private string unit_name;

    [SerializeField, Header("ユニットクラス")]
    private Unit_class unit_type;

    [SerializeField, Header("ユニットプレハブ")]
    private GameObject unit_object;

    public string Unit_name { get { return unit_name; } private set { unit_name = value; } }
    public Unit_class unit_class { get { return unit_class; } private set { unit_class = value; } }
    public GameObject Unit_object { get { return unit_object; } private set { unit_object = value; } }
}
