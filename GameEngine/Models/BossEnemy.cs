using System;
using System.Collections.Generic;

namespace GameEngine.Models
{
    public class BossEnemy : Enemy
    {
        // this overrides the getter in the base class SO Three Ways to do this 

        //   public override double TotalSpecialPower{ get; } =1000;

        //public override double TotalSpecialPower
        //{
        //    get
        //    {
        //        return 1000;
        //    }
        //}

            // C7 way expression body
        public override double TotalSpecialPower=>1000;
        public override double SpecialPowerUses => 6;





        


    }
}
