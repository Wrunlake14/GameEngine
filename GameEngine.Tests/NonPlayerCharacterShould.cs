using Xunit;

namespace GameEngine.Tests
{
    public class NonPlayerCharacterShould
    {

        //[Theory]
        //[InlineData(0, 100)]
        //[InlineData(1, 99)]
        //[InlineData(50, 50)]
        //[InlineData(101, 1)]

        // create a new class same as NonPlayerChar InternalHealthDamageTestData.TestData
        //[Theory]
        //[MemberData(nameof(InternalHealthDamageTestData.TestData),
        //   MemberType = typeof(InternalHealthDamageTestData))]

        //public void TakeDamage(int damage, int expectedHealth)
        //{
        //    NonPlayerCharacter sut = new NonPlayerCharacter();

        //    sut.TakeDamage(damage);

        //    Assert.Equal(expectedHealth, sut.Health);
        //}



        [Theory]
        [MemberData(nameof(ExternalHealthDamageTestData.TestData),
           MemberType = typeof(ExternalHealthDamageTestData))]
      //  [HealthDamageData]
        public void TakeDamage(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new NonPlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }

    }
}
