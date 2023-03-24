using Infrastructure.Services;

namespace Infrastructure.Tests;

public class UniqueIdProviderTests
{
    [Fact]
    public void GetUniqueString_Invoked20Times_ReturnDistinctValue()
    {
       // arrange
       var hashidsProvider = new UniqueIdProvider();
       var listHashIds = new List<string>();

       // act

       for(int i=0; i< 20; i++)
       {
           listHashIds.Add(hashidsProvider.GetUniqueString());
       }

       // assert
       Assert.True(listHashIds.Count == 20);
       Assert.True(listHashIds.Distinct().Count() == 20);

    }
}