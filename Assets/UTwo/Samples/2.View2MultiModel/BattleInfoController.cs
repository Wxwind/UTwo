using UnityEngine;

namespace UTwo.Samples.View2MultiModel
{
    public class BattleInfoController:MonoBehaviour
    {
        public ModelFactory models;
        
        public void SetRoleName(string roleName)
        {
            models.RoleInfo.rp_roleInfo.Value = roleName;
        }
        
        public void SetEnemyName(string enemyName)
        {
            models.EnemyInfo.rp_enemyInfo.Value = enemyName;
        }
        
    }
}