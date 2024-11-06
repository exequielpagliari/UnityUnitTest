
using NUnit.Framework;

public class SimpleTester 
{
    [Test]
    public void TestOnePlusOneEqualsTwo()
    {
        int n1 = 1;
        int n2 = 1;
        int expectedResult = 2;

        int result = n1 + n2;
        
        Assert.AreEqual(expectedResult, result);

    }
}
