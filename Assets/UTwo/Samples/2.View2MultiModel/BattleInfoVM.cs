using System.Diagnostics;
using Wx.UTwo.Core;

namespace UTwo.Samples.View2MultiModel
{
    public class BattleInfoVM:ViewModel
    {
        public ReactivePropery<string> rp_enemyInfo=new ReactivePropery<string>();
        public ReactivePropery<string> rp_roleInfo=new ReactivePropery<string>();

        public BattleInfoVM(EnemyModel enemyModel,RoleModel roleModel)
        {
            BindToModels(enemyModel, roleModel);
            LogHelper.LogInfo(base.ToString());
            RegisterAllFields();
        }

        public bool BindToModels(EnemyModel enemyModel,RoleModel roleModel)
        {
            return base.BindToModels(enemyModel,roleModel);
        }

        public void RegisterAllFields()
        {
            RegisterField<string>("UTwo.Samples.View2MultiModel.EnemyModel","rp_enemyInfo",(oldVal,newVal)=>
            {
                rp_enemyInfo.Value = newVal;
            }); 
            RegisterField<string>("UTwo.Samples.View2MultiModel.RoleModel","rp_roleInfo",(oldVal,newVal)=>
            {
                rp_roleInfo.Value = newVal;
            });
        }
    }
}