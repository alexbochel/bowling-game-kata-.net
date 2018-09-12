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
				scoreFirstRoll(frameForCurrentRoll, pointsScored);

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

		private void scoreFirstRoll(Frame frameForCurrentRoll, int pointsScored)
		{
			frameForCurrentRoll.scoreForFirstRoll = pointsScored;
			frameForCurrentRoll.rollNumber++;
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

				if (firstRollOnFrameIsAStrike(currentFrame))
				{
					addStrikeBonusToTotalScoreFromNextFrame(currentFrame, i);
				}
				else if (scoreOnFrameIsASpare(currentFrame))
				{
					addSpareBonusToTotalScoreFromNextFrame(currentFrame, i);
				}
				else
				{
					_score += currentFrame.totalScoreForFrame;
				}
			}
			return _score;
		}

		private void addStrikeBonusToTotalScoreFromNextFrame(Frame currentFrame, int frameThatStrikeWasRolled)
		{
			currentFrame.totalScoreForFrame += frames[frameThatStrikeWasRolled + 1].totalScoreForFrame;
			_score += currentFrame.totalScoreForFrame;
		}

		private void addSpareBonusToTotalScoreFromNextFrame(Frame currentFrame, int frameThatSpareWasRolled)
		{
			currentFrame.totalScoreForFrame += frames[frameThatSpareWasRolled + 1].scoreForFirstRoll;
			_score += currentFrame.totalScoreForFrame;
		}

		private bool firstRollOnFrameIsAStrike(Frame currentFrame)
		{
			return currentFrame.scoreForFirstRoll == scoreSignifyingStrike;
		}

		private bool scoreOnFrameIsASpare(Frame currentFrame)
		{
			return currentFrame.scoreForFirstRoll + currentFrame.scoreForSecondRoll == scoreSignifyingSpare;
		}
	}
}
