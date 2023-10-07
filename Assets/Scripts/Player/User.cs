using System;
using UnityEngine;

public class User : MonoBehaviour
{
   private DataUser _dataUser;
   private SaveAndLoadData _saveAndLoadData;

   private int _coin = 0;
   
   public String Name => _dataUser.Name;
   public int Coin => _coin;

   private void Awake() => _saveAndLoadData = new SaveAndLoadData();  
   
   private void Start()=> _dataUser = _saveAndLoadData.LoadUser();
   
   public void SetName(string UserName)
   {
      if (UserName.Length > 1)
      {
         _dataUser.SetNameUser(UserName);
         _saveAndLoadData.SaveUser(_dataUser);
      }
   }
}