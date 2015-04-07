using NUnit.Framework;


[TestFixture]
public class PlayerHealthTest{


	// checks to make sure if health goes above five, it is set back to 5
	[Test]
	public void Check_Health_Limiter_Is_Five() {
		//Arrange
		PlayerHealth.health = 6;
		
		//Act
		PlayerHealth.manageHealth ();
		
		//Assert
		Assert.That (5 == PlayerHealth.health);
	}



	// checks to see if true is returned when player health is 0
	[Test]
	public void Check_If_Player_Dies_Returns_True() {
		//Arrange
		PlayerHealth.health = 0;

		//Act
		bool result = PlayerHealth.IsPlayerDead();
				
		//Assert
		Assert.That (true == result);
	}

	

	// Test to see if all Hearts can be turned on
	[Test]
	public void Turns_On_All_Hearts() {
		//Arrange
		PlayerHealth.health = 5;
		
		//Act
		bool heart1 = PlayerHealth.checkHealth(1);
		bool heart2 = PlayerHealth.checkHealth(2);
		bool heart3 = PlayerHealth.checkHealth(3);
		bool heart4 = PlayerHealth.checkHealth(4);
		bool heart5 = PlayerHealth.checkHealth(5);

		//Assert
		Assert.That (true == heart1);
		Assert.That (true == heart2);
		Assert.That (true == heart3);
		Assert.That (true == heart4);
		Assert.That (true == heart5);

	}


	// checks to see if correct hearts are turned on when health is 1
	[Test]
	public void Turns_On_First_Heart() {
		//Arrange
		PlayerHealth.health = 1;
		
		//Act
		bool heart1 = PlayerHealth.checkHealth(1);
		bool heart2 = PlayerHealth.checkHealth(2);
		bool heart3 = PlayerHealth.checkHealth(3);
		bool heart4 = PlayerHealth.checkHealth(4);
		bool heart5 = PlayerHealth.checkHealth(5);

		//Assert
		Assert.That (true == heart1);
		Assert.That (false == heart2);
		Assert.That (false == heart3);
		Assert.That (false == heart4);
		Assert.That (false == heart5);
	}


	// checks to see if correct hearts are turned on when health is 2
	[Test]
	public void Turns_On_Up_To_Second_Heart() {
		//Arrange
		PlayerHealth.health = 2;
		
		//Act
		bool heart1 = PlayerHealth.checkHealth(1);
		bool heart2 = PlayerHealth.checkHealth(2);
		bool heart3 = PlayerHealth.checkHealth(3);
		bool heart4 = PlayerHealth.checkHealth(4);
		bool heart5 = PlayerHealth.checkHealth(5);
			
		//Assert
		Assert.That (true == heart1);
		Assert.That (true == heart2);
		Assert.That (false == heart3);
		Assert.That (false == heart4);
		Assert.That (false == heart5);
	}



	// checks to see if correct hearts are turned on when health is 3
	[Test]
	public void Turns_On_Up_To_Third_Heart() {
		//Arrange
		PlayerHealth.health = 3;
		
		//Act
		bool heart1 = PlayerHealth.checkHealth(1);
		bool heart2 = PlayerHealth.checkHealth(2);
		bool heart3 = PlayerHealth.checkHealth(3);
		bool heart4 = PlayerHealth.checkHealth(4);
		bool heart5 = PlayerHealth.checkHealth(5);

		//Assert
		Assert.That (true == heart1);
		Assert.That (true == heart2);
		Assert.That (true == heart3);
		Assert.That (false == heart4);
		Assert.That (false == heart5);
	}


	// checks to see if correct hearts are turned on when health is 4
	[Test]
	public void Turns_On_Up_To_Fourth_Heart() {
		//Arrange
		PlayerHealth.health = 4;
		
		//Act
		bool heart1 = PlayerHealth.checkHealth(1);
		bool heart2 = PlayerHealth.checkHealth(2);
		bool heart3 = PlayerHealth.checkHealth(3);
		bool heart4 = PlayerHealth.checkHealth(4);
		bool heart5 = PlayerHealth.checkHealth(5);

		//Assert
		Assert.That (true == heart1);
		Assert.That (true == heart2);
		Assert.That (true == heart3);
		Assert.That (true == heart4);
		Assert.That (false == heart5);
	}


	// checks to see if correct hearts are turned on when health is Negative
	[Test]
	public void No_Hearts_because_health_is_Negative() {
		//Arrange
		PlayerHealth.health = -10;
		
		//Act
		bool heart1 = PlayerHealth.checkHealth(1);
		bool heart2 = PlayerHealth.checkHealth(2);
		bool heart3 = PlayerHealth.checkHealth(3);
		bool heart4 = PlayerHealth.checkHealth(4);
		bool heart5 = PlayerHealth.checkHealth(5);

		//Assert
		Assert.That (false == heart1);
		Assert.That (false == heart2);
		Assert.That (false == heart3);
		Assert.That (false == heart4);
		Assert.That (false == heart5);
	}

}
    