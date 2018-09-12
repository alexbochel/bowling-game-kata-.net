using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame
{
	public class Game
	{
		private int _score = 0;
		private List<Frame> frames = new List<Frame>();
		private int currentFrame = 0;

		public Game()
		{
			for (int i = 0; i < 10; i++)
			{
				frames.Add(new Frame());
			}
		}

		public void roll(int pointsScored)
		{
			Frame frameForCurrentRoll = frames[currentFrame];

			if (frameForCurrentRoll.rollNumber == 0)
			{
				frameForCurrentRoll.scoreForFirstRoll = pointsScored;
				frameForCurrentRoll.rollNumber++;
			}
			else
			{
				frameForCurrentRoll.scoreForSecondRoll = pointsScored;
				currentFrame++;
			}
		}

		public int score()
		{
			foreach (Frame currentFrame in frames)
			{
				_score += currentFrame.totalScoreForFrame;
			}

			return _score;
		}
	}
}
