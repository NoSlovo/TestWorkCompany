using System;
using UnityEngine;

public class User : MonoBehaviour
{
   private DataUser _dataUser;
   private SaveAndLoadData _saveAndLoadData;

   private void Start()
   {
      _saveAndLoadData = new SaveAndLoadData();
      _dataUser = _saveAndLoadData.LoadUser();
   }

   public void SetUserName(string UserName)
   {
      if (UserName.Length > 1)
      {
         _dataUser.Name = UserName;
         _saveAndLoadData.SaveUser(_dataUser);
      }
   }
}