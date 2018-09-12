﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame
{
	public class Game
	{
		private int _score = 0;
		private List<Frame> frames = new List<Frame>();
		private int currentFrame = 0;
		private int scoreSignifyingStrike = 10;
		private int scoreSignifyingSpare = 10;
		private int firstRoll = 0;

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

			if (frameForCurrentRoll.rollNumber == firstRoll)
			{
				frameForCurrentRoll.scoreForFirstRoll = pointsScored;
				frameForCurrentRoll.rollNumber++;

				if (frameForCurrentRoll.scoreForFirstRoll == scoreSignifyingStrike)
				{
					handleRollStrike(frameForCurrentRoll, pointsScored);
				}
			}
			else
			{
				scoreSecondRollAndFinishFrame(frameForCurrentRoll, pointsScored);
			}
		}

		private void handleRollStrike(Frame frameForCurrentRoll, int pointsScored)
		{
			frameForCurrentRoll.totalScoreForFrame = pointsScored;
			currentFrame++;
		}

		private void scoreSecondRollAndFinishFrame(Frame frameForCurrentRoll, int pointsScored)
		{
			frameForCurrentRoll.scoreForSecondRoll = pointsScored;
			frameForCurrentRoll.totalScoreForFrame = frameForCurrentRoll.scoreForFirstRoll + frameForCurrentRoll.scoreForSecondRoll;
			currentFrame++;
		}

		public int score()
		{
			for (int i = 0; i < 10; i++)
			{
				Frame currentFrame = frames[i];

				if (currentFrame.scoreForFirstRoll == scoreSignifyingStrike)
				{
					currentFrame.totalScoreForFrame += frames[i + 1].totalScoreForFrame;
				}
				else if (currentFrame.scoreForFirstRoll + currentFrame.scoreForSecondRoll == scoreSignifyingSpare)
				{
					currentFrame.totalScoreForFrame += frames[i + 1].scoreForFirstRoll;
				}

				_score += currentFrame.totalScoreForFrame;
			}

			return _score;
		}
	}
}
