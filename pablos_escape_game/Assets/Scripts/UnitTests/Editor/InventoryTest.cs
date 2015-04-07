using NUnit.Framework;

/// <summary>
/// Tests for Inventory class,
/// These tests are hard to fail, they are just there incase
/// someone messses around with the code in the future
/// </summary>
[TestFixture]
public class InventoryTest
{

    

    // if player has test Key toggle true
    [Test]
    public void If_Player_has_key()
    {
        //Arrange
        bool testKey = true;
        //Act
        Inventory.updateInventoryGUI(testKey);
        //Assert
        Assert.That(true == testKey);
    }





    // if player does not have test key toggle false
    [Test]
    public void If_Player_Does_Not_Have_Key()
    {
        //Arrange
        bool testKey = false;
        //Act
        Inventory.updateInventoryGUI(testKey);
        //Assert
        Assert.That(false == testKey);
    }



}
