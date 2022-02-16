using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TresureChest : MonoBehaviour
{
    int[] _passArray = new int[] {0,0,0,0};
    int[] _correct = new int[] { 4, 0, 2, 2 };

    public Image[] _bottons;

    public Sprite[] _sprites;

    public Text _message;

    [SerializeField] GameObject _chestCap;
    Animator _anim;
    [SerializeField] BoxCollider _mainChest;

    [SerializeField] GameObject _itemKey;

    [SerializeField] AudioSource _audio;
    void Start()
    {
        _itemKey.SetActive(false);
        _anim = GameObject.Find(_chestCap.name).GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    //ボタンを押して1～9まで変更できる
    public void OnClickPassward(int position)
    {
        Debug.Log("password" + position);
        ChangeNumber(position);
        ShowNumber(position);
    }

    void ChangeNumber(int position)
    {
        int num = _passArray[position];
        num++;
        num %= 10;
        _passArray[position] = num;
    }

    void ShowNumber(int position)
    {
        int num = _passArray[position];
        _bottons[position].sprite = _sprites[num];
    }
    
    public void OnClickEnter()
    {
        //パスワードが合っていた時の処理
        if(_passArray.SequenceEqual(_correct))
        {
            _audio.Play();
            _itemKey.SetActive(true);
            _message.text = "鍵が開いた";
            _anim.SetBool("Open", true);

            _mainChest.enabled = false;
        }
        else //パスワードが違うときの処理
        {
            _message.text = "違う";
            Debug.Log("違う");
        }
    }
}
