using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;

public class cursor_test : MonoBehaviour
{
    [SerializeField, Header("カーソルの移動速度")]
    private int Speed;
    [Header("プレイヤー１ならFalse,プレイヤー２ならTrue")]
    public bool isPlayer;       //プレイヤーの識別
    [SerializeField, Header("ページ変更ボタン")]
    private GameObject pageChange;
    private Vector3 move;   //カーソル移動の際の座標
    private Vector2 playerPos; //現在の座標
    private bool isUnderObjectMove; //カードを動かしているか
    private bool isPageChange = false;
    public GameObject underObject;  //下にあるオブジェクトが何か
    [SerializeField, Header("ルートオブジェクト")]
    private GameObject RootObject;

    public const int Player1Num = 0;
    public const int Player2Num = 1;
    private int _padNum = 0;
    private Gamepad gamePad;

    private void Awake()
    {
        if (!isPlayer)
            Setup(Player1Num);
        else if(isPlayer)
            Setup(Player2Num);
    }

    /// <summary>
    /// スティック操作
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// ボタンを押した際の処理
    /// </summary>
    /// <param name="context"></param>
    public void OnPageChange(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Fire");
        }
    }
    public void Setup(int padNum)
    {
        _padNum = padNum;
        gamePad = Gamepad.all[padNum];
        this.gameObject.transform.parent = RootObject.gameObject.transform;
    }

    void Update()
    {
        transform.Translate(move * Speed * Time.deltaTime); //スティック操作による移動
        Clamp();    //移動に対する制限

        #region カードの移動→使用するまでの処理
        if (!isUnderObjectMove &&  gamePad.buttonSouth.isPressed && underObject != null)  //カードをつかんでいた場合下記の行動を実行
        {
            isUnderObjectMove = true;
            underObject.GetComponent<Drag>().OnBeginDrag();
        }
        else if (isUnderObjectMove &&  gamePad.buttonSouth.isPressed && underObject != null)
        {
            underObject.GetComponent<Drag>().OnDrag();
        }
        else if (isUnderObjectMove && ! gamePad.buttonSouth.isPressed && underObject != null)
        {
            isUnderObjectMove = false;
            underObject.GetComponent<Drag>().OnEndDrag();
        }
        #endregion
        if ((gamePad.leftShoulder.isPressed || gamePad.rightShoulder.isPressed) && isPageChange == false)
        {
            pageChange.GetComponent<PageChange>().OnPageChange();
            isPageChange = true;
        }
        else if (!(gamePad.leftShoulder.isPressed || gamePad.rightShoulder.isPressed) && isPageChange == true)
        {
            isPageChange = false;
        }
    }

    /// <summary>
    /// カーソルの移動制限
    /// </summary>
    private void Clamp()
    {
        playerPos = transform.position; //プレイヤーの位置を取得

        playerPos.x = Mathf.Clamp(playerPos.x, -1600f, 1800f); //x位置が常に範囲内か監視
        playerPos.y = Mathf.Clamp(playerPos.y, -900f, 930f); //x位置が常に範囲内か監視
        transform.position = new Vector2(playerPos.x, playerPos.y); //範囲内であれば常にその位置がそのまま入る
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isUnderObjectMove)
        {
            if (!isPlayer)
            {
                if (!gamePad.buttonEast.isPressed && underObject == null && collision.CompareTag("UnitCard1") || collision.CompareTag("StrategyCard1"))
                {
                    underObject = collision.gameObject;
                }
            }
            else
            {
                if (!gamePad.buttonEast.isPressed && underObject == null && collision.CompareTag("UnitCard2") || collision.CompareTag("StrategyCard2"))
                {
                    underObject = collision.gameObject;
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isUnderObjectMove)
        {
            if (!isPlayer)
            {
                if (!gamePad.buttonEast.isPressed && underObject == null && collision.CompareTag("UnitCard1") || collision.CompareTag("StrategyCard1"))
                {
                    if (underObject == collision.gameObject)
                        return;
                    underObject = collision.gameObject;
                }
            }
            else
            {
                if (!gamePad.buttonEast.isPressed && underObject == null && collision.CompareTag("UnitCard2") || collision.CompareTag("StrategyCard2"))
                {
                    if (underObject == collision.gameObject)
                        return;
                    underObject = collision.gameObject;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isUnderObjectMove)
        {
            if (!gamePad.buttonSouth.isPressed && underObject != null && underObject != collision)
            {
                underObject = null;
            }
        }
    }
}