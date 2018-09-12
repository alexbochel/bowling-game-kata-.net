using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame
{
	public class Game
	{
		private int _score = 0;
		private List<Frame> frames = new List<Frame>();
		private int currentRoll = 0;

		public Game()
		{
			
		}

		public void roll(int pointsScored)
		{
			

			_score += pointsScored;
		}

		public int score()
		{
			foreach (Frame allFrames in frames)
			{
				
			}

			return -1;
		}
	}
}
