namespace JadBenAutho.EasySocket.Tools
{
	/// <summary>
	/// <c>Priority</c> levels for <c>EasySocket</c> process.
	/// </summary>
	public enum Priority
	{
		/// <summary>
		/// The highest priority level.
		/// </summary>
		High,
		/// <summary>
		/// The nomal priority level.
		/// </summary>
		Normal,
		/// <summary>
		/// The lowest priority level.
		/// </summary>
		Low
	}

	/// <summary>
	/// This struct give set of static fuctions to deal with the
	/// <c>Priority</c> enum in the <c>JadBenAutho.EasySocket.Tools</c> namespace.
	/// </summary>
	struct PriorityTool
	{
		/// <summary>
		/// Get the corresponding float value to the <c>Priority</c> enum.
		/// </summary>
		/// <param name="P">The <c>Priority</c> to cast.</param>
		/// <returns>The corresponding float value of the <c>Priority</c> enum.</returns>
		public static float GetValue(Priority P)
		{
			switch (P) {
				case Priority.High:
					return 2;
				case Priority.Normal:
					return 1;
				case Priority.Low:
					return 0.5f;
				default: return 1;
			}
		}

		/// <summary>
		/// Get the corresponding Priority enum to the float value.
		/// </summary>
		/// <param name="num">The float value to cast</param>
		/// <returns></returns>
		public static Priority Resolve(float num)
		{
			switch ((short)num) {
				case 2:
					return Priority.High;
				case 1:
					return Priority.Normal;
				case 0:
					return Priority.Low;
				default: return Priority.Normal;
			}
		}
	}//end of struct

	//-------------------------------------------------------------------------------

}
