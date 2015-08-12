using System;

namespace TabataPCL
{
	public struct TabataSettings
	{
		public int RestTime;
		public int WorkTime;
		public int NumberOfSets;
	}

	public class Tabata
	{
		public Tabata (int restTime, int workTime, int sets)
		{
			IsRunning = false;
			InWorkPhase = false;

			RestTime = restTime;
			WorkTime = workTime;
			NumberOfSets = sets;
			CurrentTimeRemaining = workTime;
		}

		public int RestTime {
			get;
			set;
		}

		public int WorkTime {
			get;
			set;
		}

		public int NumberOfSets {
			get;
			set;
		}

		public bool IsRunning {
			get;
			private set;
		}

		public bool InWorkPhase {
			get;
			private set;
		}

		public int CurrentTimeRemaining {
			get;
			private set;
		}

		public string CurrentTimeRemainingFormat {
			get {
				return CurrentTimeRemaining.ToString ();
			}		
		}

		public int CurrentSet {
			get;
			private set;
		}

		private int totalRestPeriods = 0;

		public void CalculateTabata ()
		{
			CurrentTimeRemaining -= 1;

			if (CurrentTimeRemaining == 0) {
				if (InWorkPhase) {
					totalRestPeriods += 1;
					CurrentTimeRemaining = RestTime;
					CurrentSet++;
					if (totalRestPeriods == NumberOfSets) {
						ShouldStopTabata = true;
					}
				} else {					
					CurrentTimeRemaining = WorkTime;
				}

				ShouldChangePhase = true;
				InWorkPhase = !InWorkPhase;

			} else {				
				ShouldChangePhase = false;
			}
		}

		public void ChangePhase ()
		{
			InWorkPhase = !InWorkPhase;
		}

		public bool ShouldChangePhase {
			get;
			private set;
		}

		public bool ShouldStopTabata {
			get;
			private set;
		}

		public void ResetTabata() {
			ShouldStopTabata = false;
			InWorkPhase = false;
			IsRunning = false;
			CurrentTimeRemaining = WorkTime;
			CurrentSet = 0;
			totalRestPeriods = 0;
		}
	}
}

