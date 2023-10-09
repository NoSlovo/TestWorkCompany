using System;
using UnityEngine;

public class User : MonoBehaviour
{
   private DataUser _data;
   private SaveAndLoad _saveAndLoad;

   public String Name => _data.Name;
   public int Coin => _data.Coin;

   private void Awake()
   {
      _saveAndLoad = new SaveAndLoad();
      _data = _saveAndLoad.LoadData();
   }

   public void SetName(string UserName)
   {
      if (UserName.Length > 1)
      {
         _data.Name = UserName;
         _data.Coin = 0;
         _saveAndLoad.SaveData(_data);
      }
   }

   public void AddCoin(int countCoin)
   {
      if (countCoin < 0 )
         return;

      _data.Coin += countCoin;
   }
   
}