using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Unit_move    //ƒ†ƒjƒbƒg‚Ìs“®
{
    Moving_method,   //ˆÚ“®
    Battle, //UŒ‚  
}

public class Unit : MonoBehaviour
{
    [HideInInspector]
    public Unit_move unit_move;  //ƒ†ƒjƒbƒg‚ª¡‰½‚Ìs“®‚ğ‚µ‚Ä‚¢‚é‚©

    protected Unit_model unit_model;  //model‚É‚©‚¢‚Ä‚ ‚é‚à‚Ì‚ğg‚¦‚é‚æ‚¤‚É‚·‚é‚æ
    protected Unit_manager unit_manager;  // //manager‚É‚ ‚éƒ_ƒ[ƒWŒvZ‚ğg‚¦‚é‚æ‚¤‚É‚·‚é‚æ

    [Header("UŒ‚‘ÎÛ")]
    public GameObject target = null;  //UŒ‚‚·‚éƒ^[ƒQƒbƒg‚ğŠi”[
    [Header("•Ší‚ª‚ ‚éê‡‚Í‚±‚¿‚ç‚ÉŠi”[")]
    public Weapon attackZone = null;
    [HideInInspector]
    public bool isCool_down;    //ƒN[ƒ‹ƒ_ƒEƒ“‚µ‚Ä‚é‚©‚İ‚éYO!
    private bool isAttack_reserve;  //UŒ‚—\–ñ‚ğs‚Á‚Ä‚¢‚é‚©‚ğ‚İ‚éYO!

    //------------------------------------------------------------------------------

    private void Awake()
    {
        unit_model = gameObject.GetComponent<Unit_model>();//©g‚ÉƒAƒ^ƒbƒ`‚³‚ê‚Ä‚¢‚éUnit_model‚ğ’T‚·YO!
        unit_manager = GameObject.FindObjectOfType<Unit_manager>(); //hierarchy‚É‚ ‚éUnit_manager‚ğ’T‚·YOI
    }

    private void Start()
    {
        isCool_down = false; //ƒN[ƒ‹ƒ_ƒEƒ“’†‚ÍAttack_speed‚Ì”’l•ª‘Ò‹@‚µ‚Ä‚¢‚Ü‚·B
        isAttack_reserve = false;
<<<<<<< HEAD
        if (gameObject.tag == "Dragon1" || gameObject.tag == "Dragon2" || gameObject.tag == "Castle1" || gameObject.tag == "Castle2")
        {
            _dragon = GameObject.Find("ChangeDragon");
            changeDragon = _dragon.GetComponent<ChangeDragon>();
            _winorlose = GameObject.Find("WinLose");
            winOrLose = _winorlose.GetComponent<WinOrLose>();
        }
=======
>>>>>>> parent of fc52020 (kobatashi_var03ã‚³ãƒŸãƒƒãƒˆ)
    }


//------------------------------------------------------------------------------

