using ninja.systemhp;
using System;

namespace ninja
{
    public interface IDamagable
    {
        public ISystemHp GetISystemHp  { get; }
    }
}