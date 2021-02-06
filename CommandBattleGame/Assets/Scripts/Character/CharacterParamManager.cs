using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParamManager : MonoBehaviour
{
    public CharacterParam CharacterParam = new CharacterParam();
    public int CharacterAttack;
    public bool IsEnemy;

    CharacterHpViewer m_CharacterHpViewer = null;

    public float xy;
    public int ButtonNo;
    public CharacterParam GetCharacterParam
    {
        get { return CharacterParam; }
    }


    public int CharacterHP = 0;
    public int CharacterMp = 0;
    public float CharacterSpeed = 0;
    public CharacterParam.GameCharacterType CharacterType = CharacterParam.GameCharacterType.Invalide;

    public CharacterAnimationController CharacterAnimationController = null;
    // Start is called before the first frame update
    private void Init()
    {
        CharacterParam.HitPoint = CharacterHP;

        CharacterParam.MagicPoint = CharacterMp;

        CharacterParam.Speed = CharacterSpeed;

        CharacterParam.CharacterType = CharacterType;

        CharacterParam.Attack = CharacterAttack;

        CharacterParam.IsEnemy = IsEnemy;

        if (IsEnemy == true)
        {
            xy = 10f;
        }
    }
    private void Update()
    {
        xy = Time.deltatime;
        if (xy == 0)
        {
            StartCoroutine(CharacterAnimationController.StartAttackAnimation(2));

            xy = 10f;
        }
    }
    private void Start()
    {
        bool a = IsEnemy;
        if (a == false)
        {
            CharacterParam.FirstButtonAction = FirstButtonAction;
            CharacterParam.SecondButtonAction = SecondButtonAction;
            CharacterParam.ThirdButtonAction = ThirdButtonAction;
            CharacterParam.FourthButtonAction = FourthButtonAction;

            //キャラクターの一番目のボタンの行動でパラメーターがきまる・・？？

            CharacterAnimationController = GetComponent<CharacterAnimationController>();
        }
    }

    // Update is called once per frame
    private void Awake()
    {
        Init();
    }



    //一番目のボタンを押して行動出来たらaaと表示（確認の時に使う）
    private void FirstButtonAction()
    {

        StartCoroutine(CharacterAnimationController.StartAttackAnimation(2));

        ButtonNo = 0;

    }
    private void SecondButtonAction()
    {
        ButtonNo = 1;

        Debug.Log("bb");


        if (CharacterType == CharacterParam.GameCharacterType.SpellCaster)
        {



            StartCoroutine(CharacterAnimationController.StartAttackAnimation(2));

        }
    }
    private void ThirdButtonAction()
    {
        Debug.Log("cc");

        StartCoroutine(CharacterAnimationController.StartAttackAnimation(2));

        ButtonNo = 3;
    }

    private void FourthButtonAction()
    {
        Debug.Log("dd");
    }


    public void Damage(int damage)
    {
        var characterPos = m_CharacterHpViewer;

        CharacterParam.HitPoint -= damage;

        CharacterHP = CharacterParam.HitPoint;

        if ((damage <= 0) && (m_CharacterHpViewer.CharacterMaxHps[characterPos] <= CharacterHP))
        {
            CharacterHP = CharacterMaxHps[characterPos];

            CharacterParam.HitPoint = CharacterHP;

        }
            m_CharacterHpViewer.SetHp(characterPos.CharacterHp);


        }

    
}

    

