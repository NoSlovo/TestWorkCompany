using System;
using UnityEngine;

public class User : MonoBehaviour
{
   private DataUser _data;
   private SaveAndLoadData _saveAndLoadData;

   public String Name => _data.Name;
   public int Coin => _data.Coin;

   private void Awake()
   {
      _saveAndLoadData = new SaveAndLoadData();
      _data = _saveAndLoadData.LoadUser();
   }

   public void SetName(string UserName)
   {
      if (UserName.Length > 1)
      {
         _data.Name = UserName;
         _data.Coin = 0;
         _saveAndLoadData.SaveUser(_data);
      }
   }

   public void AddCoin(int countCoin)
   {
      if (countCoin < 0 )
         return;

      _data.Coin += countCoin;
   }
   
}