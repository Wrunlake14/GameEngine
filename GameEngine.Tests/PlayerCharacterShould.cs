using GameEngine.Models;
using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould : IDisposable
    {

       private readonly ITestOutputHelper _output;
        private readonly PlayerCharacter sut;


        // The Constuctor is called on each method run and the Dispose is then called after each method to cleanup the code.
       



        public PlayerCharacterShould(ITestOutputHelper output)
        {
           _output = output;
            sut = new PlayerCharacter();//C:\Users\Me\Documents\GitHub\XUnit_Projects_All\GameEngine\GameEngine\Models\NonPlayerCharacter.cs
        }



        public void Dispose()
        {
            _output.WriteLine("Dispose called");
        }


        [Fact]
        public void BeInexperiencedWhenNew()
        {
           _output.WriteLine("IsNoob true");
          
           
            Assert.True(sut.IsNoob);
            
        }

        [Fact]
        public void CalculateFullName()
        {
            
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.Equal( "Sarah Smith", sut.FullName);
            Assert.StartsWith("Sarah", sut.FullName);
            Assert.EndsWith("Smith", sut.FullName);
            Assert.Equal("sAraH smith", sut.FullName,  ignoreCase: true);
           Assert.Contains("ah Sm", sut.FullName);

            }

        [Fact]
        public void StartWithDefaultHealth()
        {
            _output.WriteLine("lok at me");

            Assert.Equal(100, sut.Health);
        }

        [Fact] // it startes at 100
        public void IncreaseHealthAfterSleeping()
        {
           

            sut.Sleep();
            Assert.InRange<int>(sut.Health, 101, 200);
        }
        [Fact] 
        public void NotHaveNickNameByDefault()
        {
            


            Assert.Null(sut.Nickname);
        }


        [Fact]
        public void HaveALongBow()
        {
            


            Assert.Contains("Long Bow", sut.Weapons);
        }


        [Fact]
        public void DoesNotContainStaffofWonder()
        {
            PlayerCharacter sut = new PlayerCharacter();


            Assert.DoesNotContain("Staff of Wonder", sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
           


            Assert.Contains(sut.Weapons, weapon=>weapon.Contains("Sword"));
        }


        [Fact]
        public void HaveAllExpectedWeapons()
        {
           

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword",
             
            };
            Assert.Equal(expectedWeapons, sut.Weapons);
        }


        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            

           
            Assert.All(sut.Weapons,weapon=>Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }


        [Fact]
        public void RaiseSleptEvent()
        {
          

            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                // this cause the event to be raised
                () => sut.Sleep());
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
          

            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(10));
        }

        /* not need now because add theory inlineData beleow
        [Fact]
        public void TakeZeroDamage()
        {
            sut.TakeDamage(0);

            Assert.Equal(100, sut.Health);
        }

        [Fact]
        public void TakeSmallDamage()
        {
            sut.TakeDamage(1);

            Assert.Equal(99, sut.Health);
        }

        [Fact]
        public void TakeMediumDamage()
        {
            sut.TakeDamage(50);

            Assert.Equal(50, sut.Health);
        }

        [Fact]
        public void HaveMinimum1Health()
        {
            sut.TakeDamage(101);

            Assert.Equal(1, sut.Health);
        }
*/

        //[Theory]
        //[InlineData(0,100)]
        //[InlineData(1, 99)]
        //[InlineData(50, 50)]
        //[InlineData(101, 1)]


        // create a new class same as NonPlayerChar InternalHealthDamageTestData.TestData

            // need to set the TestClass1 and TestClass2 file properties to copyalways.

      //  [Theory]
      //  [MemberData(nameof(InternalHealthDamageTestData.TestData),
      //MemberType = typeof(InternalHealthDamageTestData))]

      //  public void TakeDamage(int damage, int expectedHealth)
      //  {
      //      NonPlayerCharacter sut = new NonPlayerCharacter();

      //      sut.TakeDamage(damage);

      //      Assert.Equal(expectedHealth, sut.Health);
      //  }



        [Theory]
        [MemberData(nameof(ExternalHealthDamageTestData.TestData),
         MemberType = typeof(ExternalHealthDamageTestData))]
      //  [HealthDamageData]
        public void TakeDanage(int damage, int expectedHealth)
        {
            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }




    }
}
