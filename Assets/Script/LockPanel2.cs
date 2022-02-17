using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LockPanel2 : MonoBehaviour
{
    int[] _passArray = new int[] { 0, 0 };
    int[] _correct = new int[] { 1, 7 };

    [Header("ボタン")]
    [SerializeField] Image[] _bottons;

    [Header("Sprite & Text")]
    [SerializeField] Sprite[] _sprites;
    [SerializeField] Text _message;

    [Header("とびら")]
    [SerializeField] Animator LockDoor;
    Animator _anim;

    [SerializeField] AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
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
    public bool _open = false;
    public void OnClickEnter()
    {
        //パスワードが合っていた時の処理
        if (_passArray.SequenceEqual(_correct))
        {
            _open = true;
            _message.text = "鍵が開いた";
            LockDoor.SetBool("OpenDoor", true);
            Debug.Log("開錠した");
        }
        else //パスワードが違うときの処理
        {
            _message.text = "数が違うようだ";
            Debug.Log("違う");
        }
    }
}
