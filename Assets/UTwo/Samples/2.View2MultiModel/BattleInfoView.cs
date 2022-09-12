using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Wx.UTwo.Core;
using Wx.UTwo.UCore;

namespace UTwo.Samples.View2MultiModel
{
    public class BattleInfoView : UView<BattleInfoVM>
    {
        public TMP_Text RoleName;
        public TMP_Text EnemyName;

        public TMP_InputField IF_SetRoleName;
        public TMP_InputField IF_SetEnemyName;

        public Button btn_ApplyRoleName;
        public Button btn_ApplyEnemyName;

        public BattleInfoController BattleInfoController;
        private BattleInfoVM m_battleInfoVm;

        private void Start()
        {
            btn_ApplyRoleName.onClick.AddListener(()=>
            {
                BattleInfoController.SetRoleName(IF_SetRoleName.text);
                
            });
            btn_ApplyEnemyName.onClick.AddListener(()=>
            {
                BattleInfoController.SetEnemyName(IF_SetEnemyName.text);
            });
            OnInit();
            m_battleInfoVm = new BattleInfoVM(BattleInfoController.models.EnemyInfo,BattleInfoController.models.RoleInfo);
            BindingModel = m_battleInfoVm;
            LogHelper.LogInfo("Bind to the BattleInfoVM");
        }

        public override void OnInit()
        {
            LogHelper.LogInfo($"init {GetType()}");

            m_allPropertyBinder.RegisterField<string>("rp_roleInfo",
                (oldValue, newValue) =>
                {
                    RoleName.text = newValue;
                    LogHelper.LogInfo("RoleName 发生改变");
                });
            m_allPropertyBinder.RegisterField<string>("rp_enemyInfo",
                (oldValue, newValue) =>
                {
                    EnemyName.text = newValue;
                    LogHelper.LogInfo("EnemyName发生改变");
                });
        }

        public override void OnOpen()
        {
        }

        public override void OnClose()
        {
        }

        public override void OnDestroySelf()
        {
        }
        
    }
}