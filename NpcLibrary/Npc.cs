﻿namespace NpcLibrary
{
    public class Npc
    {
        #region Member Variables

        /// <summary>The senses available to this thing.</summary>
        private readonly SenseManager _senseManager = new SenseManager(); 

        #endregion

        #region Properties

        public SenseManager Senses
        {
            get { return _senseManager; }
        } 

        #endregion

        #region Public Members

        /// <summary>
        /// Allows a caller to determine whether this thing can be detected by somethings senses
        /// </summary>
        /// <param name="senses">The sense manager.</param>
        /// <returns>True if detectable by sense, else false.</returns>
        public virtual bool IsDetectableBySense(SenseManager senses)
        {
            return senses.Contains(SensoryType.Sight) && senses[SensoryType.Sight].Enabled;
        } 

        #endregion
    }
}