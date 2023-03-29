
using System;

namespace ninja.systemhp
{
    public interface ISystemHp
    {
        public event Action<int, int> HpChanged;
        public event Action<bool> IsDead;
        public void GetDamage(int damage);


    }
}
