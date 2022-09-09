using Wx.UTwo.Core;

namespace UTwo.Samples.View2MultiModel
{
    public class BattleInfoVM:ViewModel
    {
        public ReactivePropery<string> bp_enemyInfo=new ReactivePropery<string>();
        public ReactivePropery<string> bp_roleInfo=new ReactivePropery<string>();

        public BattleInfoVM(EnemyModel enemyModel,RoleModel roleModel)
        {
            BindToModels(enemyModel, roleModel);
            RegisterAllFields();
        }

        public bool BindToModels(EnemyModel enemyModel,RoleModel roleModel)
        {
            return base.BindToModels(enemyModel,roleModel);
        }

        public void RegisterAllFields()
        {
            RegisterField<string>("EnemyModel","bp_enemyInfo",(oldVal,newVal)=>
            {
                bp_enemyInfo.Value = newVal;
            }); 
            RegisterField<string>("RoleModel","bp_roleInfo",(oldVal,newVal)=>
            {
                bp_roleInfo.Value = newVal;
            });
        }
    }
}