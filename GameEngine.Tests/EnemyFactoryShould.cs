using GameEngine.Models;
using Xunit;
using System;

namespace GameEngine.Tests
{
   public class EnemyFactoryShould
    {
        [Fact]
        public void CreateNormalEnemyByDefault()
        {

            var sut = new EnemyFactory();
            Enemy enemy = sut.Create("Zombie");
            Assert.IsType<NormalEnemy>(enemy);
            

        }

        [Fact]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {

            var sut = new EnemyFactory();
            Enemy enemy = sut.Create("Zombie");
            Assert.IsNotType<DateTime>(enemy);

        }

        [Fact]
        public void CreateBossEnemy()
        {
            var sut = new EnemyFactory();

            
            var enemy = sut.Create("Zombie King", true);
            Assert.IsType<BossEnemy>(enemy);

        }


        [Fact]
        public void CreateBossEnemy_CastReturnTypeExample()
        {
            var sut = new EnemyFactory();


            var enemy = sut.Create("Zombie King", true);
            // Assert with return type
            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            // aditional assert on Type object
            Assert.Equal("Zombie King", boss.Name);

        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableExample()
        {
            var sut = new EnemyFactory();


            var enemy = sut.Create("Zombie King", true);
            // Assert with return type
            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            // aditional assert on Type object
            Assert.Equal("Zombie King", boss.Name);

        }


        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            var sut = new EnemyFactory();


            var enemy = sut.Create("Zombie King", true);
            // look at the parent
            Assert.IsAssignableFrom<Enemy>(enemy);

        }

        [Fact]
        public void CreateSeparateInstances()
        {
            var sut = new EnemyFactory();


            var enemy1 = sut.Create("Zombie King");
            var enemy2 = sut.Create("Zombie King");
            // look at the parent
            Assert.NotSame(enemy1, enemy2);

        }

        [Fact]
        public void NotAlowNullName()
        {
            var sut = new EnemyFactory();



            Assert.Throws<ArgumentNullException>(() => sut.Create(null));

            //
            Assert.Throws<ArgumentNullException>("name",() => sut.Create(null));

            //  Assert.Throws<ArgumentNullException>("isBoss", () => sut.Create(null));
            }

        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            EnemyFactory sut = new EnemyFactory();

            EnemyCreationException ex =
                Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));

            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }




    }
}