    private void FixedUpdate()
<<<<<<< HEAD
    {

        //ô”]‚³‚ê‚½‚çUŒ‚‘ÎÛ‚ğ‚È‚­‚·
        if (target != null)
        {
            if (gameObject.tag == "Unit1" && (target.gameObject.tag == "Unit1" || target.gameObject.tag == "Castle1"))
                target = null;
            else if (gameObject.tag == "Unit2" && (target.gameObject.tag == "Unit2" || target.gameObject.tag == "Castle2"))
                target = null;
        }

=======
    {   
>>>>>>> parent of fc52020 (kobatashi_var03ã‚³ãƒŸãƒƒãƒˆ)
        //•Ší‚ÌUŒ‚”ÍˆÍ‚É“ü‚Á‚½‚çƒ^[ƒQƒbƒg‚ÉŒÅ’è
        if(target == null && attackZone != null)
        {
            if(attackZone.weaponTarget != null)
            target = attackZone.weaponTarget;
        }
        //‘Ì—Í‚ª‚OˆÈ‰º‚È‚çƒIƒuƒWƒFƒNƒg‚ğíœ
        if (unit_model.hp <= 0)
        {
            //RiP
            Destroy(this.gameObject);

            if(gameObject.CompareTag("Castle1"))
            {
<<<<<<< HEAD
                winOrLose.Win_Or_Lose(false);
=======
                SceneManager.LoadScene("LoseScene");
>>>>>>> parent of fc52020 (kobatashi_var03ã‚³ãƒŸãƒƒãƒˆ)
            }
            else if (gameObject.CompareTag("Castle2"))
            {
                SceneManager.LoadScene("WinScene");
            }
        }

        else if (unit_model.hp > 0)
        {
            switch (unit_move)
            {
                case Unit_move.Moving_method:
                    Moving_method();
                    break;
                case Unit_move.Battle:
                    if (!isAttack_reserve)//˜A‘±‚Å—\–ñ‚ª‚³‚ê‚È‚¢‚æ‚¤‚É‚µ‚Ä‚¢‚é
                    {
                        unit_manager.AddAttack(GetComponent<Unit>());
                        isAttack_reserve = true;    //UŒ‚—\–ñ‚µ‚Ü‚µ‚½‚æ‚ñ
                    }
                    break;
                default:
                    Debug.Log("‚¿‚á‚ñ‚Æ“®ì‚µ‚Ä‚È‚¢‚æ‚ñ(ƒLƒƒƒ‰‚Ìs“®)");
                    break;
            }
        }
    }

    /// <summary>
    /// UŒ‚
    /// </summary>
    /// <param name="cool_time">Attack_speed(UŒ‚Œã‚©‚çŸ‚ÌUŒ‚‚ªŒÄ‚Î‚ê‚é‚Ü‚ÅB)</param>
    /// <returns></returns>
    public IEnumerator Battle(float cool_time)
    {
        if (isCool_down != true) //ƒN[ƒ‹ƒ^ƒCƒ€‚ªI—¹‚µ‚Ä‚¢‚é‚±‚Æ‚ğŠm”F
        {
            if (target != null) //UŒ‚‘ÎÛ‚ªŒˆ‚Ü‚Á‚Ä‚¢‚é‚©‚ğŠm”F
            {
                Attack();
            }
            isCool_down = true;  //UŒ‚Œã‚ÌƒN[ƒ‹ƒ^ƒCƒ€‚ğŠJn‚ğw¦
        }

        if (target == null)  //UŒ‚‘ÎÛ‚ğ“|‚µ‚½‚©Šm”F
        {
            unit_move = Unit_move.Moving_method;   //ˆÚ“®ŠJn
        }

        yield return new WaitForSeconds(cool_time); //ƒN[ƒ‹ƒ^ƒCƒ€Œv‘ªŠJn

        //ƒŠƒZƒbƒg
        isCool_down = false; //UŒ‚Œã‚Ì‘Ò‹@ŠJn
        isAttack_reserve = false;   //UŒ‚‚ªŠ®—¹‚µ—\–ñ‚ğ‰ğœ‚µ‚½‚æI
    }

    /// <summary>
    /// ˆÚ“®
    /// </summary>
    protected virtual void Moving_method()
    {
        Move();
        if (target != null)
        {
            unit_move = Unit_move.Battle;   //UŒ‚ŠJn
        }
    }

    protected virtual void Move()
    {
        //Šeƒ†ƒjƒbƒg‚²‚Æ‚É‘‚«Š·‚¦‚Ä‚Ë
    }
    protected virtual void Attack()
    {
        //Šeƒ†ƒjƒbƒg‚²‚Æ‚É‘‚«Š·‚¦‚Ä‚Ë
    }


//------------------------------------------------------------------------------

    protected virtual void OnCollisionEnter2D(Collision2D co)
    {
        if (gameObject.CompareTag("Unit1") && target == null)
        {
            if (co.collider.tag == ("Unit2") || co.collider.tag == ("Castle2"))
                target = co.gameObject;//UŒ‚‘ÎÛ‚ğ‘I‘ğ
        }
        else if (gameObject.CompareTag("Unit2") && target == null)
        {
            if (co.collider.tag == ("Unit1") || co.collider.tag == ("Castle1"))
                target = co.gameObject;     //UŒ‚‘ÎÛ‚ğ‘I‘ğ
        }
    }

    protected virtual void OnCollisionStay2D(Collision2D co)
    {
        //if(co.gameObject == target.gameObject)
        //{
        //    target = null;  //UŒ‚”ÍˆÍŠO‚Éo‚½ê‡‚Ítarget‚©‚çŠO‚·‚æ
        //}
        //else
        //{
        //    return;
        //}
        if (target == null)
        {
            if (gameObject.CompareTag("Unit1"))
            {
                if (co.collider.tag == ("Unit2") || co.collider.tag == ("Castle2"))
                    target = co.gameObject;//UŒ‚‘ÎÛ‚ğ‘I‘ğ
            }
            else if (gameObject.CompareTag("Unit2"))
            {
                if (co.collider.tag == ("Unit1") || co.collider.tag == ("Castle1"))
                    target = co.gameObject;     //UŒ‚‘ÎÛ‚ğ‘I‘ğ
            }
        }
    }
}
