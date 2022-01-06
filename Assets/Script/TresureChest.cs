using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TresureChest : MonoBehaviour
{
    int[] _passArray;
    int[] _correct = new int[] { 1, 2, 2, 6 };

    public Image[] _bottons;

    public Sprite[] _sprites;

    public Text _message;
    
    //ボタンを押して1～9まで変更できる
    public void OnClickPassward(int position)
    {
        ChangeNumber(position);
        ShowNumber(position);
    }

    void ChangeNumber(int position)
    {
        int num = _passArray[position];
        num++;
        if (num > 9) num = 0;
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

        }
        else //パスワードが違うときの処理
        {

        }
    }
}
