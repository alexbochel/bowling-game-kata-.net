namespace BowlingGame.Tests
{
	using System;
	using NUnit.Framework;
	using BowlingGame;

	[TestFixture]
	public class BowlingGameTest
	{
		Game game;

		[SetUp]
		public void willUpdateTestName()
		{
			game = new Game();
		}

		[Test]
		public void testGutterGame()
		{
			// Arrange
			int expectedScore = 0;

			// Act
			for (int i = 0; i < 20; i++)
			{
				game.roll(0);
			}

			// Assert
			Assert.AreEqual(game.score(), expectedScore);
		}

		[Test]
		public void testAllOnesGame()
		{
			// Arrange
			int expectedScore = 20;

			// Act
			for (int i = 0; i < 20; i++)
			{
				game.roll(1);
			}

			// Assert
			Assert.AreEqual(game.score(), expectedScore);
		}

		[Test]
		public void testOneSpare()
		{
			//Arrange
			int expectedScore = 16;

			// Act
			game.roll(5);
			game.roll(5);
			game.roll(3);
			rollMany(17, 0);

			// Assert
			Assert.AreEqual(expectedScore, game.score());
		}

		[Test]
		public void testOneStrike()
		{
			// Arrange
			int expectedScore = 24;

			// Act
			game.roll(10);
			game.roll(3);
			game.roll(4);
			rollMany(16, 0);

			// Assert
			Assert.AreEqual(expectedScore, game.score());
		}

		[Test]
		public void testPerfectGame()
		{
			// Arrange
			int expectedScore = 300;

			// Act
			rollMany(12, 10);

			// Assert
			Assert.AreEqual(expectedScore, game.score());
		}

		private void rollMany(int numberOfRolls, int pinsKnockedOver)
		{
			for (int i = 0; i < numberOfRolls; i++)
			{
				game.roll(pinsKnockedOver);
			}
		}
	}
}

