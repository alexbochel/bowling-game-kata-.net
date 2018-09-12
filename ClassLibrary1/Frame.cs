using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame
{
    public class Frame
    {
		private int _totalScoreForFrame;
		private int _scoreForFirstRoll;
		private int _scoreForSecondRoll;

		public int totalScoreForFrame
		{
			get { return _totalScoreForFrame; }
			set { _totalScoreForFrame = value; }
		}

		public int scoreForFirstRoll
		{
			get { return _scoreForFirstRoll; }
			set { _scoreForFirstRoll = value; }
		}

		public int scoreForSecondRoll
		{
			get { return _scoreForSecondRoll; }
			set { _scoreForSecondRoll = value; }
		}
	}
}
