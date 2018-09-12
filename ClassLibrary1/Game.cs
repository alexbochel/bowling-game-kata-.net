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

				if (frameForCurrentRoll.scoreForFirstRoll == 10)
				{
					frameForCurrentRoll.totalScoreForFrame = pointsScored;
					currentFrame++;
				}
			}
			else
			{
				frameForCurrentRoll.scoreForSecondRoll = pointsScored;
				frameForCurrentRoll.totalScoreForFrame = frameForCurrentRoll.scoreForFirstRoll + frameForCurrentRoll.scoreForSecondRoll;
				currentFrame++;
			}
		}

		public int score()
		{
			for (int i = 0; i < 10; i++)
			{
				Frame currentFrame = frames[i];

				if (currentFrame.scoreForFirstRoll == 10)
				{
					currentFrame.totalScoreForFrame += frames[i + 1].totalScoreForFrame;
				}
				else if (currentFrame.scoreForFirstRoll + currentFrame.scoreForSecondRoll == 10)
				{
					currentFrame.totalScoreForFrame += frames[i + 1].scoreForFirstRoll;
				}

				_score += currentFrame.totalScoreForFrame;
			}

			return _score;
		}
	}
}
